using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Data.Wrapper;
using GalaSoft.MvvmLight;
namespace ClinicalReporting.Data
{


    [Alias("Doctor")]
    public partial class Doctor
    {
        
        public Doctor()
        {
        }
        
        public Doctor(DoctorW doctorw)
        {
           this.DoctorID = doctorw.DoctorID;
           this.DoctorName = doctorw.DoctorName;
           
           
        }

        [PrimaryKey]
        [Alias("DoctorID")]
        public System.Int64 DoctorID { get; set; }

        [Alias("DoctorName")]
        public System.String DoctorName { get; set; }

         [Ignore]
         public bool IsNew
         {
                get
                {
         
                  return this.DoctorID == default(int);
         
                }
                
          }
          [Ignore]
          public bool IsDeleted { get; set; }
    }
}