using ClinicalReporting.Data.Services;
using System;

namespace ClinicalReporting.Data.Wrapper
{
    public class ElisaTbW : CommonWrapper<ElisaTb>
    {
        private Double _cutoffvalue;
        private Int32 _fee;
        private Int64 _patientid;
        private Double _patientvalue;
        private PatientW _patientw;
        private Int64 _serialno;
        private DateTime _tdate;

        public ElisaTbW(ElisaTb elisatbModel) : base(elisatbModel)
        {
            InitializeComplexProperties(elisatbModel);
            InitializeCollectionProperties(elisatbModel);
        }

        public ElisaTbW() : base(null)
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

        public Double PatientValue
        {
            get { return GET(ref _patientvalue); }
            set { SET(ref _patientvalue, value); }
        }

        public Double CutOffValue
        {
            get { return GET(ref _cutoffvalue); }
            set { SET(ref _cutoffvalue, value); }
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

        private void InitializeCollectionProperties(ElisaTb elisatbModel)
        {
        }

        private void InitializeComplexProperties(ElisaTb elisatbModel)
        {
            // One To One
            if (elisatbModel.Patient != null)
            {
                PatientW = new PatientW(
                    elisatbModel.Patient);
            }
        }
    }
}