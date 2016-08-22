using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SystemDB.Data.Entities.Services;
using Dapper;
using System.Text;

namespace SystemDB.Data.Entities
{

public class DepartmentRepository : IDepartmentsRepository
{
                private SQLiteConnection conn = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
                
                
                
                
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
                       
                       
                       "Student_Id = @Student_Id ,"+
                       
                       
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
                           "StudentId= @StudentId"+
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
                
                
                
                
                 public void GetFull(int id)
                {
                
                
                        
                        
                           
                           conn.Open();
                           var sql = "SELECT * FROM Department WHERE DepartmentID=@DepartmentID; "+
                           
                           "SELECT * FROM SelectedStudent WHERE DepartmentID= @DepartmentID; "+
                          //One to One Members
                          "SELECT * FROM Student WHERE      = @DepartmentID; "+
                          using (var multipleResults = this.conn.QueryMultiple(sql, new{ id }))
                          {
                                           
                          var department = multipleResults.ReadSingleOrDefault<Department>();
                          // Relations
                           var selectedstudent = multipleResults.Read<SelectedStudent>().AsList();
                           if(department != null && selectedstudent != null )
                           {
                               department.SelectedStudents.AddRange(selectedstudent);
                           
                           
                           }
                                    //One to One Members
                           var student = multipleResults.ReadSingleOrDefault<Student>();         
                             if(department != null && student != null )
                           {
                               department.Student = student;
                           
                           
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