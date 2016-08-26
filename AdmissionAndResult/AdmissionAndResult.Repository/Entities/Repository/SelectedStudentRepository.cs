using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SystemDB.Data.Entities.Services;
using Dapper;
using System.Text;
using System.Transactions;
using System.Linq;

namespace SystemDB.Data.Entities




{

public class SelectedStudentRepository : ISelectedStudentsRepository
{
                private SQLiteConnection conn = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
                
                
                
                upda
                public SelectedStudent Find(int id)
                {            
                           conn.Open();
                           var result = this.conn.QuerySingleOrDefault<SelectedStudent>("SELECT * FROM SelectedStudent WHERE"+
                           "SelectedStudentId = @SelectedStudentId",                           "StudentId = @StudentId",new{ id });
                           conn.Close();
                           return result;
                
                }
                public List<SelectedStudent> GetAll()
                {     
                       conn.Open();
                      var result = this.conn.Query<SelectedStudent>("SELECT * FROM SelectedStudent").AsList();
                      conn.Close();
                      return result;
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
                       
                       
                       "Department_ID = @Department_ID ,"+
                       
                       
                       "Student_Id = @Student_Id );"+
                       
                       "SELECT CAST(SCOPE_IDENTITY() as int)";
                       var id = conn.QuerySingle<int>(sql,selectedstudent);
                       conn.Close();
                       selectedstudent.SelectedStudentId=id;
                       selectedstudent.StudentId=id;
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
                           "StudentId=@StudentId";
                           this.conn.Execute(sql,selectedstudent);
                           conn.Close();
                           return selectedstudent;
                
                }
                
                
                public void Remove(int id)
                {
                
                           
                           conn.Open();
                           this.conn.Execute("DELETE FROM SelectedStudent WHERE "+
                           "SelectedStudentId = @SelectedStudentId",                           "StudentId = @StudentId",new{ id });
                           
                           conn.Close();
                
                }
                
                
                
                
                 public SelectedStudent GetFull(int id)
                {
                
                
                        
                        
                           conn.Open();
                           var sql = "SELECT * FROM SelectedStudent WHERE SelectedStudentId=@SelectedStudentId; "
                           +StudentId=@StudentId; "
                           +
                           
                           
                          //One to One Members
                          "SELECT * FROM Department WHERE      = @SelectedStudentId; "+     = @StudentId; "+
                                                      
                          //One to One Members
                          "SELECT * FROM Course WHERE      = @SelectedStudentId; "+     = @StudentId; "+
                                                      
                          //One to One Members
                          "SELECT * FROM Student WHERE      = @SelectedStudentId; "+     = @StudentId; "+
                           ;
                          using (var multipleResults = this.conn.QueryMultiple(sql, new{ id }))
                          {
                                           
                          var selectedstudent = multipleResults.ReadSingleOrDefault<SelectedStudent>();
                          // Relations
                                    //One to One Members
                           var department = multipleResults.ReadSingleOrDefault<Department>();         
                             if(selectedstudent != null && department != null )
                           {
                               selectedstudent.Department = department;
                           
                           
                           }
                                    
                                    //One to One Members
                           var course = multipleResults.ReadSingleOrDefault<Course>();         
                             if(selectedstudent != null && course != null )
                           {
                               selectedstudent.Course = course;
                           
                           
                           }
                                    
                                    //One to One Members
                           var student = multipleResults.ReadSingleOrDefault<Student>();         
                             if(selectedstudent != null && student != null )
                           {
                               selectedstudent.Student = student;
                           
                           
                           }
                                    
                          
                          conn.Close();
                           return selectedstudent;
                          }
                           
                          
                          
                          
        
                          
                          
                         
                           
                           

                           
                           
                           
                            
                       
                           
                           
                          
                
                }
                
                
                public void Save(SelectedStudent selectedstudent)
                {
                     
                     using( var txScope = new TransactionScope())
                     {
                     
                             if(selectedstudent.IsNew)
                             {
                             
                                this.Insert(selectedstudent);
                             } 
                             else
                             {
                                  this.Update(selectedstudent);
                             
                             }
                             
                             

                          //One to One Members
                            if(!selectedstudent.Department.IsDeleted)
                            {
                                 selectedstudent.Department.SelectedStudentIdStudentId = selectedstudent.SelectedStudentIdStudentId;
                                 
                          
                          
                           }
                           if(selectedstudent.Department.IsDeleted)
                            {
                                 selectedstudent.Department.SelectedStudentIdStudentId = selectedstudent.SelectedStudentIdStudentId;
                                 
                          
                          
                           }    
                          
                          
                             

                          //One to One Members
                            if(!selectedstudent.CourceCourse.IsDeleted)
                            {
                                 selectedstudent.CourceCourse.SelectedStudentIdStudentId = selectedstudent.SelectedStudentIdStudentId;
                                 
                          
                          
                           }
                           if(selectedstudent.CourceCourse.IsDeleted)
                            {
                                 selectedstudent.CourceCourse.SelectedStudentIdStudentId = selectedstudent.SelectedStudentIdStudentId;
                                 
                          
                          
                           }    
                          
                          
                             

                          //One to One Members
                            if(!selectedstudent.Student.IsDeleted)
                            {
                                 selectedstudent.Student.SelectedStudentIdStudentId = selectedstudent.SelectedStudentIdStudentId;
                                 
                          
                          
                           }
                           if(selectedstudent.Student.IsDeleted)
                            {
                                 selectedstudent.Student.SelectedStudentIdStudentId = selectedstudent.SelectedStudentIdStudentId;
                                 
                          
                          
                           }    
                          
                          
                          
  
                     }
                   }  
                
                
                
                
                
                
                
      
      
      
          public Department Insert(Department  department)
                {
                       conn.Open();
                       var sql = " INSERT INTO Department VALUES("+
                       
                       "Department_ID = @Department_ID ,"+
                       
                       
                       "Department_Name = @Department_Name ,"+
                       
                       
                       "Student_Strength = @Student_Strength ,"+
                       
                       
                       "HOD_Name = @HOD_Name ,"+
                       
                       
                       "Location = @Location );"+
                       
                       "SELECT CAST(SCOPE_IDENTITY() as int)";
                       var id = conn.QuerySingle<int>(sql,department);
                       conn.Close();
                       department.DepartmentID=id;
                       return department;
                }
         
         
         
                         public Department  Update(Department  department)
                         {
                           conn.Open();
                           var sql = "UPDATE Department SET "+
                           "DepartmentName= @DepartmentName"+
                           
                           "StudentStrength= @StudentStrength"+
                           
                           "HODName= @HODName"+
                           
                           "Location= @Location"+
                           
                           "WHERE"+ 
                           
                           
                           "DepartmentID=@DepartmentID";
                           
                                                   
                           this.conn.Execute(sql,department);
                           conn.Close();
                           return department;
                
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

