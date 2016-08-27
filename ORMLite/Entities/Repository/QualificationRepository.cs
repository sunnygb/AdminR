﻿using ServiceStack.OrmLite;
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
    public class QualificationRepository : IQualificationsRepository 
    { 
      
      
      private IDbConnection conn = GetConnection();

      public Qualification Add(Qualification qualification)
       {
          this.conn.Insert(qualification);
          qualification.QualificationId =this.conn.LastInsertId();
          return qualification;
       
       }
       
      public List<Qualification> GetAll()
       {
         return this.conn.Select<Qualification>();
       
       }
       
      public Qualification Find(long id)
       {
         return this.conn.SingleById<Qualification>(id);
       
       }
       
      public Qualification Update(Qualification qualification)
       {
          var result=this.conn.Update<Qualification>(qualification);
          return qualification;
       
       }
       
      public void Remove(long id)
       {
          this.conn.DeleteById<Qualification>(id);
       
       }
       
      public Qualification GetAllWithChildren(long id)
       {
          throw new NotImplementedException();
       
       }
       
      public Qualification Save(Qualification qualification)
       {
          using(var txScope= new TransactionScope())
            {
                if(qualification.IsNew)
                {
                    this.Add(qualification);
                }
                else
                {
                    this.Update(qualification);
                }
                
                
                    
                    
                 // One To One 
                 var student = qualification.Student;
                 student.StudentId = qualification.QualificationId;
                 this.conn.Save(student);
                    
                   
                    txScope.Complete();
            }
            return qualification;
       
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