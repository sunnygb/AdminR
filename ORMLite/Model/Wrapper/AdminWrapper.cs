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
    public partial class AdminW : ValidateModelCommon
    {
        public AdminW(Admin admin)
        {
           this._adminid = admin.AdminId;
           
           this._adminname = admin.AdminName;
           
           this._password = admin.Password;
           
           this._hiredate = admin.HireDate;
           
           this._changedate = admin.ChangeDate;
           
           
           // One To Many
           if(admin.VerifyingAgents !=null)
           {
              this._verifyingagentsw = new ObservableCollection<VerifyingAgentW>(
              admin.VerifyingAgents.Select(e=>new VerifyingAgentW(e)));
           }
           

        }
        
        public AdminW(){}
        
        private System.Int64 _adminid;
        public  System.Int64  adminid
        {
           get { return _adminid; }
           set { ChangeNvalidate(ref  _adminid,value); }
        }
        private System.String _adminname;
        public  System.String  adminname
        {
           get { return _adminname; }
           set { ChangeNvalidate(ref  _adminname,value); }
        }
        private System.String _password;
        public  System.String  password
        {
           get { return _password; }
           set { ChangeNvalidate(ref  _password,value); }
        }
        private System.String _hiredate;
        public  System.String  hiredate
        {
           get { return _hiredate; }
           set { ChangeNvalidate(ref  _hiredate,value); }
        }
        private System.String _changedate;
        public  System.String  changedate
        {
           get { return _changedate; }
           set { ChangeNvalidate(ref  _changedate,value); }
        }
        
        // One To Many
        private ObservableCollection<VerifyingAgentW> _verifyingagentsw;
        public  ObservableCollection<VerifyingAgentW>  verifyingagentsw
        {
           get { return _verifyingagentsw; }
           set { ChangeNvalidate(ref _verifyingagentsw,value); }
        }

        public Admin AdminModel { get; set; }
    }
}