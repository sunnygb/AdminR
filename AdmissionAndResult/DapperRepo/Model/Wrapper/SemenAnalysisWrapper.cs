using System.Collections.ObjectModel;
using System.Linq;

namespace ClinicalReporting.Model.Wrapper
{
    public partial class SemenAnalysisW : CommonWrapper<SemenAnalysis>
    {
        public SemenAnalysisW(SemenAnalysis semenanalysisModel):base(semenanalysisModel)
        {
           
           InitializeComplexProperties(semenanalysisModel);
           InitializeCollectionProperties(semenanalysisModel);
           
           
        }
        
        private void InitializeCollectionProperties(SemenAnalysis semenanalysisModel)
        {
        }
        
        private void InitializeComplexProperties(SemenAnalysis semenanalysisModel)
        {
        
           // One To One
           if(semenanalysisModel.Patient !=null)
           {
               this.PatientW = new PatientW(
               semenanalysisModel.Patient);
           }
        }
          
        public SemenAnalysisW():base(null){}
        
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
        private System.String _quantity;
        public  System.String  Quantity
        {
           get { return GET(ref _quantity); }
           set { SET(ref  _quantity,value); }
        }
        private System.String _ph;
        public  System.String  Ph
        {
           get { return GET(ref _ph); }
           set { SET(ref  _ph,value); }
        }
        private System.String _timeofcollection;
        public  System.String  TimeOfCollection
        {
           get { return GET(ref _timeofcollection); }
           set { SET(ref  _timeofcollection,value); }
        }
        private System.String _timeofexamination;
        public  System.String  TimeOfExamination
        {
           get { return GET(ref _timeofexamination); }
           set { SET(ref  _timeofexamination,value); }
        }
        private System.String _totalcount;
        public  System.String  TotalCount
        {
           get { return GET(ref _totalcount); }
           set { SET(ref  _totalcount,value); }
        }
        private System.String _activemotility;
        public  System.String  ActiveMotility
        {
           get { return GET(ref _activemotility); }
           set { SET(ref  _activemotility,value); }
        }
        private System.String _sluggish;
        public  System.String  Sluggish
        {
           get { return GET(ref _sluggish); }
           set { SET(ref  _sluggish,value); }
        }
        private System.String _nonmotile;
        public  System.String  NonMotile
        {
           get { return GET(ref _nonmotile); }
           set { SET(ref  _nonmotile,value); }
        }
        private System.String _abnormal;
        public  System.String  Abnormal
        {
           get { return GET(ref _abnormal); }
           set { SET(ref  _abnormal,value); }
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
        private System.String _epithelialcell;
        public  System.String  EpithelialCell
        {
           get { return GET(ref _epithelialcell); }
           set { SET(ref  _epithelialcell,value); }
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