using System;
using ServiceStack.DataAnnotations;

namespace ClinicalReporting.Model
{
    [Alias("Doctor")]
    public class Doctor
    {
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