using ClinicalReporting.Data.Services;
using System;

namespace ClinicalReporting.Data.Wrapper
{
    public class UrineExaminationW : CommonWrapper<UrineExamination>
    {
        private String _albumin;
        private String _amorphous;
        private String _bilirubin;
        private String _blood;
        private String _caloxalate;
        private String _cast;
        private String _colour;
        private String _crystals;
        private String _epicells;
        private Int32 _fee;
        private String _ketone;
        private String _others;
        private Int64 _patientid;
        private PatientW _patientw;
        private String _puscells;
        private String _rbc;
        private String _reaction;
        private Int64 _serialno;
        private String _specificgravity;
        private String _sugar;
        private DateTime _tdate;
        private String _uricacid;
        private String _urobilnogen;

        public UrineExaminationW(UrineExamination urineexaminationModel) : base(urineexaminationModel)
        {
            InitializeComplexProperties(urineexaminationModel);
            InitializeCollectionProperties(urineexaminationModel);
        }

        public UrineExaminationW() : base(null)
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

        public String Reaction
        {
            get { return GET(ref _reaction); }
            set { SET(ref _reaction, value); }
        }

        public String SpecificGravity
        {
            get { return GET(ref _specificgravity); }
            set { SET(ref _specificgravity, value); }
        }

        public String Albumin
        {
            get { return GET(ref _albumin); }
            set { SET(ref _albumin, value); }
        }

        public String Sugar
        {
            get { return GET(ref _sugar); }
            set { SET(ref _sugar, value); }
        }

        public String Ketone
        {
            get { return GET(ref _ketone); }
            set { SET(ref _ketone, value); }
        }

        public String Blood
        {
            get { return GET(ref _blood); }
            set { SET(ref _blood, value); }
        }

        public String Bilirubin
        {
            get { return GET(ref _bilirubin); }
            set { SET(ref _bilirubin, value); }
        }

        public String UrobilNogen
        {
            get { return GET(ref _urobilnogen); }
            set { SET(ref _urobilnogen, value); }
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

        public String EPiCells
        {
            get { return GET(ref _epicells); }
            set { SET(ref _epicells, value); }
        }

        public String Cast
        {
            get { return GET(ref _cast); }
            set { SET(ref _cast, value); }
        }

        public String Crystals
        {
            get { return GET(ref _crystals); }
            set { SET(ref _crystals, value); }
        }

        public String CalOxalate
        {
            get { return GET(ref _caloxalate); }
            set { SET(ref _caloxalate, value); }
        }

        public String UricAcid
        {
            get { return GET(ref _uricacid); }
            set { SET(ref _uricacid, value); }
        }

        public String Amorphous
        {
            get { return GET(ref _amorphous); }
            set { SET(ref _amorphous, value); }
        }

        public String Others
        {
            get { return GET(ref _others); }
            set { SET(ref _others, value); }
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

        private void InitializeCollectionProperties(UrineExamination urineexaminationModel)
        {
        }

        private void InitializeComplexProperties(UrineExamination urineexaminationModel)
        {
            // One To One
            if (urineexaminationModel.Patient != null)
            {
                PatientW = new PatientW(
                    urineexaminationModel.Patient);
            }
        }
    }
}