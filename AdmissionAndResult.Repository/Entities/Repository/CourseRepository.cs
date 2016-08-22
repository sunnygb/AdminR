using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SystemDB.Data.Entities.Services;
using Dapper;
using System.Text;

namespace SystemDB.Data.Entities
{

public class CourseRepository : ICoursesRepository
{
                private SQLiteConnection conn = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
                
                
                
                
                public Course Find(int id)
                {            
                           conn.Open();
                           var result = this.conn.QuerySingleOrDefault<Course>("SELECT * FROM Course WHERE"+
                           "CourseId = @CourseId",new{ id });
                           conn.Close();
                           return result;
                
                }
                public List<Course> GetAll()
                {     
                       conn.Open();
                      var result = this.conn.Query<Course>("SELECT * FROM Course").AsList();
                      conn.Close();
                      return result;
                }
                public Course Insert(Course  course)
                {
                       conn.Open();
                       var sql = " INSERT INTO Course VALUES("+
                       
                       "Course_Id = @Course_Id ,"+
                       
                       
                       "Course_Name = @Course_Name ,"+
                       
                       
                       "Student_Id = @Student_Id );"+
                       
                       "SELECT CAST(SCOPE_IDENTITY() as int)";
                       var id = conn.QuerySingle<int>(sql,course);
                       conn.Close();
                       course.CourseId=id;
                       return course;
                }
                
                 public Course  Update(Course  course)
                {
                           conn.Open();
                           var sql = "UPDATE Course SET "+
                           "CourseName= @CourseName"+
                           "StudentId= @StudentId"+
                           "WHERE"+ 
                           "CourseId=@CourseId";
                           this.conn.Execute(sql,course);
                           conn.Close();
                           return course;
                
                }
                
                
                public void Remove(int id)
                {
                
                           
                           conn.Open();
                           this.conn.Execute("DELETE FROM Course WHERE "+
                           "CourseId = @CourseId",new{ id });
                           
                           conn.Close();
                
                }
                
                
                
                
                 public void GetFull(int id)
                {
                
                
                        
                        
                           
                           conn.Open();
                           var sql = "SELECT * FROM Course WHERE CourseId=@CourseId; "+
                           
                           "SELECT * FROM SelectedStudent WHERE CourseId= @CourseId; "+
                          //One to One Members
                          "SELECT * FROM Student WHERE      = @CourseId; "+
                          using (var multipleResults = this.conn.QueryMultiple(sql, new{ id }))
                          {
                                           
                          var course = multipleResults.ReadSingleOrDefault<Course>();
                          // Relations
                           var selectedstudent = multipleResults.Read<SelectedStudent>().AsList();
                           if(course != null && selectedstudent != null )
                           {
                               course.CourceSelectedStudents.AddRange(selectedstudent);
                           
                           
                           }
                                    //One to One Members
                           var student = multipleResults.ReadSingleOrDefault<Student>();         
                             if(course != null && student != null )
                           {
                               course.Student = student;
                           
                           
                           }
                                    
                          
                          }
                          
                          
                          
                          
        
                          
                          
                         
                           
                           

                           
                           
                           
                            
                       
                           
                           
                           conn.Close();
                
                }
                
                
                
      
      
          public SelectedStudent Insert(SelectedStudent  selectedstudent)
                {
                       conn.Open();
                       var sql = " INSERT INTO SelectedStudent VALUES("+
                       
                       "Selected_Student_Id = @Selected_Student_Id ,"+
                       
                       
                       "Student_Registeration_Number = @Student_Registeration_Number ,"+
                       
                       
                       "Aggregate = @Aggregate ,"+
                       
                       
                       "Cource_Id = @Cource_Id ,"+
                       
                       
                       "CGPA Text = @CGPA Text ,"+
                       
                       
                       "SGPA = @SGPA ,"+
                       
                       
                       "Department_ID = @Department_ID );"+
                       
                       "SELECT CAST(SCOPE_IDENTITY() as int)";
                       var id = conn.QuerySingle<int>(sql,selectedstudent);
                       conn.Close();
                       selectedstudent.SelectedStudentId=id;
                       return selectedstudent;
                }
         
         
         
                         public SelectedStudent  Update(SelectedStudent  selectedstudent)
                         {
                           conn.Open();
                           var sql = "UPDATE SelectedStudent SET "+
                           "StudentRegisterationNumber= @StudentRegisterationNumber"+
                           "Aggregate= @Aggregate"+
                           "CourceId= @CourceId"+
                           "CGPAText= @CGPAText"+
                           "Sgpa= @Sgpa"+
                           "DepartmentID= @DepartmentID"+
                           "WHERE"+ 
                           "SelectedStudentId=@SelectedStudentId";
                           this.conn.Execute(sql,selectedstudent);
                           conn.Close();
                           return selectedstudent;
                
                         }
  
  
  
  
  
  
  
  
  
      
      
          public Student Insert(Student  student)
                {
                       conn.Open();
                       var sql = " INSERT INTO Student VALUES("+
                       
                       "Student_Id = @Student_Id ,"+
                       
                       
                       "Student_Name = @Student_Name ,"+
                       
                       
                       "Student_Email = @Student_Email ,"+
                       
                       
                       "Father_Name = @Father_Name ,"+
                       
                       
                       "Father_Monthly_Income = @Father_Monthly_Income ,"+
                       
                       
                       "Father_Occupation = @Father_Occupation ,"+
                       
                       
                       "Postal_Address = @Postal_Address ,"+
                       
                       
                       "Permanent_Address = @Permanent_Address ,"+
                       
                       
                       "Date_Of_Birth = @Date_Of_Birth ,"+
                       
                       
                       "NIC_No = @NIC_No ,"+
                       
                       
                       "Blood_Group = @Blood_Group ,"+
                       
                       
                       "Phone_Number = @Phone_Number ,"+
                       
                       
                       "Residental_Phone_Number = @Residental_Phone_Number ,"+
                       
                       
                       "Date = @Date ,"+
                       
                       
                       "Fathers_Number = @Fathers_Number );"+
                       
                       "SELECT CAST(SCOPE_IDENTITY() as int)";
                       var id = conn.QuerySingle<int>(sql,student);
                       conn.Close();
                       student.StudentId=id;
                       return student;
                }
         
         
         
                         public Student  Update(Student  student)
                         {
                           conn.Open();
                           var sql = "UPDATE Student SET "+
                           "StudentName= @StudentName"+
                           "StudentEmail= @StudentEmail"+
                           "FatherName= @FatherName"+
                           "FatherMonthlyIncome= @FatherMonthlyIncome"+
                           "FatherOccupation= @FatherOccupation"+
                           "PostalAddress= @PostalAddress"+
                           "PermanentAddress= @PermanentAddress"+
                           "DateOfBirth= @DateOfBirth"+
                           "NICNo= @NICNo"+
                           "BloodGroup= @BloodGroup"+
                           "PhoneNumber= @PhoneNumber"+
                           "ResidentalPhoneNumber= @ResidentalPhoneNumber"+
                           "Date= @Date"+
                           "FathersNumber= @FathersNumber"+
                           "WHERE"+ 
                           "StudentId=@StudentId";
                           this.conn.Execute(sql,student);
                           conn.Close();
                           return student;
                
                         }
  
  
  
  
  
  
  
  
  
                
               
                
                
                
                
                
                
                
                
                

        }
}