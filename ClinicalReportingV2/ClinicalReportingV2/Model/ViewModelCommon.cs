using GalaSoft.MvvmLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ClinicalReporting.Data.Services
{
    public class CommonWrapper<T> : ObservableObject, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public CommonWrapper(T model)
        {
            Model = model;
        }

        public T Model { get; private set; }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            else
                return null;
        }

        public bool HasErrors
        {
            get { return _errors.Count > 0; }
        }

        private void ValidateProperty<T>(string propertyName, T value)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);
            context.MemberName = propertyName;
            Validator.TryValidateProperty(value, context, results);
            if (results.Any())
            {
                _errors[propertyName] = results.Select(c => c.ErrorMessage).ToList();
            }
            else
            {
                _errors.Remove(propertyName);
            }
            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected T GET<T>(ref T member, [CallerMemberName] string propertyName = null)
        {
            PropertyInfo propertyInfo = Model.GetType().GetProperty(propertyName);
            return member = (T) propertyInfo.GetValue(Model);
        }

        protected void SET<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            PropertyInfo propertyInfo = Model.GetType().GetProperty(propertyName);
            object currentValue = propertyInfo.GetValue(Model);
            if (!Equals(currentValue, value))
            {
                propertyInfo.SetValue(Model, value);
                Set(ref member, value, propertyName);
                ValidateProperty(propertyName, value);
            }
        }

        protected void RegisterCollection<TWrapper, TModel>(ObservableCollection<TWrapper> wrapperCollection,
                                                            List<TModel> modelCollection)
            where TWrapper : CommonWrapper<TModel>
        {
            wrapperCollection.CollectionChanged += (s, e) =>
                                                       {
                                                           if (e.OldItems != null)
                                                           {
                                                               foreach (TWrapper item in e.OldItems.Cast<TWrapper>())
                                                               {
                                                                   modelCollection.Remove(item.Model);
                                                               }
                                                           }

                                                           if (e.NewItems != null)
                                                           {
                                                               foreach (TWrapper item in e.NewItems.Cast<TWrapper>())
                                                               {
                                                                   modelCollection.Add(item.Model);
                                                               }
                                                           }
                                                       };
        }

        protected void RegisterComplex<TWrapper, TModel>(ref TWrapper wrapperComplex, TModel modelComplex)
            where TWrapper : CommonWrapper<TModel>
        {
            if (!Equals(wrapperComplex.Model, modelComplex))
            {
                modelComplex = wrapperComplex.Model;
            }
        }
    }
}