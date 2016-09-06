using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Data.Wrapper;
namespace ClinicalReporting.Data
{


    [Alias("ELISA_TB")]
    public partial class ElisaTb
    {
        
        public ElisaTb()
        {
        }
        
        public ElisaTb(ElisaTbW elisatbw)
        {
           this.SerialNo = elisatbw.SerialNo;
           this.PatientID = elisatbw.PatientID;
           this.TDate = elisatbw.TDate;
           this.PatientValue = elisatbw.PatientValue;
           this.CutOffValue = elisatbw.CutOffValue;
           this.Fee = elisatbw.Fee;
           
           
        }

        [PrimaryKey]
        [Alias("SerialNo")]
        public System.Int64 SerialNo { get; set; }

        [Alias("PatientID")]
        public System.Int64 PatientID { get; set; }

        [Alias("TDate")]
        public System.DateTime TDate { get; set; }

        [Alias("Patient_Value")]
        public System.Double PatientValue { get; set; }

        [Alias("Cut_Off_Value")]
        public System.Double CutOffValue { get; set; }

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