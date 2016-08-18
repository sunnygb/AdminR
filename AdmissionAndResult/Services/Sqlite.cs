using System;
using System.Data.SQLite;
namespace AdmissionAndResult.Services
{
   static class Sqlite
    {
        private static SQLiteConnection conn;
        public static SQLiteConnection GetConnection()
        {
            if (conn == null)
            {
                conn = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
            }
            return conn;
        }
        public static void Close()
        {
            conn.Close();
        }
        public static void Open()
        {
            conn.Open();
        }
    }
}
