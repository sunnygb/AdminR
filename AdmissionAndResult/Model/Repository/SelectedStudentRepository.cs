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

    public interface ISelectedStudentsRepository
    {
       Task<SelectedStudent> AddSelectedStudentAsync(SelectedStudent selectedstudent);
       Task<List< SelectedStudent>> GetAllSelectedStudentAsync();
       Task<SelectedStudent> FindSelectedStudentAsync(long id);
       Task<SelectedStudent> UpdateSelectedStudentAsync(SelectedStudent selectedstudent);
       Task RemoveSelectedStudentAsync(long id); 
       Task<SelectedStudent> GetSelectedStudentWithChildrenAsync(long id);
       Task<SelectedStudent> SaveSelectedStudentAsync(SelectedStudent selectedstudent);
       Task<List<SelectedStudent>> QueryAsync(string query);
       
       SelectedStudent AddSelectedStudent(SelectedStudent selectedstudent);
       List< SelectedStudent> GetAllSelectedStudent();
       SelectedStudent FindSelectedStudent(long id);
       SelectedStudent UpdateSelectedStudent(SelectedStudent selectedstudent);
       void RemoveSelectedStudent(long id); 
       SelectedStudent GetWithChildren(long id);
       SelectedStudent SaveSelectedStudent(SelectedStudent selectedstudent);
       List< SelectedStudent> Query(string query);
       
       IDbConnection Custom { get;  }
    }

#endregion

#region Original Repository
        


                                                            

    public class SelectedStudentRepository : ISelectedStudentsRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public SelectedStudentRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       
       
       public SelectedStudent AddSelectedStudent(SelectedStudent selectedstudent)
       {
          this.Conn.Insert(selectedstudent);
          selectedstudent.SelectedStudentId =this.Conn.LastInsertId();
          return selectedstudent;
       
       }
       
      public List<SelectedStudent> GetAllSelectedStudent()
       {
         return Conn.Select<SelectedStudent>();
       
       }
       
      public SelectedStudent FindSelectedStudent(long id)
       {
         return Conn.SingleById<SelectedStudent>(id);
       
       }
       
      public SelectedStudent UpdateSelectedStudent(SelectedStudent selectedstudent)
       {
          var result=Conn.Update<SelectedStudent>(selectedstudent);
          return selectedstudent;
       
       }
       
      public void RemoveSelectedStudent(long id)
       {
          Conn.DeleteById<SelectedStudent>(id);
       
       }
       
      public SelectedStudent GetWithChildren(long id)
       {
          var selectedstudent = Conn.SingleById<SelectedStudent>(id);
          
          
          
   
                 // One To One 
           var selectedstudentmember = Conn.Select<SelectedStudentMember>().Where(a => a.StudentId == id).SingleOrDefault();
           if (selectedstudent != null && selectedstudentmember != null)
           {
             selectedstudent.SelectedStudentMember = selectedstudentmember;
           }
         
   
                 // One To One 
           var department = Conn.Select<Department>().Where(a => a.DepartmentID == id).SingleOrDefault();
           if (selectedstudent != null && department != null)
           {
             selectedstudent.Department = department;
           }
         
   
                 // One To One 
           var course = Conn.Select<Course>().Where(a => a.CourseId == id).SingleOrDefault();
           if (selectedstudent != null && course != null)
           {
             selectedstudent.Course = course;
           }
         
  
         return selectedstudent;
         }
       
       
      public SelectedStudent SaveSelectedStudent(SelectedStudent selectedstudent)
      {
          using(var txScope= new TransactionScope())
            {
                if(selectedstudent.IsNew)
                {
                    this.AddSelectedStudent(selectedstudent);
                }
                else
                {
                    this.UpdateSelectedStudent(selectedstudent);
                }
                
                
                    
                    
                 // One To One 
                 if(selectedstudent.SelectedStudentMember !=null)
                 {
                    var selectedstudentmember = selectedstudent.SelectedStudentMember;
                    selectedstudentmember.StudentId = selectedstudent.SelectedStudentId;
                    Conn.Save(selectedstudentmember);
                 }
                    
                    
                 // One To One 
                 if(selectedstudent.Department !=null)
                 {
                    var department = selectedstudent.Department;
                    department.DepartmentID = selectedstudent.SelectedStudentId;
                    Conn.Save(department);
                 }
                    
                    
                 // One To One 
                 if(selectedstudent.Course !=null)
                 {
                    var course = selectedstudent.Course;
                    course.CourseId = selectedstudent.SelectedStudentId;
                    Conn.Save(course);
                 }
                 
                   
                    txScope.Complete();
            }
            return selectedstudent;
       
       }
       
       public List< SelectedStudent> Query(string query)
       {
          return Conn.Select<SelectedStudent>(query);
       }
       
 #endregion
 
 
#region Asyn Methods
                                                               
                                                               
       
       
       

      public async Task<SelectedStudent> AddSelectedStudentAsync(SelectedStudent selectedstudent)
       {
          await Conn.InsertAsync(selectedstudent);
          selectedstudent.SelectedStudentId =Conn.LastInsertId();
          return selectedstudent;
       
       }
       
      public async Task<List<SelectedStudent>> GetAllSelectedStudentAsync()
       {
         return await Conn.SelectAsync<SelectedStudent>();
       
       }
       
      public async Task<SelectedStudent> FindSelectedStudentAsync(long id)
       {
         return await Conn.SingleByIdAsync<SelectedStudent>(id);
       
       }
       
      public async Task<SelectedStudent> UpdateSelectedStudentAsync(SelectedStudent selectedstudent)
       {
          await Conn.UpdateAsync<SelectedStudent>(selectedstudent);
          return selectedstudent;
       
       }
       
      public async Task RemoveSelectedStudentAsync(long id)
       {
         await Conn.DeleteByIdAsync<SelectedStudent>(id);
       
       }
       
      public async Task<SelectedStudent> GetSelectedStudentWithChildrenAsync(long id)
       {
          var selectedstudent = await Conn.SingleByIdAsync<SelectedStudent>(id);
          
          
          
   
                 // One To One 
           var selectedstudentmember = await Conn.SingleAsync<SelectedStudentMember>(e => e.StudentId == id);
           if (selectedstudent != null && selectedstudentmember != null)
           {
             selectedstudent.SelectedStudentMember = selectedstudentmember;
           }
         
   
                 // One To One 
           var department = await Conn.SingleAsync<Department>(e => e.DepartmentID == id);
           if (selectedstudent != null && department != null)
           {
             selectedstudent.Department = department;
           }
         
   
                 // One To One 
           var course = await Conn.SingleAsync<Course>(e => e.CourseId == id);
           if (selectedstudent != null && course != null)
           {
             selectedstudent.Course = course;
           }
         
  
         return selectedstudent;
         }
       
       
      public async Task<SelectedStudent> SaveSelectedStudentAsync(SelectedStudent selectedstudent)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(selectedstudent.IsNew)
                {
                   await AddSelectedStudentAsync(selectedstudent);
                }
                else
                {
                   await UpdateSelectedStudentAsync(selectedstudent);
                }
                
                
                    
                 // One To One 
                 if(selectedstudent.SelectedStudentMember!=null)
                 {
                    if(selectedstudent.SelectedStudentMember.IsDeleted)
                    {
                      var id = selectedstudent.SelectedStudentMember.StudentId;
                      await Conn.DeleteByIdAsync<Student>(id);
                    }
                    else if(!selectedstudent.SelectedStudentMember.IsDeleted)
                    {
                      var selectedstudentmember = selectedstudent.SelectedStudentMember;
                      selectedstudentmember.StudentId = selectedstudent.SelectedStudentId;
                      await Conn.SaveAsync(selectedstudentmember);
                    }
                    
                  }
                    
                 // One To One 
                 if(selectedstudent.Department!=null)
                 {
                    if(selectedstudent.Department.IsDeleted)
                    {
                      var id = selectedstudent.Department.DepartmentID;
                      await Conn.DeleteByIdAsync<Department>(id);
                    }
                    else if(!selectedstudent.Department.IsDeleted)
                    {
                      var department = selectedstudent.Department;
                      department.DepartmentID = selectedstudent.SelectedStudentId;
                      await Conn.SaveAsync(department);
                    }
                    
                  }
                    
                 // One To One 
                 if(selectedstudent.Course!=null)
                 {
                    if(selectedstudent.Course.IsDeleted)
                    {
                      var id = selectedstudent.Course.CourseId;
                      await Conn.DeleteByIdAsync<Course>(id);
                    }
                    else if(!selectedstudent.Course.IsDeleted)
                    {
                      var course = selectedstudent.Course;
                      course.CourseId = selectedstudent.SelectedStudentId;
                      await Conn.SaveAsync(course);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return selectedstudent;
       
       }
       
      public async Task<List<SelectedStudent>> QueryAsync(string query)
      {
        return await Conn.SelectAsync<SelectedStudent>(query);
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
    
    public class DesignSelectedStudentsRepository : ISelectedStudentsRepository
    {
    
    
       public SelectedStudent AddSelectedStudent(SelectedStudent selectedstudent)
       {
          return null;
       }
       public List< SelectedStudent> GetAllSelectedStudent()
       {
           var resultList = new List<SelectedStudent>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new SelectedStudent
                {
                    
                  SelectedStudentId = i+12345, 
                  StudentRegisterationNumber =  "StudentRegisterationNumber"+i, 
                  Aggregate = i+12345, 
                  CourseId = i+12345, 
                  CGPAText =  "CGPAText"+i, 
                  Sgpa =  "Sgpa"+i, 
                  DepartmentID = i+12345, 
                });
            }
            return resultList;
         
       }
       public  SelectedStudent FindSelectedStudent(long id)
       {
             return new SelectedStudent
                {
                    
                    SelectedStudentId =  12345,
                    StudentRegisterationNumber =  "StudentRegisterationNumber",
                    Aggregate =  12345,
                    CourseId =  12345,
                    CGPAText =  "CGPAText",
                    Sgpa =  "Sgpa",
                    DepartmentID =  12345,
                };
       }
       public SelectedStudent UpdateSelectedStudent(SelectedStudent selectedstudent)
       {
         return null;
       }
       public void RemoveSelectedStudent(long id)
       {
          return;
       
       }
       public SelectedStudent GetWithChildren(long id)
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

        //One to One
        var department = new Department 
        {
        DepartmentID = 12345, 
                DepartmentName =  "DepartmentName", 
                StudentStrength = 12345, 
                HODName =  "HODName", 
                Location =  "Location", 
        };

        //One to One
        var course = new Course 
        {
        CourseId = 12345, 
                CourseName =  "CourseName", 
                StudentId = 12345, 
        };

         
        return new SelectedStudent
                {
                    
                    SelectedStudentId = 12345,
                    StudentRegisterationNumber =  "StudentRegisterationNumber",
                    Aggregate = 12345,
                    CourseId = 12345,
                    CGPAText =  "CGPAText",
                    Sgpa =  "Sgpa",
                    DepartmentID = 12345,
                    
                     //One to One
                     SelectedStudentMember = student,
                     //One to One
                     Department = department,
                     //One to One
                     Course = course,
                     
                };
         
       }
       public SelectedStudent SaveSelectedStudent(SelectedStudent selectedstudent)
       {
         return null;
       }
       public List< SelectedStudent> Query(string query)
       {
          var resultList = new List<SelectedStudent>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new SelectedStudent
                {
                    
                  SelectedStudentId = i+12345, 
                  StudentRegisterationNumber =  "StudentRegisterationNumber"+i, 
                  Aggregate = i+12345, 
                  CourseId = i+12345, 
                  CGPAText =  "CGPAText"+i, 
                  Sgpa =  "Sgpa"+i, 
                  DepartmentID = i+12345, 
                });
            }
            return resultList;
       }
    
      public Task<SelectedStudent> AddSelectedStudentAsync(SelectedStudent selectedstudent)
      {
         return null;
      }
      public async Task<List<SelectedStudent>> GetAllSelectedStudentAsync()
      {
            var resultList = new List<SelectedStudent>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new SelectedStudent
                {
                    
                  SelectedStudentId = i+12345, 
                  StudentRegisterationNumber =  "StudentRegisterationNumber"+i, 
                  Aggregate = i+12345, 
                  CourseId = i+12345, 
                  CGPAText =  "CGPAText"+i, 
                  Sgpa =  "Sgpa"+i, 
                  DepartmentID = i+12345, 
                });
            }
            return resultList;
      }
      public async Task<SelectedStudent> FindSelectedStudentAsync(long id)
      {
         return new SelectedStudent
                {
                    
                    SelectedStudentId =  12345,
                    StudentRegisterationNumber =  "StudentRegisterationNumber",
                    Aggregate =  12345,
                    CourseId =  12345,
                    CGPAText =  "CGPAText",
                    Sgpa =  "Sgpa",
                    DepartmentID =  12345,
                };
      }
      public async Task<SelectedStudent> UpdateSelectedStudentAsync(SelectedStudent selectedstudent)
      {
        return null;
      }
      public async Task RemoveSelectedStudentAsync(long id)
      {
        
      }
       
      public async Task<SelectedStudent> GetSelectedStudentWithChildrenAsync(long id)
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

        //One to One
        var department = new Department 
        {
        DepartmentID = 12345, 
                DepartmentName =  "DepartmentName", 
                StudentStrength = 12345, 
                HODName =  "HODName", 
                Location =  "Location", 
        };

        //One to One
        var course = new Course 
        {
        CourseId = 12345, 
                CourseName =  "CourseName", 
                StudentId = 12345, 
        };

         
        return new SelectedStudent
                {
                    
                    SelectedStudentId = 12345,
                    StudentRegisterationNumber =  "StudentRegisterationNumber",
                    Aggregate = 12345,
                    CourseId = 12345,
                    CGPAText =  "CGPAText",
                    Sgpa =  "Sgpa",
                    DepartmentID = 12345,
                    
                     //One to One
                     SelectedStudentMember = student,
                     //One to One
                     Department = department,
                     //One to One
                     Course = course,
                     
                };
         
      }
      public async Task<SelectedStudent> SaveSelectedStudentAsync(SelectedStudent selectedstudent)
      {
        return null;
      }
      public async Task<List<SelectedStudent>> QueryAsync(string query)
      {
         var resultList = new List<SelectedStudent>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new SelectedStudent
                {
                    
                  SelectedStudentId = i+12345, 
                  StudentRegisterationNumber =  "StudentRegisterationNumber"+i, 
                  Aggregate = i+12345, 
                  CourseId = i+12345, 
                  CGPAText =  "CGPAText"+i, 
                  Sgpa =  "Sgpa"+i, 
                  DepartmentID = i+12345, 
                });
            }
            return resultList;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
#endregion    
    
    
    
    
    
    
}