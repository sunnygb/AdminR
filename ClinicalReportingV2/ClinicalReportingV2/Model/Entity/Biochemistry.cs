using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Data.Wrapper;
namespace ClinicalReporting.Data
{


    [Alias("Biochemistry")]
    public partial class Biochemistry
    {
        
        public Biochemistry()
        {
        }
        
        public Biochemistry(BiochemistryW biochemistryw)
        {
           this.SerialNo = biochemistryw.SerialNo;
           this.PatientID = biochemistryw.PatientID;
           this.TDate = biochemistryw.TDate;
           this.BloodSugarFasting = biochemistryw.BloodSugarFasting;
           this.BloodSugarFastingUnit = biochemistryw.BloodSugarFastingUnit;
           this.BloodSugarFastingNor = biochemistryw.BloodSugarFastingNor;
           this.BloodSugar2HPP = biochemistryw.BloodSugar2HPP;
           this.BloodSugar2HPPUnit = biochemistryw.BloodSugar2HPPUnit;
           this.BloodSugar2HPPNor = biochemistryw.BloodSugar2HPPNor;
           this.BloodSugarRandom = biochemistryw.BloodSugarRandom;
           this.BloodSugarRandomUnit = biochemistryw.BloodSugarRandomUnit;
           this.BloodSugarRandomNor = biochemistryw.BloodSugarRandomNor;
           this.BloodUrea = biochemistryw.BloodUrea;
           this.BloodUreaUnit = biochemistryw.BloodUreaUnit;
           this.BloodUreaNor = biochemistryw.BloodUreaNor;
           this.Bun = biochemistryw.Bun;
           this.BUNUnit = biochemistryw.BUNUnit;
           this.BUNNor = biochemistryw.BUNNor;
           this.SCreatinine = biochemistryw.SCreatinine;
           this.SCreatinineUnit = biochemistryw.SCreatinineUnit;
           this.SCreatinineNor = biochemistryw.SCreatinineNor;
           this.SUricAcid = biochemistryw.SUricAcid;
           this.SUricAcidUnit = biochemistryw.SUricAcidUnit;
           this.SUricAcidNor = biochemistryw.SUricAcidNor;
           this.SCholestrol = biochemistryw.SCholestrol;
           this.SCholestrolUnit = biochemistryw.SCholestrolUnit;
           this.SCholestrolNor = biochemistryw.SCholestrolNor;
           this.STriglycerides = biochemistryw.STriglycerides;
           this.STriglyceridesUnit = biochemistryw.STriglyceridesUnit;
           this.STriglyceridesNor = biochemistryw.STriglyceridesNor;
           this.HDLCholestrol = biochemistryw.HDLCholestrol;
           this.HDLCholestrolUnit = biochemistryw.HDLCholestrolUnit;
           this.HDLCholestrolNor = biochemistryw.HDLCholestrolNor;
           this.LDLCholestrol = biochemistryw.LDLCholestrol;
           this.LDLCholestrolUnit = biochemistryw.LDLCholestrolUnit;
           this.LDLCholestrolNor = biochemistryw.LDLCholestrolNor;
           this.SgotAst = biochemistryw.SgotAst;
           this.SGOTASTUnit = biochemistryw.SGOTASTUnit;
           this.SGOTNor = biochemistryw.SGOTNor;
           this.Ldh = biochemistryw.Ldh;
           this.LDHUnit = biochemistryw.LDHUnit;
           this.LDHNor = biochemistryw.LDHNor;
           this.Cpk = biochemistryw.Cpk;
           this.CPKUnit = biochemistryw.CPKUnit;
           this.CPKNor = biochemistryw.CPKNor;
           this.Ckmb = biochemistryw.Ckmb;
           this.CKMBUnit = biochemistryw.CKMBUnit;
           this.CKMBNor = biochemistryw.CKMBNor;
           this.SBilirubinT = biochemistryw.SBilirubinT;
           this.SBilirubinTUnit = biochemistryw.SBilirubinTUnit;
           this.SBilirubinTNor = biochemistryw.SBilirubinTNor;
           this.SBilirubinD = biochemistryw.SBilirubinD;
           this.SBilirubinDUnit = biochemistryw.SBilirubinDUnit;
           this.SBilirubinDNor = biochemistryw.SBilirubinDNor;
           this.SBilirubinInd = biochemistryw.SBilirubinInd;
           this.SBilirubinIndUnit = biochemistryw.SBilirubinIndUnit;
           this.SBilirubinIndNor = biochemistryw.SBilirubinIndNor;
           this.SAlkPhosphatase = biochemistryw.SAlkPhosphatase;
           this.SAlkPhosphataseUnit = biochemistryw.SAlkPhosphataseUnit;
           this.SAlkPhosphataseNor = biochemistryw.SAlkPhosphataseNor;
           this.SgptAlt = biochemistryw.SgptAlt;
           this.SGPTALTUnit = biochemistryw.SGPTALTUnit;
           this.SGPTALTNor = biochemistryw.SGPTALTNor;
           this.SSodium = biochemistryw.SSodium;
           this.SSodiumUnit = biochemistryw.SSodiumUnit;
           this.SSodiumNor = biochemistryw.SSodiumNor;
           this.SPotassium = biochemistryw.SPotassium;
           this.SPotassiumUnit = biochemistryw.SPotassiumUnit;
           this.SPotassiumNor = biochemistryw.SPotassiumNor;
           this.SChloride = biochemistryw.SChloride;
           this.SChlorideUnit = biochemistryw.SChlorideUnit;
           this.SChlorideNor = biochemistryw.SChlorideNor;
           this.SCalcium = biochemistryw.SCalcium;
           this.SCalciumUnit = biochemistryw.SCalciumUnit;
           this.SCalciumNor = biochemistryw.SCalciumNor;
           this.SProtein = biochemistryw.SProtein;
           this.SProteinUnit = biochemistryw.SProteinUnit;
           this.SProteinNor = biochemistryw.SProteinNor;
           this.SAlbumin = biochemistryw.SAlbumin;
           this.SAlbuminUnit = biochemistryw.SAlbuminUnit;
           this.SAlbuminNor = biochemistryw.SAlbuminNor;
           this.AGRatio = biochemistryw.AGRatio;
           this.AGRatioUnit = biochemistryw.AGRatioUnit;
           this.AGRatioNor = biochemistryw.AGRatioNor;
           this.Fee = biochemistryw.Fee;
           
           
        }

        [PrimaryKey]
        [Alias("SerialNo")]
        public System.Int64 SerialNo { get; set; }

        [Alias("PatientID")]
        public System.Int64 PatientID { get; set; }

        [Alias("TDate")]
        public System.DateTime TDate { get; set; }

        [Alias("Blood_Sugar_Fasting")]
        public System.String BloodSugarFasting { get; set; }

        [Alias("Blood_Sugar_Fasting_Unit")]
        public System.String BloodSugarFastingUnit { get; set; }

        [Alias("Blood_Sugar_Fasting_Nor")]
        public System.String BloodSugarFastingNor { get; set; }

        [Alias("Blood_Sugar_2HPP")]
        public System.String BloodSugar2HPP { get; set; }

        [Alias("Blood_Sugar_2HPP_Unit")]
        public System.String BloodSugar2HPPUnit { get; set; }

        [Alias("Blood_Sugar_2HPP_Nor")]
        public System.String BloodSugar2HPPNor { get; set; }

        [Alias("Blood_Sugar_Random")]
        public System.String BloodSugarRandom { get; set; }

        [Alias("Blood_Sugar_Random_Unit")]
        public System.String BloodSugarRandomUnit { get; set; }

        [Alias("Blood_Sugar_Random_Nor")]
        public System.String BloodSugarRandomNor { get; set; }

        [Alias("Blood_Urea")]
        public System.String BloodUrea { get; set; }

        [Alias("Blood_Urea_Unit")]
        public System.String BloodUreaUnit { get; set; }

        [Alias("Blood_Urea_Nor")]
        public System.String BloodUreaNor { get; set; }

        [Alias("BUN")]
        public System.String Bun { get; set; }

        [Alias("BUN_Unit")]
        public System.String BUNUnit { get; set; }

        [Alias("BUN_Nor")]
        public System.String BUNNor { get; set; }

        [Alias("S_Creatinine")]
        public System.String SCreatinine { get; set; }

        [Alias("S_Creatinine_Unit")]
        public System.String SCreatinineUnit { get; set; }

        [Alias("S_Creatinine_Nor")]
        public System.String SCreatinineNor { get; set; }

        [Alias("S_Uric_Acid")]
        public System.String SUricAcid { get; set; }

        [Alias("S_Uric_Acid_Unit")]
        public System.String SUricAcidUnit { get; set; }

        [Alias("S_Uric_Acid_Nor")]
        public System.String SUricAcidNor { get; set; }

        [Alias("S_Cholestrol")]
        public System.String SCholestrol { get; set; }

        [Alias("S_Cholestrol_Unit")]
        public System.String SCholestrolUnit { get; set; }

        [Alias("S_Cholestrol_Nor")]
        public System.String SCholestrolNor { get; set; }

        [Alias("S_Triglycerides")]
        public System.String STriglycerides { get; set; }

        [Alias("S_Triglycerides_Unit")]
        public System.String STriglyceridesUnit { get; set; }

        [Alias("S_Triglycerides_Nor")]
        public System.String STriglyceridesNor { get; set; }

        [Alias("HDL_Cholestrol")]
        public System.String HDLCholestrol { get; set; }

        [Alias("HDL_Cholestrol_Unit")]
        public System.String HDLCholestrolUnit { get; set; }

        [Alias("HDL_Cholestrol_Nor")]
        public System.String HDLCholestrolNor { get; set; }

        [Alias("LDL_Cholestrol")]
        public System.String LDLCholestrol { get; set; }

        [Alias("LDL_Cholestrol_Unit")]
        public System.String LDLCholestrolUnit { get; set; }

        [Alias("LDL_Cholestrol_Nor")]
        public System.String LDLCholestrolNor { get; set; }

        [Alias("SGOT_AST")]
        public System.String SgotAst { get; set; }

        [Alias("SGOT_AST_Unit")]
        public System.String SGOTASTUnit { get; set; }

        [Alias("SGOT_Nor")]
        public System.String SGOTNor { get; set; }

        [Alias("LDH")]
        public System.String Ldh { get; set; }

        [Alias("LDH_Unit")]
        public System.String LDHUnit { get; set; }

        [Alias("LDH_Nor")]
        public System.String LDHNor { get; set; }

        [Alias("CPK")]
        public System.String Cpk { get; set; }

        [Alias("CPK_Unit")]
        public System.String CPKUnit { get; set; }

        [Alias("CPK_Nor")]
        public System.String CPKNor { get; set; }

        [Alias("CKMB")]
        public System.String Ckmb { get; set; }

        [Alias("CKMB_Unit")]
        public System.String CKMBUnit { get; set; }

        [Alias("CKMB_Nor")]
        public System.String CKMBNor { get; set; }

        [Alias("S_Bilirubin_T")]
        public System.String SBilirubinT { get; set; }

        [Alias("S_Bilirubin_T_Unit")]
        public System.String SBilirubinTUnit { get; set; }

        [Alias("S_Bilirubin_T_Nor")]
        public System.String SBilirubinTNor { get; set; }

        [Alias("S_Bilirubin_D")]
        public System.String SBilirubinD { get; set; }

        [Alias("S_Bilirubin_D_Unit")]
        public System.String SBilirubinDUnit { get; set; }

        [Alias("S_Bilirubin_D_Nor")]
        public System.String SBilirubinDNor { get; set; }

        [Alias("S_Bilirubin_Ind")]
        public System.String SBilirubinInd { get; set; }

        [Alias("S_Bilirubin_Ind_Unit")]
        public System.String SBilirubinIndUnit { get; set; }

        [Alias("S_Bilirubin_Ind_Nor")]
        public System.String SBilirubinIndNor { get; set; }

        [Alias("S_Alk_Phosphatase")]
        public System.String SAlkPhosphatase { get; set; }

        [Alias("S_Alk_Phosphatase_Unit")]
        public System.String SAlkPhosphataseUnit { get; set; }

        [Alias("S_Alk_Phosphatase_Nor")]
        public System.String SAlkPhosphataseNor { get; set; }

        [Alias("SGPT_ALT")]
        public System.String SgptAlt { get; set; }

        [Alias("SGPT_ALT_Unit")]
        public System.String SGPTALTUnit { get; set; }

        [Alias("SGPT_ALT_Nor")]
        public System.String SGPTALTNor { get; set; }

        [Alias("S_Sodium")]
        public System.String SSodium { get; set; }

        [Alias("S_Sodium_Unit")]
        public System.String SSodiumUnit { get; set; }

        [Alias("S_Sodium_Nor")]
        public System.String SSodiumNor { get; set; }

        [Alias("S_Potassium")]
        public System.String SPotassium { get; set; }

        [Alias("S_Potassium_Unit")]
        public System.String SPotassiumUnit { get; set; }

        [Alias("S_Potassium_Nor")]
        public System.String SPotassiumNor { get; set; }

        [Alias("S_Chloride")]
        public System.String SChloride { get; set; }

        [Alias("S_Chloride_Unit")]
        public System.String SChlorideUnit { get; set; }

        [Alias("S_Chloride_Nor")]
        public System.String SChlorideNor { get; set; }

        [Alias("S_Calcium")]
        public System.String SCalcium { get; set; }

        [Alias("S_Calcium_Unit")]
        public System.String SCalciumUnit { get; set; }

        [Alias("S_Calcium_Nor")]
        public System.String SCalciumNor { get; set; }

        [Alias("S_Protein")]
        public System.String SProtein { get; set; }

        [Alias("S_Protein_Unit")]
        public System.String SProteinUnit { get; set; }

        [Alias("S_Protein_Nor")]
        public System.String SProteinNor { get; set; }

        [Alias("S_Albumin")]
        public System.String SAlbumin { get; set; }

        [Alias("S_Albumin_Unit")]
        public System.String SAlbuminUnit { get; set; }

        [Alias("S_Albumin_Nor")]
        public System.String SAlbuminNor { get; set; }

        [Alias("AG_Ratio")]
        public System.String AGRatio { get; set; }

        [Alias("AG_Ratio_Unit")]
        public System.String AGRatioUnit { get; set; }

        [Alias("AG_Ratio_Nor")]
        public System.String AGRatioNor { get; set; }

        [Alias("Fee")]
        public System.Int32 Fee { get; set; }

        [Ignore]
        public virtual Patient Patient { get; set; }
         [Ignore]
         public bool IsNew
         {
                get
                {
         
                  return this.SerialNo == default(int);
         
                }
                
          }
          [Ignore]
          public bool IsDeleted { get; set; }
    }
}