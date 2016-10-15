using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Table("Biochemistry")]
    public partial class Biochemistry
    {
        
        public Biochemistry()
        {
        }
        

        [Key]
        [Column("SerialNo")]
        public System.Int64 SerialNo { get; set; }

        [Column("PatientID")]
        public System.Int64 PatientID { get; set; }

        [Column("TDate")]
        public System.DateTime TDate { get; set; }

        [Column("Blood_Sugar_Fasting")]
        public System.String BloodSugarFasting { get; set; }

        [Column("Blood_Sugar_Fasting_Unit")]
        public System.String BloodSugarFastingUnit { get; set; }

        [Column("Blood_Sugar_Fasting_Nor")]
        public System.String BloodSugarFastingNor { get; set; }

        [Column("Blood_Sugar_2HPP")]
        public System.String BloodSugar2HPP { get; set; }

        [Column("Blood_Sugar_2HPP_Unit")]
        public System.String BloodSugar2HPPUnit { get; set; }

        [Column("Blood_Sugar_2HPP_Nor")]
        public System.String BloodSugar2HPPNor { get; set; }

        [Column("Blood_Sugar_Random")]
        public System.String BloodSugarRandom { get; set; }

        [Column("Blood_Sugar_Random_Unit")]
        public System.String BloodSugarRandomUnit { get; set; }

        [Column("Blood_Sugar_Random_Nor")]
        public System.String BloodSugarRandomNor { get; set; }

        [Column("Blood_Urea")]
        public System.String BloodUrea { get; set; }

        [Column("Blood_Urea_Unit")]
        public System.String BloodUreaUnit { get; set; }

        [Column("Blood_Urea_Nor")]
        public System.String BloodUreaNor { get; set; }

        [Column("BUN")]
        public System.String Bun { get; set; }

        [Column("BUN_Unit")]
        public System.String BUNUnit { get; set; }

        [Column("BUN_Nor")]
        public System.String BUNNor { get; set; }

        [Column("S_Creatinine")]
        public System.String SCreatinine { get; set; }

        [Column("S_Creatinine_Unit")]
        public System.String SCreatinineUnit { get; set; }

        [Column("S_Creatinine_Nor")]
        public System.String SCreatinineNor { get; set; }

        [Column("S_Uric_Acid")]
        public System.String SUricAcid { get; set; }

        [Column("S_Uric_Acid_Unit")]
        public System.String SUricAcidUnit { get; set; }

        [Column("S_Uric_Acid_Nor")]
        public System.String SUricAcidNor { get; set; }

        [Column("S_Cholestrol")]
        public System.String SCholestrol { get; set; }

        [Column("S_Cholestrol_Unit")]
        public System.String SCholestrolUnit { get; set; }

        [Column("S_Cholestrol_Nor")]
        public System.String SCholestrolNor { get; set; }

        [Column("S_Triglycerides")]
        public System.String STriglycerides { get; set; }

        [Column("S_Triglycerides_Unit")]
        public System.String STriglyceridesUnit { get; set; }

        [Column("S_Triglycerides_Nor")]
        public System.String STriglyceridesNor { get; set; }

        [Column("HDL_Cholestrol")]
        public System.String HDLCholestrol { get; set; }

        [Column("HDL_Cholestrol_Unit")]
        public System.String HDLCholestrolUnit { get; set; }

        [Column("HDL_Cholestrol_Nor")]
        public System.String HDLCholestrolNor { get; set; }

        [Column("LDL_Cholestrol")]
        public System.String LDLCholestrol { get; set; }

        [Column("LDL_Cholestrol_Unit")]
        public System.String LDLCholestrolUnit { get; set; }

        [Column("LDL_Cholestrol_Nor")]
        public System.String LDLCholestrolNor { get; set; }

        [Column("SGOT_AST")]
        public System.String SgotAst { get; set; }

        [Column("SGOT_AST_Unit")]
        public System.String SGOTASTUnit { get; set; }

        [Column("SGOT_Nor")]
        public System.String SGOTNor { get; set; }

        [Column("LDH")]
        public System.String Ldh { get; set; }

        [Column("LDH_Unit")]
        public System.String LDHUnit { get; set; }

        [Column("LDH_Nor")]
        public System.String LDHNor { get; set; }

        [Column("CPK")]
        public System.String Cpk { get; set; }

        [Column("CPK_Unit")]
        public System.String CPKUnit { get; set; }

        [Column("CPK_Nor")]
        public System.String CPKNor { get; set; }

        [Column("CKMB")]
        public System.String Ckmb { get; set; }

        [Column("CKMB_Unit")]
        public System.String CKMBUnit { get; set; }

        [Column("CKMB_Nor")]
        public System.String CKMBNor { get; set; }

        [Column("S_Bilirubin_T")]
        public System.String SBilirubinT { get; set; }

        [Column("S_Bilirubin_T_Unit")]
        public System.String SBilirubinTUnit { get; set; }

        [Column("S_Bilirubin_T_Nor")]
        public System.String SBilirubinTNor { get; set; }

        [Column("S_Bilirubin_D")]
        public System.String SBilirubinD { get; set; }

        [Column("S_Bilirubin_D_Unit")]
        public System.String SBilirubinDUnit { get; set; }

        [Column("S_Bilirubin_D_Nor")]
        public System.String SBilirubinDNor { get; set; }

        [Column("S_Bilirubin_Ind")]
        public System.String SBilirubinInd { get; set; }

        [Column("S_Bilirubin_Ind_Unit")]
        public System.String SBilirubinIndUnit { get; set; }

        [Column("S_Bilirubin_Ind_Nor")]
        public System.String SBilirubinIndNor { get; set; }

        [Column("S_Alk_Phosphatase")]
        public System.String SAlkPhosphatase { get; set; }

        [Column("S_Alk_Phosphatase_Unit")]
        public System.String SAlkPhosphataseUnit { get; set; }

        [Column("S_Alk_Phosphatase_Nor")]
        public System.String SAlkPhosphataseNor { get; set; }

        [Column("SGPT_ALT")]
        public System.String SgptAlt { get; set; }

        [Column("SGPT_ALT_Unit")]
        public System.String SGPTALTUnit { get; set; }

        [Column("SGPT_ALT_Nor")]
        public System.String SGPTALTNor { get; set; }

        [Column("S_Sodium")]
        public System.String SSodium { get; set; }

        [Column("S_Sodium_Unit")]
        public System.String SSodiumUnit { get; set; }

        [Column("S_Sodium_Nor")]
        public System.String SSodiumNor { get; set; }

        [Column("S_Potassium")]
        public System.String SPotassium { get; set; }

        [Column("S_Potassium_Unit")]
        public System.String SPotassiumUnit { get; set; }

        [Column("S_Potassium_Nor")]
        public System.String SPotassiumNor { get; set; }

        [Column("S_Chloride")]
        public System.String SChloride { get; set; }

        [Column("S_Chloride_Unit")]
        public System.String SChlorideUnit { get; set; }

        [Column("S_Chloride_Nor")]
        public System.String SChlorideNor { get; set; }

        [Column("S_Calcium")]
        public System.String SCalcium { get; set; }

        [Column("S_Calcium_Unit")]
        public System.String SCalciumUnit { get; set; }

        [Column("S_Calcium_Nor")]
        public System.String SCalciumNor { get; set; }

        [Column("S_Protein")]
        public System.String SProtein { get; set; }

        [Column("S_Protein_Unit")]
        public System.String SProteinUnit { get; set; }

        [Column("S_Protein_Nor")]
        public System.String SProteinNor { get; set; }

        [Column("S_Albumin")]
        public System.String SAlbumin { get; set; }

        [Column("S_Albumin_Unit")]
        public System.String SAlbuminUnit { get; set; }

        [Column("S_Albumin_Nor")]
        public System.String SAlbuminNor { get; set; }

        [Column("AG_Ratio")]
        public System.String AGRatio { get; set; }

        [Column("AG_Ratio_Unit")]
        public System.String AGRatioUnit { get; set; }

        [Column("AG_Ratio_Nor")]
        public System.String AGRatioNor { get; set; }

        [Column("Fee")]
        public System.Int32 Fee { get; set; }

        [NotMapped]
        public virtual Patient Patient { get; set; }
         [NotMapped]
         public bool IsNew
         {
                get
                {
         
                  return this.SerialNo == default(int);
         
                }
                
          }
          [NotMapped]
          public bool IsDeleted { get; set; }
    }
}