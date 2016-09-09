using ClinicalReporting.Data.Wrapper;
using ServiceStack.DataAnnotations;
using System;

namespace ClinicalReporting.Data
{
    [Alias("ELISA_HCV")]
    public class ElisaHcv
    {
        public ElisaHcv()
        {
        }

        public ElisaHcv(ElisaHcvW elisahcvw)
        {
            SerialNo = elisahcvw.SerialNo;
            PatientID = elisahcvw.PatientID;
            TDate = elisahcvw.TDate;
            PatientValue = elisahcvw.PatientValue;
            CutOffValue = elisahcvw.CutOffValue;
            Fee = elisahcvw.Fee;
        }

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