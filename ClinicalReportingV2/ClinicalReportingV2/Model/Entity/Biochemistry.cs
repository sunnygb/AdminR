using ClinicalReporting.Data.Wrapper;
using ServiceStack.DataAnnotations;
using System;

namespace ClinicalReporting.Data
{
    [Alias("Biochemistry")]
    public class Biochemistry
    {
        public Biochemistry()
        {
        }

        public Biochemistry(BiochemistryW biochemistryw)
        {
            SerialNo = biochemistryw.SerialNo;
            PatientID = biochemistryw.PatientID;
            TDate = biochemistryw.TDate;
            BloodSugarFasting = biochemistryw.BloodSugarFasting;
            BloodSugarFastingUnit = biochemistryw.BloodSugarFastingUnit;
            BloodSugarFastingNor = biochemistryw.BloodSugarFastingNor;
            BloodSugar2HPP = biochemistryw.BloodSugar2HPP;
            BloodSugar2HPPUnit = biochemistryw.BloodSugar2HPPUnit;
            BloodSugar2HPPNor = biochemistryw.BloodSugar2HPPNor;
            BloodSugarRandom = biochemistryw.BloodSugarRandom;
            BloodSugarRandomUnit = biochemistryw.BloodSugarRandomUnit;
            BloodSugarRandomNor = biochemistryw.BloodSugarRandomNor;
            BloodUrea = biochemistryw.BloodUrea;
            BloodUreaUnit = biochemistryw.BloodUreaUnit;
            BloodUreaNor = biochemistryw.BloodUreaNor;
            Bun = biochemistryw.Bun;
            BUNUnit = biochemistryw.BUNUnit;
            BUNNor = biochemistryw.BUNNor;
            SCreatinine = biochemistryw.SCreatinine;
            SCreatinineUnit = biochemistryw.SCreatinineUnit;
            SCreatinineNor = biochemistryw.SCreatinineNor;
            SUricAcid = biochemistryw.SUricAcid;
            SUricAcidUnit = biochemistryw.SUricAcidUnit;
            SUricAcidNor = biochemistryw.SUricAcidNor;
            SCholestrol = biochemistryw.SCholestrol;
            SCholestrolUnit = biochemistryw.SCholestrolUnit;
            SCholestrolNor = biochemistryw.SCholestrolNor;
            STriglycerides = biochemistryw.STriglycerides;
            STriglyceridesUnit = biochemistryw.STriglyceridesUnit;
            STriglyceridesNor = biochemistryw.STriglyceridesNor;
            HDLCholestrol = biochemistryw.HDLCholestrol;
            HDLCholestrolUnit = biochemistryw.HDLCholestrolUnit;
            HDLCholestrolNor = biochemistryw.HDLCholestrolNor;
            LDLCholestrol = biochemistryw.LDLCholestrol;
            LDLCholestrolUnit = biochemistryw.LDLCholestrolUnit;
            LDLCholestrolNor = biochemistryw.LDLCholestrolNor;
            SgotAst = biochemistryw.SgotAst;
            SGOTASTUnit = biochemistryw.SGOTASTUnit;
            SGOTNor = biochemistryw.SGOTNor;
            Ldh = biochemistryw.Ldh;
            LDHUnit = biochemistryw.LDHUnit;
            LDHNor = biochemistryw.LDHNor;
            Cpk = biochemistryw.Cpk;
            CPKUnit = biochemistryw.CPKUnit;
            CPKNor = biochemistryw.CPKNor;
            Ckmb = biochemistryw.Ckmb;
            CKMBUnit = biochemistryw.CKMBUnit;
            CKMBNor = biochemistryw.CKMBNor;
            SBilirubinT = biochemistryw.SBilirubinT;
            SBilirubinTUnit = biochemistryw.SBilirubinTUnit;
            SBilirubinTNor = biochemistryw.SBilirubinTNor;
            SBilirubinD = biochemistryw.SBilirubinD;
            SBilirubinDUnit = biochemistryw.SBilirubinDUnit;
            SBilirubinDNor = biochemistryw.SBilirubinDNor;
            SBilirubinInd = biochemistryw.SBilirubinInd;
            SBilirubinIndUnit = biochemistryw.SBilirubinIndUnit;
            SBilirubinIndNor = biochemistryw.SBilirubinIndNor;
            SAlkPhosphatase = biochemistryw.SAlkPhosphatase;
            SAlkPhosphataseUnit = biochemistryw.SAlkPhosphataseUnit;
            SAlkPhosphataseNor = biochemistryw.SAlkPhosphataseNor;
            SgptAlt = biochemistryw.SgptAlt;
            SGPTALTUnit = biochemistryw.SGPTALTUnit;
            SGPTALTNor = biochemistryw.SGPTALTNor;
            SSodium = biochemistryw.SSodium;
            SSodiumUnit = biochemistryw.SSodiumUnit;
            SSodiumNor = biochemistryw.SSodiumNor;
            SPotassium = biochemistryw.SPotassium;
            SPotassiumUnit = biochemistryw.SPotassiumUnit;
            SPotassiumNor = biochemistryw.SPotassiumNor;
            SChloride = biochemistryw.SChloride;
            SChlorideUnit = biochemistryw.SChlorideUnit;
            SChlorideNor = biochemistryw.SChlorideNor;
            SCalcium = biochemistryw.SCalcium;
            SCalciumUnit = biochemistryw.SCalciumUnit;
            SCalciumNor = biochemistryw.SCalciumNor;
            SProtein = biochemistryw.SProtein;
            SProteinUnit = biochemistryw.SProteinUnit;
            SProteinNor = biochemistryw.SProteinNor;
            SAlbumin = biochemistryw.SAlbumin;
            SAlbuminUnit = biochemistryw.SAlbuminUnit;
            SAlbuminNor = biochemistryw.SAlbuminNor;
            AGRatio = biochemistryw.AGRatio;
            AGRatioUnit = biochemistryw.AGRatioUnit;
            AGRatioNor = biochemistryw.AGRatioNor;
            Fee = biochemistryw.Fee;
        }

        [PrimaryKey]
        [Alias("SerialNo")]
        public Int64 SerialNo { get; set; }

        [Alias("PatientID")]
        public Int64 PatientID { get; set; }

        [Alias("TDate")]
        public DateTime TDate { get; set; }

        [Alias("Blood_Sugar_Fasting")]
        public String BloodSugarFasting { get; set; }

        [Alias("Blood_Sugar_Fasting_Unit")]
        public String BloodSugarFastingUnit { get; set; }

        [Alias("Blood_Sugar_Fasting_Nor")]
        public String BloodSugarFastingNor { get; set; }

        [Alias("Blood_Sugar_2HPP")]
        public String BloodSugar2HPP { get; set; }

        [Alias("Blood_Sugar_2HPP_Unit")]
        public String BloodSugar2HPPUnit { get; set; }

        [Alias("Blood_Sugar_2HPP_Nor")]
        public String BloodSugar2HPPNor { get; set; }

        [Alias("Blood_Sugar_Random")]
        public String BloodSugarRandom { get; set; }

        [Alias("Blood_Sugar_Random_Unit")]
        public String BloodSugarRandomUnit { get; set; }

        [Alias("Blood_Sugar_Random_Nor")]
        public String BloodSugarRandomNor { get; set; }

        [Alias("Blood_Urea")]
        public String BloodUrea { get; set; }

        [Alias("Blood_Urea_Unit")]
        public String BloodUreaUnit { get; set; }

        [Alias("Blood_Urea_Nor")]
        public String BloodUreaNor { get; set; }

        [Alias("BUN")]
        public String Bun { get; set; }

        [Alias("BUN_Unit")]
        public String BUNUnit { get; set; }

        [Alias("BUN_Nor")]
        public String BUNNor { get; set; }

        [Alias("S_Creatinine")]
        public String SCreatinine { get; set; }

        [Alias("S_Creatinine_Unit")]
        public String SCreatinineUnit { get; set; }

        [Alias("S_Creatinine_Nor")]
        public String SCreatinineNor { get; set; }

        [Alias("S_Uric_Acid")]
        public String SUricAcid { get; set; }

        [Alias("S_Uric_Acid_Unit")]
        public String SUricAcidUnit { get; set; }

        [Alias("S_Uric_Acid_Nor")]
        public String SUricAcidNor { get; set; }

        [Alias("S_Cholestrol")]
        public String SCholestrol { get; set; }

        [Alias("S_Cholestrol_Unit")]
        public String SCholestrolUnit { get; set; }

        [Alias("S_Cholestrol_Nor")]
        public String SCholestrolNor { get; set; }

        [Alias("S_Triglycerides")]
        public String STriglycerides { get; set; }

        [Alias("S_Triglycerides_Unit")]
        public String STriglyceridesUnit { get; set; }

        [Alias("S_Triglycerides_Nor")]
        public String STriglyceridesNor { get; set; }

        [Alias("HDL_Cholestrol")]
        public String HDLCholestrol { get; set; }

        [Alias("HDL_Cholestrol_Unit")]
        public String HDLCholestrolUnit { get; set; }

        [Alias("HDL_Cholestrol_Nor")]
        public String HDLCholestrolNor { get; set; }

        [Alias("LDL_Cholestrol")]
        public String LDLCholestrol { get; set; }

        [Alias("LDL_Cholestrol_Unit")]
        public String LDLCholestrolUnit { get; set; }

        [Alias("LDL_Cholestrol_Nor")]
        public String LDLCholestrolNor { get; set; }

        [Alias("SGOT_AST")]
        public String SgotAst { get; set; }

        [Alias("SGOT_AST_Unit")]
        public String SGOTASTUnit { get; set; }

        [Alias("SGOT_Nor")]
        public String SGOTNor { get; set; }

        [Alias("LDH")]
        public String Ldh { get; set; }

        [Alias("LDH_Unit")]
        public String LDHUnit { get; set; }

        [Alias("LDH_Nor")]
        public String LDHNor { get; set; }

        [Alias("CPK")]
        public String Cpk { get; set; }

        [Alias("CPK_Unit")]
        public String CPKUnit { get; set; }

        [Alias("CPK_Nor")]
        public String CPKNor { get; set; }

        [Alias("CKMB")]
        public String Ckmb { get; set; }

        [Alias("CKMB_Unit")]
        public String CKMBUnit { get; set; }

        [Alias("CKMB_Nor")]
        public String CKMBNor { get; set; }

        [Alias("S_Bilirubin_T")]
        public String SBilirubinT { get; set; }

        [Alias("S_Bilirubin_T_Unit")]
        public String SBilirubinTUnit { get; set; }

        [Alias("S_Bilirubin_T_Nor")]
        public String SBilirubinTNor { get; set; }

        [Alias("S_Bilirubin_D")]
        public String SBilirubinD { get; set; }

        [Alias("S_Bilirubin_D_Unit")]
        public String SBilirubinDUnit { get; set; }

        [Alias("S_Bilirubin_D_Nor")]
        public String SBilirubinDNor { get; set; }

        [Alias("S_Bilirubin_Ind")]
        public String SBilirubinInd { get; set; }

        [Alias("S_Bilirubin_Ind_Unit")]
        public String SBilirubinIndUnit { get; set; }

        [Alias("S_Bilirubin_Ind_Nor")]
        public String SBilirubinIndNor { get; set; }

        [Alias("S_Alk_Phosphatase")]
        public String SAlkPhosphatase { get; set; }

        [Alias("S_Alk_Phosphatase_Unit")]
        public String SAlkPhosphataseUnit { get; set; }

        [Alias("S_Alk_Phosphatase_Nor")]
        public String SAlkPhosphataseNor { get; set; }

        [Alias("SGPT_ALT")]
        public String SgptAlt { get; set; }

        [Alias("SGPT_ALT_Unit")]
        public String SGPTALTUnit { get; set; }

        [Alias("SGPT_ALT_Nor")]
        public String SGPTALTNor { get; set; }

        [Alias("S_Sodium")]
        public String SSodium { get; set; }

        [Alias("S_Sodium_Unit")]
        public String SSodiumUnit { get; set; }

        [Alias("S_Sodium_Nor")]
        public String SSodiumNor { get; set; }

        [Alias("S_Potassium")]
        public String SPotassium { get; set; }

        [Alias("S_Potassium_Unit")]
        public String SPotassiumUnit { get; set; }

        [Alias("S_Potassium_Nor")]
        public String SPotassiumNor { get; set; }

        [Alias("S_Chloride")]
        public String SChloride { get; set; }

        [Alias("S_Chloride_Unit")]
        public String SChlorideUnit { get; set; }

        [Alias("S_Chloride_Nor")]
        public String SChlorideNor { get; set; }

        [Alias("S_Calcium")]
        public String SCalcium { get; set; }

        [Alias("S_Calcium_Unit")]
        public String SCalciumUnit { get; set; }

        [Alias("S_Calcium_Nor")]
        public String SCalciumNor { get; set; }

        [Alias("S_Protein")]
        public String SProtein { get; set; }

        [Alias("S_Protein_Unit")]
        public String SProteinUnit { get; set; }

        [Alias("S_Protein_Nor")]
        public String SProteinNor { get; set; }

        [Alias("S_Albumin")]
        public String SAlbumin { get; set; }

        [Alias("S_Albumin_Unit")]
        public String SAlbuminUnit { get; set; }

        [Alias("S_Albumin_Nor")]
        public String SAlbuminNor { get; set; }

        [Alias("AG_Ratio")]
        public String AGRatio { get; set; }

        [Alias("AG_Ratio_Unit")]
        public String AGRatioUnit { get; set; }

        [Alias("AG_Ratio_Nor")]
        public String AGRatioNor { get; set; }

        [Alias("Fee")]
        public Int32 Fee { get; set; }

        [Ignore]
        public virtual Patient Patient { get; set; }

        [Ignore]
        public bool IsNew
        {
            get { return SerialNo == default(int); }
        }

        [Ignore]
        public bool IsDeleted { get; set; }
    }
}