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

    public interface IHaematologiesRepository
    {
       Task<Haematology> AddHaematologyAsync(Haematology haematology);
       Task<List< Haematology>> GetAllHaematologyAsync();
       Task<Haematology> FindHaematologyAsync(long id);
       Task<Haematology> UpdateHaematologyAsync(Haematology haematology);
       Task RemoveHaematologyAsync(long id); 
       Task<Haematology> GetHaematologyWithChildrenAsync(long id);
       Task<Haematology> SaveHaematologyAsync(Haematology haematology);
       Task<List<Haematology>> QueryAsync(string query);
       
       Haematology AddHaematology(Haematology haematology);
       List< Haematology> GetAllHaematology();
       Haematology FindHaematology(long id);
       Haematology UpdateHaematology(Haematology haematology);
       void RemoveHaematology(long id); 
       Haematology GetWithChildren(long id);
       Haematology SaveHaematology(Haematology haematology);
       List< Haematology> Query(string query);
       
       IDbConnection Custom { get;  }
    }

#endregion

#region Original Repository
        


                                                            

    public class HaematologyRepository : IHaematologiesRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public HaematologyRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       
       
       public Haematology AddHaematology(Haematology haematology)
       {
          this.Conn.Insert(haematology);
          haematology.SerialNo =this.Conn.LastInsertId();
          return haematology;
       
       }
       
      public List<Haematology> GetAllHaematology()
       {
         return Conn.Select<Haematology>();
       
       }
       
      public Haematology FindHaematology(long id)
       {
         return Conn.SingleById<Haematology>(id);
       
       }
       
      public Haematology UpdateHaematology(Haematology haematology)
       {
          var result=Conn.Update<Haematology>(haematology);
          return haematology;
       
       }
       
      public void RemoveHaematology(long id)
       {
          Conn.DeleteById<Haematology>(id);
       
       }
       
      public Haematology GetWithChildren(long id)
       {
          var haematology = Conn.SingleById<Haematology>(id);
          
          
          
   
                 // One To One 
           var patient = Conn.Select<Patient>().Where(a => a.PatientID == id).SingleOrDefault();
           if (haematology != null && patient != null)
           {
             haematology.Patient = patient;
           }
         
  
         return haematology;
         }
       
       
      public Haematology SaveHaematology(Haematology haematology)
      {
          using(var txScope= new TransactionScope())
            {
                if(haematology.IsNew)
                {
                    this.AddHaematology(haematology);
                }
                else
                {
                    this.UpdateHaematology(haematology);
                }
                
                
                    
                    
                 // One To One 
                 if(haematology.Patient !=null)
                 {
                    var patient = haematology.Patient;
                    patient.PatientID = haematology.SerialNo;
                    Conn.Save(patient);
                 }
                 
                   
                    txScope.Complete();
            }
            return haematology;
       
       }
       
       public List< Haematology> Query(string query)
       {
          return Conn.Select<Haematology>(query);
       }
       
 #endregion
 
 
#region Asyn Methods
                                                               
                                                               
       
       
       

      public async Task<Haematology> AddHaematologyAsync(Haematology haematology)
       {
          await Conn.InsertAsync(haematology);
          haematology.SerialNo =Conn.LastInsertId();
          return haematology;
       
       }
       
      public async Task<List<Haematology>> GetAllHaematologyAsync()
       {
         return await Conn.SelectAsync<Haematology>();
       
       }
       
      public async Task<Haematology> FindHaematologyAsync(long id)
       {
         return await Conn.SingleByIdAsync<Haematology>(id);
       
       }
       
      public async Task<Haematology> UpdateHaematologyAsync(Haematology haematology)
       {
          await Conn.UpdateAsync<Haematology>(haematology);
          return haematology;
       
       }
       
      public async Task RemoveHaematologyAsync(long id)
       {
         await Conn.DeleteByIdAsync<Haematology>(id);
       
       }
       
      public async Task<Haematology> GetHaematologyWithChildrenAsync(long id)
       {
          var haematology = await Conn.SingleByIdAsync<Haematology>(id);
          
          
          
   
                 // One To One 
           var patient = await Conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (haematology != null && patient != null)
           {
             haematology.Patient = patient;
           }
         
  
         return haematology;
         }
       
       
      public async Task<Haematology> SaveHaematologyAsync(Haematology haematology)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(haematology.IsNew)
                {
                   await AddHaematologyAsync(haematology);
                }
                else
                {
                   await UpdateHaematologyAsync(haematology);
                }
                
                
                    
                 // One To One 
                 if(haematology.Patient!=null)
                 {
                    if(haematology.Patient.IsDeleted)
                    {
                      var id = haematology.Patient.PatientID;
                      await Conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!haematology.Patient.IsDeleted)
                    {
                      var patient = haematology.Patient;
                      patient.PatientID = haematology.SerialNo;
                      await Conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return haematology;
       
       }
       
      public async Task<List<Haematology>> QueryAsync(string query)
      {
        return await Conn.SelectAsync<Haematology>(query);
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
    
    public class DesignHaematologiesRepository : IHaematologiesRepository
    {
    
    
       public Haematology AddHaematology(Haematology haematology)
       {
          return null;
       }
       public List< Haematology> GetAllHaematology()
       {
           var resultList = new List<Haematology>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Haematology
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  Hb =  "Hb"+i, 
                  HBUnit =  "HBUnit"+i, 
                  HBNor =  "HBNor"+i, 
                  Tlc =  "Tlc"+i, 
                  TLCUnit =  "TLCUnit"+i, 
                  TLCNor =  "TLCNor"+i, 
                  Esr =  "Esr"+i, 
                  ESRUnit =  "ESRUnit"+i, 
                  ESRNor =  "ESRNor"+i, 
                  Bt =  "Bt"+i, 
                  BTUnit =  "BTUnit"+i, 
                  BTNor =  "BTNor"+i, 
                  Ct =  "Ct"+i, 
                  CTUnit =  "CTUnit"+i, 
                  CTNor =  "CTNor"+i, 
                  PlateletsCount =  "PlateletsCount"+i, 
                  PlateletsCountUnit =  "PlateletsCountUnit"+i, 
                  PlateletsCountNor =  "PlateletsCountNor"+i, 
                  Pt =  "Pt"+i, 
                  PTUnit =  "PTUnit"+i, 
                  PTNor =  "PTNor"+i, 
                  Dlc =  "Dlc"+i, 
                  DLCUnit =  "DLCUnit"+i, 
                  DLCNor =  "DLCNor"+i, 
                  Polymorphs =  "Polymorphs"+i, 
                  PolymorphsUnit =  "PolymorphsUnit"+i, 
                  PolymorphsNor =  "PolymorphsNor"+i, 
                  Lymphocytes =  "Lymphocytes"+i, 
                  LymphocytesUnit =  "LymphocytesUnit"+i, 
                  LymphocytesNor =  "LymphocytesNor"+i, 
                  Monocyte =  "Monocyte"+i, 
                  MonocyteUnit =  "MonocyteUnit"+i, 
                  MonocyteNor =  "MonocyteNor"+i, 
                  Eosinophil =  "Eosinophil"+i, 
                  EosinophilUnit =  "EosinophilUnit"+i, 
                  EosinophilNor =  "EosinophilNor"+i, 
                  Basophil =  "Basophil"+i, 
                  BasophilUnit =  "BasophilUnit"+i, 
                  BasophilNor =  "BasophilNor"+i, 
                  MalariaParasites =  "MalariaParasites"+i, 
                  MalariaParasitesUnit =  "MalariaParasitesUnit"+i, 
                  MalariaParasitesNor =  "MalariaParasitesNor"+i, 
                  BloodGroup =  "BloodGroup"+i, 
                  BloodGroupUnit =  "BloodGroupUnit"+i, 
                  BloodGroupNor =  "BloodGroupNor"+i, 
                  RHFactor =  "RHFactor"+i, 
                  RHFactorUnit =  "RHFactorUnit"+i, 
                  RHFactorNor =  "RHFactorNor"+i, 
                  TotalRBC =  "TotalRBC"+i, 
                  TotalRBCUnit =  "TotalRBCUnit"+i, 
                  TotalRBCNor =  "TotalRBCNor"+i, 
                  PVCHaematorcrit =  "PVCHaematorcrit"+i, 
                  PVCHaematorcritUnit =  "PVCHaematorcritUnit"+i, 
                  PVCHaematorcritNor =  "PVCHaematorcritNor"+i, 
                  MCV =  "MCV"+i, 
                  MCVUnit =  "MCVUnit"+i, 
                  MCVNor =  "MCVNor"+i, 
                  MCH =  "MCH"+i, 
                  MCHUnit =  "MCHUnit"+i, 
                  MCHNor =  "MCHNor"+i, 
                  MCHC =  "MCHC"+i, 
                  MCHCUnit =  "MCHCUnit"+i, 
                  MCHCNor =  "MCHCNor"+i, 
                  Fee = i+12345, 
                });
            }
            return resultList;
         
       }
       public  Haematology FindHaematology(long id)
       {
             return new Haematology
                {
                    
                    SerialNo =  12345,
                    PatientID =  12345,
                    TDate =  DateTime.Now,
                    Hb =  "Hb",
                    HBUnit =  "HBUnit",
                    HBNor =  "HBNor",
                    Tlc =  "Tlc",
                    TLCUnit =  "TLCUnit",
                    TLCNor =  "TLCNor",
                    Esr =  "Esr",
                    ESRUnit =  "ESRUnit",
                    ESRNor =  "ESRNor",
                    Bt =  "Bt",
                    BTUnit =  "BTUnit",
                    BTNor =  "BTNor",
                    Ct =  "Ct",
                    CTUnit =  "CTUnit",
                    CTNor =  "CTNor",
                    PlateletsCount =  "PlateletsCount",
                    PlateletsCountUnit =  "PlateletsCountUnit",
                    PlateletsCountNor =  "PlateletsCountNor",
                    Pt =  "Pt",
                    PTUnit =  "PTUnit",
                    PTNor =  "PTNor",
                    Dlc =  "Dlc",
                    DLCUnit =  "DLCUnit",
                    DLCNor =  "DLCNor",
                    Polymorphs =  "Polymorphs",
                    PolymorphsUnit =  "PolymorphsUnit",
                    PolymorphsNor =  "PolymorphsNor",
                    Lymphocytes =  "Lymphocytes",
                    LymphocytesUnit =  "LymphocytesUnit",
                    LymphocytesNor =  "LymphocytesNor",
                    Monocyte =  "Monocyte",
                    MonocyteUnit =  "MonocyteUnit",
                    MonocyteNor =  "MonocyteNor",
                    Eosinophil =  "Eosinophil",
                    EosinophilUnit =  "EosinophilUnit",
                    EosinophilNor =  "EosinophilNor",
                    Basophil =  "Basophil",
                    BasophilUnit =  "BasophilUnit",
                    BasophilNor =  "BasophilNor",
                    MalariaParasites =  "MalariaParasites",
                    MalariaParasitesUnit =  "MalariaParasitesUnit",
                    MalariaParasitesNor =  "MalariaParasitesNor",
                    BloodGroup =  "BloodGroup",
                    BloodGroupUnit =  "BloodGroupUnit",
                    BloodGroupNor =  "BloodGroupNor",
                    RHFactor =  "RHFactor",
                    RHFactorUnit =  "RHFactorUnit",
                    RHFactorNor =  "RHFactorNor",
                    TotalRBC =  "TotalRBC",
                    TotalRBCUnit =  "TotalRBCUnit",
                    TotalRBCNor =  "TotalRBCNor",
                    PVCHaematorcrit =  "PVCHaematorcrit",
                    PVCHaematorcritUnit =  "PVCHaematorcritUnit",
                    PVCHaematorcritNor =  "PVCHaematorcritNor",
                    MCV =  "MCV",
                    MCVUnit =  "MCVUnit",
                    MCVNor =  "MCVNor",
                    MCH =  "MCH",
                    MCHUnit =  "MCHUnit",
                    MCHNor =  "MCHNor",
                    MCHC =  "MCHC",
                    MCHCUnit =  "MCHCUnit",
                    MCHCNor =  "MCHCNor",
                    Fee =  12345,
                };
       }
       public Haematology UpdateHaematology(Haematology haematology)
       {
         return null;
       }
       public void RemoveHaematology(long id)
       {
          return;
       
       }
       public Haematology GetWithChildren(long id)
       {
              
        //One to One
        var patient = new Patient 
        {
        PatientID = 12345, 
                Name =  "Name", 
                Age =  "Age", 
                Sex =  "Sex", 
                RefBy =  "RefBy", 
        };

         
        return new Haematology
                {
                    
                    SerialNo = 12345,
                    PatientID = 12345,
                    TDate =  DateTime.Now,
                    Hb =  "Hb",
                    HBUnit =  "HBUnit",
                    HBNor =  "HBNor",
                    Tlc =  "Tlc",
                    TLCUnit =  "TLCUnit",
                    TLCNor =  "TLCNor",
                    Esr =  "Esr",
                    ESRUnit =  "ESRUnit",
                    ESRNor =  "ESRNor",
                    Bt =  "Bt",
                    BTUnit =  "BTUnit",
                    BTNor =  "BTNor",
                    Ct =  "Ct",
                    CTUnit =  "CTUnit",
                    CTNor =  "CTNor",
                    PlateletsCount =  "PlateletsCount",
                    PlateletsCountUnit =  "PlateletsCountUnit",
                    PlateletsCountNor =  "PlateletsCountNor",
                    Pt =  "Pt",
                    PTUnit =  "PTUnit",
                    PTNor =  "PTNor",
                    Dlc =  "Dlc",
                    DLCUnit =  "DLCUnit",
                    DLCNor =  "DLCNor",
                    Polymorphs =  "Polymorphs",
                    PolymorphsUnit =  "PolymorphsUnit",
                    PolymorphsNor =  "PolymorphsNor",
                    Lymphocytes =  "Lymphocytes",
                    LymphocytesUnit =  "LymphocytesUnit",
                    LymphocytesNor =  "LymphocytesNor",
                    Monocyte =  "Monocyte",
                    MonocyteUnit =  "MonocyteUnit",
                    MonocyteNor =  "MonocyteNor",
                    Eosinophil =  "Eosinophil",
                    EosinophilUnit =  "EosinophilUnit",
                    EosinophilNor =  "EosinophilNor",
                    Basophil =  "Basophil",
                    BasophilUnit =  "BasophilUnit",
                    BasophilNor =  "BasophilNor",
                    MalariaParasites =  "MalariaParasites",
                    MalariaParasitesUnit =  "MalariaParasitesUnit",
                    MalariaParasitesNor =  "MalariaParasitesNor",
                    BloodGroup =  "BloodGroup",
                    BloodGroupUnit =  "BloodGroupUnit",
                    BloodGroupNor =  "BloodGroupNor",
                    RHFactor =  "RHFactor",
                    RHFactorUnit =  "RHFactorUnit",
                    RHFactorNor =  "RHFactorNor",
                    TotalRBC =  "TotalRBC",
                    TotalRBCUnit =  "TotalRBCUnit",
                    TotalRBCNor =  "TotalRBCNor",
                    PVCHaematorcrit =  "PVCHaematorcrit",
                    PVCHaematorcritUnit =  "PVCHaematorcritUnit",
                    PVCHaematorcritNor =  "PVCHaematorcritNor",
                    MCV =  "MCV",
                    MCVUnit =  "MCVUnit",
                    MCVNor =  "MCVNor",
                    MCH =  "MCH",
                    MCHUnit =  "MCHUnit",
                    MCHNor =  "MCHNor",
                    MCHC =  "MCHC",
                    MCHCUnit =  "MCHCUnit",
                    MCHCNor =  "MCHCNor",
                    Fee = 12345,
                    
                     //One to One
                     Patient = patient,
                     
                };
         
       }
       public Haematology SaveHaematology(Haematology haematology)
       {
         return null;
       }
       public List< Haematology> Query(string query)
       {
          var resultList = new List<Haematology>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Haematology
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  Hb =  "Hb"+i, 
                  HBUnit =  "HBUnit"+i, 
                  HBNor =  "HBNor"+i, 
                  Tlc =  "Tlc"+i, 
                  TLCUnit =  "TLCUnit"+i, 
                  TLCNor =  "TLCNor"+i, 
                  Esr =  "Esr"+i, 
                  ESRUnit =  "ESRUnit"+i, 
                  ESRNor =  "ESRNor"+i, 
                  Bt =  "Bt"+i, 
                  BTUnit =  "BTUnit"+i, 
                  BTNor =  "BTNor"+i, 
                  Ct =  "Ct"+i, 
                  CTUnit =  "CTUnit"+i, 
                  CTNor =  "CTNor"+i, 
                  PlateletsCount =  "PlateletsCount"+i, 
                  PlateletsCountUnit =  "PlateletsCountUnit"+i, 
                  PlateletsCountNor =  "PlateletsCountNor"+i, 
                  Pt =  "Pt"+i, 
                  PTUnit =  "PTUnit"+i, 
                  PTNor =  "PTNor"+i, 
                  Dlc =  "Dlc"+i, 
                  DLCUnit =  "DLCUnit"+i, 
                  DLCNor =  "DLCNor"+i, 
                  Polymorphs =  "Polymorphs"+i, 
                  PolymorphsUnit =  "PolymorphsUnit"+i, 
                  PolymorphsNor =  "PolymorphsNor"+i, 
                  Lymphocytes =  "Lymphocytes"+i, 
                  LymphocytesUnit =  "LymphocytesUnit"+i, 
                  LymphocytesNor =  "LymphocytesNor"+i, 
                  Monocyte =  "Monocyte"+i, 
                  MonocyteUnit =  "MonocyteUnit"+i, 
                  MonocyteNor =  "MonocyteNor"+i, 
                  Eosinophil =  "Eosinophil"+i, 
                  EosinophilUnit =  "EosinophilUnit"+i, 
                  EosinophilNor =  "EosinophilNor"+i, 
                  Basophil =  "Basophil"+i, 
                  BasophilUnit =  "BasophilUnit"+i, 
                  BasophilNor =  "BasophilNor"+i, 
                  MalariaParasites =  "MalariaParasites"+i, 
                  MalariaParasitesUnit =  "MalariaParasitesUnit"+i, 
                  MalariaParasitesNor =  "MalariaParasitesNor"+i, 
                  BloodGroup =  "BloodGroup"+i, 
                  BloodGroupUnit =  "BloodGroupUnit"+i, 
                  BloodGroupNor =  "BloodGroupNor"+i, 
                  RHFactor =  "RHFactor"+i, 
                  RHFactorUnit =  "RHFactorUnit"+i, 
                  RHFactorNor =  "RHFactorNor"+i, 
                  TotalRBC =  "TotalRBC"+i, 
                  TotalRBCUnit =  "TotalRBCUnit"+i, 
                  TotalRBCNor =  "TotalRBCNor"+i, 
                  PVCHaematorcrit =  "PVCHaematorcrit"+i, 
                  PVCHaematorcritUnit =  "PVCHaematorcritUnit"+i, 
                  PVCHaematorcritNor =  "PVCHaematorcritNor"+i, 
                  MCV =  "MCV"+i, 
                  MCVUnit =  "MCVUnit"+i, 
                  MCVNor =  "MCVNor"+i, 
                  MCH =  "MCH"+i, 
                  MCHUnit =  "MCHUnit"+i, 
                  MCHNor =  "MCHNor"+i, 
                  MCHC =  "MCHC"+i, 
                  MCHCUnit =  "MCHCUnit"+i, 
                  MCHCNor =  "MCHCNor"+i, 
                  Fee = i+12345, 
                });
            }
            return resultList;
       }
    
      public Task<Haematology> AddHaematologyAsync(Haematology haematology)
      {
         return null;
      }
      public async Task<List<Haematology>> GetAllHaematologyAsync()
      {
            var resultList = new List<Haematology>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Haematology
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  Hb =  "Hb"+i, 
                  HBUnit =  "HBUnit"+i, 
                  HBNor =  "HBNor"+i, 
                  Tlc =  "Tlc"+i, 
                  TLCUnit =  "TLCUnit"+i, 
                  TLCNor =  "TLCNor"+i, 
                  Esr =  "Esr"+i, 
                  ESRUnit =  "ESRUnit"+i, 
                  ESRNor =  "ESRNor"+i, 
                  Bt =  "Bt"+i, 
                  BTUnit =  "BTUnit"+i, 
                  BTNor =  "BTNor"+i, 
                  Ct =  "Ct"+i, 
                  CTUnit =  "CTUnit"+i, 
                  CTNor =  "CTNor"+i, 
                  PlateletsCount =  "PlateletsCount"+i, 
                  PlateletsCountUnit =  "PlateletsCountUnit"+i, 
                  PlateletsCountNor =  "PlateletsCountNor"+i, 
                  Pt =  "Pt"+i, 
                  PTUnit =  "PTUnit"+i, 
                  PTNor =  "PTNor"+i, 
                  Dlc =  "Dlc"+i, 
                  DLCUnit =  "DLCUnit"+i, 
                  DLCNor =  "DLCNor"+i, 
                  Polymorphs =  "Polymorphs"+i, 
                  PolymorphsUnit =  "PolymorphsUnit"+i, 
                  PolymorphsNor =  "PolymorphsNor"+i, 
                  Lymphocytes =  "Lymphocytes"+i, 
                  LymphocytesUnit =  "LymphocytesUnit"+i, 
                  LymphocytesNor =  "LymphocytesNor"+i, 
                  Monocyte =  "Monocyte"+i, 
                  MonocyteUnit =  "MonocyteUnit"+i, 
                  MonocyteNor =  "MonocyteNor"+i, 
                  Eosinophil =  "Eosinophil"+i, 
                  EosinophilUnit =  "EosinophilUnit"+i, 
                  EosinophilNor =  "EosinophilNor"+i, 
                  Basophil =  "Basophil"+i, 
                  BasophilUnit =  "BasophilUnit"+i, 
                  BasophilNor =  "BasophilNor"+i, 
                  MalariaParasites =  "MalariaParasites"+i, 
                  MalariaParasitesUnit =  "MalariaParasitesUnit"+i, 
                  MalariaParasitesNor =  "MalariaParasitesNor"+i, 
                  BloodGroup =  "BloodGroup"+i, 
                  BloodGroupUnit =  "BloodGroupUnit"+i, 
                  BloodGroupNor =  "BloodGroupNor"+i, 
                  RHFactor =  "RHFactor"+i, 
                  RHFactorUnit =  "RHFactorUnit"+i, 
                  RHFactorNor =  "RHFactorNor"+i, 
                  TotalRBC =  "TotalRBC"+i, 
                  TotalRBCUnit =  "TotalRBCUnit"+i, 
                  TotalRBCNor =  "TotalRBCNor"+i, 
                  PVCHaematorcrit =  "PVCHaematorcrit"+i, 
                  PVCHaematorcritUnit =  "PVCHaematorcritUnit"+i, 
                  PVCHaematorcritNor =  "PVCHaematorcritNor"+i, 
                  MCV =  "MCV"+i, 
                  MCVUnit =  "MCVUnit"+i, 
                  MCVNor =  "MCVNor"+i, 
                  MCH =  "MCH"+i, 
                  MCHUnit =  "MCHUnit"+i, 
                  MCHNor =  "MCHNor"+i, 
                  MCHC =  "MCHC"+i, 
                  MCHCUnit =  "MCHCUnit"+i, 
                  MCHCNor =  "MCHCNor"+i, 
                  Fee = i+12345, 
                });
            }
            return resultList;
      }
      public async Task<Haematology> FindHaematologyAsync(long id)
      {
         return new Haematology
                {
                    
                    SerialNo =  12345,
                    PatientID =  12345,
                    TDate =  DateTime.Now,
                    Hb =  "Hb",
                    HBUnit =  "HBUnit",
                    HBNor =  "HBNor",
                    Tlc =  "Tlc",
                    TLCUnit =  "TLCUnit",
                    TLCNor =  "TLCNor",
                    Esr =  "Esr",
                    ESRUnit =  "ESRUnit",
                    ESRNor =  "ESRNor",
                    Bt =  "Bt",
                    BTUnit =  "BTUnit",
                    BTNor =  "BTNor",
                    Ct =  "Ct",
                    CTUnit =  "CTUnit",
                    CTNor =  "CTNor",
                    PlateletsCount =  "PlateletsCount",
                    PlateletsCountUnit =  "PlateletsCountUnit",
                    PlateletsCountNor =  "PlateletsCountNor",
                    Pt =  "Pt",
                    PTUnit =  "PTUnit",
                    PTNor =  "PTNor",
                    Dlc =  "Dlc",
                    DLCUnit =  "DLCUnit",
                    DLCNor =  "DLCNor",
                    Polymorphs =  "Polymorphs",
                    PolymorphsUnit =  "PolymorphsUnit",
                    PolymorphsNor =  "PolymorphsNor",
                    Lymphocytes =  "Lymphocytes",
                    LymphocytesUnit =  "LymphocytesUnit",
                    LymphocytesNor =  "LymphocytesNor",
                    Monocyte =  "Monocyte",
                    MonocyteUnit =  "MonocyteUnit",
                    MonocyteNor =  "MonocyteNor",
                    Eosinophil =  "Eosinophil",
                    EosinophilUnit =  "EosinophilUnit",
                    EosinophilNor =  "EosinophilNor",
                    Basophil =  "Basophil",
                    BasophilUnit =  "BasophilUnit",
                    BasophilNor =  "BasophilNor",
                    MalariaParasites =  "MalariaParasites",
                    MalariaParasitesUnit =  "MalariaParasitesUnit",
                    MalariaParasitesNor =  "MalariaParasitesNor",
                    BloodGroup =  "BloodGroup",
                    BloodGroupUnit =  "BloodGroupUnit",
                    BloodGroupNor =  "BloodGroupNor",
                    RHFactor =  "RHFactor",
                    RHFactorUnit =  "RHFactorUnit",
                    RHFactorNor =  "RHFactorNor",
                    TotalRBC =  "TotalRBC",
                    TotalRBCUnit =  "TotalRBCUnit",
                    TotalRBCNor =  "TotalRBCNor",
                    PVCHaematorcrit =  "PVCHaematorcrit",
                    PVCHaematorcritUnit =  "PVCHaematorcritUnit",
                    PVCHaematorcritNor =  "PVCHaematorcritNor",
                    MCV =  "MCV",
                    MCVUnit =  "MCVUnit",
                    MCVNor =  "MCVNor",
                    MCH =  "MCH",
                    MCHUnit =  "MCHUnit",
                    MCHNor =  "MCHNor",
                    MCHC =  "MCHC",
                    MCHCUnit =  "MCHCUnit",
                    MCHCNor =  "MCHCNor",
                    Fee =  12345,
                };
      }
      public async Task<Haematology> UpdateHaematologyAsync(Haematology haematology)
      {
        return null;
      }
      public async Task RemoveHaematologyAsync(long id)
      {
        
      }
       
      public async Task<Haematology> GetHaematologyWithChildrenAsync(long id)
      {
        //One to One
        var patient = new Patient 
        {
        PatientID = 12345, 
                Name =  "Name", 
                Age =  "Age", 
                Sex =  "Sex", 
                RefBy =  "RefBy", 
        };

         
        return new Haematology
                {
                    
                    SerialNo = 12345,
                    PatientID = 12345,
                    TDate =  DateTime.Now,
                    Hb =  "Hb",
                    HBUnit =  "HBUnit",
                    HBNor =  "HBNor",
                    Tlc =  "Tlc",
                    TLCUnit =  "TLCUnit",
                    TLCNor =  "TLCNor",
                    Esr =  "Esr",
                    ESRUnit =  "ESRUnit",
                    ESRNor =  "ESRNor",
                    Bt =  "Bt",
                    BTUnit =  "BTUnit",
                    BTNor =  "BTNor",
                    Ct =  "Ct",
                    CTUnit =  "CTUnit",
                    CTNor =  "CTNor",
                    PlateletsCount =  "PlateletsCount",
                    PlateletsCountUnit =  "PlateletsCountUnit",
                    PlateletsCountNor =  "PlateletsCountNor",
                    Pt =  "Pt",
                    PTUnit =  "PTUnit",
                    PTNor =  "PTNor",
                    Dlc =  "Dlc",
                    DLCUnit =  "DLCUnit",
                    DLCNor =  "DLCNor",
                    Polymorphs =  "Polymorphs",
                    PolymorphsUnit =  "PolymorphsUnit",
                    PolymorphsNor =  "PolymorphsNor",
                    Lymphocytes =  "Lymphocytes",
                    LymphocytesUnit =  "LymphocytesUnit",
                    LymphocytesNor =  "LymphocytesNor",
                    Monocyte =  "Monocyte",
                    MonocyteUnit =  "MonocyteUnit",
                    MonocyteNor =  "MonocyteNor",
                    Eosinophil =  "Eosinophil",
                    EosinophilUnit =  "EosinophilUnit",
                    EosinophilNor =  "EosinophilNor",
                    Basophil =  "Basophil",
                    BasophilUnit =  "BasophilUnit",
                    BasophilNor =  "BasophilNor",
                    MalariaParasites =  "MalariaParasites",
                    MalariaParasitesUnit =  "MalariaParasitesUnit",
                    MalariaParasitesNor =  "MalariaParasitesNor",
                    BloodGroup =  "BloodGroup",
                    BloodGroupUnit =  "BloodGroupUnit",
                    BloodGroupNor =  "BloodGroupNor",
                    RHFactor =  "RHFactor",
                    RHFactorUnit =  "RHFactorUnit",
                    RHFactorNor =  "RHFactorNor",
                    TotalRBC =  "TotalRBC",
                    TotalRBCUnit =  "TotalRBCUnit",
                    TotalRBCNor =  "TotalRBCNor",
                    PVCHaematorcrit =  "PVCHaematorcrit",
                    PVCHaematorcritUnit =  "PVCHaematorcritUnit",
                    PVCHaematorcritNor =  "PVCHaematorcritNor",
                    MCV =  "MCV",
                    MCVUnit =  "MCVUnit",
                    MCVNor =  "MCVNor",
                    MCH =  "MCH",
                    MCHUnit =  "MCHUnit",
                    MCHNor =  "MCHNor",
                    MCHC =  "MCHC",
                    MCHCUnit =  "MCHCUnit",
                    MCHCNor =  "MCHCNor",
                    Fee = 12345,
                    
                     //One to One
                     Patient = patient,
                     
                };
         
      }
      public async Task<Haematology> SaveHaematologyAsync(Haematology haematology)
      {
        return null;
      }
      public async Task<List<Haematology>> QueryAsync(string query)
      {
         var resultList = new List<Haematology>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Haematology
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  Hb =  "Hb"+i, 
                  HBUnit =  "HBUnit"+i, 
                  HBNor =  "HBNor"+i, 
                  Tlc =  "Tlc"+i, 
                  TLCUnit =  "TLCUnit"+i, 
                  TLCNor =  "TLCNor"+i, 
                  Esr =  "Esr"+i, 
                  ESRUnit =  "ESRUnit"+i, 
                  ESRNor =  "ESRNor"+i, 
                  Bt =  "Bt"+i, 
                  BTUnit =  "BTUnit"+i, 
                  BTNor =  "BTNor"+i, 
                  Ct =  "Ct"+i, 
                  CTUnit =  "CTUnit"+i, 
                  CTNor =  "CTNor"+i, 
                  PlateletsCount =  "PlateletsCount"+i, 
                  PlateletsCountUnit =  "PlateletsCountUnit"+i, 
                  PlateletsCountNor =  "PlateletsCountNor"+i, 
                  Pt =  "Pt"+i, 
                  PTUnit =  "PTUnit"+i, 
                  PTNor =  "PTNor"+i, 
                  Dlc =  "Dlc"+i, 
                  DLCUnit =  "DLCUnit"+i, 
                  DLCNor =  "DLCNor"+i, 
                  Polymorphs =  "Polymorphs"+i, 
                  PolymorphsUnit =  "PolymorphsUnit"+i, 
                  PolymorphsNor =  "PolymorphsNor"+i, 
                  Lymphocytes =  "Lymphocytes"+i, 
                  LymphocytesUnit =  "LymphocytesUnit"+i, 
                  LymphocytesNor =  "LymphocytesNor"+i, 
                  Monocyte =  "Monocyte"+i, 
                  MonocyteUnit =  "MonocyteUnit"+i, 
                  MonocyteNor =  "MonocyteNor"+i, 
                  Eosinophil =  "Eosinophil"+i, 
                  EosinophilUnit =  "EosinophilUnit"+i, 
                  EosinophilNor =  "EosinophilNor"+i, 
                  Basophil =  "Basophil"+i, 
                  BasophilUnit =  "BasophilUnit"+i, 
                  BasophilNor =  "BasophilNor"+i, 
                  MalariaParasites =  "MalariaParasites"+i, 
                  MalariaParasitesUnit =  "MalariaParasitesUnit"+i, 
                  MalariaParasitesNor =  "MalariaParasitesNor"+i, 
                  BloodGroup =  "BloodGroup"+i, 
                  BloodGroupUnit =  "BloodGroupUnit"+i, 
                  BloodGroupNor =  "BloodGroupNor"+i, 
                  RHFactor =  "RHFactor"+i, 
                  RHFactorUnit =  "RHFactorUnit"+i, 
                  RHFactorNor =  "RHFactorNor"+i, 
                  TotalRBC =  "TotalRBC"+i, 
                  TotalRBCUnit =  "TotalRBCUnit"+i, 
                  TotalRBCNor =  "TotalRBCNor"+i, 
                  PVCHaematorcrit =  "PVCHaematorcrit"+i, 
                  PVCHaematorcritUnit =  "PVCHaematorcritUnit"+i, 
                  PVCHaematorcritNor =  "PVCHaematorcritNor"+i, 
                  MCV =  "MCV"+i, 
                  MCVUnit =  "MCVUnit"+i, 
                  MCVNor =  "MCVNor"+i, 
                  MCH =  "MCH"+i, 
                  MCHUnit =  "MCHUnit"+i, 
                  MCHNor =  "MCHNor"+i, 
                  MCHC =  "MCHC"+i, 
                  MCHCUnit =  "MCHCUnit"+i, 
                  MCHCNor =  "MCHCNor"+i, 
                  Fee = i+12345, 
                });
            }
            return resultList;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
#endregion    
    
    
    
    
    
    
}