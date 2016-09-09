using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Data;

namespace ClinicalReporting.Services
{
    internal class ORMLiteConnection : IDbConnectionFactory
    {
        private IDbConnectionFactory DB;

        public IDbConnection CreateDbConnection()
        {
            String connectionString = Environment.CurrentDirectory + "\\DataBase.db";
            DB = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
            return DB.OpenDbConnection();
        }

        public IDbConnection OpenDbConnection()
        {
            return DB.Open();
        }
    }
}