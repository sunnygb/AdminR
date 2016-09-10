using System;

namespace ClinicalReporting.Model.Wrapper
{
    public class SerologyW : CommonWrapper<Serology>
    {
        private String _IGG;
        private String _IGM;
        private String _antihcv;
        private String _asotitre;
        private Int64 _fee;
        private String _hbsag;
        private String _helicobacterpylori;
        private String _hiv;
        private String _igg;
        private String _igm;
        private String _kahnsvdrl;
        private String _mantoex;
        private String _parathyphiah;
        private String _parathyphibh;
        private Int64 _patientid;
        private PatientW _patientw;
        private String _pregnancytest;
        private String _rafactor;
        private Int64 _serialno;
        private String _styphith;
        private String _styphito;
        private String _tbplus;
        private String _tdate;
        private String _typhoid;
        private String _widaltest;

        public SerologyW(Serology serologyModel) : base(serologyModel)
        {
            InitializeComplexProperties(serologyModel);
            InitializeCollectionProperties(serologyModel);
        }

        public SerologyW() : base(null)
        {
        }

        public Int64 Serialno
        {
            get { return GET(ref _serialno); }
            set { SET(ref _serialno, value); }
        }

        public Int64 Patientid
        {
            get { return GET(ref _patientid); }
            set { SET(ref _patientid, value); }
        }

        public String Tdate
        {
            get { return GET(ref _tdate); }
            set { SET(ref _tdate, value); }
        }

        public String WidalTest
        {
            get { return GET(ref _widaltest); }
            set { SET(ref _widaltest, value); }
        }

        public String STyphiTo
        {
            get { return GET(ref _styphito); }
            set { SET(ref _styphito, value); }
        }

        public String STyphiTh
        {
            get { return GET(ref _styphith); }
            set { SET(ref _styphith, value); }
        }

        public String ParaThyphiAh
        {
            get { return GET(ref _parathyphiah); }
            set { SET(ref _parathyphiah, value); }
        }

        public String ParaThyphiBh
        {
            get { return GET(ref _parathyphibh); }
            set { SET(ref _parathyphibh, value); }
        }

        public String Typhoid
        {
            get { return GET(ref _typhoid); }
            set { SET(ref _typhoid, value); }
        }

        public String IGM
        {
            get { return GET(ref _igm); }
            set { SET(ref _igm, value); }
        }

        public String IGG
        {
            get { return GET(ref _igg); }
            set { SET(ref _igg, value); }
        }

        public String HbsAg
        {
            get { return GET(ref _hbsag); }
            set { SET(ref _hbsag, value); }
        }

        public String AsoTitre
        {
            get { return GET(ref _asotitre); }
            set { SET(ref _asotitre, value); }
        }

        public String PregnancyTest
        {
            get { return GET(ref _pregnancytest); }
            set { SET(ref _pregnancytest, value); }
        }

        public String RaFactor
        {
            get { return GET(ref _rafactor); }
            set { SET(ref _rafactor, value); }
        }

        public String AntiHcv
        {
            get { return GET(ref _antihcv); }
            set { SET(ref _antihcv, value); }
        }

        public String Mantoex
        {
            get { return GET(ref _mantoex); }
            set { SET(ref _mantoex, value); }
        }

        public String KahnsVdrl
        {
            get { return GET(ref _kahnsvdrl); }
            set { SET(ref _kahnsvdrl, value); }
        }

        public String TbPlus
        {
            get { return GET(ref _tbplus); }
            set { SET(ref _tbplus, value); }
        }

        public String Igm
        {
            get { return GET(ref _IGM); }
            set { SET(ref _igm, value); }
        }

        public String Igg
        {
            get { return GET(ref _IGG); }
            set { SET(ref _igg, value); }
        }

        public String HelicobacterPylori
        {
            get { return GET(ref _helicobacterpylori); }
            set { SET(ref _helicobacterpylori, value); }
        }

        public String Hiv
        {
            get { return GET(ref _hiv); }
            set { SET(ref _hiv, value); }
        }

        public Int64 Fee
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

        private void InitializeCollectionProperties(Serology serologyModel)
        {
        }

        private void InitializeComplexProperties(Serology serologyModel)
        {
            // One To One
            if (serologyModel.Patient != null)
            {
                PatientW = new PatientW(
                    serologyModel.Patient);
            }
        }
    }
}