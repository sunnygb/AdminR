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
    public partial class VerifyingAgentW : ValidateModelCommon
    {
        public VerifyingAgentW(VerifyingAgent verifyingagent)
        {
           this._verifyingagentid = verifyingagent.VerifyingAgentId;
           
           this._verifyingagentname = verifyingagent.VerifyingAgentName;
           
           this._degreeverification = verifyingagent.DegreeVerification;
           
           this._adminid = verifyingagent.AdminId;
           
           this._senddate = verifyingagent.SendDate;
           
           this._recivedate = verifyingagent.ReciveDate;
           
           this._studentid = verifyingagent.StudentId;
           
           
           // One To One
           if(verifyingagent.Admin !=null)
           {
               this._adminw = new AdminW(
               verifyingagent.Admin);
           }
           // One To One
           if(verifyingagent.Student !=null)
           {
               this._studentw = new StudentW(
               verifyingagent.Student);
           }

        }
        
        public VerifyingAgentW(){}
        
        private System.Int64 _verifyingagentid;
        public  System.Int64  verifyingagentid
        {
           get { return _verifyingagentid; }
           set { ChangeNvalidate(ref  _verifyingagentid,value); }
        }
        private System.String _verifyingagentname;
        public  System.String  verifyingagentname
        {
           get { return _verifyingagentname; }
           set { ChangeNvalidate(ref  _verifyingagentname,value); }
        }
        private System.String _degreeverification;
        public  System.String  degreeverification
        {
           get { return _degreeverification; }
           set { ChangeNvalidate(ref  _degreeverification,value); }
        }
        private System.Int64 _adminid;
        public  System.Int64  adminid
        {
           get { return _adminid; }
           set { ChangeNvalidate(ref  _adminid,value); }
        }
        private System.String _senddate;
        public  System.String  senddate
        {
           get { return _senddate; }
           set { ChangeNvalidate(ref  _senddate,value); }
        }
        private System.String _recivedate;
        public  System.String  recivedate
        {
           get { return _recivedate; }
           set { ChangeNvalidate(ref  _recivedate,value); }
        }
        private System.Int64 _studentid;
        public  System.Int64  studentid
        {
           get { return _studentid; }
           set { ChangeNvalidate(ref  _studentid,value); }
        }
        
        // One To One
        private AdminW _adminw;
        public  AdminW  adminw
        {
           get { return _adminw; }
           set { ChangeNvalidate(ref _adminw,value); }
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