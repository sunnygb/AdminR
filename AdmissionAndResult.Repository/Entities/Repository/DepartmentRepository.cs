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

public class DepartmentRepository : IDepartmentsRepository
{
                private SQLiteConnection conn = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
                
                
                
                upda
                public Department Find(int id)
                {            
                           conn.Open();
                           var result = this.conn.QuerySingleOrDefault<Department>("SELECT * FROM Department WHERE"+
                           "DepartmentID = @DepartmentID",new{ id });
                           conn.Close();
                           return result;
                
                }
                public List<Department> GetAll()
                {     
                       conn.Open();
                      var result = this.conn.Query<Department>("SELECT * FROM Department").AsList();
                      conn.Close();
                      return result;
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
                
                
                public void Remove(int id)
                {
                
                           
                           conn.Open();
                           this.conn.Execute("DELETE FROM Department WHERE "+
                           "DepartmentID = @DepartmentID",new{ id });
                           
                           conn.Close();
                
                }
                
                
                
                
                 public Department GetFull(int id)
                {
                
                
                        
                        
                           conn.Open();
                           var sql = "SELECT * FROM Department WHERE DepartmentID=@DepartmentID; "
                           +
                           
                           //One To many Relations
                           "SELECT * FROM SelectedStudent WHERE DepartmentID= @DepartmentID; "      
 ;
                          using (var multipleResults = this.conn.QueryMultiple(sql, new{ id }))
                          {
                                           
                          var department = multipleResults.ReadSingleOrDefault<Department>();
                          // Relations
                           var selectedstudent = multipleResults.Read<SelectedStudent>().AsList();
                           if(department != null && selectedstudent != null )
                           {
                               department.SelectedStudents.AddRange(selectedstudent);
                           
                           
                           }
                          
                          conn.Close();
                           return department;
                          }
                           
                          
                          
                          
        
                          
                          
                         
                           
                           

                           
                           
                           
                            
                       
                           
                           
                          
                
                }
                
                
                public void Save(Department department)
                {
                     
                     using( var txScope = new TransactionScope())
                     {
                     
                             if(department.IsNew)
                             {
                             
                                this.Insert(department);
                             } 
                             else
                             {
                                  this.Update(department);
                             
                             }
                             
                             
                             //One to Many Members
                             foreach(var addr in department.SelectedStudents.Where(a => !a.IsDeleted))
                              {
                                addr.DepartmentID= department.DepartmentID;
                                   if(addr.IsNew)
                                   {
                                   this.Insert(addr);
                                   }
                                   else
                                   {
                                   this.Update(addr);
                                   }
                          
                          }
                           foreach(var addr in department.SelectedStudents.Where(a => a.IsDeleted))
                              {
                                
                                
                                
                                
                              this.conn.Execute("DELETE FROM SelectedStudent WHERE "+
                           "SelectedStudentId = @SelectedStudentId",new{ addr.SelectedStudentId });                           "StudentId = @StudentId",new{ addr.StudentId });
                           
                          
                            
  
                      
                
               
                          
                          
                          }    
                          
                          
                          
  
                     }
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

