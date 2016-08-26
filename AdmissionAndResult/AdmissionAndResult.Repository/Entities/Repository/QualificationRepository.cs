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

public class QualificationRepository : IQualificationsRepository
{
                private SQLiteConnection conn = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
                
                
                
                upda
                public Qualification Find(int id)
                {            
                           conn.Open();
                           var result = this.conn.QuerySingleOrDefault<Qualification>("SELECT * FROM Qualification WHERE"+
                           "QualificationId = @QualificationId",new{ id });
                           conn.Close();
                           return result;
                
                }
                public List<Qualification> GetAll()
                {     
                       conn.Open();
                      var result = this.conn.Query<Qualification>("SELECT * FROM Qualification").AsList();
                      conn.Close();
                      return result;
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
                
                
                public void Remove(int id)
                {
                
                           
                           conn.Open();
                           this.conn.Execute("DELETE FROM Qualification WHERE "+
                           "QualificationId = @QualificationId",new{ id });
                           
                           conn.Close();
                
                }
                
                
                
                
                 public Qualification GetFull(int id)
                {
                
                
                        
                        
                           conn.Open();
                           var sql = "SELECT * FROM Qualification WHERE QualificationId=@QualificationId; "
                           +
                           
                           
                          //One to One Members
                          "SELECT * FROM Student WHERE      = @QualificationId; "+
                           ;
                          using (var multipleResults = this.conn.QueryMultiple(sql, new{ id }))
                          {
                                           
                          var qualification = multipleResults.ReadSingleOrDefault<Qualification>();
                          // Relations
                                    //One to One Members
                           var student = multipleResults.ReadSingleOrDefault<Student>();         
                             if(qualification != null && student != null )
                           {
                               qualification.Student = student;
                           
                           
                           }
                                    
                          
                          conn.Close();
                           return qualification;
                          }
                           
                          
                          
                          
        
                          
                          
                         
                           
                           

                           
                           
                           
                            
                       
                           
                           
                          
                
                }
                
                
                public void Save(Qualification qualification)
                {
                     
                     using( var txScope = new TransactionScope())
                     {
                     
                             if(qualification.IsNew)
                             {
                             
                                this.Insert(qualification);
                             } 
                             else
                             {
                                  this.Update(qualification);
                             
                             }
                             
                             

                          //One to One Members
                            if(!qualification.Student.IsDeleted)
                            {
                                 qualification.Student.QualificationId = qualification.QualificationId;
                                 
                          
                          
                           }
                           if(qualification.Student.IsDeleted)
                            {
                                 qualification.Student.QualificationId = qualification.QualificationId;
                                 
                          
                          
                           }    
                          
                          
                          
  
                     }
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

