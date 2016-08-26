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

public class AdminRepository : IAdminsRepository
{
                private SQLiteConnection conn = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
                
                
                
                upda
                public Admin Find(int id)
                {            
                           conn.Open();
                           var result = this.conn.QuerySingleOrDefault<Admin>("SELECT * FROM Admin WHERE"+
                           "AdminId = @AdminId",new{ id });
                           conn.Close();
                           return result;
                
                }
                public List<Admin> GetAll()
                {     
                       conn.Open();
                      var result = this.conn.Query<Admin>("SELECT * FROM Admin").AsList();
                      conn.Close();
                      return result;
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
                
                
                public void Remove(int id)
                {
                
                           
                           conn.Open();
                           this.conn.Execute("DELETE FROM Admin WHERE "+
                           "AdminId = @AdminId",new{ id });
                           
                           conn.Close();
                
                }
                
                
                
                
                 public Admin GetFull(int id)
                {
                
                
                        
                        
                           conn.Open();
                           var sql = "SELECT * FROM Admin WHERE AdminId=@AdminId; "
                           +
                           
                           //One To many Relations
                           "SELECT * FROM VerifyingAgent WHERE AdminId= @AdminId; "      
 ;
                          using (var multipleResults = this.conn.QueryMultiple(sql, new{ id }))
                          {
                                           
                          var admin = multipleResults.ReadSingleOrDefault<Admin>();
                          // Relations
                           var verifyingagent = multipleResults.Read<VerifyingAgent>().AsList();
                           if(admin != null && verifyingagent != null )
                           {
                               admin.VerifyingAgents.AddRange(verifyingagent);
                           
                           
                           }
                          
                          conn.Close();
                           return admin;
                          }
                           
                          
                          
                          
        
                          
                          
                         
                           
                           

                           
                           
                           
                            
                       
                           
                           
                          
                
                }
                
                
                public void Save(Admin admin)
                {
                     
                     using( var txScope = new TransactionScope())
                     {
                     
                             if(admin.IsNew)
                             {
                             
                                this.Insert(admin);
                             } 
                             else
                             {
                                  this.Update(admin);
                             
                             }
                             
                             
                             //One to Many Members
                             foreach(var addr in admin.VerifyingAgents.Where(a => !a.IsDeleted))
                              {
                                addr.AdminId= admin.AdminId;
                                   if(addr.IsNew)
                                   {
                                   this.Insert(addr);
                                   }
                                   else
                                   {
                                   this.Update(addr);
                                   }
                          
                          }
                           foreach(var addr in admin.VerifyingAgents.Where(a => a.IsDeleted))
                              {
                                
                                
                                
                                
                              this.conn.Execute("DELETE FROM VerifyingAgent WHERE "+
                           "VerifyingAgentId = @VerifyingAgentId",new{ addr.VerifyingAgentId });
                           
                          
                            
  
                      
                
               
                          
                          
                          }    
                          
                          
                          
  
                     }
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
  
  
  
  
  
  
  
  
  
                
               
                      

        }
}

