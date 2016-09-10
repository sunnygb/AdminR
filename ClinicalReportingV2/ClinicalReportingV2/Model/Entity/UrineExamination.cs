using System;
using ServiceStack.DataAnnotations;

namespace ClinicalReporting.Model
{
    [Alias("UrineExamination")]
    public class UrineExamination
    {
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