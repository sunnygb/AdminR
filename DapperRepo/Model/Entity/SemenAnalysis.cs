using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Table("SemenAnalysis")]
    public partial class SemenAnalysis
    {
        
        public SemenAnalysis()
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

        [Column("Quantity")]
        public System.String Quantity { get; set; }

        [Column("PH")]
        public System.String Ph { get; set; }

        [Column("Time_Of_Collection")]
        public System.String TimeOfCollection { get; set; }

        [Column("Time_Of_Examination")]
        public System.String TimeOfExamination { get; set; }

        [Column("Total_Count")]
        public System.String TotalCount { get; set; }

        [Column("Active_Motility")]
        public System.String ActiveMotility { get; set; }

        [Column("Sluggish")]
        public System.String Sluggish { get; set; }

        [Column("Non_Motile")]
        public System.String NonMotile { get; set; }

        [Column("Abnormal")]
        public System.String Abnormal { get; set; }

        [Column("Pus_Cells")]
        public System.String PusCells { get; set; }

        [Column("RBC")]
        public System.String Rbc { get; set; }

        [Column("Epithelial_Cell")]
        public System.String EpithelialCell { get; set; }

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