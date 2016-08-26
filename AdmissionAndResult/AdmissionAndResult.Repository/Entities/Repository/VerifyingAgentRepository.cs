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

public class VerifyingAgentRepository : IVerifyingAgentsRepository
{
                private SQLiteConnection conn = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
                
                
                
                upda
                public VerifyingAgent Find(int id)
                {            
                           conn.Open();
                           var result = this.conn.QuerySingleOrDefault<VerifyingAgent>("SELECT * FROM VerifyingAgent WHERE"+
                           "VerifyingAgentId = @VerifyingAgentId",new{ id });
                           conn.Close();
                           return result;
                
                }
                public List<VerifyingAgent> GetAll()
                {     
                       conn.Open();
                      var result = this.conn.Query<VerifyingAgent>("SELECT * FROM VerifyingAgent").AsList();
                      conn.Close();
                      return result;
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
                
                
                public void Remove(int id)
                {
                
                           
                           conn.Open();
                           this.conn.Execute("DELETE FROM VerifyingAgent WHERE "+
                           "VerifyingAgentId = @VerifyingAgentId",new{ id });
                           
                           conn.Close();
                
                }
                
                
                
                
                 public VerifyingAgent GetFull(int id)
                {
                
                
                        
                        
                           conn.Open();
                           var sql = "SELECT * FROM VerifyingAgent WHERE VerifyingAgentId=@VerifyingAgentId; "
                           +
                           
                           
                          //One to One Members
                          "SELECT * FROM Admin WHERE      = @VerifyingAgentId; "+
                                                      
                          //One to One Members
                          "SELECT * FROM Student WHERE      = @VerifyingAgentId; "+
                           ;
                          using (var multipleResults = this.conn.QueryMultiple(sql, new{ id }))
                          {
                                           
                          var verifyingagent = multipleResults.ReadSingleOrDefault<VerifyingAgent>();
                          // Relations
                                    //One to One Members
                           var admin = multipleResults.ReadSingleOrDefault<Admin>();         
                             if(verifyingagent != null && admin != null )
                           {
                               verifyingagent.Admin = admin;
                           
                           
                           }
                                    
                                    //One to One Members
                           var student = multipleResults.ReadSingleOrDefault<Student>();         
                             if(verifyingagent != null && student != null )
                           {
                               verifyingagent.Student = student;
                           
                           
                           }
                                    
                          
                          conn.Close();
                           return verifyingagent;
                          }
                           
                          
                          
                          
        
                          
                          
                         
                           
                           

                           
                           
                           
                            
                       
                           
                           
                          
                
                }
                
                
                public void Save(VerifyingAgent verifyingagent)
                {
                     
                     using( var txScope = new TransactionScope())
                     {
                     
                             if(verifyingagent.IsNew)
                             {
                             
                                this.Insert(verifyingagent);
                             } 
                             else
                             {
                                  this.Update(verifyingagent);
                             
                             }
                             
                             

                          //One to One Members
                            if(!verifyingagent.Admin.IsDeleted)
                            {
                                 verifyingagent.Admin.VerifyingAgentId = verifyingagent.VerifyingAgentId;
                                 
                          
                          
                           }
                           if(verifyingagent.Admin.IsDeleted)
                            {
                                 verifyingagent.Admin.VerifyingAgentId = verifyingagent.VerifyingAgentId;
                                 
                          
                          
                           }    
                          
                          
                             

                          //One to One Members
                            if(!verifyingagent.Student.IsDeleted)
                            {
                                 verifyingagent.Student.VerifyingAgentId = verifyingagent.VerifyingAgentId;
                                 
                          
                          
                           }
                           if(verifyingagent.Student.IsDeleted)
                            {
                                 verifyingagent.Student.VerifyingAgentId = verifyingagent.VerifyingAgentId;
                                 
                          
                          
                           }    
                          
                          
                          
  
                     }
                   }  
                
                
                
                
                
                
                
      
      
      
          public Admin Insert(Admin  admin)
                {
                       conn.Open();
                       var sql = " INSERT INTO Admin VALUES("+
                       
                       "Admin_Id = @Admin_Id ,"+
                       
                       
                       "Admin_Name = @Admin_Name ,"+
                       
                       
                       "Password = @Password ,"+
                       
                       
                       "Hire_Date = @Hire_Date ,"+
                       
                       
                       "Change_Date = @Change_Date );"+
                       
                       "SELECT CAST(SCOPE_IDENTITY() as int)";
                       var id = conn.QuerySingle<int>(sql,admin);
                       conn.Close();
                       admin.AdminId=id;
                       return admin;
                }
         
         
         
                         public Admin  Update(Admin  admin)
                         {
                           conn.Open();
                           var sql = "UPDATE Admin SET "+
                           "AdminName= @AdminName"+
                           
                           "Password= @Password"+
                           
                           "HireDate= @HireDate"+
                           
                           "ChangeDate= @ChangeDate"+
                           
                           "WHERE"+ 
                           
                           
                           "AdminId=@AdminId";
                           
                                                   
                           this.conn.Execute(sql,admin);
                           conn.Close();
                           return admin;
                
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

