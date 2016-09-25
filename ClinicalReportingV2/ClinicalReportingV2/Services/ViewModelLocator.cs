﻿
using System;
using System.Windows;
using ClinicalReporting.Model.Repository;
using ClinicalReporting.Services;
using ClinicalReporting.Views;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ServiceStack.Data;
using ServiceStack.OrmLite;


namespace ClinicalReporting.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IDbConnectionFactory>(
                () =>
                new OrmLiteConnectionFactory(Environment.CurrentDirectory + "\\DataBase.db", SqliteDialect.Provider));
            SimpleIoc.Default.Register<IPatientsRepository, PatientRepository>();
            SimpleIoc.Default.Register<IDoctorsRepository, DoctorRepository>();
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
            SimpleIoc.Default.Register<ICommonView>(() => new AddPatientView(), PatientView);
            SimpleIoc.Default.Register<ICommonView>(() => new MainHeaderView(), HeaderView);
            SimpleIoc.Default.Register<ICommonView>(() => new SearchView(),     SearchView);
            SimpleIoc.Default.Register<IFrameNavigation,FrameNavigation>();
        }

        public static string HeaderView = "HeaderView";
        public static string SearchView = "SearchView";
        public static string PatientView = "AddPatientView";

        public MainwindowViewModel Mian
        {
            get
            {
                
                return ServiceLocator.Current.GetInstance<MainwindowViewModel>();
            }
        }


        public static ViewModelLocator Instance
        {
            get
            {
               
                return Application.Current.Resources["Locator"] as ViewModelLocator;
            }
        }


    }
}