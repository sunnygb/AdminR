using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Table("Doctor")]
    public partial class Doctor
    {
        
        public Doctor()
        {
        }
        

        [Key]
        [Column("DoctorID")]
        public System.Int64 DoctorID { get; set; }

        [Column("DoctorName")]
        public System.String DoctorName { get; set; }

         [NotMapped]
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