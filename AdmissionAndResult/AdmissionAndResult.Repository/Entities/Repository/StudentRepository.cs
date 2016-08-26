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

public class StudentRepository : IStudentsRepository
{
                private SQLiteConnection conn = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
                
                
                
                upda
                public Student Find(int id)
                {            
                           conn.Open();
                           var result = this.conn.QuerySingleOrDefault<Student>("SELECT * FROM Student WHERE"+
                           "StudentId = @StudentId",new{ id });
                           conn.Close();
                           return result;
                
                }
                public List<Student> GetAll()
                {     
                       conn.Open();
                      var result = this.conn.Query<Student>("SELECT * FROM Student").AsList();
                      conn.Close();
                      return result;
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
                
                
                public void Remove(int id)
                {
                
                           
                           conn.Open();
                           this.conn.Execute("DELETE FROM Student WHERE "+
                           "StudentId = @StudentId",new{ id });
                           
                           conn.Close();
                
                }
                
                
                
                
                 public Student GetFull(int id)
                {
                
                
                        
                        
                           conn.Open();
                           var sql = "SELECT * FROM Student WHERE StudentId=@StudentId; "
                           +
                           
                           //One To many Relations
                           "SELECT * FROM Course WHERE StudentId= @StudentId; " +               
                            //One To many Relations
                           "SELECT * FROM VerifyingAgent WHERE StudentId= @StudentId; " +               
                            
                          //One to One Members
                          "SELECT * FROM Qualification WHERE      = @StudentId; "+
                                                      //One To many Relations
                           "SELECT * FROM SelectedStudent WHERE StudentId= @StudentId; "                
 ;
                          using (var multipleResults = this.conn.QueryMultiple(sql, new{ id }))
                          {
                                           
                          var student = multipleResults.ReadSingleOrDefault<Student>();
                          // Relations
                           var course = multipleResults.Read<Course>().AsList();
                           if(student != null && course != null )
                           {
                               student.Courses.AddRange(course);
                           
                           
                           }
                           var verifyingagent = multipleResults.Read<VerifyingAgent>().AsList();
                           if(student != null && verifyingagent != null )
                           {
                               student.VerifyingAgents.AddRange(verifyingagent);
                           
                           
                           }
                                    //One to One Members
                           var qualification = multipleResults.ReadSingleOrDefault<Qualification>();         
                             if(student != null && qualification != null )
                           {
                               student.Qualification = qualification;
                           
                           
                           }
                                    
                           var selectedstudent = multipleResults.Read<SelectedStudent>().AsList();
                           if(student != null && selectedstudent != null )
                           {
                               student.SelectedStudents.AddRange(selectedstudent);
                           
                           
                           }
                          
                          conn.Close();
                           return student;
                          }
                           
                          
                          
                          
        
                          
                          
                         
                           
                           

                           
                           
                           
                            
                       
                           
                           
                          
                
                }
                
                
                public void Save(Student student)
                {
                     
                     using( var txScope = new TransactionScope())
                     {
                     
                             if(student.IsNew)
                             {
                             
                                this.Insert(student);
                             } 
                             else
                             {
                                  this.Update(student);
                             
                             }
                             
                             
                             //One to Many Members
                             foreach(var addr in student.Courses.Where(a => !a.IsDeleted))
                              {
                                addr.StudentId= student.StudentId;
                                   if(addr.IsNew)
                                   {
                                   this.Insert(addr);
                                   }
                                   else
                                   {
                                   this.Update(addr);
                                   }
                          
                          }
                           foreach(var addr in student.Courses.Where(a => a.IsDeleted))
                              {
                                
                                
                                
                                
                              this.conn.Execute("DELETE FROM Course WHERE "+
                           "CourseId = @CourseId",new{ addr.CourseId });
                           
                          
                            
  
                      
                
               
                          
                          
                          }    
                          
                          
                             
                             //One to Many Members
                             foreach(var addr in student.VerifyingAgents.Where(a => !a.IsDeleted))
                              {
                                addr.StudentId= student.StudentId;
                                   if(addr.IsNew)
                                   {
                                   this.Insert(addr);
                                   }
                                   else
                                   {
                                   this.Update(addr);
                                   }
                          
                          }
                           foreach(var addr in student.VerifyingAgents.Where(a => a.IsDeleted))
                              {
                                
                                
                                
                                
                              this.conn.Execute("DELETE FROM VerifyingAgent WHERE "+
                           "VerifyingAgentId = @VerifyingAgentId",new{ addr.VerifyingAgentId });
                           
                          
                            
  
                      
                
               
                          
                          
                          }    
                          
                          
                             

                          //One to One Members
                            if(!student.Qualification.IsDeleted)
                            {
                                 student.Qualification.StudentId = student.StudentId;
                                 
                          
                          
                           }
                           if(student.Qualification.IsDeleted)
                            {
                                 student.Qualification.StudentId = student.StudentId;
                                 
                          
                          
                           }    
                          
                          
                             
                             //One to Many Members
                             foreach(var addr in student.SelectedStudents.Where(a => !a.IsDeleted))
                              {
                                addr.StudentId= student.StudentId;
                                   if(addr.IsNew)
                                   {
                                   this.Insert(addr);
                                   }
                                   else
                                   {
                                   this.Update(addr);
                                   }
                          
                          }
                           foreach(var addr in student.SelectedStudents.Where(a => a.IsDeleted))
                              {
                                
                                
                                
                                
                              this.conn.Execute("DELETE FROM SelectedStudent WHERE "+
                           "SelectedStudentId = @SelectedStudentId",new{ addr.SelectedStudentId });                           "StudentId = @StudentId",new{ addr.StudentId });
                           
                          
                            
  
                      
                
               
                          
                          
                          }    
                          
                          
                          
  
                     }
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
  
  
  
  
  
  
  
  
  
      
      
      
          public VerifyingAgent Insert(VerifyingAgent  verifyingagent)
                {
                       conn.Open();
                       var sql = " INSERT INTO VerifyingAgent VALUES("+
                       
                       "Verifying_Agent_Id = @Verifying_Agent_Id ,"+
                       
                       
                       "Verifying_Agent_Name = @Verifying_Agent_Name ,"+
                       
                       
                       "Degree_Verification = @Degree_Verification ,"+
                       
                       
                       "Admin_Id = @Admin_Id ,"+
                       
                       
                       "Send_Date = @Send_Date ,"+
                       
                       
                       "Recive_Date = @Recive_Date ,"+
                       
                       
                       "Student_Id = @Student_Id );"+
                       
                       "SELECT CAST(SCOPE_IDENTITY() as int)";
                       var id = conn.QuerySingle<int>(sql,verifyingagent);
                       conn.Close();
                       verifyingagent.VerifyingAgentId=id;
                       return verifyingagent;
                }
         
         
         
                         public VerifyingAgent  Update(VerifyingAgent  verifyingagent)
                         {
                           conn.Open();
                           var sql = "UPDATE VerifyingAgent SET "+
                           "VerifyingAgentName= @VerifyingAgentName"+
                           
                           "DegreeVerification= @DegreeVerification"+
                           
                           "AdminId= @AdminId"+
                           
                           "SendDate= @SendDate"+
                           
                           "ReciveDate= @ReciveDate"+
                           
                           "StudentId= @StudentId"+
                           
                           "WHERE"+ 
                           
                           
                           "VerifyingAgentId=@VerifyingAgentId";
                           
                                                   
                           this.conn.Execute(sql,verifyingagent);
                           conn.Close();
                           return verifyingagent;
                
                         }
  
  
  
  
  
  
  
  
  
      
      
      
          public Qualification Insert(Qualification  qualification)
                {
                       conn.Open();
                       var sql = " INSERT INTO Qualification VALUES("+
                       
                       "Qualification_Id = @Qualification_Id ,"+
                       
                       
                       "NTS_Obt_Marks = @NTS_Obt_Marks ,"+
                       
                       
                       "Inter_Obt_Marks = @Inter_Obt_Marks ,"+
                       
                       
                       "Matric_Obt_Marks = @Matric_Obt_Marks ,"+
                       
                       
                       "FSC_Year = @FSC_Year ,"+
                       
                       
                       "BS_Year = @BS_Year ,"+
                       
                       
                       "MS_Year = @MS_Year ,"+
                       
                       
                       "Matric_Year = @Matric_Year ,"+
                       
                       
                       "MS_Institute_Name = @MS_Institute_Name ,"+
                       
                       
                       "BS_Institute_Name = @BS_Institute_Name ,"+
                       
                       
                       "Inter_Institute_Name = @Inter_Institute_Name ,"+
                       
                       
                       "Matric_Institute_Name = @Matric_Institute_Name ,"+
                       
                       
                       "Inter_Roll_No = @Inter_Roll_No ,"+
                       
                       
                       "NTS_Roll_No = @NTS_Roll_No ,"+
                       
                       
                       "Matric_Roll_No = @Matric_Roll_No ,"+
                       
                       
                       "MS_Roll_No = @MS_Roll_No ,"+
                       
                       
                       "GAT_Roll_No = @GAT_Roll_No ,"+
                       
                       
                       "BS_Roll_No = @BS_Roll_No ,"+
                       
                       
                       "Board_Name = @Board_Name ,"+
                       
                       
                       "GAT_Obt_Marks = @GAT_Obt_Marks ,"+
                       
                       
                       "Batchlor_Obt_CGPA = @Batchlor_Obt_CGPA ,"+
                       
                       
                       "MSC_Obt_CGPA = @MSC_Obt_CGPA ,"+
                       
                       
                       "Verified_NTS_Marks = @Verified_NTS_Marks ,"+
                       
                       
                       "Verified_Matric_Marks = @Verified_Matric_Marks ,"+
                       
                       
                       "Verified_FSC_Marks = @Verified_FSC_Marks ,"+
                       
                       
                       "Verified_MSC_CGPA = @Verified_MSC_CGPA ,"+
                       
                       
                       "Verified_BS_CGPA = @Verified_BS_CGPA ,"+
                       
                       
                       "BS_Degree = @BS_Degree ,"+
                       
                       
                       "MS_Degree = @MS_Degree ,"+
                       
                       
                       "BS_isVerified = @BS_isVerified ,"+
                       
                       
                       "MS_isVerified = @MS_isVerified ,"+
                       
                       
                       "PHD_isVerified = @PHD_isVerified ,"+
                       
                       
                       "Matric_isVerified = @Matric_isVerified ,"+
                       
                       
                       "Inter_isVerified = @Inter_isVerified );"+
                       
                       "SELECT CAST(SCOPE_IDENTITY() as int)";
                       var id = conn.QuerySingle<int>(sql,qualification);
                       conn.Close();
                       qualification.QualificationId=id;
                       return qualification;
                }
         
         
         
                         public Qualification  Update(Qualification  qualification)
                         {
                           conn.Open();
                           var sql = "UPDATE Qualification SET "+
                           "NTSObtMarks= @NTSObtMarks"+
                           
                           "InterObtMarks= @InterObtMarks"+
                           
                           "MatricObtMarks= @MatricObtMarks"+
                           
                           "FSCYear= @FSCYear"+
                           
                           "BSYear= @BSYear"+
                           
                           "MSYear= @MSYear"+
                           
                           "MatricYear= @MatricYear"+
                           
                           "MSInstituteName= @MSInstituteName"+
                           
                           "BSInstituteName= @BSInstituteName"+
                           
                           "InterInstituteName= @InterInstituteName"+
                           
                           "MatricInstituteName= @MatricInstituteName"+
                           
                           "InterRollNo= @InterRollNo"+
                           
                           "NTSRollNo= @NTSRollNo"+
                           
                           "MatricRollNo= @MatricRollNo"+
                           
                           "MSRollNo= @MSRollNo"+
                           
                           "GATRollNo= @GATRollNo"+
                           
                           "BSRollNo= @BSRollNo"+
                           
                           "BoardName= @BoardName"+
                           
                           "GATObtMarks= @GATObtMarks"+
                           
                           "BatchlorObtCGPA= @BatchlorObtCGPA"+
                           
                           "MSCObtCGPA= @MSCObtCGPA"+
                           
                           "VerifiedNTSMarks= @VerifiedNTSMarks"+
                           
                           "VerifiedMatricMarks= @VerifiedMatricMarks"+
                           
                           "VerifiedFSCMarks= @VerifiedFSCMarks"+
                           
                           "VerifiedMSCCGPA= @VerifiedMSCCGPA"+
                           
                           "VerifiedBSCGPA= @VerifiedBSCGPA"+
                           
                           "BSDegree= @BSDegree"+
                           
                           "MSDegree= @MSDegree"+
                           
                           "BSIsVerified= @BSIsVerified"+
                           
                           "MSIsVerified= @MSIsVerified"+
                           
                           "PHDIsVerified= @PHDIsVerified"+
                           
                           "MatricIsVerified= @MatricIsVerified"+
                           
                           "InterIsVerified= @InterIsVerified"+
                           
                           "WHERE"+ 
                           
                           
                           "QualificationId=@QualificationId";
                           
                                                   
                           this.conn.Execute(sql,qualification);
                           conn.Close();
                           return qualification;
                
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
  
  
  
  
  
  
  
  
  
                
               
                      

        }
}

