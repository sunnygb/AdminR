using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using AdmissionAndResult.Data.Wrapper;
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
           this.QualificationId = qualificationw.qualificationid;
           this.NTSObtMarks = qualificationw.ntsobtmarks;
           this.InterObtMarks = qualificationw.interobtmarks;
           this.MatricObtMarks = qualificationw.matricobtmarks;
           this.FSCYear = qualificationw.fscyear;
           this.BSYear = qualificationw.bsyear;
           this.MSYear = qualificationw.msyear;
           this.MatricYear = qualificationw.matricyear;
           this.MSInstituteName = qualificationw.msinstitutename;
           this.BSInstituteName = qualificationw.bsinstitutename;
           this.InterInstituteName = qualificationw.interinstitutename;
           this.MatricInstituteName = qualificationw.matricinstitutename;
           this.InterRollNo = qualificationw.interrollno;
           this.NTSRollNo = qualificationw.ntsrollno;
           this.MatricRollNo = qualificationw.matricrollno;
           this.MSRollNo = qualificationw.msrollno;
           this.GATRollNo = qualificationw.gatrollno;
           this.BSRollNo = qualificationw.bsrollno;
           this.BoardName = qualificationw.boardname;
           this.GATObtMarks = qualificationw.gatobtmarks;
           this.BatchlorObtCGPA = qualificationw.batchlorobtcgpa;
           this.MSCObtCGPA = qualificationw.mscobtcgpa;
           this.VerifiedNTSMarks = qualificationw.verifiedntsmarks;
           this.VerifiedMatricMarks = qualificationw.verifiedmatricmarks;
           this.VerifiedFSCMarks = qualificationw.verifiedfscmarks;
           this.VerifiedMSCCGPA = qualificationw.verifiedmsccgpa;
           this.VerifiedBSCGPA = qualificationw.verifiedbscgpa;
           this.BSDegree = qualificationw.bsdegree;
           this.MSDegree = qualificationw.msdegree;
           this.BSIsVerified = qualificationw.bsisverified;
           this.MSIsVerified = qualificationw.msisverified;
           this.PHDIsVerified = qualificationw.phdisverified;
           this.MatricIsVerified = qualificationw.matricisverified;
           this.InterIsVerified = qualificationw.interisverified;
           
           
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