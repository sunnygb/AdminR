using AdmissionAndResult.Data.Wrapper;
using ServiceStack.DataAnnotations;
namespace AdmissionAndResult.Data
{


    [Alias("Qualification")]
    public partial class Qualification
    {
        
        public Qualification()
        {
        }
        
        public Qualification(QualificationW qualificationw)
        {
           this.QualificationId = qualificationw.QualificationId;
           this.NTSObtMarks = qualificationw.NTSObtMarks;
           this.InterObtMarks = qualificationw.InterObtMarks;
           this.MatricObtMarks = qualificationw.MatricObtMarks;
           this.FSCYear = qualificationw.FSCYear;
           this.BSYear = qualificationw.BSYear;
           this.MSYear = qualificationw.MSYear;
           this.MatricYear = qualificationw.MatricYear;
           this.MSInstituteName = qualificationw.MSInstituteName;
           this.BSInstituteName = qualificationw.BSInstituteName;
           this.InterInstituteName = qualificationw.InterInstituteName;
           this.MatricInstituteName = qualificationw.MatricInstituteName;
           this.InterRollNo = qualificationw.InterRollNo;
           this.NTSRollNo = qualificationw.NTSRollNo;
           this.MatricRollNo = qualificationw.MatricRollNo;
           this.MSRollNo = qualificationw.MSRollNo;
           this.GATRollNo = qualificationw.GATRollNo;
           this.BSRollNo = qualificationw.BSRollNo;
           this.BoardName = qualificationw.BoardName;
           this.GATObtMarks = qualificationw.GATObtMarks;
           this.BatchlorObtCGPA = qualificationw.BatchlorObtCGPA;
           this.MSCObtCGPA = qualificationw.MSCObtCGPA;
           this.VerifiedNTSMarks = qualificationw.VerifiedNTSMarks;
           this.VerifiedMatricMarks = qualificationw.VerifiedMatricMarks;
           this.VerifiedFSCMarks = qualificationw.VerifiedFSCMarks;
           this.VerifiedMSCCGPA = qualificationw.VerifiedMSCCGPA;
           this.VerifiedBSCGPA = qualificationw.VerifiedBSCGPA;
           this.BSDegree = qualificationw.BSDegree;
           this.MSDegree = qualificationw.MSDegree;
           this.BSIsVerified = qualificationw.BSIsVerified;
           this.MSIsVerified = qualificationw.MSIsVerified;
           this.PHDIsVerified = qualificationw.PHDIsVerified;
           this.MatricIsVerified = qualificationw.MatricIsVerified;
           this.InterIsVerified = qualificationw.InterIsVerified;
           
           
        }

        [PrimaryKey]
        [Alias("Qualification_Id")]
        public System.Int64 QualificationId { get; set; }

        [Alias("NTS_Obt_Marks")]
        public System.String NTSObtMarks { get; set; }

        [Alias("Inter_Obt_Marks")]
        public System.String InterObtMarks { get; set; }

        [Alias("Matric_Obt_Marks")]
        public System.String MatricObtMarks { get; set; }

        [Alias("FSC_Year")]
        public System.String FSCYear { get; set; }

        [Alias("BS_Year")]
        public System.String BSYear { get; set; }

        [Alias("MS_Year")]
        public System.String MSYear { get; set; }

        [Alias("Matric_Year")]
        public System.String MatricYear { get; set; }

        [Alias("MS_Institute_Name")]
        public System.String MSInstituteName { get; set; }

        [Alias("BS_Institute_Name")]
        public System.String BSInstituteName { get; set; }

        [Alias("Inter_Institute_Name")]
        public System.String InterInstituteName { get; set; }

        [Alias("Matric_Institute_Name")]
        public System.String MatricInstituteName { get; set; }

        [Alias("Inter_Roll_No")]
        public System.Int64 InterRollNo { get; set; }

        [Alias("NTS_Roll_No")]
        public System.Int64 NTSRollNo { get; set; }

        [Alias("Matric_Roll_No")]
        public System.String MatricRollNo { get; set; }

        [Alias("MS_Roll_No")]
        public System.Int64 MSRollNo { get; set; }

        [Alias("GAT_Roll_No")]
        public System.Int64 GATRollNo { get; set; }

        [Alias("BS_Roll_No")]
        public System.String BSRollNo { get; set; }

        [Alias("Board_Name")]
        public System.String BoardName { get; set; }

        [Alias("GAT_Obt_Marks")]
        public System.Int64 GATObtMarks { get; set; }

        [Alias("Batchlor_Obt_CGPA")]
        public System.Double BatchlorObtCGPA { get; set; }

        [Alias("MSC_Obt_CGPA")]
        public System.Double MSCObtCGPA { get; set; }

        [Alias("Verified_NTS_Marks")]
        public System.Int64 VerifiedNTSMarks { get; set; }

        [Alias("Verified_Matric_Marks")]
        public System.Int64 VerifiedMatricMarks { get; set; }

        [Alias("Verified_FSC_Marks")]
        public System.Int64 VerifiedFSCMarks { get; set; }

        [Alias("Verified_MSC_CGPA")]
        public System.Int64 VerifiedMSCCGPA { get; set; }

        [Alias("Verified_BS_CGPA")]
        public System.Int64 VerifiedBSCGPA { get; set; }

        [Alias("BS_Degree")]
        public System.String BSDegree { get; set; }

        [Alias("MS_Degree")]
        public System.String MSDegree { get; set; }

        [Alias("BS_isVerified")]
        public System.Int64 BSIsVerified { get; set; }

        [Alias("MS_isVerified")]
        public System.Int64 MSIsVerified { get; set; }

        [Alias("PHD_isVerified")]
        public System.Int64 PHDIsVerified { get; set; }

        [Alias("Matric_isVerified")]
        public System.Int64 MatricIsVerified { get; set; }

        [Alias("Inter_isVerified")]
        public System.Int64 InterIsVerified { get; set; }

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