using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClinicalReporting.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;


namespace ClinicalReporting.Services
{
   public interface IFrameNavigation:INavigationService
    {
       object Parameter { get; }
       void NavigateTo(string pageKey, object parameter, string contentControll);
       void SetMainFrame(string pageKey, string contentControll);
       void SetUserFrame(string pageKey, string contentControll);
    }

    public class FrameNavigation : ObservableObject,IFrameNavigation
    {
        #region Fields
        private readonly Dictionary<string, Uri> _pagesByKey;
        private readonly List<string> _historic;
        private string _currentPageKey;
        

        #endregion
         
        #region Properties                                              
        public string CurrentPageKey
        {
            get
            {
                return _currentPageKey;
            }

            private  set { Set(() =>CurrentPageKey ,ref _currentPageKey, value); }
        }
        public object Parameter { get; private set; }
        #endregion

        #region Ctors and Methods
        public FrameNavigation()
        {
            _pagesByKey = new Dictionary<string, Uri>();
            _historic = new List<string>();
        }                
        public void GoBack()
        {
            if (_historic.Count > 1)
            {
                _historic.RemoveAt(_historic.Count - 1);
                NavigateTo(_historic.Last(), null);
            }
        }
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null,"MainFrame");
        }
        public void NavigateTo(string pageKey,string contenctControll)
        {
            NavigateTo(pageKey, null, contenctControll);
        }
        public void NavigateTo(string pageKey, object parameter)
        {
            NavigateTo(pageKey, parameter, "MainFrame");
        }
        public  virtual void SetMainFrame(string pageKey, string contentControll)
        {
                 var p = Application.Current.MainWindow;
                 var frame = p.FindName(contentControll) as Frame;

                 if (frame != null)
                 {
                     //frame.Source = _pagesByKey[pageKey];
                     //frame.Content = _userControlByKey[pageKey];
                     frame.Content = ServiceLocator.Current.GetInstance<ICommonView>(pageKey);
                     frame.NavigationService.RemoveBackEntry();
                 }
                 CurrentPageKey = pageKey;

                 //var frame = GetDescendantFromName(Application.Current.MainWindow, contentControll) as Frame;


                 //if (frame != null)
                 //{
                 //    frame.Source = _pagesByKey[pageKey];
                 //}
                 //CurrentPageKey = pageKey;
             

        }
        public void SetUserFrame( string pageKey, string contentControll)
        {
                var mainFrame =(Frame)Application.Current.MainWindow.FindName("MainFrame");
                if (mainFrame != null)
                {
                    var userControll = mainFrame.Content as UserControl;
                    if (userControll != null)
                    {
                        var frame = userControll.FindName(contentControll) as Frame;
                        if (frame != null)
                        {
                            frame.Content = ServiceLocator.Current.GetInstance<ICommonView>(pageKey);
                            frame.NavigationService.RemoveBackEntry();
                        }
                    }

                CurrentPageKey = pageKey;

                    //var frame = GetDescendantFromName(p, contentControll) as Frame;
                    //if (frame != null)
                    //{
                    //    frame.Source = _pagesByKey[pageKey];
                        
                    //}
                    //_historic.Add(pageKey);
                    //CurrentPageKey = pageKey;
                

               
            }
        }
        public virtual void NavigateTo(string pageKey, object parameter,string contentControll )
        {
            
                if (!_pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
                }

                var frame = Application.Current.MainWindow.FindName(contentControll) as Frame;
                
                if (frame != null)
                {
                    frame.Content = ServiceLocator.Current.GetInstance<ICommonView>(pageKey);
                }
                _historic.Add(pageKey);
                
                CurrentPageKey = pageKey;


                //var frame = GetDescendantFromName(Application.Current.MainWindow, contentControll) as Frame;
                //if (frame != null)
                //{
                //    frame.Source = _pagesByKey[pageKey];
                //}
                //Parameter = parameter;
                //_historic.Add(pageKey);
                //CurrentPageKey = pageKey;
            
        }
        public void Configure(string key, Uri pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(key))
                {
                    _pagesByKey[key] = pageType;
                }
                else
                {
                    _pagesByKey.Add(key, pageType);
                }
            }
        }
        public void ConfigureControl(string key, UserControl View)
        {
            lock (_userControlByKey)
            {
                if (_userControlByKey.ContainsKey(key))
                {
                    _userControlByKey[key] = View;
                }
                else
                {
                    _userControlByKey.Add(key, View);
                }
            }
        }
            
        }
        #endregion

        #region Old Methology
        //private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        //{
        //    var count = VisualTreeHelper.GetChildrenCount(parent);
            
            

        //    if (count < 1)
        //    {
        //        return null;
        //    }

        //    for (var i = 0; i < count; i++)
        //    {
        //        var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
        //        if (frameworkElement != null)
        //        {
        //            if (frameworkElement.Name == name)
        //            {
        //                return frameworkElement;
        //            }

        //            frameworkElement = GetDescendantFromName(frameworkElement, name);
        //            if (frameworkElement != null)
        //            {
        //                return frameworkElement;
        //            }
        //        }
        //    }
        //    return null;
        //}

        //public DependencyObject ConvertToDependency(string xamlFile)
        //{
            
        //    using ( var fs = new FileStream(xamlFile,FileMode.Open))
        //    {
        //        var dependencyView = (DependencyObject) XamlReader.Load(fs);
        //        return dependencyView;

        //    }
        //}
        #endregion
    }

