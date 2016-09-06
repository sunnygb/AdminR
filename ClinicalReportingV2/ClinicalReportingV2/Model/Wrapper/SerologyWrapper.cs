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
    public partial class SerologyW : CommonWrapper<Serology>
    {
        public SerologyW(Serology serologyModel):base(serologyModel)
        {
           
           InitializeComplexProperties(serologyModel);
           InitializeCollectionProperties(serologyModel);
           
           
        }
        
        private void InitializeCollectionProperties(Serology serologyModel)
        {
        }
        
        private void InitializeComplexProperties(Serology serologyModel)
        {
        
           // One To One
           if(serologyModel.Patient !=null)
           {
               this.PatientW = new PatientW(
               serologyModel.Patient);
           }
        }
          
        public SerologyW():base(null){}
        
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
        private System.String _widaltest;
        public  System.String  WidalTest
        {
           get { return GET(ref _widaltest); }
           set { SET(ref  _widaltest,value); }
        }
        private System.String _styphito;
        public  System.String  STyphiTO
        {
           get { return GET(ref _styphito); }
           set { SET(ref  _styphito,value); }
        }
        private System.String _styphith;
        public  System.String  STyphiTH
        {
           get { return GET(ref _styphith); }
           set { SET(ref  _styphith,value); }
        }
        private System.String _parathyphiah;
        public  System.String  ParaThyphiAh
        {
           get { return GET(ref _parathyphiah); }
           set { SET(ref  _parathyphiah,value); }
        }
        private System.String _parathyphibh;
        public  System.String  ParaThyphiBh
        {
           get { return GET(ref _parathyphibh); }
           set { SET(ref  _parathyphibh,value); }
        }
        private System.String _hbsag;
        public  System.String  HBSAg
        {
           get { return GET(ref _hbsag); }
           set { SET(ref  _hbsag,value); }
        }
        private System.String _asotitre;
        public  System.String  ASOTitre
        {
           get { return GET(ref _asotitre); }
           set { SET(ref  _asotitre,value); }
        }
        private System.String _pregnancytest;
        public  System.String  PregnancyTest
        {
           get { return GET(ref _pregnancytest); }
           set { SET(ref  _pregnancytest,value); }
        }
        private System.String _rafactor;
        public  System.String  RAFactor
        {
           get { return GET(ref _rafactor); }
           set { SET(ref  _rafactor,value); }
        }
        private System.String _antihcv;
        public  System.String  AntiHcv
        {
           get { return GET(ref _antihcv); }
           set { SET(ref  _antihcv,value); }
        }
        private System.String _mantoex;
        public  System.String  Mantoex
        {
           get { return GET(ref _mantoex); }
           set { SET(ref  _mantoex,value); }
        }
        private System.String _kahnsvdrl;
        public  System.String  KahnsVDRL
        {
           get { return GET(ref _kahnsvdrl); }
           set { SET(ref  _kahnsvdrl,value); }
        }
        private System.String _tbplus;
        public  System.String  TBPlus
        {
           get { return GET(ref _tbplus); }
           set { SET(ref  _tbplus,value); }
        }
        private System.String _hiv;
        public  System.String  Hiv
        {
           get { return GET(ref _hiv); }
           set { SET(ref  _hiv,value); }
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