using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Collections.Generic;
using System.Transactions;
using ServiceStack.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalReporting.Model.Repository
{    



#region Interface

    public interface ICoursesRepository
    {
       Task<Course> AddCourseAsync(Course course);
       Task<List< Course>> GetAllCourseAsync();
       Task<Course> FindCourseAsync(long id);
       Task<Course> UpdateCourseAsync(Course course);
       Task RemoveCourseAsync(long id); 
       Task<Course> GetCourseWithChildrenAsync(long id);
       Task<Course> SaveCourseAsync(Course course);
       Task<List<Course>> QueryAsync(string query);
       
       Course AddCourse(Course course);
       List< Course> GetAllCourse();
       Course FindCourse(long id);
       Course UpdateCourse(Course course);
       void RemoveCourse(long id); 
       Course GetWithChildren(long id);
       Course SaveCourse(Course course);
       List< Course> Query(string query);
       
       IDbConnection Custom { get;  }
    }

#endregion

#region Original Repository
        


                                                            

    public class CourseRepository : ICoursesRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public CourseRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       
       
       public Course AddCourse(Course course)
       {
          this.Conn.Insert(course);
          course.CourseId =this.Conn.LastInsertId();
          return course;
       
       }
       
      public List<Course> GetAllCourse()
       {
         return Conn.Select<Course>();
       
       }
       
      public Course FindCourse(long id)
       {
         return Conn.SingleById<Course>(id);
       
       }
       
      public Course UpdateCourse(Course course)
       {
          var result=Conn.Update<Course>(course);
          return course;
       
       }
       
      public void RemoveCourse(long id)
       {
          Conn.DeleteById<Course>(id);
       
       }
       
      public Course GetWithChildren(long id)
       {
          var course = Conn.SingleById<Course>(id);
          
          
          
   
                 // One To One 
           var student = Conn.Select<Student>().Where(a => a.StudentId == id).SingleOrDefault();
           if (course != null && student != null)
           {
             course.Student = student;
           }
         
        
                 //One To Many
           var selectedstudents = Conn.Select<SelectedStudent>().Where(a => a.SelectedStudentId == id).ToList();
           if (course != null && selectedstudents != null)
           {
             course.SelectedStudents.AddRange(selectedstudents);
           }      
                  
                  
                  
  
         return course;
         }
       
       
      public Course SaveCourse(Course course)
      {
          using(var txScope= new TransactionScope())
            {
                if(course.IsNew)
                {
                    this.AddCourse(course);
                }
                else
                {
                    this.UpdateCourse(course);
                }
                
                
                    
                    
                 // One To One 
                 if(course.Student !=null)
                 {
                    var student = course.Student;
                    student.StudentId = course.CourseId;
                    Conn.Save(student);
                 }
        
                 //One To Many
                  foreach(var selectedstudent in course.SelectedStudents.Where(s => !s.IsDeleted))
                  { 
                  
                    selectedstudent.CourseId =course.CourseId;
                    Conn.Save(selectedstudent);
                  }
                  foreach(var selectedstudent in course.SelectedStudents.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<SelectedStudent>(selectedstudent.SelectedStudentId);
                  }
                 
                   
                    txScope.Complete();
            }
            return course;
       
       }
       
       public List< Course> Query(string query)
       {
          return Conn.Select<Course>(query);
       }
       
 #endregion
 
 
#region Asyn Methods
                                                               
                                                               
       
       
       

      public async Task<Course> AddCourseAsync(Course course)
       {
          await Conn.InsertAsync(course);
          course.CourseId =Conn.LastInsertId();
          return course;
       
       }
       
      public async Task<List<Course>> GetAllCourseAsync()
       {
         return await Conn.SelectAsync<Course>();
       
       }
       
      public async Task<Course> FindCourseAsync(long id)
       {
         return await Conn.SingleByIdAsync<Course>(id);
       
       }
       
      public async Task<Course> UpdateCourseAsync(Course course)
       {
          await Conn.UpdateAsync<Course>(course);
          return course;
       
       }
       
      public async Task RemoveCourseAsync(long id)
       {
         await Conn.DeleteByIdAsync<Course>(id);
       
       }
       
      public async Task<Course> GetCourseWithChildrenAsync(long id)
       {
          var course = await Conn.SingleByIdAsync<Course>(id);
          
          
          
   
                 // One To One 
           var student = await Conn.SingleAsync<Student>(e => e.StudentId == id);
           if (course != null && student != null)
           {
             course.Student = student;
           }
         
        
                 //One To Many
           var selectedstudents = await Conn.SelectAsync<SelectedStudent>(e => e.SelectedStudentId == id);
           if (course != null && selectedstudents != null)
           {
             course.SelectedStudents.AddRange(selectedstudents);
           }      
                  
                  
                  
  
         return course;
         }
       
       
      public async Task<Course> SaveCourseAsync(Course course)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(course.IsNew)
                {
                   await AddCourseAsync(course);
                }
                else
                {
                   await UpdateCourseAsync(course);
                }
                
                
                    
                 // One To One 
                 if(course.Student!=null)
                 {
                    if(course.Student.IsDeleted)
                    {
                      var id = course.Student.StudentId;
                      await Conn.DeleteByIdAsync<Student>(id);
                    }
                    else if(!course.Student.IsDeleted)
                    {
                      var student = course.Student;
                      student.StudentId = course.CourseId;
                      await Conn.SaveAsync(student);
                    }
                    
                  }
        
                 //One To Many
                  foreach(var selectedstudent in course.SelectedStudents.Where(s => !s.IsDeleted))
                  { 
                  
                    selectedstudent.CourseId =course.CourseId;
                    await Conn.SaveAsync(selectedstudent);
                  }
                  foreach(var selectedstudent in course.SelectedStudents.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<SelectedStudent>(selectedstudent.SelectedStudentId);
                  }
                 
                   
                    txScope.Complete();
            }
            return course;
       
       }
       
      public async Task<List<Course>> QueryAsync(string query)
      {
        return await Conn.SelectAsync<Course>(query);
      }
      
      
       #endregion
       
       
       
#region Design Repository
       


      public IDbConnection Custom { get { return Conn; }  }
       
       public void Dispose()
       {
          if (Conn != null)
              Conn.Dispose();
       }
   
    }
    
    public class DesignCoursesRepository : ICoursesRepository
    {
    
    
       public Course AddCourse(Course course)
       {
          return null;
       }
       public List< Course> GetAllCourse()
       {
           var resultList = new List<Course>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Course
                {
                    
                  CourseId = i+12345, 
                  CourseName =  "CourseName"+i, 
                  StudentId = i+12345, 
                });
            }
            return resultList;
         
       }
       public  Course FindCourse(long id)
       {
             return new Course
                {
                    
                    CourseId =  12345,
                    CourseName =  "CourseName",
                    StudentId =  12345,
                };
       }
       public Course UpdateCourse(Course course)
       {
         return null;
       }
       public void RemoveCourse(long id)
       {
          return;
       
       }
       public Course GetWithChildren(long id)
       {
              
        //One to One
        var student = new Student 
        {
        StudentId = 12345, 
                StudentName =  "StudentName", 
                StudentEmail =  "StudentEmail", 
                FatherName =  "FatherName", 
                FatherMonthlyIncome =  "FatherMonthlyIncome", 
                FatherOccupation =  "FatherOccupation", 
                PostalAddress =  "PostalAddress", 
                PermanentAddress =  "PermanentAddress", 
                DateOfBirth =  "DateOfBirth", 
                NICNo =  "NICNo", 
                BloodGroup =  "BloodGroup", 
                PhoneNumber =  "PhoneNumber", 
                ResidentalPhoneNumber =  "ResidentalPhoneNumber", 
                Date =  "Date", 
                FathersNumber =  "FathersNumber", 
        };

        // One to Many
        var selectedstudent1= new SelectedStudent 
                 {
            SelectedStudentId = 12345, 
                              StudentRegisterationNumber =  "StudentRegisterationNumber", 
                              Aggregate = 12345, 
                              CourseId = 12345, 
                              CGPAText =  "CGPAText", 
                              Sgpa =  "Sgpa", 
                              DepartmentID = 12345, 
                  };
        var selectedstudent2= new SelectedStudent 
                 {
            SelectedStudentId = 12345, 
                              StudentRegisterationNumber =  "StudentRegisterationNumber", 
                              Aggregate = 12345, 
                              CourseId = 12345, 
                              CGPAText =  "CGPAText", 
                              Sgpa =  "Sgpa", 
                              DepartmentID = 12345, 
                  };         

         
        return new Course
                {
                    
                    CourseId = 12345,
                    CourseName =  "CourseName",
                    StudentId = 12345,
                    
                     //One to One
                     Student = student,
                     // One to Many
                     SelectedStudents = new List<SelectedStudent>{selectedstudent1,selectedstudent2},
                     
                };
         
       }
       public Course SaveCourse(Course course)
       {
         return null;
       }
       public List< Course> Query(string query)
       {
          var resultList = new List<Course>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Course
                {
                    
                  CourseId = i+12345, 
                  CourseName =  "CourseName"+i, 
                  StudentId = i+12345, 
                });
            }
            return resultList;
       }
    
      public Task<Course> AddCourseAsync(Course course)
      {
         return null;
      }
      public async Task<List<Course>> GetAllCourseAsync()
      {
            var resultList = new List<Course>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Course
                {
                    
                  CourseId = i+12345, 
                  CourseName =  "CourseName"+i, 
                  StudentId = i+12345, 
                });
            }
            return resultList;
      }
      public async Task<Course> FindCourseAsync(long id)
      {
         return new Course
                {
                    
                    CourseId =  12345,
                    CourseName =  "CourseName",
                    StudentId =  12345,
                };
      }
      public async Task<Course> UpdateCourseAsync(Course course)
      {
        return null;
      }
      public async Task RemoveCourseAsync(long id)
      {
        
      }
       
      public async Task<Course> GetCourseWithChildrenAsync(long id)
      {
        //One to One
        var student = new Student 
        {
        StudentId = 12345, 
                StudentName =  "StudentName", 
                StudentEmail =  "StudentEmail", 
                FatherName =  "FatherName", 
                FatherMonthlyIncome =  "FatherMonthlyIncome", 
                FatherOccupation =  "FatherOccupation", 
                PostalAddress =  "PostalAddress", 
                PermanentAddress =  "PermanentAddress", 
                DateOfBirth =  "DateOfBirth", 
                NICNo =  "NICNo", 
                BloodGroup =  "BloodGroup", 
                PhoneNumber =  "PhoneNumber", 
                ResidentalPhoneNumber =  "ResidentalPhoneNumber", 
                Date =  "Date", 
                FathersNumber =  "FathersNumber", 
        };

        // One to Many
        var selectedstudent1= new SelectedStudent 
                 {
            SelectedStudentId = 12345, 
                              StudentRegisterationNumber =  "StudentRegisterationNumber", 
                              Aggregate = 12345, 
                              CourseId = 12345, 
                              CGPAText =  "CGPAText", 
                              Sgpa =  "Sgpa", 
                              DepartmentID = 12345, 
                  };
        var selectedstudent2= new SelectedStudent 
                 {
            SelectedStudentId = 12345, 
                              StudentRegisterationNumber =  "StudentRegisterationNumber", 
                              Aggregate = 12345, 
                              CourseId = 12345, 
                              CGPAText =  "CGPAText", 
                              Sgpa =  "Sgpa", 
                              DepartmentID = 12345, 
                  };         

         
        return new Course
                {
                    
                    CourseId = 12345,
                    CourseName =  "CourseName",
                    StudentId = 12345,
                    
                     //One to One
                     Student = student,
                     // One to Many
                     SelectedStudents = new List<SelectedStudent>{selectedstudent1,selectedstudent2},
                     
                };
         
      }
      public async Task<Course> SaveCourseAsync(Course course)
      {
        return null;
      }
      public async Task<List<Course>> QueryAsync(string query)
      {
         var resultList = new List<Course>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Course
                {
                    
                  CourseId = i+12345, 
                  CourseName =  "CourseName"+i, 
                  StudentId = i+12345, 
                });
            }
            return resultList;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
#endregion    
    
    
    
    
    
    
}