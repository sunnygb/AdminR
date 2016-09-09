using ClinicalReporting.Data.Wrapper;
using ServiceStack.DataAnnotations;
using System;

namespace ClinicalReporting.Data
{
    [Alias("Doctor")]
    public class Doctor
    {
        public Doctor()
        {
        }

        public Doctor(DoctorW doctorw)
        {
            DoctorID = doctorw.DoctorID;
            DoctorName = doctorw.DoctorName;
        }

        [PrimaryKey]
        [Alias("DoctorID")]
        public Int64 DoctorID { get; set; }

        [Alias("DoctorName")]
        public String DoctorName { get; set; }

        [Ignore]
        public bool IsNew
        {
            get { return DoctorID == default(int); }
        }

        [Ignore]
        public bool IsDeleted { get; set; }
    }
}