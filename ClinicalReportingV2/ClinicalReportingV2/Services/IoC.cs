using System;
using ClinicalReporting.Model.Repository;
using Microsoft.Practices.Unity;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace ClinicalReporting.Data.Services
{
    public static class ContainerHelper
    {
        private static readonly IUnityContainer _container;

        static ContainerHelper()
        {
            _container = new UnityContainer();
            String connectionString = Environment.CurrentDirectory + "\\DataBase.db";
            var db = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
            _container.RegisterInstance(typeof (IDbConnectionFactory), db);


            _container.RegisterType(typeof (IPatientsRepository), typeof (PatientRepository),
                                    new ContainerControlledLifetimeManager());
            _container.RegisterType(typeof (IDoctorsRepository), typeof (DoctorRepository),
                                    new ContainerControlledLifetimeManager());
        }

        public static IUnityContainer Container
        {
            get { return _container; }
        }
    }
}