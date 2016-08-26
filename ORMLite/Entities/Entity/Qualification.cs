using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;

namespace AdmissionAndResult.Data
{



    public partial class Qualification
    {
    
        public Qualification()
        {
        }

        [PrimaryKey]
        [AutoIncrement]  
        [Alias("Qualification_Id")]
        public long QualificationId { get; set; }

        [Alias("NTS_Obt_Marks")]
        public string NTSObtMarks { get; set; }

        [Alias("Inter_Obt_Marks")]
        public string InterObtMarks { get; set; }

        [Alias("Matric_Obt_Marks")]
        public string MatricObtMarks { get; set; }

        [Alias("FSC_Year")]
        public string FSCYear { get; set; }

        [Alias("BS_Year")]
        public string BSYear { get; set; }

        [Alias("MS_Year")]
        public string MSYear { get; set; }

        [Alias("Matric_Year")]
        public string MatricYear { get; set; }

        [Alias("MS_Institute_Name")]
        public string MSInstituteName { get; set; }

        [Alias("BS_Institute_Name")]
        public string BSInstituteName { get; set; }

        [Alias("Inter_Institute_Name")]
        public string InterInstituteName { get; set; }

        [Alias("Matric_Institute_Name")]
        public string MatricInstituteName { get; set; }

        [Alias("Inter_Roll_No")]
        public long? InterRollNo { get; set; }

        [Alias("NTS_Roll_No")]
        public long? NTSRollNo { get; set; }

        [Alias("Matric_Roll_No")]
        public string MatricRollNo { get; set; }

        [Alias("MS_Roll_No")]
        public long? MSRollNo { get; set; }

        [Alias("GAT_Roll_No")]
        public long? GATRollNo { get; set; }

        [Alias("BS_Roll_No")]
        public string BSRollNo { get; set; }

        [Alias("Board_Name")]
        public string BoardName { get; set; }

        [Alias("GAT_Obt_Marks")]
        public long? GATObtMarks { get; set; }

        [Alias("Batchlor_Obt_CGPA")]
        public double? BatchlorObtCGPA { get; set; }

        [Alias("MSC_Obt_CGPA")]
        public double? MSCObtCGPA { get; set; }

        [Alias("Verified_NTS_Marks")]
        public long? VerifiedNTSMarks { get; set; }

        [Alias("Verified_Matric_Marks")]
        public long? VerifiedMatricMarks { get; set; }

        [Alias("Verified_FSC_Marks")]
        public long? VerifiedFSCMarks { get; set; }

        [Alias("Verified_MSC_CGPA")]
        public long? VerifiedMSCCGPA { get; set; }

        [Alias("Verified_BS_CGPA")]
        public long? VerifiedBSCGPA { get; set; }

        [Alias("BS_Degree")]
        public string BSDegree { get; set; }

        [Alias("MS_Degree")]
        public string MSDegree { get; set; }

        [Alias("BS_isVerified")]
        public long? BSIsVerified { get; set; }

        [Alias("MS_isVerified")]
        public long? MSIsVerified { get; set; }

        [Alias("PHD_isVerified")]
        public long? PHDIsVerified { get; set; }

        [Alias("Matric_isVerified")]
        public long? MatricIsVerified { get; set; }

        [Alias("Inter_isVerified")]
        public long? InterIsVerified { get; set; }

        [Ignore]
        public virtual Student Student { get; set; }
         [Ignore]
         public bool IsNew
         {
                get
                {
         
                  return this.QualificationId == default(int);
         
                }
                
          }
          [Ignore]
          public bool IsDeleted { get; set; }
    }
}