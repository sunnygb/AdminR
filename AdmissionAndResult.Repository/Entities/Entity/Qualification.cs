﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities
{



    public partial class Qualification
    {
        public Qualification()
        {
        }

        public long QualificationId { get; set; }
        public string NTSObtMarks { get; set; }
        public long? NTSMaxMarks { get; set; }
        public string FSCObtMarks { get; set; }
        public long FSCMaxMarks { get; set; }
        public string MatricObtMarks { get; set; }
        public long MatricMaxMarks { get; set; }
        public string NTSYear { get; set; }
        public string FSCYear { get; set; }
        public string BSYear { get; set; }
        public string MSYear { get; set; }
        public string GATYear { get; set; }
        public string MatricYear { get; set; }
        public string MSInstituteName { get; set; }
        public string BSInstituteName { get; set; }
        public string FSCInstituteName { get; set; }
        public string MatricInstituteName { get; set; }
        public long? FscRollNo { get; set; }
        public long? NTSRollNo { get; set; }
        public string MatricRollNo { get; set; }
        public long? MSRollNo { get; set; }
        public long? GATRollNo { get; set; }
        public string BSRollNo { get; set; }
        public string BoardName { get; set; }
        public string GATMaxMarks { get; set; }
        public long? GATObtMarks { get; set; }
        public double? BatchlorMaxCGPA { get; set; }
        public double? BatchlorObtCGPA { get; set; }
        public double? MSCMaxCGPA { get; set; }
        public double? MSCObtCGPA { get; set; }
        public long? VerifiedNTSMarks { get; set; }
        public long? VerifiedMatricMarks { get; set; }
        public long? VerifiedFSCMarks { get; set; }
        public long? VerifiedGATMarks { get; set; }
        public double? VerifiedMSCCGPA { get; set; }
        public double? VerifiedBSCGPA { get; set; }
        public string BSDegree { get; set; }
        public string MSDegree { get; set; }
        public object  { get; set; }

        public virtual Student Student { get; set; }
    }
}