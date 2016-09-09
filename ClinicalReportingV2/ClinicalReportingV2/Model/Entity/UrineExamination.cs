using ClinicalReporting.Data.Wrapper;
using ServiceStack.DataAnnotations;
using System;

namespace ClinicalReporting.Data
{
    [Alias("UrineExamination")]
    public class UrineExamination
    {
        public UrineExamination()
        {
        }

        public UrineExamination(UrineExaminationW urineexaminationw)
        {
            SerialNo = urineexaminationw.SerialNo;
            PatientID = urineexaminationw.PatientID;
            TDate = urineexaminationw.TDate;
            Colour = urineexaminationw.Colour;
            Reaction = urineexaminationw.Reaction;
            SpecificGravity = urineexaminationw.SpecificGravity;
            Albumin = urineexaminationw.Albumin;
            Sugar = urineexaminationw.Sugar;
            Ketone = urineexaminationw.Ketone;
            Blood = urineexaminationw.Blood;
            Bilirubin = urineexaminationw.Bilirubin;
            UrobilNogen = urineexaminationw.UrobilNogen;
            PusCells = urineexaminationw.PusCells;
            Rbc = urineexaminationw.Rbc;
            EPiCells = urineexaminationw.EPiCells;
            Cast = urineexaminationw.Cast;
            Crystals = urineexaminationw.Crystals;
            CalOxalate = urineexaminationw.CalOxalate;
            UricAcid = urineexaminationw.UricAcid;
            Amorphous = urineexaminationw.Amorphous;
            Others = urineexaminationw.Others;
            Fee = urineexaminationw.Fee;
        }

        [PrimaryKey]
        [Alias("SerialNo")]
        public Int64 SerialNo { get; set; }

        [Alias("PatientID")]
        public Int64 PatientID { get; set; }

        [Alias("TDate")]
        public DateTime TDate { get; set; }

        [Alias("Colour")]
        public String Colour { get; set; }

        [Alias("Reaction")]
        public String Reaction { get; set; }

        [Alias("Specific_Gravity")]
        public String SpecificGravity { get; set; }

        [Alias("Albumin")]
        public String Albumin { get; set; }

        [Alias("Sugar")]
        public String Sugar { get; set; }

        [Alias("Ketone")]
        public String Ketone { get; set; }

        [Alias("Blood")]
        public String Blood { get; set; }

        [Alias("Bilirubin")]
        public String Bilirubin { get; set; }

        [Alias("Urobil_Nogen")]
        public String UrobilNogen { get; set; }

        [Alias("Pus_Cells")]
        public String PusCells { get; set; }

        [Alias("RBC")]
        public String Rbc { get; set; }

        [Alias("EPi_Cells")]
        public String EPiCells { get; set; }

        [Alias("Cast")]
        public String Cast { get; set; }

        [Alias("Crystals")]
        public String Crystals { get; set; }

        [Alias("Cal_Oxalate")]
        public String CalOxalate { get; set; }

        [Alias("Uric_Acid")]
        public String UricAcid { get; set; }

        [Alias("Amorphous")]
        public String Amorphous { get; set; }

        [Alias("Others")]
        public String Others { get; set; }

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