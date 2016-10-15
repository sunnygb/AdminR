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

    public interface IQualificationsRepository
    {
       Task<Qualification> AddQualificationAsync(Qualification qualification);
       Task<List< Qualification>> GetAllQualificationAsync();
       Task<Qualification> FindQualificationAsync(long id);
       Task<Qualification> UpdateQualificationAsync(Qualification qualification);
       Task RemoveQualificationAsync(long id); 
       Task<Qualification> GetQualificationWithChildrenAsync(long id);
       Task<Qualification> SaveQualificationAsync(Qualification qualification);
       Task<List<Qualification>> QueryAsync(string query);
       
       Qualification AddQualification(Qualification qualification);
       List< Qualification> GetAllQualification();
       Qualification FindQualification(long id);
       Qualification UpdateQualification(Qualification qualification);
       void RemoveQualification(long id); 
       Qualification GetWithChildren(long id);
       Qualification SaveQualification(Qualification qualification);
       List< Qualification> Query(string query);
       
       IDbConnection Custom { get;  }
    }

#endregion

#region Original Repository
        


                                                            

    public class QualificationRepository : IQualificationsRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public QualificationRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       
       
       public Qualification AddQualification(Qualification qualification)
       {
          this.Conn.Insert(qualification);
          qualification.QualificationId =this.Conn.LastInsertId();
          return qualification;
       
       }
       
      public List<Qualification> GetAllQualification()
       {
         return Conn.Select<Qualification>();
       
       }
       
      public Qualification FindQualification(long id)
       {
         return Conn.SingleById<Qualification>(id);
       
       }
       
      public Qualification UpdateQualification(Qualification qualification)
       {
          var result=Conn.Update<Qualification>(qualification);
          return qualification;
       
       }
       
      public void RemoveQualification(long id)
       {
          Conn.DeleteById<Qualification>(id);
       
       }
       
      public Qualification GetWithChildren(long id)
       {
          var qualification = Conn.SingleById<Qualification>(id);
          
          
          
   
                 // One To One 
           var student = Conn.Select<Student>().Where(a => a.StudentId == id).SingleOrDefault();
           if (qualification != null && student != null)
           {
             qualification.Student = student;
           }
         
  
         return qualification;
         }
       
       
      public Qualification SaveQualification(Qualification qualification)
      {
          using(var txScope= new TransactionScope())
            {
                if(qualification.IsNew)
                {
                    this.AddQualification(qualification);
                }
                else
                {
                    this.UpdateQualification(qualification);
                }
                
                
                    
                    
                 // One To One 
                 if(qualification.Student !=null)
                 {
                    var student = qualification.Student;
                    student.StudentId = qualification.QualificationId;
                    Conn.Save(student);
                 }
                 
                   
                    txScope.Complete();
            }
            return qualification;
       
       }
       
       public List< Qualification> Query(string query)
       {
          return Conn.Select<Qualification>(query);
       }
       
 #endregion
 
 
#region Asyn Methods
                                                               
                                                               
       
       
       

      public async Task<Qualification> AddQualificationAsync(Qualification qualification)
       {
          await Conn.InsertAsync(qualification);
          qualification.QualificationId =Conn.LastInsertId();
          return qualification;
       
       }
       
      public async Task<List<Qualification>> GetAllQualificationAsync()
       {
         return await Conn.SelectAsync<Qualification>();
       
       }
       
      public async Task<Qualification> FindQualificationAsync(long id)
       {
         return await Conn.SingleByIdAsync<Qualification>(id);
       
       }
       
      public async Task<Qualification> UpdateQualificationAsync(Qualification qualification)
       {
          await Conn.UpdateAsync<Qualification>(qualification);
          return qualification;
       
       }
       
      public async Task RemoveQualificationAsync(long id)
       {
         await Conn.DeleteByIdAsync<Qualification>(id);
       
       }
       
      public async Task<Qualification> GetQualificationWithChildrenAsync(long id)
       {
          var qualification = await Conn.SingleByIdAsync<Qualification>(id);
          
          
          
   
                 // One To One 
           var student = await Conn.SingleAsync<Student>(e => e.StudentId == id);
           if (qualification != null && student != null)
           {
             qualification.Student = student;
           }
         
  
         return qualification;
         }
       
       
      public async Task<Qualification> SaveQualificationAsync(Qualification qualification)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(qualification.IsNew)
                {
                   await AddQualificationAsync(qualification);
                }
                else
                {
                   await UpdateQualificationAsync(qualification);
                }
                
                
                    
                 // One To One 
                 if(qualification.Student!=null)
                 {
                    if(qualification.Student.IsDeleted)
                    {
                      var id = qualification.Student.StudentId;
                      await Conn.DeleteByIdAsync<Student>(id);
                    }
                    else if(!qualification.Student.IsDeleted)
                    {
                      var student = qualification.Student;
                      student.StudentId = qualification.QualificationId;
                      await Conn.SaveAsync(student);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return qualification;
       
       }
       
      public async Task<List<Qualification>> QueryAsync(string query)
      {
        return await Conn.SelectAsync<Qualification>(query);
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
    
    public class DesignQualificationsRepository : IQualificationsRepository
    {
    
    
       public Qualification AddQualification(Qualification qualification)
       {
          return null;
       }
       public List< Qualification> GetAllQualification()
       {
           var resultList = new List<Qualification>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Qualification
                {
                    
                  QualificationId = i+12345, 
                  NTSObtMarks =  "NTSObtMarks"+i, 
                  InterObtMarks =  "InterObtMarks"+i, 
                  MatricObtMarks =  "MatricObtMarks"+i, 
                  FSCYear =  "FSCYear"+i, 
                  BSYear =  "BSYear"+i, 
                  MSYear =  "MSYear"+i, 
                  MatricYear =  "MatricYear"+i, 
                  MSInstituteName =  "MSInstituteName"+i, 
                  BSInstituteName =  "BSInstituteName"+i, 
                  InterInstituteName =  "InterInstituteName"+i, 
                  MatricInstituteName =  "MatricInstituteName"+i, 
                  InterRollNo = i+12345, 
                  NTSRollNo = i+12345, 
                  MatricRollNo =  "MatricRollNo"+i, 
                  MSRollNo = i+12345, 
                  GATRollNo = i+12345, 
                  BSRollNo =  "BSRollNo"+i, 
                  BoardName =  "BoardName"+i, 
                  GATObtMarks = i+12345, 
                  BatchlorObtCGPA = i+12345, 
                  MSCObtCGPA = i+12345, 
                  VerifiedNTSMarks = i+12345, 
                  VerifiedMatricMarks = i+12345, 
                  VerifiedFSCMarks = i+12345, 
                  VerifiedMSCCGPA = i+12345, 
                  VerifiedBSCGPA = i+12345, 
                  BSDegree =  "BSDegree"+i, 
                  MSDegree =  "MSDegree"+i, 
                  BSIsVerified = i+12345, 
                  MSIsVerified = i+12345, 
                  PHDIsVerified = i+12345, 
                  MatricIsVerified = i+12345, 
                  InterIsVerified = i+12345, 
                });
            }
            return resultList;
         
       }
       public  Qualification FindQualification(long id)
       {
             return new Qualification
                {
                    
                    QualificationId =  12345,
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
                    InterRollNo =  12345,
                    NTSRollNo =  12345,
                    MatricRollNo =  "MatricRollNo",
                    MSRollNo =  12345,
                    GATRollNo =  12345,
                    BSRollNo =  "BSRollNo",
                    BoardName =  "BoardName",
                    GATObtMarks =  12345,
                    BatchlorObtCGPA =  12345,
                    MSCObtCGPA =  12345,
                    VerifiedNTSMarks =  12345,
                    VerifiedMatricMarks =  12345,
                    VerifiedFSCMarks =  12345,
                    VerifiedMSCCGPA =  12345,
                    VerifiedBSCGPA =  12345,
                    BSDegree =  "BSDegree",
                    MSDegree =  "MSDegree",
                    BSIsVerified =  12345,
                    MSIsVerified =  12345,
                    PHDIsVerified =  12345,
                    MatricIsVerified =  12345,
                    InterIsVerified =  12345,
                };
       }
       public Qualification UpdateQualification(Qualification qualification)
       {
         return null;
       }
       public void RemoveQualification(long id)
       {
          return;
       
       }
       public Qualification GetWithChildren(long id)
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

         
        return new Qualification
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
                    
                     //One to One
                     Student = student,
                     
                };
         
       }
       public Qualification SaveQualification(Qualification qualification)
       {
         return null;
       }
       public List< Qualification> Query(string query)
       {
          var resultList = new List<Qualification>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Qualification
                {
                    
                  QualificationId = i+12345, 
                  NTSObtMarks =  "NTSObtMarks"+i, 
                  InterObtMarks =  "InterObtMarks"+i, 
                  MatricObtMarks =  "MatricObtMarks"+i, 
                  FSCYear =  "FSCYear"+i, 
                  BSYear =  "BSYear"+i, 
                  MSYear =  "MSYear"+i, 
                  MatricYear =  "MatricYear"+i, 
                  MSInstituteName =  "MSInstituteName"+i, 
                  BSInstituteName =  "BSInstituteName"+i, 
                  InterInstituteName =  "InterInstituteName"+i, 
                  MatricInstituteName =  "MatricInstituteName"+i, 
                  InterRollNo = i+12345, 
                  NTSRollNo = i+12345, 
                  MatricRollNo =  "MatricRollNo"+i, 
                  MSRollNo = i+12345, 
                  GATRollNo = i+12345, 
                  BSRollNo =  "BSRollNo"+i, 
                  BoardName =  "BoardName"+i, 
                  GATObtMarks = i+12345, 
                  BatchlorObtCGPA = i+12345, 
                  MSCObtCGPA = i+12345, 
                  VerifiedNTSMarks = i+12345, 
                  VerifiedMatricMarks = i+12345, 
                  VerifiedFSCMarks = i+12345, 
                  VerifiedMSCCGPA = i+12345, 
                  VerifiedBSCGPA = i+12345, 
                  BSDegree =  "BSDegree"+i, 
                  MSDegree =  "MSDegree"+i, 
                  BSIsVerified = i+12345, 
                  MSIsVerified = i+12345, 
                  PHDIsVerified = i+12345, 
                  MatricIsVerified = i+12345, 
                  InterIsVerified = i+12345, 
                });
            }
            return resultList;
       }
    
      public Task<Qualification> AddQualificationAsync(Qualification qualification)
      {
         return null;
      }
      public async Task<List<Qualification>> GetAllQualificationAsync()
      {
            var resultList = new List<Qualification>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Qualification
                {
                    
                  QualificationId = i+12345, 
                  NTSObtMarks =  "NTSObtMarks"+i, 
                  InterObtMarks =  "InterObtMarks"+i, 
                  MatricObtMarks =  "MatricObtMarks"+i, 
                  FSCYear =  "FSCYear"+i, 
                  BSYear =  "BSYear"+i, 
                  MSYear =  "MSYear"+i, 
                  MatricYear =  "MatricYear"+i, 
                  MSInstituteName =  "MSInstituteName"+i, 
                  BSInstituteName =  "BSInstituteName"+i, 
                  InterInstituteName =  "InterInstituteName"+i, 
                  MatricInstituteName =  "MatricInstituteName"+i, 
                  InterRollNo = i+12345, 
                  NTSRollNo = i+12345, 
                  MatricRollNo =  "MatricRollNo"+i, 
                  MSRollNo = i+12345, 
                  GATRollNo = i+12345, 
                  BSRollNo =  "BSRollNo"+i, 
                  BoardName =  "BoardName"+i, 
                  GATObtMarks = i+12345, 
                  BatchlorObtCGPA = i+12345, 
                  MSCObtCGPA = i+12345, 
                  VerifiedNTSMarks = i+12345, 
                  VerifiedMatricMarks = i+12345, 
                  VerifiedFSCMarks = i+12345, 
                  VerifiedMSCCGPA = i+12345, 
                  VerifiedBSCGPA = i+12345, 
                  BSDegree =  "BSDegree"+i, 
                  MSDegree =  "MSDegree"+i, 
                  BSIsVerified = i+12345, 
                  MSIsVerified = i+12345, 
                  PHDIsVerified = i+12345, 
                  MatricIsVerified = i+12345, 
                  InterIsVerified = i+12345, 
                });
            }
            return resultList;
      }
      public async Task<Qualification> FindQualificationAsync(long id)
      {
         return new Qualification
                {
                    
                    QualificationId =  12345,
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
                    InterRollNo =  12345,
                    NTSRollNo =  12345,
                    MatricRollNo =  "MatricRollNo",
                    MSRollNo =  12345,
                    GATRollNo =  12345,
                    BSRollNo =  "BSRollNo",
                    BoardName =  "BoardName",
                    GATObtMarks =  12345,
                    BatchlorObtCGPA =  12345,
                    MSCObtCGPA =  12345,
                    VerifiedNTSMarks =  12345,
                    VerifiedMatricMarks =  12345,
                    VerifiedFSCMarks =  12345,
                    VerifiedMSCCGPA =  12345,
                    VerifiedBSCGPA =  12345,
                    BSDegree =  "BSDegree",
                    MSDegree =  "MSDegree",
                    BSIsVerified =  12345,
                    MSIsVerified =  12345,
                    PHDIsVerified =  12345,
                    MatricIsVerified =  12345,
                    InterIsVerified =  12345,
                };
      }
      public async Task<Qualification> UpdateQualificationAsync(Qualification qualification)
      {
        return null;
      }
      public async Task RemoveQualificationAsync(long id)
      {
        
      }
       
      public async Task<Qualification> GetQualificationWithChildrenAsync(long id)
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

         
        return new Qualification
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
                    
                     //One to One
                     Student = student,
                     
                };
         
      }
      public async Task<Qualification> SaveQualificationAsync(Qualification qualification)
      {
        return null;
      }
      public async Task<List<Qualification>> QueryAsync(string query)
      {
         var resultList = new List<Qualification>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Qualification
                {
                    
                  QualificationId = i+12345, 
                  NTSObtMarks =  "NTSObtMarks"+i, 
                  InterObtMarks =  "InterObtMarks"+i, 
                  MatricObtMarks =  "MatricObtMarks"+i, 
                  FSCYear =  "FSCYear"+i, 
                  BSYear =  "BSYear"+i, 
                  MSYear =  "MSYear"+i, 
                  MatricYear =  "MatricYear"+i, 
                  MSInstituteName =  "MSInstituteName"+i, 
                  BSInstituteName =  "BSInstituteName"+i, 
                  InterInstituteName =  "InterInstituteName"+i, 
                  MatricInstituteName =  "MatricInstituteName"+i, 
                  InterRollNo = i+12345, 
                  NTSRollNo = i+12345, 
                  MatricRollNo =  "MatricRollNo"+i, 
                  MSRollNo = i+12345, 
                  GATRollNo = i+12345, 
                  BSRollNo =  "BSRollNo"+i, 
                  BoardName =  "BoardName"+i, 
                  GATObtMarks = i+12345, 
                  BatchlorObtCGPA = i+12345, 
                  MSCObtCGPA = i+12345, 
                  VerifiedNTSMarks = i+12345, 
                  VerifiedMatricMarks = i+12345, 
                  VerifiedFSCMarks = i+12345, 
                  VerifiedMSCCGPA = i+12345, 
                  VerifiedBSCGPA = i+12345, 
                  BSDegree =  "BSDegree"+i, 
                  MSDegree =  "MSDegree"+i, 
                  BSIsVerified = i+12345, 
                  MSIsVerified = i+12345, 
                  PHDIsVerified = i+12345, 
                  MatricIsVerified = i+12345, 
                  InterIsVerified = i+12345, 
                });
            }
            return resultList;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
#endregion    
    
    
    
    
    
    
}