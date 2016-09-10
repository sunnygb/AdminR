using System;
using ServiceStack.DataAnnotations;

namespace ClinicalReporting.Model
{
    [Alias("ELISA_HCV")]
    public class ElisaHcv
    {
        [PrimaryKey]
        [Alias("SerialNo")]
        public Int64 SerialNo { get; set; }

        [Alias("PatientID")]
        public Int64 PatientID { get; set; }

        [Alias("TDate")]
        public DateTime TDate { get; set; }

        [Alias("Patient_Value")]
        public Double PatientValue { get; set; }

        [Alias("Cut_Off_Value")]
        public Double CutOffValue { get; set; }

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