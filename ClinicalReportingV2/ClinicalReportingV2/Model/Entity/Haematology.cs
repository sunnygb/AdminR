using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Alias("Haematology")]
    public partial class Haematology
    {
        
        public Haematology()
        {
        }
        

        [PrimaryKey]
        [Alias("SerialNo")]
        public System.Int64 SerialNo { get; set; }

        [Alias("PatientID")]
        public System.Int64 PatientID { get; set; }

        [Alias("TDate")]
        public System.DateTime TDate { get; set; }

        [Alias("HB")]
        public System.String Hb { get; set; }

        [Alias("HB_Unit")]
        public System.String HBUnit { get; set; }

        [Alias("HB_Nor")]
        public System.String HBNor { get; set; }

        [Alias("TLC")]
        public System.String Tlc { get; set; }

        [Alias("TLC_Unit")]
        public System.String TLCUnit { get; set; }

        [Alias("TLC_Nor")]
        public System.String TLCNor { get; set; }

        [Alias("ESR")]
        public System.String Esr { get; set; }

        [Alias("ESR_Unit")]
        public System.String ESRUnit { get; set; }

        [Alias("ESR_Nor")]
        public System.String ESRNor { get; set; }

        [Alias("BT")]
        public System.String Bt { get; set; }

        [Alias("BT_Unit")]
        public System.String BTUnit { get; set; }

        [Alias("BT_Nor")]
        public System.String BTNor { get; set; }

        [Alias("CT")]
        public System.String Ct { get; set; }

        [Alias("CT_Unit")]
        public System.String CTUnit { get; set; }

        [Alias("CT_Nor")]
        public System.String CTNor { get; set; }

        [Alias("Platelets_Count")]
        public System.String PlateletsCount { get; set; }

        [Alias("Platelets_Count_Unit")]
        public System.String PlateletsCountUnit { get; set; }

        [Alias("Platelets_Count_Nor")]
        public System.String PlateletsCountNor { get; set; }

        [Alias("PT")]
        public System.String Pt { get; set; }

        [Alias("PT_Unit")]
        public System.String PTUnit { get; set; }

        [Alias("PT_Nor")]
        public System.String PTNor { get; set; }

        [Alias("DLC")]
        public System.String Dlc { get; set; }

        [Alias("DLC_Unit")]
        public System.String DLCUnit { get; set; }

        [Alias("DLC_Nor")]
        public System.String DLCNor { get; set; }

        [Alias("Polymorphs")]
        public System.String Polymorphs { get; set; }

        [Alias("Polymorphs_Unit")]
        public System.String PolymorphsUnit { get; set; }

        [Alias("Polymorphs_Nor")]
        public System.String PolymorphsNor { get; set; }

        [Alias("Lymphocytes")]
        public System.String Lymphocytes { get; set; }

        [Alias("Lymphocytes_Unit")]
        public System.String LymphocytesUnit { get; set; }

        [Alias("Lymphocytes_Nor")]
        public System.String LymphocytesNor { get; set; }

        [Alias("Monocyte")]
        public System.String Monocyte { get; set; }

        [Alias("Monocyte_Unit")]
        public System.String MonocyteUnit { get; set; }

        [Alias("Monocyte_Nor")]
        public System.String MonocyteNor { get; set; }

        [Alias("Eosinophil")]
        public System.String Eosinophil { get; set; }

        [Alias("Eosinophil_Unit")]
        public System.String EosinophilUnit { get; set; }

        [Alias("Eosinophil_Nor")]
        public System.String EosinophilNor { get; set; }

        [Alias("Basophil")]
        public System.String Basophil { get; set; }

        [Alias("Basophil_Unit")]
        public System.String BasophilUnit { get; set; }

        [Alias("Basophil_Nor")]
        public System.String BasophilNor { get; set; }

        [Alias("Malaria_Parasites")]
        public System.String MalariaParasites { get; set; }

        [Alias("Malaria_Parasites_Unit")]
        public System.String MalariaParasitesUnit { get; set; }

        [Alias("Malaria_Parasites_Nor")]
        public System.String MalariaParasitesNor { get; set; }

        [Alias("Blood_Group")]
        public System.String BloodGroup { get; set; }

        [Alias("Blood_Group_Unit")]
        public System.String BloodGroupUnit { get; set; }

        [Alias("Blood_Group_Nor")]
        public System.String BloodGroupNor { get; set; }

        [Alias("RH_Factor")]
        public System.String RHFactor { get; set; }

        [Alias("RH_Factor_Unit")]
        public System.String RHFactorUnit { get; set; }

        [Alias("RH_Factor_Nor")]
        public System.String RHFactorNor { get; set; }

        [Alias("Total_R_B_C")]
        public System.String TotalRBC { get; set; }

        [Alias("Total_R_B_C_Unit")]
        public System.String TotalRBCUnit { get; set; }

        [Alias("Total_R_B_C_Nor")]
        public System.String TotalRBCNor { get; set; }

        [Alias("P_V_C_Haematorcrit")]
        public System.String PVCHaematorcrit { get; set; }

        [Alias("P_V_C_Haematorcrit_Unit")]
        public System.String PVCHaematorcritUnit { get; set; }

        [Alias("P_V_C_Haematorcrit_Nor")]
        public System.String PVCHaematorcritNor { get; set; }

        [Alias("M_C_V")]
        public System.String MCV { get; set; }

        [Alias("M_C_V_Unit")]
        public System.String MCVUnit { get; set; }

        [Alias("M_C_V_Nor")]
        public System.String MCVNor { get; set; }

        [Alias("M_C_H")]
        public System.String MCH { get; set; }

        [Alias("M_C_H_Unit")]
        public System.String MCHUnit { get; set; }

        [Alias("M_C_H_Nor")]
        public System.String MCHNor { get; set; }

        [Alias("M_C_H_C")]
        public System.String MCHC { get; set; }

        [Alias("M_C_H_C_Unit")]
        public System.String MCHCUnit { get; set; }

        [Alias("M_C_H_C_Nor")]
        public System.String MCHCNor { get; set; }

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