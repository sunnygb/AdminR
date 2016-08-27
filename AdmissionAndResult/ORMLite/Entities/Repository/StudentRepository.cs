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
    public class StudentRepository : IStudentsRepository 
    { 
      
      
      private IDbConnection conn = GetConnection();

      public Student Add(Student student)
       {
          this.conn.Insert(student);
          student.StudentId =this.conn.LastInsertId();
          return student;
       
       }
       
      public List<Student> GetAll()
       {
         return this.conn.Select<Student>();
       
       }
       
      public Student Find(long id)
       {
           return this.conn.SingleById<Student>(id);
       
       }
       
      public Student Update(Student student)
       {
          
          var result=this.conn.Update<Student>(student);
          return student;

       
       }
       
      public void Remove(long id)
       {
           this.conn.DeleteById<Student>(id);
       
       }
       
      public Student GetAllWithChildren(long id)
       {
           //this.conn.ExecuteSql(" select * from selectedstudent where studentid=@id;", id);
           this.conn.LoadSelect<SelectedStudent>(x => x.StudentId = id);
           var student = this.conn.SingleById<Student>(id);
           var selected = this.conn.Where<SelectedStudent>(new { StudentId = id });
           if (student != null && selected != null)
           {
               student.SelectedStudents.AddRange(selected);
           }
           return student;
       }
       
      public Student Save(Student student)
       {
            using(var txScope= new TransactionScope())
            {
                if(student.IsNew)
                {
                    this.Add(student);
                }
                else
                {
                    this.Update(student);
                }
                foreach(var selected in student.SelectedStudents.Where(s => !s.IsDeleted))
                {
                    selected.StudentId= student.StudentId;
                    this.conn.Save(student);
                }
                foreach(var selected in student.SelectedStudents.Where(s => s.IsDeleted))
                {
                    this.conn.DeleteById<SelectedStudent>(selected.SelectedStudentId);

                }
                    txScope.Complete();
            }
            return student;
       
       }
       private static IDbConnection GetConnection()
       {
          string connectionString = "D:\\AdmissionAndResult\\ORMLite.Tests\\bin\\Debug\\SystemDB.db";
          var dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
          var db = dbFactory.OpenDbConnection();
          return db;

       
       }
   
    }
}