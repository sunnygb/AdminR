using System;

namespace ClinicalReporting.Model.Wrapper
{
    public class BloodGroupW : CommonWrapper<BloodGroup>
    {
        private String _antihcv;
        private String _donarbloodgroup;
        private String _donarname;
        private Int32 _fee;
        private String _hbsag;
        private String _patientbloodgroup;
        private Int64 _patientid;
        private PatientW _patientw;
        private Int64 _serialno;
        private DateTime _tdate;

        public BloodGroupW(BloodGroup bloodgroupModel) : base(bloodgroupModel)
        {
            InitializeComplexProperties(bloodgroupModel);
            InitializeCollectionProperties(bloodgroupModel);
        }

        public BloodGroupW() : base(null)
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

        public String PatientBloodGroup
        {
            get { return GET(ref _patientbloodgroup); }
            set { SET(ref _patientbloodgroup, value); }
        }

        public String DonarName
        {
            get { return GET(ref _donarname); }
            set { SET(ref _donarname, value); }
        }

        public String DonarBloodGroup
        {
            get { return GET(ref _donarbloodgroup); }
            set { SET(ref _donarbloodgroup, value); }
        }

        public String HbsAg
        {
            get { return GET(ref _hbsag); }
            set { SET(ref _hbsag, value); }
        }

        public String AntiHCV
        {
            get { return GET(ref _antihcv); }
            set { SET(ref _antihcv, value); }
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

        private void InitializeCollectionProperties(BloodGroup bloodgroupModel)
        {
        }

        private void InitializeComplexProperties(BloodGroup bloodgroupModel)
        {
            // One To One
            if (bloodgroupModel.Patient != null)
            {
                PatientW = new PatientW(
                    bloodgroupModel.Patient);
            }
        }
    }
}