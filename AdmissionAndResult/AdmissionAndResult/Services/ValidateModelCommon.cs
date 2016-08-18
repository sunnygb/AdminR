using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AdmissionAndResult.Services
{
    
   public  class ValidateModelCommon :ViewModelBase, INotifyDataErrorInfo
    {


        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };
       public void  ChangeNvalidate<T>(ref T member,T value, [CallerMemberName] string propertyName=null)
       {
           Set<T>(ref member, value, propertyName);
           ValidateProperty(propertyName, value);
       }

        public System.Collections.IEnumerable GetErrors(string propertyName)
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

        private void ValidateProperty<T>(string propertyName,T value)
        {
           
            var results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(this);
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



    }
}
