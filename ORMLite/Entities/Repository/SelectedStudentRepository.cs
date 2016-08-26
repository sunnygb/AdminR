using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using AdmissionAndResult.Data.Services;
using System.Text;
using System.Transactions;
using System.Linq;

namespace AdmissionAndResult.Data.Repository
{    
    public class SelectedStudentRepository : ISelectedStudentsRepository 
    { 
      
      
      private IDbConnection conn = GetConnection();

      public SelectedStudent Add(SelectedStudent selectedstudent)
       {
          this.conn.Insert(selectedstudent);
          selectedstudent.SelectedStudentId =this.conn.LastInsertId();
          return selectedstudent;
       
       }
       
      public List<SelectedStudent> GetAll()
       {
         return this.conn.Select<SelectedStudent>();
       
       }
       
      public SelectedStudent Find(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public SelectedStudent Update(SelectedStudent selectedstudent)
       {
          throw new NotImplementedException();
       
       }
       
      public void Remove(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public SelectedStudent GetAllWithChildren(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public void Save(SelectedStudent selectedstudent)
       {
          throw new NotImplementedException();
       
       }
       private static IDbConnection GetConnection()
       {
          string connectionString =Environment.CurrentDirectory + "\\SystemDB.db";
          var dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
          var db = dbFactory.OpenDbConnection();
          return db;

       
       }
   
    }
}