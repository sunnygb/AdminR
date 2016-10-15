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

    public interface IBiochemistriesRepository
    {
       Task<Biochemistry> AddBiochemistryAsync(Biochemistry biochemistry);
       Task<List< Biochemistry>> GetAllBiochemistryAsync();
       Task<Biochemistry> FindBiochemistryAsync(long id);
       Task<Biochemistry> UpdateBiochemistryAsync(Biochemistry biochemistry);
       Task RemoveBiochemistryAsync(long id); 
       
       Task<Biochemistry> GetBiochemistryWithChildrenAsync(long id);
       Task<Biochemistry> SaveBiochemistryAsync(Biochemistry biochemistry);
       Task<List<Biochemistry>> QueryAsync(string query);
       IDbConnection Custom { get;  }
    }


    public class BiochemistryRepository : IBiochemistriesRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public BiochemistryRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       

      public async Task<Biochemistry> AddBiochemistryAsync(Biochemistry biochemistry)
       {
          await Conn.InsertAsync(biochemistry);
          biochemistry.SerialNo =Conn.LastInsertId();
          return biochemistry;
       
       }
       
      public async Task<List<Biochemistry>> GetAllBiochemistryAsync()
       {
         return await Conn.SelectAsync<Biochemistry>();
       
       }
       
      public async Task<Biochemistry> FindBiochemistryAsync(long id)
       {
         return await Conn.SingleByIdAsync<Biochemistry>(id);
       
       }
       
      public async Task<Biochemistry> UpdateBiochemistryAsync(Biochemistry biochemistry)
       {
          await Conn.UpdateAsync<Biochemistry>(biochemistry);
          return biochemistry;
       
       }
       
      public async Task RemoveBiochemistryAsync(long id)
       {
         await Conn.DeleteByIdAsync<Biochemistry>(id);
       
       }
       
      public async Task<Biochemistry> GetBiochemistryWithChildrenAsync(long id)
       {
          var biochemistry = await Conn.SingleByIdAsync<Biochemistry>(id);
          
          
          
   
                 // One To One 
           var patient = await Conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (biochemistry != null && patient != null)
           {
             biochemistry.Patient = patient;
           }
         
  
         return biochemistry;
         }
       
       
      public async Task<Biochemistry> SaveBiochemistryAsync(Biochemistry biochemistry)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(biochemistry.IsNew)
                {
                   await AddBiochemistryAsync(biochemistry);
                }
                else
                {
                   await UpdateBiochemistryAsync(biochemistry);
                }
                
                
                    
                 // One To One 
                 if(biochemistry.Patient!=null)
                 {
                    if(biochemistry.Patient.IsDeleted)
                    {
                      var id = biochemistry.Patient.PatientID;
                      await Conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!biochemistry.Patient.IsDeleted)
                    {
                      var patient = biochemistry.Patient;
                      patient.PatientID = biochemistry.SerialNo;
                      await Conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return biochemistry;
       
       }
       
      public async Task<List<Biochemistry>> QueryAsync(string query)
      {
        var result = await Conn.SelectAsync<Biochemistry>(query);
        return result;
      }
      public IDbConnection Custom { get { return Conn; }  }
       
       public void Dispose()
       {
          if (Conn != null)
              Conn.Dispose();
       }
   
    }
    
    public class DesignBiochemistriesRepository : IBiochemistriesRepository
    {
      public Task<Biochemistry> AddBiochemistryAsync(Biochemistry biochemistry)
      {
         return null;
      }
      public async Task<List<Biochemistry>> GetAllBiochemistryAsync()
      {
            var resultList = new List<Biochemistry>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Biochemistry
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  BloodSugarFasting =  "BloodSugarFasting"+i, 
                  BloodSugarFastingUnit =  "BloodSugarFastingUnit"+i, 
                  BloodSugarFastingNor =  "BloodSugarFastingNor"+i, 
                  BloodSugar2HPP =  "BloodSugar2HPP"+i, 
                  BloodSugar2HPPUnit =  "BloodSugar2HPPUnit"+i, 
                  BloodSugar2HPPNor =  "BloodSugar2HPPNor"+i, 
                  BloodSugarRandom =  "BloodSugarRandom"+i, 
                  BloodSugarRandomUnit =  "BloodSugarRandomUnit"+i, 
                  BloodSugarRandomNor =  "BloodSugarRandomNor"+i, 
                  BloodUrea =  "BloodUrea"+i, 
                  BloodUreaUnit =  "BloodUreaUnit"+i, 
                  BloodUreaNor =  "BloodUreaNor"+i, 
                  Bun =  "Bun"+i, 
                  BUNUnit =  "BUNUnit"+i, 
                  BUNNor =  "BUNNor"+i, 
                  SCreatinine =  "SCreatinine"+i, 
                  SCreatinineUnit =  "SCreatinineUnit"+i, 
                  SCreatinineNor =  "SCreatinineNor"+i, 
                  SUricAcid =  "SUricAcid"+i, 
                  SUricAcidUnit =  "SUricAcidUnit"+i, 
                  SUricAcidNor =  "SUricAcidNor"+i, 
                  SCholestrol =  "SCholestrol"+i, 
                  SCholestrolUnit =  "SCholestrolUnit"+i, 
                  SCholestrolNor =  "SCholestrolNor"+i, 
                  STriglycerides =  "STriglycerides"+i, 
                  STriglyceridesUnit =  "STriglyceridesUnit"+i, 
                  STriglyceridesNor =  "STriglyceridesNor"+i, 
                  HDLCholestrol =  "HDLCholestrol"+i, 
                  HDLCholestrolUnit =  "HDLCholestrolUnit"+i, 
                  HDLCholestrolNor =  "HDLCholestrolNor"+i, 
                  LDLCholestrol =  "LDLCholestrol"+i, 
                  LDLCholestrolUnit =  "LDLCholestrolUnit"+i, 
                  LDLCholestrolNor =  "LDLCholestrolNor"+i, 
                  SgotAst =  "SgotAst"+i, 
                  SGOTASTUnit =  "SGOTASTUnit"+i, 
                  SGOTNor =  "SGOTNor"+i, 
                  Ldh =  "Ldh"+i, 
                  LDHUnit =  "LDHUnit"+i, 
                  LDHNor =  "LDHNor"+i, 
                  Cpk =  "Cpk"+i, 
                  CPKUnit =  "CPKUnit"+i, 
                  CPKNor =  "CPKNor"+i, 
                  Ckmb =  "Ckmb"+i, 
                  CKMBUnit =  "CKMBUnit"+i, 
                  CKMBNor =  "CKMBNor"+i, 
                  SBilirubinT =  "SBilirubinT"+i, 
                  SBilirubinTUnit =  "SBilirubinTUnit"+i, 
                  SBilirubinTNor =  "SBilirubinTNor"+i, 
                  SBilirubinD =  "SBilirubinD"+i, 
                  SBilirubinDUnit =  "SBilirubinDUnit"+i, 
                  SBilirubinDNor =  "SBilirubinDNor"+i, 
                  SBilirubinInd =  "SBilirubinInd"+i, 
                  SBilirubinIndUnit =  "SBilirubinIndUnit"+i, 
                  SBilirubinIndNor =  "SBilirubinIndNor"+i, 
                  SAlkPhosphatase =  "SAlkPhosphatase"+i, 
                  SAlkPhosphataseUnit =  "SAlkPhosphataseUnit"+i, 
                  SAlkPhosphataseNor =  "SAlkPhosphataseNor"+i, 
                  SgptAlt =  "SgptAlt"+i, 
                  SGPTALTUnit =  "SGPTALTUnit"+i, 
                  SGPTALTNor =  "SGPTALTNor"+i, 
                  SSodium =  "SSodium"+i, 
                  SSodiumUnit =  "SSodiumUnit"+i, 
                  SSodiumNor =  "SSodiumNor"+i, 
                  SPotassium =  "SPotassium"+i, 
                  SPotassiumUnit =  "SPotassiumUnit"+i, 
                  SPotassiumNor =  "SPotassiumNor"+i, 
                  SChloride =  "SChloride"+i, 
                  SChlorideUnit =  "SChlorideUnit"+i, 
                  SChlorideNor =  "SChlorideNor"+i, 
                  SCalcium =  "SCalcium"+i, 
                  SCalciumUnit =  "SCalciumUnit"+i, 
                  SCalciumNor =  "SCalciumNor"+i, 
                  SProtein =  "SProtein"+i, 
                  SProteinUnit =  "SProteinUnit"+i, 
                  SProteinNor =  "SProteinNor"+i, 
                  SAlbumin =  "SAlbumin"+i, 
                  SAlbuminUnit =  "SAlbuminUnit"+i, 
                  SAlbuminNor =  "SAlbuminNor"+i, 
                  AGRatio =  "AGRatio"+i, 
                  AGRatioUnit =  "AGRatioUnit"+i, 
                  AGRatioNor =  "AGRatioNor"+i, 
                  Fee = i+12345, 
                });
            }
            return resultList;
      }
      public async Task<Biochemistry> FindBiochemistryAsync(long id)
      {
         return new Biochemistry
                {
                    
                    SerialNo =  12345,
                    PatientID =  12345,
                    TDate =  DateTime.Now,
                    BloodSugarFasting =  "BloodSugarFasting",
                    BloodSugarFastingUnit =  "BloodSugarFastingUnit",
                    BloodSugarFastingNor =  "BloodSugarFastingNor",
                    BloodSugar2HPP =  "BloodSugar2HPP",
                    BloodSugar2HPPUnit =  "BloodSugar2HPPUnit",
                    BloodSugar2HPPNor =  "BloodSugar2HPPNor",
                    BloodSugarRandom =  "BloodSugarRandom",
                    BloodSugarRandomUnit =  "BloodSugarRandomUnit",
                    BloodSugarRandomNor =  "BloodSugarRandomNor",
                    BloodUrea =  "BloodUrea",
                    BloodUreaUnit =  "BloodUreaUnit",
                    BloodUreaNor =  "BloodUreaNor",
                    Bun =  "Bun",
                    BUNUnit =  "BUNUnit",
                    BUNNor =  "BUNNor",
                    SCreatinine =  "SCreatinine",
                    SCreatinineUnit =  "SCreatinineUnit",
                    SCreatinineNor =  "SCreatinineNor",
                    SUricAcid =  "SUricAcid",
                    SUricAcidUnit =  "SUricAcidUnit",
                    SUricAcidNor =  "SUricAcidNor",
                    SCholestrol =  "SCholestrol",
                    SCholestrolUnit =  "SCholestrolUnit",
                    SCholestrolNor =  "SCholestrolNor",
                    STriglycerides =  "STriglycerides",
                    STriglyceridesUnit =  "STriglyceridesUnit",
                    STriglyceridesNor =  "STriglyceridesNor",
                    HDLCholestrol =  "HDLCholestrol",
                    HDLCholestrolUnit =  "HDLCholestrolUnit",
                    HDLCholestrolNor =  "HDLCholestrolNor",
                    LDLCholestrol =  "LDLCholestrol",
                    LDLCholestrolUnit =  "LDLCholestrolUnit",
                    LDLCholestrolNor =  "LDLCholestrolNor",
                    SgotAst =  "SgotAst",
                    SGOTASTUnit =  "SGOTASTUnit",
                    SGOTNor =  "SGOTNor",
                    Ldh =  "Ldh",
                    LDHUnit =  "LDHUnit",
                    LDHNor =  "LDHNor",
                    Cpk =  "Cpk",
                    CPKUnit =  "CPKUnit",
                    CPKNor =  "CPKNor",
                    Ckmb =  "Ckmb",
                    CKMBUnit =  "CKMBUnit",
                    CKMBNor =  "CKMBNor",
                    SBilirubinT =  "SBilirubinT",
                    SBilirubinTUnit =  "SBilirubinTUnit",
                    SBilirubinTNor =  "SBilirubinTNor",
                    SBilirubinD =  "SBilirubinD",
                    SBilirubinDUnit =  "SBilirubinDUnit",
                    SBilirubinDNor =  "SBilirubinDNor",
                    SBilirubinInd =  "SBilirubinInd",
                    SBilirubinIndUnit =  "SBilirubinIndUnit",
                    SBilirubinIndNor =  "SBilirubinIndNor",
                    SAlkPhosphatase =  "SAlkPhosphatase",
                    SAlkPhosphataseUnit =  "SAlkPhosphataseUnit",
                    SAlkPhosphataseNor =  "SAlkPhosphataseNor",
                    SgptAlt =  "SgptAlt",
                    SGPTALTUnit =  "SGPTALTUnit",
                    SGPTALTNor =  "SGPTALTNor",
                    SSodium =  "SSodium",
                    SSodiumUnit =  "SSodiumUnit",
                    SSodiumNor =  "SSodiumNor",
                    SPotassium =  "SPotassium",
                    SPotassiumUnit =  "SPotassiumUnit",
                    SPotassiumNor =  "SPotassiumNor",
                    SChloride =  "SChloride",
                    SChlorideUnit =  "SChlorideUnit",
                    SChlorideNor =  "SChlorideNor",
                    SCalcium =  "SCalcium",
                    SCalciumUnit =  "SCalciumUnit",
                    SCalciumNor =  "SCalciumNor",
                    SProtein =  "SProtein",
                    SProteinUnit =  "SProteinUnit",
                    SProteinNor =  "SProteinNor",
                    SAlbumin =  "SAlbumin",
                    SAlbuminUnit =  "SAlbuminUnit",
                    SAlbuminNor =  "SAlbuminNor",
                    AGRatio =  "AGRatio",
                    AGRatioUnit =  "AGRatioUnit",
                    AGRatioNor =  "AGRatioNor",
                    Fee =  12345,
                };
      }
      public async Task<Biochemistry> UpdateBiochemistryAsync(Biochemistry biochemistry)
      {
        return null;
      }
      public async Task RemoveBiochemistryAsync(long id)
      {
        
      }
       
      public async Task<Biochemistry> GetBiochemistryWithChildrenAsync(long id)
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

         
        return new Biochemistry
                {
                    
                    SerialNo = 12345,
                    PatientID = 12345,
                    TDate =  DateTime.Now,
                    BloodSugarFasting =  "BloodSugarFasting",
                    BloodSugarFastingUnit =  "BloodSugarFastingUnit",
                    BloodSugarFastingNor =  "BloodSugarFastingNor",
                    BloodSugar2HPP =  "BloodSugar2HPP",
                    BloodSugar2HPPUnit =  "BloodSugar2HPPUnit",
                    BloodSugar2HPPNor =  "BloodSugar2HPPNor",
                    BloodSugarRandom =  "BloodSugarRandom",
                    BloodSugarRandomUnit =  "BloodSugarRandomUnit",
                    BloodSugarRandomNor =  "BloodSugarRandomNor",
                    BloodUrea =  "BloodUrea",
                    BloodUreaUnit =  "BloodUreaUnit",
                    BloodUreaNor =  "BloodUreaNor",
                    Bun =  "Bun",
                    BUNUnit =  "BUNUnit",
                    BUNNor =  "BUNNor",
                    SCreatinine =  "SCreatinine",
                    SCreatinineUnit =  "SCreatinineUnit",
                    SCreatinineNor =  "SCreatinineNor",
                    SUricAcid =  "SUricAcid",
                    SUricAcidUnit =  "SUricAcidUnit",
                    SUricAcidNor =  "SUricAcidNor",
                    SCholestrol =  "SCholestrol",
                    SCholestrolUnit =  "SCholestrolUnit",
                    SCholestrolNor =  "SCholestrolNor",
                    STriglycerides =  "STriglycerides",
                    STriglyceridesUnit =  "STriglyceridesUnit",
                    STriglyceridesNor =  "STriglyceridesNor",
                    HDLCholestrol =  "HDLCholestrol",
                    HDLCholestrolUnit =  "HDLCholestrolUnit",
                    HDLCholestrolNor =  "HDLCholestrolNor",
                    LDLCholestrol =  "LDLCholestrol",
                    LDLCholestrolUnit =  "LDLCholestrolUnit",
                    LDLCholestrolNor =  "LDLCholestrolNor",
                    SgotAst =  "SgotAst",
                    SGOTASTUnit =  "SGOTASTUnit",
                    SGOTNor =  "SGOTNor",
                    Ldh =  "Ldh",
                    LDHUnit =  "LDHUnit",
                    LDHNor =  "LDHNor",
                    Cpk =  "Cpk",
                    CPKUnit =  "CPKUnit",
                    CPKNor =  "CPKNor",
                    Ckmb =  "Ckmb",
                    CKMBUnit =  "CKMBUnit",
                    CKMBNor =  "CKMBNor",
                    SBilirubinT =  "SBilirubinT",
                    SBilirubinTUnit =  "SBilirubinTUnit",
                    SBilirubinTNor =  "SBilirubinTNor",
                    SBilirubinD =  "SBilirubinD",
                    SBilirubinDUnit =  "SBilirubinDUnit",
                    SBilirubinDNor =  "SBilirubinDNor",
                    SBilirubinInd =  "SBilirubinInd",
                    SBilirubinIndUnit =  "SBilirubinIndUnit",
                    SBilirubinIndNor =  "SBilirubinIndNor",
                    SAlkPhosphatase =  "SAlkPhosphatase",
                    SAlkPhosphataseUnit =  "SAlkPhosphataseUnit",
                    SAlkPhosphataseNor =  "SAlkPhosphataseNor",
                    SgptAlt =  "SgptAlt",
                    SGPTALTUnit =  "SGPTALTUnit",
                    SGPTALTNor =  "SGPTALTNor",
                    SSodium =  "SSodium",
                    SSodiumUnit =  "SSodiumUnit",
                    SSodiumNor =  "SSodiumNor",
                    SPotassium =  "SPotassium",
                    SPotassiumUnit =  "SPotassiumUnit",
                    SPotassiumNor =  "SPotassiumNor",
                    SChloride =  "SChloride",
                    SChlorideUnit =  "SChlorideUnit",
                    SChlorideNor =  "SChlorideNor",
                    SCalcium =  "SCalcium",
                    SCalciumUnit =  "SCalciumUnit",
                    SCalciumNor =  "SCalciumNor",
                    SProtein =  "SProtein",
                    SProteinUnit =  "SProteinUnit",
                    SProteinNor =  "SProteinNor",
                    SAlbumin =  "SAlbumin",
                    SAlbuminUnit =  "SAlbuminUnit",
                    SAlbuminNor =  "SAlbuminNor",
                    AGRatio =  "AGRatio",
                    AGRatioUnit =  "AGRatioUnit",
                    AGRatioNor =  "AGRatioNor",
                    Fee = 12345,
                    
                     //One to One
                     Patient = patient,
                     
                };
         
      }
      public async Task<Biochemistry> SaveBiochemistryAsync(Biochemistry biochemistry)
      {
        return null;
      }
      public async Task<List<Biochemistry>> QueryAsync(string query)
      {
         return null;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
    
    
    
    
    
    
    
}