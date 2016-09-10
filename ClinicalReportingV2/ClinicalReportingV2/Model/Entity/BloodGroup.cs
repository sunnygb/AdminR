using System;
using ServiceStack.DataAnnotations;

namespace ClinicalReporting.Model
{
    [Alias("BloodGroup")]
    public class BloodGroup
    {
        [PrimaryKey]
        [Alias("SerialNo")]
        public Int64 SerialNo { get; set; }

        [Alias("PatientID")]
        public Int64 PatientID { get; set; }

        [Alias("TDate")]
        public DateTime TDate { get; set; }

        [Alias("Patient_Blood_Group")]
        public String PatientBloodGroup { get; set; }

        [Alias("Donar_Name")]
        public String DonarName { get; set; }

        [Alias("Donar_Blood_Group")]
        public String DonarBloodGroup { get; set; }

        [Alias("HbsAg")]
        public String HbsAg { get; set; }

        [Alias("AntiHCV")]
        public String AntiHCV { get; set; }

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