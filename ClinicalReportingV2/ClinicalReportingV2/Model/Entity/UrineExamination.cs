using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Alias("UrineExamination")]
    public partial class UrineExamination
    {
        
        public UrineExamination()
        {
        }
        

        [PrimaryKey]
        [Alias("SerialNo")]
        public System.Int64 SerialNo { get; set; }

        [Alias("PatientID")]
        public System.Int64 PatientID { get; set; }

        [Alias("TDate")]
        public System.DateTime TDate { get; set; }

        [Alias("Colour")]
        public System.String Colour { get; set; }

        [Alias("Reaction")]
        public System.String Reaction { get; set; }

        [Alias("Specific_Gravity")]
        public System.String SpecificGravity { get; set; }

        [Alias("Albumin")]
        public System.String Albumin { get; set; }

        [Alias("Sugar")]
        public System.String Sugar { get; set; }

        [Alias("Ketone")]
        public System.String Ketone { get; set; }

        [Alias("Blood")]
        public System.String Blood { get; set; }

        [Alias("Bilirubin")]
        public System.String Bilirubin { get; set; }

        [Alias("Urobil_Nogen")]
        public System.String UrobilNogen { get; set; }

        [Alias("Pus_Cells")]
        public System.String PusCells { get; set; }

        [Alias("RBC")]
        public System.String Rbc { get; set; }

        [Alias("EPi_Cells")]
        public System.String EPiCells { get; set; }

        [Alias("Cast")]
        public System.String Cast { get; set; }

        [Alias("Crystals")]
        public System.String Crystals { get; set; }

        [Alias("Cal_Oxalate")]
        public System.String CalOxalate { get; set; }

        [Alias("Uric_Acid")]
        public System.String UricAcid { get; set; }

        [Alias("Amorphous")]
        public System.String Amorphous { get; set; }

        [Alias("Others")]
        public System.String Others { get; set; }

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