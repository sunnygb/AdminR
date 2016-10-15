using AdmissionAndResult.Data.Services;

namespace AdmissionAndResult.Data.Wrapper
{
    public partial class VerifyingAgentW : CommonWrapper<VerifyingAgent>
    {
        public VerifyingAgentW(VerifyingAgent verifyingagentModel):base(verifyingagentModel)
        {
           
           InitializeComplexProperties(verifyingagentModel);
           InitializeCollectionProperties(verifyingagentModel);
           
           
        }
        
        private void InitializeCollectionProperties(VerifyingAgent verifyingagentModel)
        {
        }
        
        private void InitializeComplexProperties(VerifyingAgent verifyingagentModel)
        {
        
           // One To One
           if(verifyingagentModel.Admin !=null)
           {
               this.AdminW = new AdminW(
               verifyingagentModel.Admin);
           }
           // One To One
           if(verifyingagentModel.Student !=null)
           {
               this.StudentW = new StudentW(
               verifyingagentModel.Student);
           }
        }
          
        public VerifyingAgentW():base(null){}
        
        private System.Int64 _verifyingagentid;
        public  System.Int64  VerifyingAgentId
        {
           get { return GET(ref _verifyingagentid); }
           set { SET(ref  _verifyingagentid,value); }
        }
        private System.String _verifyingagentname;
        public  System.String  VerifyingAgentName
        {
           get { return GET(ref _verifyingagentname); }
           set { SET(ref  _verifyingagentname,value); }
        }
        private System.String _degreeverification;
        public  System.String  DegreeVerification
        {
           get { return GET(ref _degreeverification); }
           set { SET(ref  _degreeverification,value); }
        }
        private System.Int64 _adminid;
        public  System.Int64  AdminId
        {
           get { return GET(ref _adminid); }
           set { SET(ref  _adminid,value); }
        }
        private System.String _senddate;
        public  System.String  SendDate
        {
           get { return GET(ref _senddate); }
           set { SET(ref  _senddate,value); }
        }
        private System.String _recivedate;
        public  System.String  ReciveDate
        {
           get { return GET(ref _recivedate); }
           set { SET(ref  _recivedate,value); }
        }
        private System.Int64 _studentid;
        public  System.Int64  StudentId
        {
           get { return GET(ref _studentid); }
           set { SET(ref  _studentid,value); }
        }
        
        // One To One
        private AdminW _adminw;
        public  AdminW  AdminW
        { 
           get { return _adminw; } 
           set { _adminw = value;
           if(!Equals(_adminw,Model.Admin))
           {Model.Admin = _adminw.Model;};}
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