using ClinicalReporting.Data.Services;
using System;

namespace ClinicalReporting.Data.Wrapper
{
    public class SemenAnalysisW : CommonWrapper<SemenAnalysis>
    {
        private String _abnormal;
        private String _activemotility;
        private String _colour;
        private String _epithelialcell;
        private Int32 _fee;
        private String _nonmotile;
        private Int64 _patientid;
        private PatientW _patientw;
        private String _ph;
        private String _puscells;
        private String _quantity;
        private String _rbc;
        private Int64 _serialno;
        private String _sluggish;
        private DateTime _tdate;
        private String _timeofcollection;
        private String _timeofexamination;
        private String _totalcount;

        public SemenAnalysisW(SemenAnalysis semenanalysisModel) : base(semenanalysisModel)
        {
            InitializeComplexProperties(semenanalysisModel);
            InitializeCollectionProperties(semenanalysisModel);
        }

        public SemenAnalysisW() : base(null)
        {
        }

        public Int64 SerialNo
        {
            get { return GET(ref _serialno); }
            set { SET(ref _serialno, value); }
        }

        public Int64 PatientID
        {
            get { return GET(ref _patientid); }
            set { SET(ref _patientid, value); }
        }

        public DateTime TDate
        {
            get { return GET(ref _tdate); }
            set { SET(ref _tdate, value); }
        }

        public String Colour
        {
            get { return GET(ref _colour); }
            set { SET(ref _colour, value); }
        }

        public String Quantity
        {
            get { return GET(ref _quantity); }
            set { SET(ref _quantity, value); }
        }

        public String Ph
        {
            get { return GET(ref _ph); }
            set { SET(ref _ph, value); }
        }

        public String TimeOfCollection
        {
            get { return GET(ref _timeofcollection); }
            set { SET(ref _timeofcollection, value); }
        }

        public String TimeOfExamination
        {
            get { return GET(ref _timeofexamination); }
            set { SET(ref _timeofexamination, value); }
        }

        public String TotalCount
        {
            get { return GET(ref _totalcount); }
            set { SET(ref _totalcount, value); }
        }

        public String ActiveMotility
        {
            get { return GET(ref _activemotility); }
            set { SET(ref _activemotility, value); }
        }

        public String Sluggish
        {
            get { return GET(ref _sluggish); }
            set { SET(ref _sluggish, value); }
        }

        public String NonMotile
        {
            get { return GET(ref _nonmotile); }
            set { SET(ref _nonmotile, value); }
        }

        public String Abnormal
        {
            get { return GET(ref _abnormal); }
            set { SET(ref _abnormal, value); }
        }

        public String PusCells
        {
            get { return GET(ref _puscells); }
            set { SET(ref _puscells, value); }
        }

        public String Rbc
        {
            get { return GET(ref _rbc); }
            set { SET(ref _rbc, value); }
        }

        public String EpithelialCell
        {
            get { return GET(ref _epithelialcell); }
            set { SET(ref _epithelialcell, value); }
        }

        public Int32 Fee
        {
            get { return GET(ref _fee); }
            set { SET(ref _fee, value); }
        }

        // One To One

        public PatientW PatientW
        {
            get { return _patientw; }
            set
            {
                _patientw = value;
                if (!Equals(_patientw, Model.Patient))
                {
                    Model.Patient = _patientw.Model;
                }
                ;
            }
        }

        private void InitializeCollectionProperties(SemenAnalysis semenanalysisModel)
        {
        }

        private void InitializeComplexProperties(SemenAnalysis semenanalysisModel)
        {
            // One To One
            if (semenanalysisModel.Patient != null)
            {
                PatientW = new PatientW(
                    semenanalysisModel.Patient);
            }
        }
    }
}