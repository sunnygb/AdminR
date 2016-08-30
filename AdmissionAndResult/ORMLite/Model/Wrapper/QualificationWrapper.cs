using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using AdmissionAndResult.Data;
using AdmissionAndResult.Data.Services;
using AdmissionAndResult.Data.Wrapper;

namespace AdmissionAndResult.Data.Wrapper
{
    public partial class QualificationW : ValidateModelCommon
    {
        public QualificationW(Qualification qualification)
        {
           this._qualificationid = qualification.QualificationId;
           
           this._ntsobtmarks = qualification.NTSObtMarks;
           
           this._interobtmarks = qualification.InterObtMarks;
           
           this._matricobtmarks = qualification.MatricObtMarks;
           
           this._fscyear = qualification.FSCYear;
           
           this._bsyear = qualification.BSYear;
           
           this._msyear = qualification.MSYear;
           
           this._matricyear = qualification.MatricYear;
           
           this._msinstitutename = qualification.MSInstituteName;
           
           this._bsinstitutename = qualification.BSInstituteName;
           
           this._interinstitutename = qualification.InterInstituteName;
           
           this._matricinstitutename = qualification.MatricInstituteName;
           
           this._interrollno = qualification.InterRollNo;
           
           this._ntsrollno = qualification.NTSRollNo;
           
           this._matricrollno = qualification.MatricRollNo;
           
           this._msrollno = qualification.MSRollNo;
           
           this._gatrollno = qualification.GATRollNo;
           
           this._bsrollno = qualification.BSRollNo;
           
           this._boardname = qualification.BoardName;
           
           this._gatobtmarks = qualification.GATObtMarks;
           
           this._batchlorobtcgpa = qualification.BatchlorObtCGPA;
           
           this._mscobtcgpa = qualification.MSCObtCGPA;
           
           this._verifiedntsmarks = qualification.VerifiedNTSMarks;
           
           this._verifiedmatricmarks = qualification.VerifiedMatricMarks;
           
           this._verifiedfscmarks = qualification.VerifiedFSCMarks;
           
           this._verifiedmsccgpa = qualification.VerifiedMSCCGPA;
           
           this._verifiedbscgpa = qualification.VerifiedBSCGPA;
           
           this._bsdegree = qualification.BSDegree;
           
           this._msdegree = qualification.MSDegree;
           
           this._bsisverified = qualification.BSIsVerified;
           
           this._msisverified = qualification.MSIsVerified;
           
           this._phdisverified = qualification.PHDIsVerified;
           
           this._matricisverified = qualification.MatricIsVerified;
           
           this._interisverified = qualification.InterIsVerified;
           
           
           // One To One
           if(qualification.Student !=null)
           {
               this._studentw = new StudentW(
               qualification.Student);
           }

        }
        
        public QualificationW(){}
        
        private System.Int64 _qualificationid;
        public  System.Int64  qualificationid
        {
           get { return _qualificationid; }
           set { ChangeNvalidate(ref  _qualificationid,value); }
        }
        private System.String _ntsobtmarks;
        public  System.String  ntsobtmarks
        {
           get { return _ntsobtmarks; }
           set { ChangeNvalidate(ref  _ntsobtmarks,value); }
        }
        private System.String _interobtmarks;
        public  System.String  interobtmarks
        {
           get { return _interobtmarks; }
           set { ChangeNvalidate(ref  _interobtmarks,value); }
        }
        private System.String _matricobtmarks;
        public  System.String  matricobtmarks
        {
           get { return _matricobtmarks; }
           set { ChangeNvalidate(ref  _matricobtmarks,value); }
        }
        private System.String _fscyear;
        public  System.String  fscyear
        {
           get { return _fscyear; }
           set { ChangeNvalidate(ref  _fscyear,value); }
        }
        private System.String _bsyear;
        public  System.String  bsyear
        {
           get { return _bsyear; }
           set { ChangeNvalidate(ref  _bsyear,value); }
        }
        private System.String _msyear;
        public  System.String  msyear
        {
           get { return _msyear; }
           set { ChangeNvalidate(ref  _msyear,value); }
        }
        private System.String _matricyear;
        public  System.String  matricyear
        {
           get { return _matricyear; }
           set { ChangeNvalidate(ref  _matricyear,value); }
        }
        private System.String _msinstitutename;
        public  System.String  msinstitutename
        {
           get { return _msinstitutename; }
           set { ChangeNvalidate(ref  _msinstitutename,value); }
        }
        private System.String _bsinstitutename;
        public  System.String  bsinstitutename
        {
           get { return _bsinstitutename; }
           set { ChangeNvalidate(ref  _bsinstitutename,value); }
        }
        private System.String _interinstitutename;
        public  System.String  interinstitutename
        {
           get { return _interinstitutename; }
           set { ChangeNvalidate(ref  _interinstitutename,value); }
        }
        private System.String _matricinstitutename;
        public  System.String  matricinstitutename
        {
           get { return _matricinstitutename; }
           set { ChangeNvalidate(ref  _matricinstitutename,value); }
        }
        private System.Int64 _interrollno;
        public  System.Int64  interrollno
        {
           get { return _interrollno; }
           set { ChangeNvalidate(ref  _interrollno,value); }
        }
        private System.Int64 _ntsrollno;
        public  System.Int64  ntsrollno
        {
           get { return _ntsrollno; }
           set { ChangeNvalidate(ref  _ntsrollno,value); }
        }
        private System.String _matricrollno;
        public  System.String  matricrollno
        {
           get { return _matricrollno; }
           set { ChangeNvalidate(ref  _matricrollno,value); }
        }
        private System.Int64 _msrollno;
        public  System.Int64  msrollno
        {
           get { return _msrollno; }
           set { ChangeNvalidate(ref  _msrollno,value); }
        }
        private System.Int64 _gatrollno;
        public  System.Int64  gatrollno
        {
           get { return _gatrollno; }
           set { ChangeNvalidate(ref  _gatrollno,value); }
        }
        private System.String _bsrollno;
        public  System.String  bsrollno
        {
           get { return _bsrollno; }
           set { ChangeNvalidate(ref  _bsrollno,value); }
        }
        private System.String _boardname;
        public  System.String  boardname
        {
           get { return _boardname; }
           set { ChangeNvalidate(ref  _boardname,value); }
        }
        private System.Int64 _gatobtmarks;
        public  System.Int64  gatobtmarks
        {
           get { return _gatobtmarks; }
           set { ChangeNvalidate(ref  _gatobtmarks,value); }
        }
        private System.Double _batchlorobtcgpa;
        public  System.Double  batchlorobtcgpa
        {
           get { return _batchlorobtcgpa; }
           set { ChangeNvalidate(ref  _batchlorobtcgpa,value); }
        }
        private System.Double _mscobtcgpa;
        public  System.Double  mscobtcgpa
        {
           get { return _mscobtcgpa; }
           set { ChangeNvalidate(ref  _mscobtcgpa,value); }
        }
        private System.Int64 _verifiedntsmarks;
        public  System.Int64  verifiedntsmarks
        {
           get { return _verifiedntsmarks; }
           set { ChangeNvalidate(ref  _verifiedntsmarks,value); }
        }
        private System.Int64 _verifiedmatricmarks;
        public  System.Int64  verifiedmatricmarks
        {
           get { return _verifiedmatricmarks; }
           set { ChangeNvalidate(ref  _verifiedmatricmarks,value); }
        }
        private System.Int64 _verifiedfscmarks;
        public  System.Int64  verifiedfscmarks
        {
           get { return _verifiedfscmarks; }
           set { ChangeNvalidate(ref  _verifiedfscmarks,value); }
        }
        private System.Int64 _verifiedmsccgpa;
        public  System.Int64  verifiedmsccgpa
        {
           get { return _verifiedmsccgpa; }
           set { ChangeNvalidate(ref  _verifiedmsccgpa,value); }
        }
        private System.Int64 _verifiedbscgpa;
        public  System.Int64  verifiedbscgpa
        {
           get { return _verifiedbscgpa; }
           set { ChangeNvalidate(ref  _verifiedbscgpa,value); }
        }
        private System.String _bsdegree;
        public  System.String  bsdegree
        {
           get { return _bsdegree; }
           set { ChangeNvalidate(ref  _bsdegree,value); }
        }
        private System.String _msdegree;
        public  System.String  msdegree
        {
           get { return _msdegree; }
           set { ChangeNvalidate(ref  _msdegree,value); }
        }
        private System.Int64 _bsisverified;
        public  System.Int64  bsisverified
        {
           get { return _bsisverified; }
           set { ChangeNvalidate(ref  _bsisverified,value); }
        }
        private System.Int64 _msisverified;
        public  System.Int64  msisverified
        {
           get { return _msisverified; }
           set { ChangeNvalidate(ref  _msisverified,value); }
        }
        private System.Int64 _phdisverified;
        public  System.Int64  phdisverified
        {
           get { return _phdisverified; }
           set { ChangeNvalidate(ref  _phdisverified,value); }
        }
        private System.Int64 _matricisverified;
        public  System.Int64  matricisverified
        {
           get { return _matricisverified; }
           set { ChangeNvalidate(ref  _matricisverified,value); }
        }
        private System.Int64 _interisverified;
        public  System.Int64  interisverified
        {
           get { return _interisverified; }
           set { ChangeNvalidate(ref  _interisverified,value); }
        }
        
        // One To One
        private StudentW _studentw;
        public  StudentW  studentw
        {
           get { return _studentw; }
           set { ChangeNvalidate(ref _studentw,value); }
        }
        
        
    }
}