﻿using System.Collections.ObjectModel;
using System.Linq;

namespace ClinicalReporting.Model.Wrapper
{
    public partial class ElisaTbW : CommonWrapper<ElisaTb>
    {
        public ElisaTbW(ElisaTb elisatbModel):base(elisatbModel)
        {
           
           InitializeComplexProperties(elisatbModel);
           InitializeCollectionProperties(elisatbModel);
           
           
        }
        
        private void InitializeCollectionProperties(ElisaTb elisatbModel)
        {
        }
        
        private void InitializeComplexProperties(ElisaTb elisatbModel)
        {
        
           // One To One
           if(elisatbModel.Patient !=null)
           {
               this.PatientW = new PatientW(
               elisatbModel.Patient);
           }
        }
          
        public ElisaTbW():base(null){}
        
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