using ClinicalReporting.Data.Wrapper;
using ServiceStack.DataAnnotations;
using System;

namespace ClinicalReporting.Data
{
    [Alias("Haematology")]
    public class Haematology
    {
        public Haematology()
        {
        }

        public Haematology(HaematologyW haematologyw)
        {
            SerialNo = haematologyw.SerialNo;
            PatientID = haematologyw.PatientID;
            TDate = haematologyw.TDate;
            Hb = haematologyw.Hb;
            HBUnit = haematologyw.HBUnit;
            HBNor = haematologyw.HBNor;
            Tlc = haematologyw.Tlc;
            TLCUnit = haematologyw.TLCUnit;
            TLCNor = haematologyw.TLCNor;
            Esr = haematologyw.Esr;
            ESRUnit = haematologyw.ESRUnit;
            ESRNor = haematologyw.ESRNor;
            Bt = haematologyw.Bt;
            BTUnit = haematologyw.BTUnit;
            BTNor = haematologyw.BTNor;
            Ct = haematologyw.Ct;
            CTUnit = haematologyw.CTUnit;
            CTNor = haematologyw.CTNor;
            PlateletsCount = haematologyw.PlateletsCount;
            PlateletsCountUnit = haematologyw.PlateletsCountUnit;
            PlateletsCountNor = haematologyw.PlateletsCountNor;
            Pt = haematologyw.Pt;
            PTUnit = haematologyw.PTUnit;
            PTNor = haematologyw.PTNor;
            Dlc = haematologyw.Dlc;
            DLCUnit = haematologyw.DLCUnit;
            DLCNor = haematologyw.DLCNor;
            Polymorphs = haematologyw.Polymorphs;
            PolymorphsUnit = haematologyw.PolymorphsUnit;
            PolymorphsNor = haematologyw.PolymorphsNor;
            Lymphocytes = haematologyw.Lymphocytes;
            LymphocytesUnit = haematologyw.LymphocytesUnit;
            LymphocytesNor = haematologyw.LymphocytesNor;
            Monocyte = haematologyw.Monocyte;
            MonocyteUnit = haematologyw.MonocyteUnit;
            MonocyteNor = haematologyw.MonocyteNor;
            Eosinophil = haematologyw.Eosinophil;
            EosinophilUnit = haematologyw.EosinophilUnit;
            EosinophilNor = haematologyw.EosinophilNor;
            Basophil = haematologyw.Basophil;
            BasophilUnit = haematologyw.BasophilUnit;
            BasophilNor = haematologyw.BasophilNor;
            MalariaParasites = haematologyw.MalariaParasites;
            MalariaParasitesUnit = haematologyw.MalariaParasitesUnit;
            MalariaParasitesNor = haematologyw.MalariaParasitesNor;
            BloodGroup = haematologyw.BloodGroup;
            BloodGroupUnit = haematologyw.BloodGroupUnit;
            BloodGroupNor = haematologyw.BloodGroupNor;
            RHFactor = haematologyw.RHFactor;
            RHFactorUnit = haematologyw.RHFactorUnit;
            RHFactorNor = haematologyw.RHFactorNor;
            TotalRBC = haematologyw.TotalRBC;
            TotalRBCUnit = haematologyw.TotalRBCUnit;
            TotalRBCNor = haematologyw.TotalRBCNor;
            PVCHaematorcrit = haematologyw.PVCHaematorcrit;
            PVCHaematorcritUnit = haematologyw.PVCHaematorcritUnit;
            PVCHaematorcritNor = haematologyw.PVCHaematorcritNor;
            MCV = haematologyw.MCV;
            MCVUnit = haematologyw.MCVUnit;
            MCVNor = haematologyw.MCVNor;
            MCH = haematologyw.MCH;
            MCHUnit = haematologyw.MCHUnit;
            MCHNor = haematologyw.MCHNor;
            MCHC = haematologyw.MCHC;
            MCHCUnit = haematologyw.MCHCUnit;
            MCHCNor = haematologyw.MCHCNor;
            Fee = haematologyw.Fee;
        }

        [PrimaryKey]
        [Alias("SerialNo")]
        public Int64 SerialNo { get; set; }

        [Alias("PatientID")]
        public Int64 PatientID { get; set; }

        [Alias("TDate")]
        public DateTime TDate { get; set; }

        [Alias("HB")]
        public String Hb { get; set; }

        [Alias("HB_Unit")]
        public String HBUnit { get; set; }

        [Alias("HB_Nor")]
        public String HBNor { get; set; }

        [Alias("TLC")]
        public String Tlc { get; set; }

        [Alias("TLC_Unit")]
        public String TLCUnit { get; set; }

        [Alias("TLC_Nor")]
        public String TLCNor { get; set; }

        [Alias("ESR")]
        public String Esr { get; set; }

        [Alias("ESR_Unit")]
        public String ESRUnit { get; set; }

        [Alias("ESR_Nor")]
        public String ESRNor { get; set; }

        [Alias("BT")]
        public String Bt { get; set; }

        [Alias("BT_Unit")]
        public String BTUnit { get; set; }

        [Alias("BT_Nor")]
        public String BTNor { get; set; }

        [Alias("CT")]
        public String Ct { get; set; }

        [Alias("CT_Unit")]
        public String CTUnit { get; set; }

        [Alias("CT_Nor")]
        public String CTNor { get; set; }

        [Alias("Platelets_Count")]
        public String PlateletsCount { get; set; }

        [Alias("Platelets_Count_Unit")]
        public String PlateletsCountUnit { get; set; }

        [Alias("Platelets_Count_Nor")]
        public String PlateletsCountNor { get; set; }

        [Alias("PT")]
        public String Pt { get; set; }

        [Alias("PT_Unit")]
        public String PTUnit { get; set; }

        [Alias("PT_Nor")]
        public String PTNor { get; set; }

        [Alias("DLC")]
        public String Dlc { get; set; }

        [Alias("DLC_Unit")]
        public String DLCUnit { get; set; }

        [Alias("DLC_Nor")]
        public String DLCNor { get; set; }

        [Alias("Polymorphs")]
        public String Polymorphs { get; set; }

        [Alias("Polymorphs_Unit")]
        public String PolymorphsUnit { get; set; }

        [Alias("Polymorphs_Nor")]
        public String PolymorphsNor { get; set; }

        [Alias("Lymphocytes")]
        public String Lymphocytes { get; set; }

        [Alias("Lymphocytes_Unit")]
        public String LymphocytesUnit { get; set; }

        [Alias("Lymphocytes_Nor")]
        public String LymphocytesNor { get; set; }

        [Alias("Monocyte")]
        public String Monocyte { get; set; }

        [Alias("Monocyte_Unit")]
        public String MonocyteUnit { get; set; }

        [Alias("Monocyte_Nor")]
        public String MonocyteNor { get; set; }

        [Alias("Eosinophil")]
        public String Eosinophil { get; set; }

        [Alias("Eosinophil_Unit")]
        public String EosinophilUnit { get; set; }

        [Alias("Eosinophil_Nor")]
        public String EosinophilNor { get; set; }

        [Alias("Basophil")]
        public String Basophil { get; set; }

        [Alias("Basophil_Unit")]
        public String BasophilUnit { get; set; }

        [Alias("Basophil_Nor")]
        public String BasophilNor { get; set; }

        [Alias("Malaria_Parasites")]
        public String MalariaParasites { get; set; }

        [Alias("Malaria_Parasites_Unit")]
        public String MalariaParasitesUnit { get; set; }

        [Alias("Malaria_Parasites_Nor")]
        public String MalariaParasitesNor { get; set; }

        [Alias("Blood_Group")]
        public String BloodGroup { get; set; }

        [Alias("Blood_Group_Unit")]
        public String BloodGroupUnit { get; set; }

        [Alias("Blood_Group_Nor")]
        public String BloodGroupNor { get; set; }

        [Alias("RH_Factor")]
        public String RHFactor { get; set; }

        [Alias("RH_Factor_Unit")]
        public String RHFactorUnit { get; set; }

        [Alias("RH_Factor_Nor")]
        public String RHFactorNor { get; set; }

        [Alias("Total_R_B_C")]
        public String TotalRBC { get; set; }

        [Alias("Total_R_B_C_Unit")]
        public String TotalRBCUnit { get; set; }

        [Alias("Total_R_B_C_Nor")]
        public String TotalRBCNor { get; set; }

        [Alias("P_V_C_Haematorcrit")]
        public String PVCHaematorcrit { get; set; }

        [Alias("P_V_C_Haematorcrit_Unit")]
        public String PVCHaematorcritUnit { get; set; }

        [Alias("P_V_C_Haematorcrit_Nor")]
        public String PVCHaematorcritNor { get; set; }

        [Alias("M_C_V")]
        public String MCV { get; set; }

        [Alias("M_C_V_Unit")]
        public String MCVUnit { get; set; }

        [Alias("M_C_V_Nor")]
        public String MCVNor { get; set; }

        [Alias("M_C_H")]
        public String MCH { get; set; }

        [Alias("M_C_H_Unit")]
        public String MCHUnit { get; set; }

        [Alias("M_C_H_Nor")]
        public String MCHNor { get; set; }

        [Alias("M_C_H_C")]
        public String MCHC { get; set; }

        [Alias("M_C_H_C_Unit")]
        public String MCHCUnit { get; set; }

        [Alias("M_C_H_C_Nor")]
        public String MCHCNor { get; set; }

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