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

    public interface IStudentsRepository
    {
       Task<Student> AddStudentAsync(Student student);
       Task<List< Student>> GetAllStudentAsync();
       Task<Student> FindStudentAsync(long id);
       Task<Student> UpdateStudentAsync(Student student);
       Task RemoveStudentAsync(long id); 
       Task<Student> GetStudentWithChildrenAsync(long id);
       Task<Student> SaveStudentAsync(Student student);
       Task<List<Student>> QueryAsync(string query);
       
       Student AddStudent(Student student);
       List< Student> GetAllStudent();
       Student FindStudent(long id);
       Student UpdateStudent(Student student);
       void RemoveStudent(long id); 
       Student GetWithChildren(long id);
       Student SaveStudent(Student student);
       List< Student> Query(string query);
       
       IDbConnection Custom { get;  }
    }

#endregion

#region Original Repository
        


                                                            

    public class StudentRepository : IStudentsRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public StudentRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       
       
       public Student AddStudent(Student student)
       {
          this.Conn.Insert(student);
          student.StudentId =this.Conn.LastInsertId();
          return student;
       
       }
       
      public List<Student> GetAllStudent()
       {
         return Conn.Select<Student>();
       
       }
       
      public Student FindStudent(long id)
       {
         return Conn.SingleById<Student>(id);
       
       }
       
      public Student UpdateStudent(Student student)
       {
          var result=Conn.Update<Student>(student);
          return student;
       
       }
       
      public void RemoveStudent(long id)
       {
          Conn.DeleteById<Student>(id);
       
       }
       
      public Student GetWithChildren(long id)
       {
          var student = Conn.SingleById<Student>(id);
          
          
          
        
                 //One To Many
           var courses = Conn.Select<Course>().Where(a => a.CourseId == id).ToList();
           if (student != null && courses != null)
           {
             student.Courses.AddRange(courses);
           }      
                  
                  
                  
        
                 //One To Many
           var verifyingagents = Conn.Select<VerifyingAgent>().Where(a => a.VerifyingAgentId == id).ToList();
           if (student != null && verifyingagents != null)
           {
             student.VerifyingAgents.AddRange(verifyingagents);
           }      
                  
                  
                  
   
                 // One To One 
           var qualification = Conn.Select<Qualification>().Where(a => a.QualificationId == id).SingleOrDefault();
           if (student != null && qualification != null)
           {
             student.Qualification = qualification;
           }
         
   
                 // One To One 
           var selectedselectedstudent = Conn.Select<SelectedStudent>().Where(a => a.SelectedStudentId == id).SingleOrDefault();
           if (student != null && selectedselectedstudent != null)
           {
             student.SelectedStudent = selectedselectedstudent;
           }
         
  
         return student;
         }
       
       
      public Student SaveStudent(Student student)
      {
          using(var txScope= new TransactionScope())
            {
                if(student.IsNew)
                {
                    this.AddStudent(student);
                }
                else
                {
                    this.UpdateStudent(student);
                }
                
                
        
                 //One To Many
                  foreach(var course in student.Courses.Where(s => !s.IsDeleted))
                  { 
                  
                    course.StudentId =student.StudentId;
                    Conn.Save(course);
                  }
                  foreach(var course in student.Courses.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<Course>(course.CourseId);
                  }
        
                 //One To Many
                  foreach(var verifyingagent in student.VerifyingAgents.Where(s => !s.IsDeleted))
                  { 
                  
                    verifyingagent.StudentId =student.StudentId;
                    Conn.Save(verifyingagent);
                  }
                  foreach(var verifyingagent in student.VerifyingAgents.Where(s => s.IsDeleted))
                  { 
                  
                    Conn.DeleteById<VerifyingAgent>(verifyingagent.VerifyingAgentId);
                  }
                    
                    
                 // One To One 
                 if(student.Qualification !=null)
                 {
                    var qualification = student.Qualification;
                    qualification.QualificationId = student.StudentId;
                    Conn.Save(qualification);
                 }
                    
                    
                 // One To One 
                 if(student.SelectedStudent !=null)
                 {
                    var selectedselectedstudent = student.SelectedStudent;
                    selectedselectedstudent.SelectedStudentId = student.StudentId;
                    Conn.Save(selectedselectedstudent);
                 }
                 
                   
                    txScope.Complete();
            }
            return student;
       
       }
       
       public List< Student> Query(string query)
       {
          return Conn.Select<Student>(query);
       }
       
 #endregion
 
 
#region Asyn Methods
                                                               
                                                               
       
       
       

      public async Task<Student> AddStudentAsync(Student student)
       {
          await Conn.InsertAsync(student);
          student.StudentId =Conn.LastInsertId();
          return student;
       
       }
       
      public async Task<List<Student>> GetAllStudentAsync()
       {
         return await Conn.SelectAsync<Student>();
       
       }
       
      public async Task<Student> FindStudentAsync(long id)
       {
         return await Conn.SingleByIdAsync<Student>(id);
       
       }
       
      public async Task<Student> UpdateStudentAsync(Student student)
       {
          await Conn.UpdateAsync<Student>(student);
          return student;
       
       }
       
      public async Task RemoveStudentAsync(long id)
       {
         await Conn.DeleteByIdAsync<Student>(id);
       
       }
       
      public async Task<Student> GetStudentWithChildrenAsync(long id)
       {
          var student = await Conn.SingleByIdAsync<Student>(id);
          
          
          
        
                 //One To Many
           var courses = await Conn.SelectAsync<Course>(e => e.CourseId == id);
           if (student != null && courses != null)
           {
             student.Courses.AddRange(courses);
           }      
                  
                  
                  
        
                 //One To Many
           var verifyingagents = await Conn.SelectAsync<VerifyingAgent>(e => e.VerifyingAgentId == id);
           if (student != null && verifyingagents != null)
           {
             student.VerifyingAgents.AddRange(verifyingagents);
           }      
                  
                  
                  
   
                 // One To One 
           var qualification = await Conn.SingleAsync<Qualification>(e => e.QualificationId == id);
           if (student != null && qualification != null)
           {
             student.Qualification = qualification;
           }
         
   
                 // One To One 
           var selectedselectedstudent = await Conn.SingleAsync<SelectedStudent>(e => e.SelectedStudentId == id);
           if (student != null && selectedselectedstudent != null)
           {
             student.SelectedStudent = selectedselectedstudent;
           }
         
  
         return student;
         }
       
       
      public async Task<Student> SaveStudentAsync(Student student)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(student.IsNew)
                {
                   await AddStudentAsync(student);
                }
                else
                {
                   await UpdateStudentAsync(student);
                }
                
                
        
                 //One To Many
                  foreach(var course in student.Courses.Where(s => !s.IsDeleted))
                  { 
                  
                    course.StudentId =student.StudentId;
                    await Conn.SaveAsync(course);
                  }
                  foreach(var course in student.Courses.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<Course>(course.CourseId);
                  }
        
                 //One To Many
                  foreach(var verifyingagent in student.VerifyingAgents.Where(s => !s.IsDeleted))
                  { 
                  
                    verifyingagent.StudentId =student.StudentId;
                    await Conn.SaveAsync(verifyingagent);
                  }
                  foreach(var verifyingagent in student.VerifyingAgents.Where(s => s.IsDeleted))
                  { 
                  
                    await Conn.DeleteByIdAsync<VerifyingAgent>(verifyingagent.VerifyingAgentId);
                  }
                    
                 // One To One 
                 if(student.Qualification!=null)
                 {
                    if(student.Qualification.IsDeleted)
                    {
                      var id = student.Qualification.QualificationId;
                      await Conn.DeleteByIdAsync<Qualification>(id);
                    }
                    else if(!student.Qualification.IsDeleted)
                    {
                      var qualification = student.Qualification;
                      qualification.QualificationId = student.StudentId;
                      await Conn.SaveAsync(qualification);
                    }
                    
                  }
                    
                 // One To One 
                 if(student.SelectedStudent!=null)
                 {
                    if(student.SelectedStudent.IsDeleted)
                    {
                      var id = student.SelectedStudent.SelectedStudentId;
                      await Conn.DeleteByIdAsync<SelectedStudent>(id);
                    }
                    else if(!student.SelectedStudent.IsDeleted)
                    {
                      var selectedselectedstudent = student.SelectedStudent;
                      selectedselectedstudent.SelectedStudentId = student.StudentId;
                      await Conn.SaveAsync(selectedselectedstudent);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return student;
       
       }
       
      public async Task<List<Student>> QueryAsync(string query)
      {
        return await Conn.SelectAsync<Student>(query);
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
    
    public class DesignStudentsRepository : IStudentsRepository
    {
    
    
       public Student AddStudent(Student student)
       {
          return null;
       }
       public List< Student> GetAllStudent()
       {
           var resultList = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Student
                {
                    
                  StudentId = i+12345, 
                  StudentName =  "StudentName"+i, 
                  StudentEmail =  "StudentEmail"+i, 
                  FatherName =  "FatherName"+i, 
                  FatherMonthlyIncome =  "FatherMonthlyIncome"+i, 
                  FatherOccupation =  "FatherOccupation"+i, 
                  PostalAddress =  "PostalAddress"+i, 
                  PermanentAddress =  "PermanentAddress"+i, 
                  DateOfBirth =  "DateOfBirth"+i, 
                  NICNo =  "NICNo"+i, 
                  BloodGroup =  "BloodGroup"+i, 
                  PhoneNumber =  "PhoneNumber"+i, 
                  ResidentalPhoneNumber =  "ResidentalPhoneNumber"+i, 
                  Date =  "Date"+i, 
                  FathersNumber =  "FathersNumber"+i, 
                });
            }
            return resultList;
         
       }
       public  Student FindStudent(long id)
       {
             return new Student
                {
                    
                    StudentId =  12345,
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
       }
       public Student UpdateStudent(Student student)
       {
         return null;
       }
       public void RemoveStudent(long id)
       {
          return;
       
       }
       public Student GetWithChildren(long id)
       {
              
        // One to Many
        var course1= new Course 
                 {
            CourseId = 12345, 
                              CourseName =  "CourseName", 
                              StudentId = 12345, 
                  };
        var course2= new Course 
                 {
            CourseId = 12345, 
                              CourseName =  "CourseName", 
                              StudentId = 12345, 
                  };         

        // One to Many
        var verifyingagent1= new VerifyingAgent 
                 {
            VerifyingAgentId = 12345, 
                              VerifyingAgentName =  "VerifyingAgentName", 
                              DegreeVerification =  "DegreeVerification", 
                              AdminId = 12345, 
                              SendDate =  "SendDate", 
                              ReciveDate =  "ReciveDate", 
                              StudentId = 12345, 
                  };
        var verifyingagent2= new VerifyingAgent 
                 {
            VerifyingAgentId = 12345, 
                              VerifyingAgentName =  "VerifyingAgentName", 
                              DegreeVerification =  "DegreeVerification", 
                              AdminId = 12345, 
                              SendDate =  "SendDate", 
                              ReciveDate =  "ReciveDate", 
                              StudentId = 12345, 
                  };         

        //One to One
        var qualification = new Qualification 
        {
        QualificationId = 12345, 
                NTSObtMarks =  "NTSObtMarks", 
                InterObtMarks =  "InterObtMarks", 
                MatricObtMarks =  "MatricObtMarks", 
                FSCYear =  "FSCYear", 
                BSYear =  "BSYear", 
                MSYear =  "MSYear", 
                MatricYear =  "MatricYear", 
                MSInstituteName =  "MSInstituteName", 
                BSInstituteName =  "BSInstituteName", 
                InterInstituteName =  "InterInstituteName", 
                MatricInstituteName =  "MatricInstituteName", 
                InterRollNo = 12345, 
                NTSRollNo = 12345, 
                MatricRollNo =  "MatricRollNo", 
                MSRollNo = 12345, 
                GATRollNo = 12345, 
                BSRollNo =  "BSRollNo", 
                BoardName =  "BoardName", 
                GATObtMarks = 12345, 
                BatchlorObtCGPA = 12345, 
                MSCObtCGPA = 12345, 
                VerifiedNTSMarks = 12345, 
                VerifiedMatricMarks = 12345, 
                VerifiedFSCMarks = 12345, 
                VerifiedMSCCGPA = 12345, 
                VerifiedBSCGPA = 12345, 
                BSDegree =  "BSDegree", 
                MSDegree =  "MSDegree", 
                BSIsVerified = 12345, 
                MSIsVerified = 12345, 
                PHDIsVerified = 12345, 
                MatricIsVerified = 12345, 
                InterIsVerified = 12345, 
        };

        //One to One
        var selectedstudent = new SelectedStudent 
        {
        SelectedStudentId = 12345, 
                StudentRegisterationNumber =  "StudentRegisterationNumber", 
                Aggregate = 12345, 
                CourseId = 12345, 
                CGPAText =  "CGPAText", 
                Sgpa =  "Sgpa", 
                DepartmentID = 12345, 
        };

         
        return new Student
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
                    
                     // One to Many
                     Courses = new List<Course>{course1,course2},
                     // One to Many
                     VerifyingAgents = new List<VerifyingAgent>{verifyingagent1,verifyingagent2},
                     //One to One
                     Qualification = qualification,
                     //One to One
                     SelectedStudent = selectedstudent,
                     
                };
         
       }
       public Student SaveStudent(Student student)
       {
         return null;
       }
       public List< Student> Query(string query)
       {
          var resultList = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Student
                {
                    
                  StudentId = i+12345, 
                  StudentName =  "StudentName"+i, 
                  StudentEmail =  "StudentEmail"+i, 
                  FatherName =  "FatherName"+i, 
                  FatherMonthlyIncome =  "FatherMonthlyIncome"+i, 
                  FatherOccupation =  "FatherOccupation"+i, 
                  PostalAddress =  "PostalAddress"+i, 
                  PermanentAddress =  "PermanentAddress"+i, 
                  DateOfBirth =  "DateOfBirth"+i, 
                  NICNo =  "NICNo"+i, 
                  BloodGroup =  "BloodGroup"+i, 
                  PhoneNumber =  "PhoneNumber"+i, 
                  ResidentalPhoneNumber =  "ResidentalPhoneNumber"+i, 
                  Date =  "Date"+i, 
                  FathersNumber =  "FathersNumber"+i, 
                });
            }
            return resultList;
       }
    
      public Task<Student> AddStudentAsync(Student student)
      {
         return null;
      }
      public async Task<List<Student>> GetAllStudentAsync()
      {
            var resultList = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Student
                {
                    
                  StudentId = i+12345, 
                  StudentName =  "StudentName"+i, 
                  StudentEmail =  "StudentEmail"+i, 
                  FatherName =  "FatherName"+i, 
                  FatherMonthlyIncome =  "FatherMonthlyIncome"+i, 
                  FatherOccupation =  "FatherOccupation"+i, 
                  PostalAddress =  "PostalAddress"+i, 
                  PermanentAddress =  "PermanentAddress"+i, 
                  DateOfBirth =  "DateOfBirth"+i, 
                  NICNo =  "NICNo"+i, 
                  BloodGroup =  "BloodGroup"+i, 
                  PhoneNumber =  "PhoneNumber"+i, 
                  ResidentalPhoneNumber =  "ResidentalPhoneNumber"+i, 
                  Date =  "Date"+i, 
                  FathersNumber =  "FathersNumber"+i, 
                });
            }
            return resultList;
      }
      public async Task<Student> FindStudentAsync(long id)
      {
         return new Student
                {
                    
                    StudentId =  12345,
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
      }
      public async Task<Student> UpdateStudentAsync(Student student)
      {
        return null;
      }
      public async Task RemoveStudentAsync(long id)
      {
        
      }
       
      public async Task<Student> GetStudentWithChildrenAsync(long id)
      {
        // One to Many
        var course1= new Course 
                 {
            CourseId = 12345, 
                              CourseName =  "CourseName", 
                              StudentId = 12345, 
                  };
        var course2= new Course 
                 {
            CourseId = 12345, 
                              CourseName =  "CourseName", 
                              StudentId = 12345, 
                  };         

        // One to Many
        var verifyingagent1= new VerifyingAgent 
                 {
            VerifyingAgentId = 12345, 
                              VerifyingAgentName =  "VerifyingAgentName", 
                              DegreeVerification =  "DegreeVerification", 
                              AdminId = 12345, 
                              SendDate =  "SendDate", 
                              ReciveDate =  "ReciveDate", 
                              StudentId = 12345, 
                  };
        var verifyingagent2= new VerifyingAgent 
                 {
            VerifyingAgentId = 12345, 
                              VerifyingAgentName =  "VerifyingAgentName", 
                              DegreeVerification =  "DegreeVerification", 
                              AdminId = 12345, 
                              SendDate =  "SendDate", 
                              ReciveDate =  "ReciveDate", 
                              StudentId = 12345, 
                  };         

        //One to One
        var qualification = new Qualification 
        {
        QualificationId = 12345, 
                NTSObtMarks =  "NTSObtMarks", 
                InterObtMarks =  "InterObtMarks", 
                MatricObtMarks =  "MatricObtMarks", 
                FSCYear =  "FSCYear", 
                BSYear =  "BSYear", 
                MSYear =  "MSYear", 
                MatricYear =  "MatricYear", 
                MSInstituteName =  "MSInstituteName", 
                BSInstituteName =  "BSInstituteName", 
                InterInstituteName =  "InterInstituteName", 
                MatricInstituteName =  "MatricInstituteName", 
                InterRollNo = 12345, 
                NTSRollNo = 12345, 
                MatricRollNo =  "MatricRollNo", 
                MSRollNo = 12345, 
                GATRollNo = 12345, 
                BSRollNo =  "BSRollNo", 
                BoardName =  "BoardName", 
                GATObtMarks = 12345, 
                BatchlorObtCGPA = 12345, 
                MSCObtCGPA = 12345, 
                VerifiedNTSMarks = 12345, 
                VerifiedMatricMarks = 12345, 
                VerifiedFSCMarks = 12345, 
                VerifiedMSCCGPA = 12345, 
                VerifiedBSCGPA = 12345, 
                BSDegree =  "BSDegree", 
                MSDegree =  "MSDegree", 
                BSIsVerified = 12345, 
                MSIsVerified = 12345, 
                PHDIsVerified = 12345, 
                MatricIsVerified = 12345, 
                InterIsVerified = 12345, 
        };

        //One to One
        var selectedstudent = new SelectedStudent 
        {
        SelectedStudentId = 12345, 
                StudentRegisterationNumber =  "StudentRegisterationNumber", 
                Aggregate = 12345, 
                CourseId = 12345, 
                CGPAText =  "CGPAText", 
                Sgpa =  "Sgpa", 
                DepartmentID = 12345, 
        };

         
        return new Student
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
                    
                     // One to Many
                     Courses = new List<Course>{course1,course2},
                     // One to Many
                     VerifyingAgents = new List<VerifyingAgent>{verifyingagent1,verifyingagent2},
                     //One to One
                     Qualification = qualification,
                     //One to One
                     SelectedStudent = selectedstudent,
                     
                };
         
      }
      public async Task<Student> SaveStudentAsync(Student student)
      {
        return null;
      }
      public async Task<List<Student>> QueryAsync(string query)
      {
         var resultList = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Student
                {
                    
                  StudentId = i+12345, 
                  StudentName =  "StudentName"+i, 
                  StudentEmail =  "StudentEmail"+i, 
                  FatherName =  "FatherName"+i, 
                  FatherMonthlyIncome =  "FatherMonthlyIncome"+i, 
                  FatherOccupation =  "FatherOccupation"+i, 
                  PostalAddress =  "PostalAddress"+i, 
                  PermanentAddress =  "PermanentAddress"+i, 
                  DateOfBirth =  "DateOfBirth"+i, 
                  NICNo =  "NICNo"+i, 
                  BloodGroup =  "BloodGroup"+i, 
                  PhoneNumber =  "PhoneNumber"+i, 
                  ResidentalPhoneNumber =  "ResidentalPhoneNumber"+i, 
                  Date =  "Date"+i, 
                  FathersNumber =  "FathersNumber"+i, 
                });
            }
            return resultList;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
#endregion    
    
    
    
    
    
    
}