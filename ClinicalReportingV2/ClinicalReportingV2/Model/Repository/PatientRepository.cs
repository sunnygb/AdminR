using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace ClinicalReporting.Model.Repository
{
    public interface IPatientsRepository
    {
        IDbConnection Custom { get; }
        Task<Patient> AddPatientAsync(Patient patient);
        Task<List<Patient>> GetAllPatientAsync();
        Task<Patient> FindPatientAsync(long id);
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task RemovePatientAsync(long id);

        Task<Patient> GetPatientWithChildrenAsync(long id);
        Task<Patient> SavePatientAsync(Patient patient);
        Task<List<Patient>> QueryAsync(string query);
    }


    public class PatientRepository : IPatientsRepository, IDisposable
    {
        private IDbConnection _conn;

        public PatientRepository(IDbConnectionFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        private IDbConnectionFactory DbFactory { get; set; }

        private IDbConnection Conn
        {
            get { return _conn ?? (_conn = DbFactory.Open()); }
        }

        public void Dispose()
        {
            if (Conn != null)
                Conn.Dispose();
        }


        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            await Conn.InsertAsync(patient);
            patient.PatientID = Conn.LastInsertId();
            return patient;
        }

        public async Task<List<Patient>> GetAllPatientAsync()
        {
            return await Conn.SelectAsync<Patient>();
        }

        public async Task<Patient> FindPatientAsync(long id)
        {
            return await Conn.SingleByIdAsync<Patient>(id);
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            await Conn.UpdateAsync(patient);
            return patient;
        }

        public async Task RemovePatientAsync(long id)
        {
            await Conn.DeleteByIdAsync<Patient>(id);
        }

        public async Task<Patient> GetPatientWithChildrenAsync(long id)
        {
            Patient patient = await Conn.SingleByIdAsync<Patient>(id);


            //One To Many
            List<Haematology> haematologies = await Conn.SelectAsync<Haematology>(e => e.SerialNo == id);
            if (patient != null && haematologies != null)
            {
                patient.Haematologies.AddRange(haematologies);
            }


            //One To Many
            List<ElisaTb> elisatbs = await Conn.SelectAsync<ElisaTb>(e => e.SerialNo == id);
            if (patient != null && elisatbs != null)
            {
                patient.ElisaTbs.AddRange(elisatbs);
            }


            //One To Many
            List<ElisaHcv> elisahcvs = await Conn.SelectAsync<ElisaHcv>(e => e.SerialNo == id);
            if (patient != null && elisahcvs != null)
            {
                patient.ElisaHcvs.AddRange(elisahcvs);
            }


            //One To Many
            List<ElisaHbsag> elisahbsags = await Conn.SelectAsync<ElisaHbsag>(e => e.SerialNo == id);
            if (patient != null && elisahbsags != null)
            {
                patient.ElisaHbsags.AddRange(elisahbsags);
            }


            //One To Many
            List<BloodGroup> bloodgroups = await Conn.SelectAsync<BloodGroup>(e => e.SerialNo == id);
            if (patient != null && bloodgroups != null)
            {
                patient.BloodGroups.AddRange(bloodgroups);
            }


            //One To Many
            List<Biochemistry> biochemistries = await Conn.SelectAsync<Biochemistry>(e => e.SerialNo == id);
            if (patient != null && biochemistries != null)
            {
                patient.Biochemistries.AddRange(biochemistries);
            }


            //One To Many
            List<SemenAnalysis> semenanalyses = await Conn.SelectAsync<SemenAnalysis>(e => e.SerialNo == id);
            if (patient != null && semenanalyses != null)
            {
                patient.SemenAnalyses.AddRange(semenanalyses);
            }


            //One To Many
            List<UrineExamination> urineexaminations = await Conn.SelectAsync<UrineExamination>(e => e.SerialNo == id);
            if (patient != null && urineexaminations != null)
            {
                patient.UrineExaminations.AddRange(urineexaminations);
            }


            //One To Many
            List<Serology> serologies = await Conn.SelectAsync<Serology>(e => e.Serialno == id);
            if (patient != null && serologies != null)
            {
                patient.Serologies.AddRange(serologies);
            }


            return patient;
        }


        public async Task<Patient> SavePatientAsync(Patient patient)
        {
            using (var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (patient.IsNew)
                {
                    await AddPatientAsync(patient);
                }
                else
                {
                    await UpdatePatientAsync(patient);
                }


                //One To Many
                foreach (Haematology haematology in patient.Haematologies.Where(s => !s.IsDeleted))
                {
                    haematology.PatientID = patient.PatientID;
                    await Conn.SaveAsync(haematology);
                }
                foreach (Haematology haematology in patient.Haematologies.Where(s => s.IsDeleted))
                {
                    await Conn.DeleteByIdAsync<Haematology>(haematology.SerialNo);
                }

                //One To Many
                foreach (ElisaTb elisatb in patient.ElisaTbs.Where(s => !s.IsDeleted))
                {
                    elisatb.PatientID = patient.PatientID;
                    await Conn.SaveAsync(elisatb);
                }
                foreach (ElisaTb elisatb in patient.ElisaTbs.Where(s => s.IsDeleted))
                {
                    await Conn.DeleteByIdAsync<ElisaTb>(elisatb.SerialNo);
                }

                //One To Many
                foreach (ElisaHcv elisahcv in patient.ElisaHcvs.Where(s => !s.IsDeleted))
                {
                    elisahcv.PatientID = patient.PatientID;
                    await Conn.SaveAsync(elisahcv);
                }
                foreach (ElisaHcv elisahcv in patient.ElisaHcvs.Where(s => s.IsDeleted))
                {
                    await Conn.DeleteByIdAsync<ElisaHcv>(elisahcv.SerialNo);
                }

                //One To Many
                foreach (ElisaHbsag elisahbsag in patient.ElisaHbsags.Where(s => !s.IsDeleted))
                {
                    elisahbsag.PatientID = patient.PatientID;
                    await Conn.SaveAsync(elisahbsag);
                }
                foreach (ElisaHbsag elisahbsag in patient.ElisaHbsags.Where(s => s.IsDeleted))
                {
                    await Conn.DeleteByIdAsync<ElisaHbsag>(elisahbsag.SerialNo);
                }

                //One To Many
                foreach (BloodGroup bloodgroup in patient.BloodGroups.Where(s => !s.IsDeleted))
                {
                    bloodgroup.PatientID = patient.PatientID;
                    await Conn.SaveAsync(bloodgroup);
                }
                foreach (BloodGroup bloodgroup in patient.BloodGroups.Where(s => s.IsDeleted))
                {
                    await Conn.DeleteByIdAsync<BloodGroup>(bloodgroup.SerialNo);
                }

                //One To Many
                foreach (Biochemistry biochemistry in patient.Biochemistries.Where(s => !s.IsDeleted))
                {
                    biochemistry.PatientID = patient.PatientID;
                    await Conn.SaveAsync(biochemistry);
                }
                foreach (Biochemistry biochemistry in patient.Biochemistries.Where(s => s.IsDeleted))
                {
                    await Conn.DeleteByIdAsync<Biochemistry>(biochemistry.SerialNo);
                }

                //One To Many
                foreach (SemenAnalysis semenanalysis in patient.SemenAnalyses.Where(s => !s.IsDeleted))
                {
                    semenanalysis.PatientID = patient.PatientID;
                    await Conn.SaveAsync(semenanalysis);
                }
                foreach (SemenAnalysis semenanalysis in patient.SemenAnalyses.Where(s => s.IsDeleted))
                {
                    await Conn.DeleteByIdAsync<SemenAnalysis>(semenanalysis.SerialNo);
                }

                //One To Many
                foreach (UrineExamination urineexamination in patient.UrineExaminations.Where(s => !s.IsDeleted))
                {
                    urineexamination.PatientID = patient.PatientID;
                    await Conn.SaveAsync(urineexamination);
                }
                foreach (UrineExamination urineexamination in patient.UrineExaminations.Where(s => s.IsDeleted))
                {
                    await Conn.DeleteByIdAsync<UrineExamination>(urineexamination.SerialNo);
                }

                //One To Many
                foreach (Serology serology in patient.Serologies.Where(s => !s.IsDeleted))
                {
                    serology.Patientid = patient.PatientID;
                    await Conn.SaveAsync(serology);
                }
                foreach (Serology serology in patient.Serologies.Where(s => s.IsDeleted))
                {
                    await Conn.DeleteByIdAsync<Serology>(serology.Serialno);
                }


                txScope.Complete();
            }
            return patient;
        }

        public async Task<List<Patient>> QueryAsync(string query)
        {
            List<Patient> result = await Conn.SelectAsync<Patient>(query);
            return result;
        }

        public IDbConnection Custom
        {
            get { return Conn; }
        }
    }

    public class DesignPatientsRepository : IPatientsRepository
    {
        public Task<Patient> AddPatientAsync(Patient patient)
        {
            return null;
        }

        public async Task<List<Patient>> GetAllPatientAsync()
        {
            var resultList = new List<Patient>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Patient
                                   {
                                       PatientID = i + 12345,
                                       Name = "Name" + i,
                                       Age = "Age" + i,
                                       Sex = "Sex" + i,
                                       RefBy = "RefBy" + i,
                                   });
            }
            return resultList;
        }

        public async Task<Patient> FindPatientAsync(long id)
        {
            return new Patient
                       {
                           PatientID = 12345,
                           Name = "Name",
                           Age = "Age",
                           Sex = "Sex",
                           RefBy = "RefBy",
                       };
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            return null;
        }

        public async Task RemovePatientAsync(long id)
        {
        }

        public async Task<Patient> GetPatientWithChildrenAsync(long id)
        {
            // One to Many
            var haematology1 = new Haematology
                                   {
                                       SerialNo = 12345,
                                       PatientID = 12345,
                                       TDate = DateTime.Now,
                                       Hb = "Hb",
                                       HBUnit = "HBUnit",
                                       HBNor = "HBNor",
                                       Tlc = "Tlc",
                                       TLCUnit = "TLCUnit",
                                       TLCNor = "TLCNor",
                                       Esr = "Esr",
                                       ESRUnit = "ESRUnit",
                                       ESRNor = "ESRNor",
                                       Bt = "Bt",
                                       BTUnit = "BTUnit",
                                       BTNor = "BTNor",
                                       Ct = "Ct",
                                       CTUnit = "CTUnit",
                                       CTNor = "CTNor",
                                       PlateletsCount = "PlateletsCount",
                                       PlateletsCountUnit = "PlateletsCountUnit",
                                       PlateletsCountNor = "PlateletsCountNor",
                                       Pt = "Pt",
                                       PTUnit = "PTUnit",
                                       PTNor = "PTNor",
                                       Dlc = "Dlc",
                                       DLCUnit = "DLCUnit",
                                       DLCNor = "DLCNor",
                                       Polymorphs = "Polymorphs",
                                       PolymorphsUnit = "PolymorphsUnit",
                                       PolymorphsNor = "PolymorphsNor",
                                       Lymphocytes = "Lymphocytes",
                                       LymphocytesUnit = "LymphocytesUnit",
                                       LymphocytesNor = "LymphocytesNor",
                                       Monocyte = "Monocyte",
                                       MonocyteUnit = "MonocyteUnit",
                                       MonocyteNor = "MonocyteNor",
                                       Eosinophil = "Eosinophil",
                                       EosinophilUnit = "EosinophilUnit",
                                       EosinophilNor = "EosinophilNor",
                                       Basophil = "Basophil",
                                       BasophilUnit = "BasophilUnit",
                                       BasophilNor = "BasophilNor",
                                       MalariaParasites = "MalariaParasites",
                                       MalariaParasitesUnit = "MalariaParasitesUnit",
                                       MalariaParasitesNor = "MalariaParasitesNor",
                                       BloodGroup = "BloodGroup",
                                       BloodGroupUnit = "BloodGroupUnit",
                                       BloodGroupNor = "BloodGroupNor",
                                       RHFactor = "RHFactor",
                                       RHFactorUnit = "RHFactorUnit",
                                       RHFactorNor = "RHFactorNor",
                                       TotalRBC = "TotalRBC",
                                       TotalRBCUnit = "TotalRBCUnit",
                                       TotalRBCNor = "TotalRBCNor",
                                       PVCHaematorcrit = "PVCHaematorcrit",
                                       PVCHaematorcritUnit = "PVCHaematorcritUnit",
                                       PVCHaematorcritNor = "PVCHaematorcritNor",
                                       MCV = "MCV",
                                       MCVUnit = "MCVUnit",
                                       MCVNor = "MCVNor",
                                       MCH = "MCH",
                                       MCHUnit = "MCHUnit",
                                       MCHNor = "MCHNor",
                                       MCHC = "MCHC",
                                       MCHCUnit = "MCHCUnit",
                                       MCHCNor = "MCHCNor",
                                       Fee = 12345,
                                   };
            var haematology2 = new Haematology
                                   {
                                       SerialNo = 12345,
                                       PatientID = 12345,
                                       TDate = DateTime.Now,
                                       Hb = "Hb",
                                       HBUnit = "HBUnit",
                                       HBNor = "HBNor",
                                       Tlc = "Tlc",
                                       TLCUnit = "TLCUnit",
                                       TLCNor = "TLCNor",
                                       Esr = "Esr",
                                       ESRUnit = "ESRUnit",
                                       ESRNor = "ESRNor",
                                       Bt = "Bt",
                                       BTUnit = "BTUnit",
                                       BTNor = "BTNor",
                                       Ct = "Ct",
                                       CTUnit = "CTUnit",
                                       CTNor = "CTNor",
                                       PlateletsCount = "PlateletsCount",
                                       PlateletsCountUnit = "PlateletsCountUnit",
                                       PlateletsCountNor = "PlateletsCountNor",
                                       Pt = "Pt",
                                       PTUnit = "PTUnit",
                                       PTNor = "PTNor",
                                       Dlc = "Dlc",
                                       DLCUnit = "DLCUnit",
                                       DLCNor = "DLCNor",
                                       Polymorphs = "Polymorphs",
                                       PolymorphsUnit = "PolymorphsUnit",
                                       PolymorphsNor = "PolymorphsNor",
                                       Lymphocytes = "Lymphocytes",
                                       LymphocytesUnit = "LymphocytesUnit",
                                       LymphocytesNor = "LymphocytesNor",
                                       Monocyte = "Monocyte",
                                       MonocyteUnit = "MonocyteUnit",
                                       MonocyteNor = "MonocyteNor",
                                       Eosinophil = "Eosinophil",
                                       EosinophilUnit = "EosinophilUnit",
                                       EosinophilNor = "EosinophilNor",
                                       Basophil = "Basophil",
                                       BasophilUnit = "BasophilUnit",
                                       BasophilNor = "BasophilNor",
                                       MalariaParasites = "MalariaParasites",
                                       MalariaParasitesUnit = "MalariaParasitesUnit",
                                       MalariaParasitesNor = "MalariaParasitesNor",
                                       BloodGroup = "BloodGroup",
                                       BloodGroupUnit = "BloodGroupUnit",
                                       BloodGroupNor = "BloodGroupNor",
                                       RHFactor = "RHFactor",
                                       RHFactorUnit = "RHFactorUnit",
                                       RHFactorNor = "RHFactorNor",
                                       TotalRBC = "TotalRBC",
                                       TotalRBCUnit = "TotalRBCUnit",
                                       TotalRBCNor = "TotalRBCNor",
                                       PVCHaematorcrit = "PVCHaematorcrit",
                                       PVCHaematorcritUnit = "PVCHaematorcritUnit",
                                       PVCHaematorcritNor = "PVCHaematorcritNor",
                                       MCV = "MCV",
                                       MCVUnit = "MCVUnit",
                                       MCVNor = "MCVNor",
                                       MCH = "MCH",
                                       MCHUnit = "MCHUnit",
                                       MCHNor = "MCHNor",
                                       MCHC = "MCHC",
                                       MCHCUnit = "MCHCUnit",
                                       MCHCNor = "MCHCNor",
                                       Fee = 12345,
                                   };

            // One to Many
            var elisatb1 = new ElisaTb
                               {
                                   SerialNo = 12345,
                                   PatientID = 12345,
                                   TDate = DateTime.Now,
                                   PatientValue = 12345,
                                   CutOffValue = 12345,
                                   Fee = 12345,
                               };
            var elisatb2 = new ElisaTb
                               {
                                   SerialNo = 12345,
                                   PatientID = 12345,
                                   TDate = DateTime.Now,
                                   PatientValue = 12345,
                                   CutOffValue = 12345,
                                   Fee = 12345,
                               };

            // One to Many
            var elisahcv1 = new ElisaHcv
                                {
                                    SerialNo = 12345,
                                    PatientID = 12345,
                                    TDate = DateTime.Now,
                                    PatientValue = 12345,
                                    CutOffValue = 12345,
                                    Fee = 12345,
                                };
            var elisahcv2 = new ElisaHcv
                                {
                                    SerialNo = 12345,
                                    PatientID = 12345,
                                    TDate = DateTime.Now,
                                    PatientValue = 12345,
                                    CutOffValue = 12345,
                                    Fee = 12345,
                                };

            // One to Many
            var elisahbsag1 = new ElisaHbsag
                                  {
                                      SerialNo = 12345,
                                      PatientID = 12345,
                                      TDate = DateTime.Now,
                                      PatientValue = 12345,
                                      CutOffValue = 12345,
                                      Fee = 12345,
                                  };
            var elisahbsag2 = new ElisaHbsag
                                  {
                                      SerialNo = 12345,
                                      PatientID = 12345,
                                      TDate = DateTime.Now,
                                      PatientValue = 12345,
                                      CutOffValue = 12345,
                                      Fee = 12345,
                                  };

            // One to Many
            var bloodgroup1 = new BloodGroup
                                  {
                                      SerialNo = 12345,
                                      PatientID = 12345,
                                      TDate = DateTime.Now,
                                      PatientBloodGroup = "PatientBloodGroup",
                                      DonarName = "DonarName",
                                      DonarBloodGroup = "DonarBloodGroup",
                                      HbsAg = "HbsAg",
                                      AntiHCV = "AntiHCV",
                                      Fee = 12345,
                                  };
            var bloodgroup2 = new BloodGroup
                                  {
                                      SerialNo = 12345,
                                      PatientID = 12345,
                                      TDate = DateTime.Now,
                                      PatientBloodGroup = "PatientBloodGroup",
                                      DonarName = "DonarName",
                                      DonarBloodGroup = "DonarBloodGroup",
                                      HbsAg = "HbsAg",
                                      AntiHCV = "AntiHCV",
                                      Fee = 12345,
                                  };

            // One to Many
            var biochemistry1 = new Biochemistry
                                    {
                                        SerialNo = 12345,
                                        PatientID = 12345,
                                        TDate = DateTime.Now,
                                        BloodSugarFasting = "BloodSugarFasting",
                                        BloodSugarFastingUnit = "BloodSugarFastingUnit",
                                        BloodSugarFastingNor = "BloodSugarFastingNor",
                                        BloodSugar2HPP = "BloodSugar2HPP",
                                        BloodSugar2HPPUnit = "BloodSugar2HPPUnit",
                                        BloodSugar2HPPNor = "BloodSugar2HPPNor",
                                        BloodSugarRandom = "BloodSugarRandom",
                                        BloodSugarRandomUnit = "BloodSugarRandomUnit",
                                        BloodSugarRandomNor = "BloodSugarRandomNor",
                                        BloodUrea = "BloodUrea",
                                        BloodUreaUnit = "BloodUreaUnit",
                                        BloodUreaNor = "BloodUreaNor",
                                        Bun = "Bun",
                                        BUNUnit = "BUNUnit",
                                        BUNNor = "BUNNor",
                                        SCreatinine = "SCreatinine",
                                        SCreatinineUnit = "SCreatinineUnit",
                                        SCreatinineNor = "SCreatinineNor",
                                        SUricAcid = "SUricAcid",
                                        SUricAcidUnit = "SUricAcidUnit",
                                        SUricAcidNor = "SUricAcidNor",
                                        SCholestrol = "SCholestrol",
                                        SCholestrolUnit = "SCholestrolUnit",
                                        SCholestrolNor = "SCholestrolNor",
                                        STriglycerides = "STriglycerides",
                                        STriglyceridesUnit = "STriglyceridesUnit",
                                        STriglyceridesNor = "STriglyceridesNor",
                                        HDLCholestrol = "HDLCholestrol",
                                        HDLCholestrolUnit = "HDLCholestrolUnit",
                                        HDLCholestrolNor = "HDLCholestrolNor",
                                        LDLCholestrol = "LDLCholestrol",
                                        LDLCholestrolUnit = "LDLCholestrolUnit",
                                        LDLCholestrolNor = "LDLCholestrolNor",
                                        SgotAst = "SgotAst",
                                        SGOTASTUnit = "SGOTASTUnit",
                                        SGOTNor = "SGOTNor",
                                        Ldh = "Ldh",
                                        LDHUnit = "LDHUnit",
                                        LDHNor = "LDHNor",
                                        Cpk = "Cpk",
                                        CPKUnit = "CPKUnit",
                                        CPKNor = "CPKNor",
                                        Ckmb = "Ckmb",
                                        CKMBUnit = "CKMBUnit",
                                        CKMBNor = "CKMBNor",
                                        SBilirubinT = "SBilirubinT",
                                        SBilirubinTUnit = "SBilirubinTUnit",
                                        SBilirubinTNor = "SBilirubinTNor",
                                        SBilirubinD = "SBilirubinD",
                                        SBilirubinDUnit = "SBilirubinDUnit",
                                        SBilirubinDNor = "SBilirubinDNor",
                                        SBilirubinInd = "SBilirubinInd",
                                        SBilirubinIndUnit = "SBilirubinIndUnit",
                                        SBilirubinIndNor = "SBilirubinIndNor",
                                        SAlkPhosphatase = "SAlkPhosphatase",
                                        SAlkPhosphataseUnit = "SAlkPhosphataseUnit",
                                        SAlkPhosphataseNor = "SAlkPhosphataseNor",
                                        SgptAlt = "SgptAlt",
                                        SGPTALTUnit = "SGPTALTUnit",
                                        SGPTALTNor = "SGPTALTNor",
                                        SSodium = "SSodium",
                                        SSodiumUnit = "SSodiumUnit",
                                        SSodiumNor = "SSodiumNor",
                                        SPotassium = "SPotassium",
                                        SPotassiumUnit = "SPotassiumUnit",
                                        SPotassiumNor = "SPotassiumNor",
                                        SChloride = "SChloride",
                                        SChlorideUnit = "SChlorideUnit",
                                        SChlorideNor = "SChlorideNor",
                                        SCalcium = "SCalcium",
                                        SCalciumUnit = "SCalciumUnit",
                                        SCalciumNor = "SCalciumNor",
                                        SProtein = "SProtein",
                                        SProteinUnit = "SProteinUnit",
                                        SProteinNor = "SProteinNor",
                                        SAlbumin = "SAlbumin",
                                        SAlbuminUnit = "SAlbuminUnit",
                                        SAlbuminNor = "SAlbuminNor",
                                        AGRatio = "AGRatio",
                                        AGRatioUnit = "AGRatioUnit",
                                        AGRatioNor = "AGRatioNor",
                                        Fee = 12345,
                                    };
            var biochemistry2 = new Biochemistry
                                    {
                                        SerialNo = 12345,
                                        PatientID = 12345,
                                        TDate = DateTime.Now,
                                        BloodSugarFasting = "BloodSugarFasting",
                                        BloodSugarFastingUnit = "BloodSugarFastingUnit",
                                        BloodSugarFastingNor = "BloodSugarFastingNor",
                                        BloodSugar2HPP = "BloodSugar2HPP",
                                        BloodSugar2HPPUnit = "BloodSugar2HPPUnit",
                                        BloodSugar2HPPNor = "BloodSugar2HPPNor",
                                        BloodSugarRandom = "BloodSugarRandom",
                                        BloodSugarRandomUnit = "BloodSugarRandomUnit",
                                        BloodSugarRandomNor = "BloodSugarRandomNor",
                                        BloodUrea = "BloodUrea",
                                        BloodUreaUnit = "BloodUreaUnit",
                                        BloodUreaNor = "BloodUreaNor",
                                        Bun = "Bun",
                                        BUNUnit = "BUNUnit",
                                        BUNNor = "BUNNor",
                                        SCreatinine = "SCreatinine",
                                        SCreatinineUnit = "SCreatinineUnit",
                                        SCreatinineNor = "SCreatinineNor",
                                        SUricAcid = "SUricAcid",
                                        SUricAcidUnit = "SUricAcidUnit",
                                        SUricAcidNor = "SUricAcidNor",
                                        SCholestrol = "SCholestrol",
                                        SCholestrolUnit = "SCholestrolUnit",
                                        SCholestrolNor = "SCholestrolNor",
                                        STriglycerides = "STriglycerides",
                                        STriglyceridesUnit = "STriglyceridesUnit",
                                        STriglyceridesNor = "STriglyceridesNor",
                                        HDLCholestrol = "HDLCholestrol",
                                        HDLCholestrolUnit = "HDLCholestrolUnit",
                                        HDLCholestrolNor = "HDLCholestrolNor",
                                        LDLCholestrol = "LDLCholestrol",
                                        LDLCholestrolUnit = "LDLCholestrolUnit",
                                        LDLCholestrolNor = "LDLCholestrolNor",
                                        SgotAst = "SgotAst",
                                        SGOTASTUnit = "SGOTASTUnit",
                                        SGOTNor = "SGOTNor",
                                        Ldh = "Ldh",
                                        LDHUnit = "LDHUnit",
                                        LDHNor = "LDHNor",
                                        Cpk = "Cpk",
                                        CPKUnit = "CPKUnit",
                                        CPKNor = "CPKNor",
                                        Ckmb = "Ckmb",
                                        CKMBUnit = "CKMBUnit",
                                        CKMBNor = "CKMBNor",
                                        SBilirubinT = "SBilirubinT",
                                        SBilirubinTUnit = "SBilirubinTUnit",
                                        SBilirubinTNor = "SBilirubinTNor",
                                        SBilirubinD = "SBilirubinD",
                                        SBilirubinDUnit = "SBilirubinDUnit",
                                        SBilirubinDNor = "SBilirubinDNor",
                                        SBilirubinInd = "SBilirubinInd",
                                        SBilirubinIndUnit = "SBilirubinIndUnit",
                                        SBilirubinIndNor = "SBilirubinIndNor",
                                        SAlkPhosphatase = "SAlkPhosphatase",
                                        SAlkPhosphataseUnit = "SAlkPhosphataseUnit",
                                        SAlkPhosphataseNor = "SAlkPhosphataseNor",
                                        SgptAlt = "SgptAlt",
                                        SGPTALTUnit = "SGPTALTUnit",
                                        SGPTALTNor = "SGPTALTNor",
                                        SSodium = "SSodium",
                                        SSodiumUnit = "SSodiumUnit",
                                        SSodiumNor = "SSodiumNor",
                                        SPotassium = "SPotassium",
                                        SPotassiumUnit = "SPotassiumUnit",
                                        SPotassiumNor = "SPotassiumNor",
                                        SChloride = "SChloride",
                                        SChlorideUnit = "SChlorideUnit",
                                        SChlorideNor = "SChlorideNor",
                                        SCalcium = "SCalcium",
                                        SCalciumUnit = "SCalciumUnit",
                                        SCalciumNor = "SCalciumNor",
                                        SProtein = "SProtein",
                                        SProteinUnit = "SProteinUnit",
                                        SProteinNor = "SProteinNor",
                                        SAlbumin = "SAlbumin",
                                        SAlbuminUnit = "SAlbuminUnit",
                                        SAlbuminNor = "SAlbuminNor",
                                        AGRatio = "AGRatio",
                                        AGRatioUnit = "AGRatioUnit",
                                        AGRatioNor = "AGRatioNor",
                                        Fee = 12345,
                                    };

            // One to Many
            var semenanalysis1 = new SemenAnalysis
                                     {
                                         SerialNo = 12345,
                                         PatientID = 12345,
                                         TDate = DateTime.Now,
                                         Colour = "Colour",
                                         Quantity = "Quantity",
                                         Ph = "Ph",
                                         TimeOfCollection = "TimeOfCollection",
                                         TimeOfExamination = "TimeOfExamination",
                                         TotalCount = "TotalCount",
                                         ActiveMotility = "ActiveMotility",
                                         Sluggish = "Sluggish",
                                         NonMotile = "NonMotile",
                                         Abnormal = "Abnormal",
                                         PusCells = "PusCells",
                                         Rbc = "Rbc",
                                         EpithelialCell = "EpithelialCell",
                                         Fee = 12345,
                                     };
            var semenanalysis2 = new SemenAnalysis
                                     {
                                         SerialNo = 12345,
                                         PatientID = 12345,
                                         TDate = DateTime.Now,
                                         Colour = "Colour",
                                         Quantity = "Quantity",
                                         Ph = "Ph",
                                         TimeOfCollection = "TimeOfCollection",
                                         TimeOfExamination = "TimeOfExamination",
                                         TotalCount = "TotalCount",
                                         ActiveMotility = "ActiveMotility",
                                         Sluggish = "Sluggish",
                                         NonMotile = "NonMotile",
                                         Abnormal = "Abnormal",
                                         PusCells = "PusCells",
                                         Rbc = "Rbc",
                                         EpithelialCell = "EpithelialCell",
                                         Fee = 12345,
                                     };

            // One to Many
            var urineexamination1 = new UrineExamination
                                        {
                                            SerialNo = 12345,
                                            PatientID = 12345,
                                            TDate = DateTime.Now,
                                            Colour = "Colour",
                                            Reaction = "Reaction",
                                            SpecificGravity = "SpecificGravity",
                                            Albumin = "Albumin",
                                            Sugar = "Sugar",
                                            Ketone = "Ketone",
                                            Blood = "Blood",
                                            Bilirubin = "Bilirubin",
                                            UrobilNogen = "UrobilNogen",
                                            PusCells = "PusCells",
                                            Rbc = "Rbc",
                                            EPiCells = "EPiCells",
                                            Cast = "Cast",
                                            Crystals = "Crystals",
                                            CalOxalate = "CalOxalate",
                                            UricAcid = "UricAcid",
                                            Amorphous = "Amorphous",
                                            Others = "Others",
                                            Fee = 12345,
                                        };
            var urineexamination2 = new UrineExamination
                                        {
                                            SerialNo = 12345,
                                            PatientID = 12345,
                                            TDate = DateTime.Now,
                                            Colour = "Colour",
                                            Reaction = "Reaction",
                                            SpecificGravity = "SpecificGravity",
                                            Albumin = "Albumin",
                                            Sugar = "Sugar",
                                            Ketone = "Ketone",
                                            Blood = "Blood",
                                            Bilirubin = "Bilirubin",
                                            UrobilNogen = "UrobilNogen",
                                            PusCells = "PusCells",
                                            Rbc = "Rbc",
                                            EPiCells = "EPiCells",
                                            Cast = "Cast",
                                            Crystals = "Crystals",
                                            CalOxalate = "CalOxalate",
                                            UricAcid = "UricAcid",
                                            Amorphous = "Amorphous",
                                            Others = "Others",
                                            Fee = 12345,
                                        };

            // One to Many
            var serology1 = new Serology
                                {
                                    Serialno = 12345,
                                    Patientid = 12345,
                                    Tdate = "Tdate",
                                    WidalTest = "WidalTest",
                                    STyphiTo = "STyphiTo",
                                    STyphiTh = "STyphiTh",
                                    ParaThyphiAh = "ParaThyphiAh",
                                    ParaThyphiBh = "ParaThyphiBh",
                                    Typhoid = "Typhoid",
                                    IGM = "IGM",
                                    IGG = "IGG",
                                    HbsAg = "HbsAg",
                                    AsoTitre = "AsoTitre",
                                    PregnancyTest = "PregnancyTest",
                                    RaFactor = "RaFactor",
                                    AntiHcv = "AntiHcv",
                                    Mantoex = "Mantoex",
                                    KahnsVdrl = "KahnsVdrl",
                                    TbPlus = "TbPlus",
                                    Igm = "Igm",
                                    Igg = "Igg",
                                    HelicobacterPylori = "HelicobacterPylori",
                                    Hiv = "Hiv",
                                    Fee = 12345,
                                };
            var serology2 = new Serology
                                {
                                    Serialno = 12345,
                                    Patientid = 12345,
                                    Tdate = "Tdate",
                                    WidalTest = "WidalTest",
                                    STyphiTo = "STyphiTo",
                                    STyphiTh = "STyphiTh",
                                    ParaThyphiAh = "ParaThyphiAh",
                                    ParaThyphiBh = "ParaThyphiBh",
                                    Typhoid = "Typhoid",
                                    IGM = "IGM",
                                    IGG = "IGG",
                                    HbsAg = "HbsAg",
                                    AsoTitre = "AsoTitre",
                                    PregnancyTest = "PregnancyTest",
                                    RaFactor = "RaFactor",
                                    AntiHcv = "AntiHcv",
                                    Mantoex = "Mantoex",
                                    KahnsVdrl = "KahnsVdrl",
                                    TbPlus = "TbPlus",
                                    Igm = "Igm",
                                    Igg = "Igg",
                                    HelicobacterPylori = "HelicobacterPylori",
                                    Hiv = "Hiv",
                                    Fee = 12345,
                                };


            return new Patient
                       {
                           PatientID = 12345,
                           Name = "Name",
                           Age = "Age",
                           Sex = "Sex",
                           RefBy = "RefBy",
                    
                           // One to Many
                           Haematologies = new List<Haematology> {haematology1, haematology2},
                           // One to Many
                           ElisaTbs = new List<ElisaTb> {elisatb1, elisatb2},
                           // One to Many
                           ElisaHcvs = new List<ElisaHcv> {elisahcv1, elisahcv2},
                           // One to Many
                           ElisaHbsags = new List<ElisaHbsag> {elisahbsag1, elisahbsag2},
                           // One to Many
                           BloodGroups = new List<BloodGroup> {bloodgroup1, bloodgroup2},
                           // One to Many
                           Biochemistries = new List<Biochemistry> {biochemistry1, biochemistry2},
                           // One to Many
                           SemenAnalyses = new List<SemenAnalysis> {semenanalysis1, semenanalysis2},
                           // One to Many
                           UrineExaminations = new List<UrineExamination> {urineexamination1, urineexamination2},
                           // One to Many
                           Serologies = new List<Serology> {serology1, serology2},
                       };
        }

        public async Task<Patient> SavePatientAsync(Patient patient)
        {
            return null;
        }

        public async Task<List<Patient>> QueryAsync(string query)
        {
            return null;
        }

        public IDbConnection Custom
        {
            get { return null; }
        }
    }
}