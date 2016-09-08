using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using ClinicalReporting.Data.Services;
using ServiceStack.OrmLite.Sqlite;
using ServiceStack.OrmLite;
using ServiceStack.Data;
using ClinicalReporting.Data.Repository;
using System.Linq;
using ServiceStack.Configuration;


namespace ClinicalReporting.Data.Services
{
    public static class ContainerHelper
    {
        private static IUnityContainer _container;
        static ContainerHelper()
        {
            _container = new UnityContainer();
            String connectionString = Environment.CurrentDirectory + "\\DataBase.db";
            var db = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
            _container.RegisterInstance(typeof(IDbConnectionFactory), db);
             
           
            _container.RegisterType(typeof(IPatientsRepository),typeof(PatientRepository),
                new ContainerControlledLifetimeManager());
            _container.RegisterType(typeof(IDoctorsRepository), typeof(DoctorRepository),
                new ContainerControlledLifetimeManager());




        }
        public static IUnityContainer Container
        {
            get { return _container; }
        }
    }

    public class UnityIocAdapter : IContainerAdapter
    {
        private readonly IUnityContainer container;

        public UnityIocAdapter(IUnityContainer container)
        {
            this.container = container;
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public T TryResolve<T>()
        {
            if (container.IsRegistered<T>())
            {
                return container.Resolve<T>();
            }

            return default(T);
        }
    }
}
