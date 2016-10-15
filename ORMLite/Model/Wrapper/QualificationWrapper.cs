using AdmissionAndResult.Data.Services;

namespace AdmissionAndResult.Data.Wrapper
{
    public partial class QualificationW : CommonWrapper<Qualification>
    {
        public QualificationW(Qualification qualificationModel):base(qualificationModel)
        {
           
           InitializeComplexProperties(qualificationModel);
           InitializeCollectionProperties(qualificationModel);
           
           
        }
        
        private void InitializeCollectionProperties(Qualification qualificationModel)
        {
        }
        
        private void InitializeComplexProperties(Qualification qualificationModel)
        {
        
           // One To One
           if(qualificationModel.Student !=null)
           {
               this.StudentW = new StudentW(
               qualificationModel.Student);
           }
        }
          
        public QualificationW():base(null){}
        
        private System.Int64 _qualificationid;
        public  System.Int64  QualificationId
        {
           get { return GET(ref _qualificationid); }
           set { SET(ref  _qualificationid,value); }
        }
        private System.String _ntsobtmarks;
        public  System.String  NTSObtMarks
        {
           get { return GET(ref _ntsobtmarks); }
           set { SET(ref  _ntsobtmarks,value); }
        }
        private System.String _interobtmarks;
        public  System.String  InterObtMarks
        {
           get { return GET(ref _interobtmarks); }
           set { SET(ref  _interobtmarks,value); }
        }
        private System.String _matricobtmarks;
        public  System.String  MatricObtMarks
        {
           get { return GET(ref _matricobtmarks); }
           set { SET(ref  _matricobtmarks,value); }
        }
        private System.String _fscyear;
        public  System.String  FSCYear
        {
           get { return GET(ref _fscyear); }
           set { SET(ref  _fscyear,value); }
        }
        private System.String _bsyear;
        public  System.String  BSYear
        {
           get { return GET(ref _bsyear); }
           set { SET(ref  _bsyear,value); }
        }
        private System.String _msyear;
        public  System.String  MSYear
        {
           get { return GET(ref _msyear); }
           set { SET(ref  _msyear,value); }
        }
        private System.String _matricyear;
        public  System.String  MatricYear
        {
           get { return GET(ref _matricyear); }
           set { SET(ref  _matricyear,value); }
        }
        private System.String _msinstitutename;
        public  System.String  MSInstituteName
        {
           get { return GET(ref _msinstitutename); }
           set { SET(ref  _msinstitutename,value); }
        }
        private System.String _bsinstitutename;
        public  System.String  BSInstituteName
        {
           get { return GET(ref _bsinstitutename); }
           set { SET(ref  _bsinstitutename,value); }
        }
        private System.String _interinstitutename;
        public  System.String  InterInstituteName
        {
           get { return GET(ref _interinstitutename); }
           set { SET(ref  _interinstitutename,value); }
        }
        private System.String _matricinstitutename;
        public  System.String  MatricInstituteName
        {
           get { return GET(ref _matricinstitutename); }
           set { SET(ref  _matricinstitutename,value); }
        }
        private System.Int64 _interrollno;
        public  System.Int64  InterRollNo
        {
           get { return GET(ref _interrollno); }
           set { SET(ref  _interrollno,value); }
        }
        private System.Int64 _ntsrollno;
        public  System.Int64  NTSRollNo
        {
           get { return GET(ref _ntsrollno); }
           set { SET(ref  _ntsrollno,value); }
        }
        private System.String _matricrollno;
        public  System.String  MatricRollNo
        {
           get { return GET(ref _matricrollno); }
           set { SET(ref  _matricrollno,value); }
        }
        private System.Int64 _msrollno;
        public  System.Int64  MSRollNo
        {
           get { return GET(ref _msrollno); }
           set { SET(ref  _msrollno,value); }
        }
        private System.Int64 _gatrollno;
        public  System.Int64  GATRollNo
        {
           get { return GET(ref _gatrollno); }
           set { SET(ref  _gatrollno,value); }
        }
        private System.String _bsrollno;
        public  System.String  BSRollNo
        {
           get { return GET(ref _bsrollno); }
           set { SET(ref  _bsrollno,value); }
        }
        private System.String _boardname;
        public  System.String  BoardName
        {
           get { return GET(ref _boardname); }
           set { SET(ref  _boardname,value); }
        }
        private System.Int64 _gatobtmarks;
        public  System.Int64  GATObtMarks
        {
           get { return GET(ref _gatobtmarks); }
           set { SET(ref  _gatobtmarks,value); }
        }
        private System.Double _batchlorobtcgpa;
        public  System.Double  BatchlorObtCGPA
        {
           get { return GET(ref _batchlorobtcgpa); }
           set { SET(ref  _batchlorobtcgpa,value); }
        }
        private System.Double _mscobtcgpa;
        public  System.Double  MSCObtCGPA
        {
           get { return GET(ref _mscobtcgpa); }
           set { SET(ref  _mscobtcgpa,value); }
        }
        private System.Int64 _verifiedntsmarks;
        public  System.Int64  VerifiedNTSMarks
        {
           get { return GET(ref _verifiedntsmarks); }
           set { SET(ref  _verifiedntsmarks,value); }
        }
        private System.Int64 _verifiedmatricmarks;
        public  System.Int64  VerifiedMatricMarks
        {
           get { return GET(ref _verifiedmatricmarks); }
           set { SET(ref  _verifiedmatricmarks,value); }
        }
        private System.Int64 _verifiedfscmarks;
        public  System.Int64  VerifiedFSCMarks
        {
           get { return GET(ref _verifiedfscmarks); }
           set { SET(ref  _verifiedfscmarks,value); }
        }
        private System.Int64 _verifiedmsccgpa;
        public  System.Int64  VerifiedMSCCGPA
        {
           get { return GET(ref _verifiedmsccgpa); }
           set { SET(ref  _verifiedmsccgpa,value); }
        }
        private System.Int64 _verifiedbscgpa;
        public  System.Int64  VerifiedBSCGPA
        {
           get { return GET(ref _verifiedbscgpa); }
           set { SET(ref  _verifiedbscgpa,value); }
        }
        private System.String _bsdegree;
        public  System.String  BSDegree
        {
           get { return GET(ref _bsdegree); }
           set { SET(ref  _bsdegree,value); }
        }
        private System.String _msdegree;
        public  System.String  MSDegree
        {
           get { return GET(ref _msdegree); }
           set { SET(ref  _msdegree,value); }
        }
        private System.Int64 _bsisverified;
        public  System.Int64  BSIsVerified
        {
           get { return GET(ref _bsisverified); }
           set { SET(ref  _bsisverified,value); }
        }
        private System.Int64 _msisverified;
        public  System.Int64  MSIsVerified
        {
           get { return GET(ref _msisverified); }
           set { SET(ref  _msisverified,value); }
        }
        private System.Int64 _phdisverified;
        public  System.Int64  PHDIsVerified
        {
           get { return GET(ref _phdisverified); }
           set { SET(ref  _phdisverified,value); }
        }
        private System.Int64 _matricisverified;
        public  System.Int64  MatricIsVerified
        {
           get { return GET(ref _matricisverified); }
           set { SET(ref  _matricisverified,value); }
        }
        private System.Int64 _interisverified;
        public  System.Int64  InterIsVerified
        {
           get { return GET(ref _interisverified); }
           set { SET(ref  _interisverified,value); }
        }
        
        // One To One
        private StudentW _studentw;
        public  StudentW  StudentW
        { 
           get { return _studentw; } 
           set { _studentw = value;
           if(!Equals(_studentw,Model.Student))
           {Model.Student = _studentw.Model;};}
        }
        
        
        
    }
}