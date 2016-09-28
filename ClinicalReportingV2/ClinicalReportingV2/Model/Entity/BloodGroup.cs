using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Alias("BloodGroup")]
    public partial class BloodGroup
    {
        
        public BloodGroup()
        {
        }
        

        [PrimaryKey]
        [Alias("SerialNo")]
        public System.Int64 SerialNo { get; set; }

        [Alias("PatientID")]
        public System.Int64 PatientID { get; set; }

        [Alias("TDate")]
        public System.DateTime TDate { get; set; }

        [Alias("Patient_Blood_Group")]
        public System.String PatientBloodGroup { get; set; }

        [Alias("Donar_Name")]
        public System.String DonarName { get; set; }

        [Alias("Donar_Blood_Group")]
        public System.String DonarBloodGroup { get; set; }

        [Alias("HbsAg")]
        public System.String HbsAg { get; set; }

        [Alias("AntiHCV")]
        public System.String AntiHCV { get; set; }

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