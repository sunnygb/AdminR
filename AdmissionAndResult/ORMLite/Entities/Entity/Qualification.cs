using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionAndResult.Data
{



    public partial class Qualification
    {
    
        public Qualification()
        {
        }

        public long QualificationId { get; set; }
        public string NTSObtMarks { get; set; }
        public string InterObtMarks { get; set; }
        public string MatricObtMarks { get; set; }
        public string FSCYear { get; set; }
        public string BSYear { get; set; }
        public string MSYear { get; set; }
        public string MatricYear { get; set; }
        public string MSInstituteName { get; set; }
        public string BSInstituteName { get; set; }
        public string InterInstituteName { get; set; }
        public string MatricInstituteName { get; set; }
        public long? InterRollNo { get; set; }
        public long? NTSRollNo { get; set; }
        public string MatricRollNo { get; set; }
        public long? MSRollNo { get; set; }
        public long? GATRollNo { get; set; }
        public string BSRollNo { get; set; }
        public string BoardName { get; set; }
        public long? GATObtMarks { get; set; }
        public double? BatchlorObtCGPA { get; set; }
        public double? MSCObtCGPA { get; set; }
        public long? VerifiedNTSMarks { get; set; }
        public long? VerifiedMatricMarks { get; set; }
        public long? VerifiedFSCMarks { get; set; }
        public long? VerifiedMSCCGPA { get; set; }
        public long? VerifiedBSCGPA { get; set; }
        public string BSDegree { get; set; }
        public string MSDegree { get; set; }
        public long? BSIsVerified { get; set; }
        public long? MSIsVerified { get; set; }
        public long? PHDIsVerified { get; set; }
        public long? MatricIsVerified { get; set; }
        public long? InterIsVerified { get; set; }

        public virtual Student Student { get; set; }

         public bool IsNew
         {
                get
                {
         
                  return this.QualificationId == default(int);
         
                }
                
          }
          public bool IsDeleted { get; set; }
    }
}