using Microsoft.Practices.Unity;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalReporting.Services
{
     class ORMLiteConnection : IDbConnectionFactory
    {

         private IDbConnectionFactory DB;
        public ORMLiteConnection()
        {
            
        }

        public System.Data.IDbConnection CreateDbConnection()
        {
            String connectionString = Environment.CurrentDirectory + "\\DataBase.db";
            DB = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
            return DB.OpenDbConnection();
            
        }

        public System.Data.IDbConnection OpenDbConnection()
        {
            return this.DB.Open();
        }
    }
}
