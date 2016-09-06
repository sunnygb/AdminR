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
    public partial class UrineExaminationW : CommonWrapper<UrineExamination>
    {
        public UrineExaminationW(UrineExamination urineexaminationModel):base(urineexaminationModel)
        {
           
           InitializeComplexProperties(urineexaminationModel);
           InitializeCollectionProperties(urineexaminationModel);
           
           
        }
        
        private void InitializeCollectionProperties(UrineExamination urineexaminationModel)
        {
        }
        
        private void InitializeComplexProperties(UrineExamination urineexaminationModel)
        {
        
           // One To One
           if(urineexaminationModel.Patient !=null)
           {
               this.PatientW = new PatientW(
               urineexaminationModel.Patient);
           }
        }
          
        public UrineExaminationW():base(null){}
        
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
        private System.String _colour;
        public  System.String  Colour
        {
           get { return GET(ref _colour); }
           set { SET(ref  _colour,value); }
        }
        private System.String _reaction;
        public  System.String  Reaction
        {
           get { return GET(ref _reaction); }
           set { SET(ref  _reaction,value); }
        }
        private System.String _specificgravity;
        public  System.String  SpecificGravity
        {
           get { return GET(ref _specificgravity); }
           set { SET(ref  _specificgravity,value); }
        }
        private System.String _albumin;
        public  System.String  Albumin
        {
           get { return GET(ref _albumin); }
           set { SET(ref  _albumin,value); }
        }
        private System.String _sugar;
        public  System.String  Sugar
        {
           get { return GET(ref _sugar); }
           set { SET(ref  _sugar,value); }
        }
        private System.String _ketone;
        public  System.String  Ketone
        {
           get { return GET(ref _ketone); }
           set { SET(ref  _ketone,value); }
        }
        private System.String _blood;
        public  System.String  Blood
        {
           get { return GET(ref _blood); }
           set { SET(ref  _blood,value); }
        }
        private System.String _bilirubin;
        public  System.String  Bilirubin
        {
           get { return GET(ref _bilirubin); }
           set { SET(ref  _bilirubin,value); }
        }
        private System.String _urobilnogen;
        public  System.String  UrobilNogen
        {
           get { return GET(ref _urobilnogen); }
           set { SET(ref  _urobilnogen,value); }
        }
        private System.String _puscells;
        public  System.String  PusCells
        {
           get { return GET(ref _puscells); }
           set { SET(ref  _puscells,value); }
        }
        private System.String _rbc;
        public  System.String  Rbc
        {
           get { return GET(ref _rbc); }
           set { SET(ref  _rbc,value); }
        }
        private System.String _epicells;
        public  System.String  EPiCells
        {
           get { return GET(ref _epicells); }
           set { SET(ref  _epicells,value); }
        }
        private System.String _cast;
        public  System.String  Cast
        {
           get { return GET(ref _cast); }
           set { SET(ref  _cast,value); }
        }
        private System.String _crystals;
        public  System.String  Crystals
        {
           get { return GET(ref _crystals); }
           set { SET(ref  _crystals,value); }
        }
        private System.String _caloxalate;
        public  System.String  CalOxalate
        {
           get { return GET(ref _caloxalate); }
           set { SET(ref  _caloxalate,value); }
        }
        private System.String _uricacid;
        public  System.String  UricAcid
        {
           get { return GET(ref _uricacid); }
           set { SET(ref  _uricacid,value); }
        }
        private System.String _amorphous;
        public  System.String  Amorphous
        {
           get { return GET(ref _amorphous); }
           set { SET(ref  _amorphous,value); }
        }
        private System.String _others;
        public  System.String  Others
        {
           get { return GET(ref _others); }
           set { SET(ref  _others,value); }
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