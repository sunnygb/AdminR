using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Table("BloodGroup")]
    public partial class BloodGroup
    {
        
        public BloodGroup()
        {
        }
        

        [Key]
        [Column("SerialNo")]
        public System.Int64 SerialNo { get; set; }

        [Column("PatientID")]
        public System.Int64 PatientID { get; set; }

        [Column("TDate")]
        public System.DateTime TDate { get; set; }

        [Column("Patient_Blood_Group")]
        public System.String PatientBloodGroup { get; set; }

        [Column("Donar_Name")]
        public System.String DonarName { get; set; }

        [Column("Donar_Blood_Group")]
        public System.String DonarBloodGroup { get; set; }

        [Column("HbsAg")]
        public System.String HbsAg { get; set; }

        [Column("AntiHCV")]
        public System.String AntiHCV { get; set; }

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