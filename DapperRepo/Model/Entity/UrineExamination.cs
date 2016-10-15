using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Table("UrineExamination")]
    public partial class UrineExamination
    {
        
        public UrineExamination()
        {
        }
        

        [Key]
        [Column("SerialNo")]
        public System.Int64 SerialNo { get; set; }

        [Column("PatientID")]
        public System.Int64 PatientID { get; set; }

        [Column("TDate")]
        public System.DateTime TDate { get; set; }

        [Column("Colour")]
        public System.String Colour { get; set; }

        [Column("Reaction")]
        public System.String Reaction { get; set; }

        [Column("Specific_Gravity")]
        public System.String SpecificGravity { get; set; }

        [Column("Albumin")]
        public System.String Albumin { get; set; }

        [Column("Sugar")]
        public System.String Sugar { get; set; }

        [Column("Ketone")]
        public System.String Ketone { get; set; }

        [Column("Blood")]
        public System.String Blood { get; set; }

        [Column("Bilirubin")]
        public System.String Bilirubin { get; set; }

        [Column("Urobil_Nogen")]
        public System.String UrobilNogen { get; set; }

        [Column("Pus_Cells")]
        public System.String PusCells { get; set; }

        [Column("RBC")]
        public System.String Rbc { get; set; }

        [Column("EPi_Cells")]
        public System.String EPiCells { get; set; }

        [Column("Cast")]
        public System.String Cast { get; set; }

        [Column("Crystals")]
        public System.String Crystals { get; set; }

        [Column("Cal_Oxalate")]
        public System.String CalOxalate { get; set; }

        [Column("Uric_Acid")]
        public System.String UricAcid { get; set; }

        [Column("Amorphous")]
        public System.String Amorphous { get; set; }

        [Column("Others")]
        public System.String Others { get; set; }

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