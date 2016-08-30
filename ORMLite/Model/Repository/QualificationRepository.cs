using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using AdmissionAndResult.Data.Services;
using System.Text;
using System.Transactions;
using System.Linq;
using ServiceStack.Data;

namespace AdmissionAndResult.Data.Repository
{    
    public class QualificationRepository : IQualificationsRepository,IDisposable
    { 
      
      
       public IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection conn 
       { 
          get 
          {
            return _conn = _conn ??  DbFactory.Open();
          }
       }

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
          var qualification = this.conn.SingleById<Qualification>(id);
          
          
          
   
                 // One To One 
           var student = this.conn.Select<Student>().Where(a => a.StudentId == id).SingleOrDefault();
           if (qualification != null && student != null)
           {
             qualification.Student = student;
           }
         
  
         return qualification;
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
                 if(qualification.Student !=null)
                 {
                    var student = qualification.Student;
                    student.StudentId = qualification.QualificationId;
                    this.conn.Save(student);
                 }
                 
                   
                    txScope.Complete();
            }
            return qualification;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}