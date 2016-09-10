using System;
using System.Windows;
using ClinicalReporting.Model.Repository;
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
            SimpleIoc.Default.Register<MainHeaderViewModel>();
            SimpleIoc.Default.Register<AddPatientViewModel>();
            SimpleIoc.Default.Register<MainwindowViewModel>();
        }

        public MainwindowViewModel Mian
        {
            get { return ServiceLocator.Current.GetInstance<MainwindowViewModel>(); }
        }


        public static ViewModelLocator Instance
        {
            get { return Application.Current.Resources["Locator"] as ViewModelLocator; }
        }
    }
}