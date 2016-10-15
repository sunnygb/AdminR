using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Table("Haematology")]
    public partial class Haematology
    {
        
        public Haematology()
        {
        }
        

        [Key]
        [Column("SerialNo")]
        public System.Int64 SerialNo { get; set; }

        [Column("PatientID")]
        public System.Int64 PatientID { get; set; }

        [Column("TDate")]
        public System.DateTime TDate { get; set; }

        [Column("HB")]
        public System.String Hb { get; set; }

        [Column("HB_Unit")]
        public System.String HBUnit { get; set; }

        [Column("HB_Nor")]
        public System.String HBNor { get; set; }

        [Column("TLC")]
        public System.String Tlc { get; set; }

        [Column("TLC_Unit")]
        public System.String TLCUnit { get; set; }

        [Column("TLC_Nor")]
        public System.String TLCNor { get; set; }

        [Column("ESR")]
        public System.String Esr { get; set; }

        [Column("ESR_Unit")]
        public System.String ESRUnit { get; set; }

        [Column("ESR_Nor")]
        public System.String ESRNor { get; set; }

        [Column("BT")]
        public System.String Bt { get; set; }

        [Column("BT_Unit")]
        public System.String BTUnit { get; set; }

        [Column("BT_Nor")]
        public System.String BTNor { get; set; }

        [Column("CT")]
        public System.String Ct { get; set; }

        [Column("CT_Unit")]
        public System.String CTUnit { get; set; }

        [Column("CT_Nor")]
        public System.String CTNor { get; set; }

        [Column("Platelets_Count")]
        public System.String PlateletsCount { get; set; }

        [Column("Platelets_Count_Unit")]
        public System.String PlateletsCountUnit { get; set; }

        [Column("Platelets_Count_Nor")]
        public System.String PlateletsCountNor { get; set; }

        [Column("PT")]
        public System.String Pt { get; set; }

        [Column("PT_Unit")]
        public System.String PTUnit { get; set; }

        [Column("PT_Nor")]
        public System.String PTNor { get; set; }

        [Column("DLC")]
        public System.String Dlc { get; set; }

        [Column("DLC_Unit")]
        public System.String DLCUnit { get; set; }

        [Column("DLC_Nor")]
        public System.String DLCNor { get; set; }

        [Column("Polymorphs")]
        public System.String Polymorphs { get; set; }

        [Column("Polymorphs_Unit")]
        public System.String PolymorphsUnit { get; set; }

        [Column("Polymorphs_Nor")]
        public System.String PolymorphsNor { get; set; }

        [Column("Lymphocytes")]
        public System.String Lymphocytes { get; set; }

        [Column("Lymphocytes_Unit")]
        public System.String LymphocytesUnit { get; set; }

        [Column("Lymphocytes_Nor")]
        public System.String LymphocytesNor { get; set; }

        [Column("Monocyte")]
        public System.String Monocyte { get; set; }

        [Column("Monocyte_Unit")]
        public System.String MonocyteUnit { get; set; }

        [Column("Monocyte_Nor")]
        public System.String MonocyteNor { get; set; }

        [Column("Eosinophil")]
        public System.String Eosinophil { get; set; }

        [Column("Eosinophil_Unit")]
        public System.String EosinophilUnit { get; set; }

        [Column("Eosinophil_Nor")]
        public System.String EosinophilNor { get; set; }

        [Column("Basophil")]
        public System.String Basophil { get; set; }

        [Column("Basophil_Unit")]
        public System.String BasophilUnit { get; set; }

        [Column("Basophil_Nor")]
        public System.String BasophilNor { get; set; }

        [Column("Malaria_Parasites")]
        public System.String MalariaParasites { get; set; }

        [Column("Malaria_Parasites_Unit")]
        public System.String MalariaParasitesUnit { get; set; }

        [Column("Malaria_Parasites_Nor")]
        public System.String MalariaParasitesNor { get; set; }

        [Column("Blood_Group")]
        public System.String BloodGroup { get; set; }

        [Column("Blood_Group_Unit")]
        public System.String BloodGroupUnit { get; set; }

        [Column("Blood_Group_Nor")]
        public System.String BloodGroupNor { get; set; }

        [Column("RH_Factor")]
        public System.String RHFactor { get; set; }

        [Column("RH_Factor_Unit")]
        public System.String RHFactorUnit { get; set; }

        [Column("RH_Factor_Nor")]
        public System.String RHFactorNor { get; set; }

        [Column("Total_R_B_C")]
        public System.String TotalRBC { get; set; }

        [Column("Total_R_B_C_Unit")]
        public System.String TotalRBCUnit { get; set; }

        [Column("Total_R_B_C_Nor")]
        public System.String TotalRBCNor { get; set; }

        [Column("P_V_C_Haematorcrit")]
        public System.String PVCHaematorcrit { get; set; }

        [Column("P_V_C_Haematorcrit_Unit")]
        public System.String PVCHaematorcritUnit { get; set; }

        [Column("P_V_C_Haematorcrit_Nor")]
        public System.String PVCHaematorcritNor { get; set; }

        [Column("M_C_V")]
        public System.String MCV { get; set; }

        [Column("M_C_V_Unit")]
        public System.String MCVUnit { get; set; }

        [Column("M_C_V_Nor")]
        public System.String MCVNor { get; set; }

        [Column("M_C_H")]
        public System.String MCH { get; set; }

        [Column("M_C_H_Unit")]
        public System.String MCHUnit { get; set; }

        [Column("M_C_H_Nor")]
        public System.String MCHNor { get; set; }

        [Column("M_C_H_C")]
        public System.String MCHC { get; set; }

        [Column("M_C_H_C_Unit")]
        public System.String MCHCUnit { get; set; }

        [Column("M_C_H_C_Nor")]
        public System.String MCHCNor { get; set; }

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