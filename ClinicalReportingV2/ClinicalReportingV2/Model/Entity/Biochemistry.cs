using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Alias("Biochemistry")]
    public partial class Biochemistry
    {
        
        public Biochemistry()
        {
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