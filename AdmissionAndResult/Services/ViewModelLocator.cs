
using System;
using System.Windows;
using AdmissionAndResult;
using AdmissionAndResult.ViewModel;
using AdmissionAndResult.Views;
using ClinicalReporting.Model.Repository;
using AdmissionAndResult.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Practices.ServiceLocation;
using ServiceStack.Data;
using ServiceStack.OrmLite;


namespace AdmissionAndResult.Services
{


    public static class ViewList
    {
        public static string MainHeaderView = "MainHeaderView";
        public static string StudentSearchView = "StudentSearchView";
        public static string StudentAdmitView = "StudentAdmitView";
        public static string StudentverifyingReport = "StudentverifyingReport";

    }
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            //DispatcherHelper.Initialize();
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            RegisterViews();
            RegisterViewModels();
            RegisterRepository();
            
        }

        private void RegisterRepository()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IStudentsRepository, DesignStudentsRepository>();
                SimpleIoc.Default.Register<IVerifyingAgentsRepository, DesignVerifyingAgentsRepository>();
            }
            else
            {
                SimpleIoc.Default.Register<IDbConnectionFactory>(
               () =>
               new OrmLiteConnectionFactory(Environment.CurrentDirectory + "\\SystemDB.db", SqliteDialect.Provider));
                SimpleIoc.Default.Register<IStudentsRepository, StudentRepository>();
                SimpleIoc.Default.Register<IVerifyingAgentsRepository, VerifyingAgentRepository>();
            }
        }

        private void RegisterViewModels()
        {
            SimpleIoc.Default.Register<StudentAdmitViewModel>();
            SimpleIoc.Default.Register<StudentSearchViewModel>();
            SimpleIoc.Default.Register<MainwindowViewModel>();
        }


        public void RegisterViews()
        {
            //var navigationService = new FrameNavigation();
            //navigationService.Configure(MainHeaderView, new Uri("../Views/Header/MainHeaderView.xaml", UriKind.Relative));
            //navigationService.Configure(StudentSearchView, new Uri("../Views/StudentSearchView.xaml", UriKind.Relative));
            //navigationService.Configure(StudentAdmitView, new Uri("../Views/AddPatientView.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<ICommonView>(() => new StudentverifyingReport(), ViewList.StudentverifyingReport);
            SimpleIoc.Default.Register<ICommonView>(() => new MainHeaderView(), ViewList.MainHeaderView);
            SimpleIoc.Default.Register<ICommonView>(() => new StudentAdmitView(), ViewList.StudentAdmitView);
            SimpleIoc.Default.Register<ICommonView>(() => new StudentSearchView(), ViewList.StudentSearchView);
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