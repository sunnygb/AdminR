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
        public  System.Int64  Serialno
        {
           get { return GET(ref _serialno); }
           set { SET(ref  _serialno,value); }
        }
        private System.Int64 _patientid;
        public  System.Int64  Patientid
        {
           get { return GET(ref _patientid); }
           set { SET(ref  _patientid,value); }
        }
        private System.String _tdate;
        public  System.String  Tdate
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
        public  System.String  STyphiTo
        {
           get { return GET(ref _styphito); }
           set { SET(ref  _styphito,value); }
        }
        private System.String _styphith;
        public  System.String  STyphiTh
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
        private System.String _typhoid;
        public  System.String  Typhoid
        {
           get { return GET(ref _typhoid); }
           set { SET(ref  _typhoid,value); }
        }
        private System.String _IGM;
        public  System.String  IGM
        {
            get { return GET(ref _IGM); }
           set { SET(ref  _IGM,value); }
        }
        private System.String _IGG;
        public  System.String  IGG
        {
            get { return GET(ref _IGG); }
            set { SET(ref  _IGG, value); }
        }
        private System.String _hbsag;
        public  System.String  HbsAg
        {
           get { return GET(ref _hbsag); }
           set { SET(ref  _hbsag,value); }
        }
        private System.String _asotitre;
        public  System.String  AsoTitre
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
        public  System.String  RaFactor
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
        public  System.String  KahnsVdrl
        {
           get { return GET(ref _kahnsvdrl); }
           set { SET(ref  _kahnsvdrl,value); }
        }
        private System.String _tbplus;
        public  System.String  TbPlus
        {
           get { return GET(ref _tbplus); }
           set { SET(ref  _tbplus,value); }
        }
        private System.String _igm;
        public  System.String  Igm
        {
            get { return GET(ref _igm); }
            set { SET(ref  _igm, value); }
        }
        private System.String _igg;
        public  System.String  Igg
        {
           get { return GET(ref _igg); }
           set { SET(ref  _igg,value); }
        }
        private System.String _helicobacterpylori;
        public  System.String  HelicobacterPylori
        {
           get { return GET(ref _helicobacterpylori); }
           set { SET(ref  _helicobacterpylori,value); }
        }
        private System.String _hiv;
        public  System.String  Hiv
        {
           get { return GET(ref _hiv); }
           set { SET(ref  _hiv,value); }
        }
        private System.Int64 _fee;
        public  System.Int64  Fee
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