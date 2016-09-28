
using System;
using System.Windows;
using ClinicalReporting.Model.Repository;
using ClinicalReporting.Services;
using ClinicalReporting.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Practices.ServiceLocation;
using ServiceStack.Data;
using ServiceStack.OrmLite;


namespace ClinicalReporting.ViewModel
{


    public static class ViewList
    {
        public static string HeaderView = "HeaderView";
        public static string SearchView = "SearchView";
        public static string PatientView = "PatientView";
    }
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //DispatcherHelper.Initialize();
            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IPatientsRepository, DesignPatientsRepository>();
                SimpleIoc.Default.Register<IDoctorsRepository, DesignDoctorsRepository>();
            }
            else
            {
                SimpleIoc.Default.Register<IDbConnectionFactory>(
               () =>
               new OrmLiteConnectionFactory(Environment.CurrentDirectory + "\\DataBase.db", SqliteDialect.Provider));
                SimpleIoc.Default.Register<IPatientsRepository, PatientRepository>();
                SimpleIoc.Default.Register<IDoctorsRepository, DoctorRepository>();
            }
           
            SimpleIoc.Default.Register<AddPatientViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
            SimpleIoc.Default.Register<MainwindowViewModel>();
            RegisterViews();
            
        }



   

        public void RegisterViews()
        {
            //var navigationService = new FrameNavigation();
            //navigationService.Configure(HeaderView, new Uri("../Views/Header/MainHeaderView.xaml", UriKind.Relative));
            //navigationService.Configure(SearchView, new Uri("../Views/SearchView.xaml", UriKind.Relative));
            //navigationService.Configure(PatientView, new Uri("../Views/AddPatientView.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<ICommonView>(() => new AddPatientView(), ViewList.PatientView);
            SimpleIoc.Default.Register<ICommonView>(() => new MainHeaderView(), ViewList.HeaderView);
            SimpleIoc.Default.Register<ICommonView>(() => new SearchView(), ViewList.SearchView);
            SimpleIoc.Default.Register<IFrameNavigation,FrameNavigation>();
        }



        public static ViewModelLocator Instance
        {
            get
            {
               
                return Application.Current.Resources["Locator"] as ViewModelLocator;
            }
        }

        public MainwindowViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainwindowViewModel>(); }
        }
    }
}