using System.Collections.ObjectModel;
using System.Linq;

namespace ClinicalReporting.Model.Wrapper
{
    public partial class BloodGroupW : CommonWrapper<BloodGroup>
    {
        public BloodGroupW(BloodGroup bloodgroupModel):base(bloodgroupModel)
        {
           
           InitializeComplexProperties(bloodgroupModel);
           InitializeCollectionProperties(bloodgroupModel);
           
           
        }
        
        private void InitializeCollectionProperties(BloodGroup bloodgroupModel)
        {
        }
        
        private void InitializeComplexProperties(BloodGroup bloodgroupModel)
        {
        
           // One To One
           if(bloodgroupModel.Patient !=null)
           {
               this.PatientW = new PatientW(
               bloodgroupModel.Patient);
           }
        }
          
        public BloodGroupW():base(null){}
        
        private System.Int64 _serialno;
        public  System.Int64  SerialNo
        {
           get { return GET(ref _serialno); }
           set { SET(ref  _serialno,value); }
        }
        private System.Int64 _patientid;
        public  System.Int64  PatientID
        {
           get { return GET(ref _patientid); }
           set { SET(ref  _patientid,value); }
        }
        private System.DateTime _tdate;
        public  System.DateTime  TDate
        {
           get { return GET(ref _tdate); }
           set { SET(ref  _tdate,value); }
        }
        private System.String _patientbloodgroup;
        public  System.String  PatientBloodGroup
        {
           get { return GET(ref _patientbloodgroup); }
           set { SET(ref  _patientbloodgroup,value); }
        }
        private System.String _donarname;
        public  System.String  DonarName
        {
           get { return GET(ref _donarname); }
           set { SET(ref  _donarname,value); }
        }
        private System.String _donarbloodgroup;
        public  System.String  DonarBloodGroup
        {
           get { return GET(ref _donarbloodgroup); }
           set { SET(ref  _donarbloodgroup,value); }
        }
        private System.String _hbsag;
        public  System.String  HbsAg
        {
           get { return GET(ref _hbsag); }
           set { SET(ref  _hbsag,value); }
        }
        private System.String _antihcv;
        public  System.String  AntiHCV
        {
           get { return GET(ref _antihcv); }
           set { SET(ref  _antihcv,value); }
        }
        private System.Int32 _fee;
        public  System.Int32  Fee
        {
           get { return GET(ref _fee); }
           set { SET(ref  _fee,value); }
        }
        
        // One To One
        private PatientW _patientw;
        public  PatientW  PatientW
        { 
           get { return _patientw; } 
           set { _patientw = value;
           if(!Equals(_patientw,Model.Patient))
           {Model.Patient = _patientw.Model;};}
        }
        
        
        
    }
}