using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using ClinicalReporting.Data;
using ClinicalReporting.Data.Services;
using ClinicalReporting.Data.Wrapper;

namespace ClinicalReporting.Data.Wrapper
{
    public partial class ElisaHcvW : CommonWrapper<ElisaHcv>
    {
        public ElisaHcvW(ElisaHcv elisahcvModel):base(elisahcvModel)
        {
           
           InitializeComplexProperties(elisahcvModel);
           InitializeCollectionProperties(elisahcvModel);
           
           
        }
        
        private void InitializeCollectionProperties(ElisaHcv elisahcvModel)
        {
        }
        
        private void InitializeComplexProperties(ElisaHcv elisahcvModel)
        {
        
           // One To One
           if(elisahcvModel.Patient !=null)
           {
               this.PatientW = new PatientW(
               elisahcvModel.Patient);
           }
        }
          
        public ElisaHcvW():base(null){}
        
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
        private System.Double _patientvalue;
        public  System.Double  PatientValue
        {
           get { return GET(ref _patientvalue); }
           set { SET(ref  _patientvalue,value); }
        }
        private System.Double _cutoffvalue;
        public  System.Double  CutOffValue
        {
           get { return GET(ref _cutoffvalue); }
           set { SET(ref  _cutoffvalue,value); }
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