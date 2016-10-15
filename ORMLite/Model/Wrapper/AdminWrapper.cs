using AdmissionAndResult.Data.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace AdmissionAndResult.Data.Wrapper
{
    public partial class AdminW : CommonWrapper<Admin>
    {
        public AdminW(Admin adminModel):base(adminModel)
        {
           
           InitializeComplexProperties(adminModel);
           InitializeCollectionProperties(adminModel);
           
           
        }
        
        private void InitializeCollectionProperties(Admin adminModel)
        {
           // One To Many
           if(adminModel.VerifyingAgents !=null)
           {
              this._verifyingagentsw = new ObservableCollection<VerifyingAgentW>(
              adminModel.VerifyingAgents.Select(e=>new VerifyingAgentW(e)));
              RegisterCollection(_verifyingagentsw,adminModel.VerifyingAgents);
           }
        }
        
        private void InitializeComplexProperties(Admin adminModel)
        {
        
           
        }
          
        public AdminW():base(null){}
        
        private System.Int64 _adminid;
        public  System.Int64  AdminId
        {
           get { return GET(ref _adminid); }
           set { SET(ref  _adminid,value); }
        }
        private System.String _adminname;
        public  System.String  AdminName
        {
           get { return GET(ref _adminname); }
           set { SET(ref  _adminname,value); }
        }
        private System.String _password;
        public  System.String  Password
        {
           get { return GET(ref _password); }
           set { SET(ref  _password,value); }
        }
        private System.String _hiredate;
        public  System.String  HireDate
        {
           get { return GET(ref _hiredate); }
           set { SET(ref  _hiredate,value); }
        }
        private System.String _changedate;
        public  System.String  ChangeDate
        {
           get { return GET(ref _changedate); }
           set { SET(ref  _changedate,value); }
        }
        
        // One To Many
        private ObservableCollection<VerifyingAgentW> _verifyingagentsw;
        public  ObservableCollection<VerifyingAgentW>  VerifyingAgentsW
        { 
          get { return _verifyingagentsw; }
          set { _verifyingagentsw = value; }
        }
        
        
    }
}