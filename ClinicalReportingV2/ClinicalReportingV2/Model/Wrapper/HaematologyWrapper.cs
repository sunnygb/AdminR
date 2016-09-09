using ClinicalReporting.Data.Services;
using System;

namespace ClinicalReporting.Data.Wrapper
{
    public class HaematologyW : CommonWrapper<Haematology>
    {
        private String _basophil;
        private String _basophilnor;
        private String _basophilunit;
        private String _bloodgroup;
        private String _bloodgroupnor;
        private String _bloodgroupunit;
        private String _bt;
        private String _btnor;
        private String _btunit;
        private String _ct;
        private String _ctnor;
        private String _ctunit;
        private String _dlc;
        private String _dlcnor;
        private String _dlcunit;
        private String _eosinophil;
        private String _eosinophilnor;
        private String _eosinophilunit;
        private String _esr;
        private String _esrnor;
        private String _esrunit;
        private Int32 _fee;
        private String _hb;
        private String _hbnor;
        private String _hbunit;
        private String _lymphocytes;
        private String _lymphocytesnor;
        private String _lymphocytesunit;
        private String _malariaparasites;
        private String _malariaparasitesnor;
        private String _malariaparasitesunit;
        private String _mch;
        private String _mchc;
        private String _mchcnor;
        private String _mchcunit;
        private String _mchnor;
        private String _mchunit;
        private String _mcv;
        private String _mcvnor;
        private String _mcvunit;
        private String _monocyte;
        private String _monocytenor;
        private String _monocyteunit;
        private Int64 _patientid;
        private PatientW _patientw;
        private String _plateletscount;
        private String _plateletscountnor;
        private String _plateletscountunit;
        private String _polymorphs;
        private String _polymorphsnor;
        private String _polymorphsunit;
        private String _pt;
        private String _ptnor;
        private String _ptunit;
        private String _pvchaematorcrit;
        private String _pvchaematorcritnor;
        private String _pvchaematorcritunit;
        private String _rhfactor;
        private String _rhfactornor;
        private String _rhfactorunit;
        private Int64 _serialno;
        private DateTime _tdate;
        private String _tlc;
        private String _tlcnor;
        private String _tlcunit;
        private String _totalrbc;
        private String _totalrbcnor;
        private String _totalrbcunit;

        public HaematologyW(Haematology haematologyModel) : base(haematologyModel)
        {
            InitializeComplexProperties(haematologyModel);
            InitializeCollectionProperties(haematologyModel);
        }

        public HaematologyW() : base(null)
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

        public String Hb
        {
            get { return GET(ref _hb); }
            set { SET(ref _hb, value); }
        }

        public String HBUnit
        {
            get { return GET(ref _hbunit); }
            set { SET(ref _hbunit, value); }
        }

        public String HBNor
        {
            get { return GET(ref _hbnor); }
            set { SET(ref _hbnor, value); }
        }

        public String Tlc
        {
            get { return GET(ref _tlc); }
            set { SET(ref _tlc, value); }
        }

        public String TLCUnit
        {
            get { return GET(ref _tlcunit); }
            set { SET(ref _tlcunit, value); }
        }

        public String TLCNor
        {
            get { return GET(ref _tlcnor); }
            set { SET(ref _tlcnor, value); }
        }

        public String Esr
        {
            get { return GET(ref _esr); }
            set { SET(ref _esr, value); }
        }

        public String ESRUnit
        {
            get { return GET(ref _esrunit); }
            set { SET(ref _esrunit, value); }
        }

        public String ESRNor
        {
            get { return GET(ref _esrnor); }
            set { SET(ref _esrnor, value); }
        }

        public String Bt
        {
            get { return GET(ref _bt); }
            set { SET(ref _bt, value); }
        }

        public String BTUnit
        {
            get { return GET(ref _btunit); }
            set { SET(ref _btunit, value); }
        }

        public String BTNor
        {
            get { return GET(ref _btnor); }
            set { SET(ref _btnor, value); }
        }

        public String Ct
        {
            get { return GET(ref _ct); }
            set { SET(ref _ct, value); }
        }

        public String CTUnit
        {
            get { return GET(ref _ctunit); }
            set { SET(ref _ctunit, value); }
        }

        public String CTNor
        {
            get { return GET(ref _ctnor); }
            set { SET(ref _ctnor, value); }
        }

        public String PlateletsCount
        {
            get { return GET(ref _plateletscount); }
            set { SET(ref _plateletscount, value); }
        }

        public String PlateletsCountUnit
        {
            get { return GET(ref _plateletscountunit); }
            set { SET(ref _plateletscountunit, value); }
        }

        public String PlateletsCountNor
        {
            get { return GET(ref _plateletscountnor); }
            set { SET(ref _plateletscountnor, value); }
        }

        public String Pt
        {
            get { return GET(ref _pt); }
            set { SET(ref _pt, value); }
        }

        public String PTUnit
        {
            get { return GET(ref _ptunit); }
            set { SET(ref _ptunit, value); }
        }

        public String PTNor
        {
            get { return GET(ref _ptnor); }
            set { SET(ref _ptnor, value); }
        }

        public String Dlc
        {
            get { return GET(ref _dlc); }
            set { SET(ref _dlc, value); }
        }

        public String DLCUnit
        {
            get { return GET(ref _dlcunit); }
            set { SET(ref _dlcunit, value); }
        }

        public String DLCNor
        {
            get { return GET(ref _dlcnor); }
            set { SET(ref _dlcnor, value); }
        }

        public String Polymorphs
        {
            get { return GET(ref _polymorphs); }
            set { SET(ref _polymorphs, value); }
        }

        public String PolymorphsUnit
        {
            get { return GET(ref _polymorphsunit); }
            set { SET(ref _polymorphsunit, value); }
        }

        public String PolymorphsNor
        {
            get { return GET(ref _polymorphsnor); }
            set { SET(ref _polymorphsnor, value); }
        }

        public String Lymphocytes
        {
            get { return GET(ref _lymphocytes); }
            set { SET(ref _lymphocytes, value); }
        }

        public String LymphocytesUnit
        {
            get { return GET(ref _lymphocytesunit); }
            set { SET(ref _lymphocytesunit, value); }
        }

        public String LymphocytesNor
        {
            get { return GET(ref _lymphocytesnor); }
            set { SET(ref _lymphocytesnor, value); }
        }

        public String Monocyte
        {
            get { return GET(ref _monocyte); }
            set { SET(ref _monocyte, value); }
        }

        public String MonocyteUnit
        {
            get { return GET(ref _monocyteunit); }
            set { SET(ref _monocyteunit, value); }
        }

        public String MonocyteNor
        {
            get { return GET(ref _monocytenor); }
            set { SET(ref _monocytenor, value); }
        }

        public String Eosinophil
        {
            get { return GET(ref _eosinophil); }
            set { SET(ref _eosinophil, value); }
        }

        public String EosinophilUnit
        {
            get { return GET(ref _eosinophilunit); }
            set { SET(ref _eosinophilunit, value); }
        }

        public String EosinophilNor
        {
            get { return GET(ref _eosinophilnor); }
            set { SET(ref _eosinophilnor, value); }
        }

        public String Basophil
        {
            get { return GET(ref _basophil); }
            set { SET(ref _basophil, value); }
        }

        public String BasophilUnit
        {
            get { return GET(ref _basophilunit); }
            set { SET(ref _basophilunit, value); }
        }

        public String BasophilNor
        {
            get { return GET(ref _basophilnor); }
            set { SET(ref _basophilnor, value); }
        }

        public String MalariaParasites
        {
            get { return GET(ref _malariaparasites); }
            set { SET(ref _malariaparasites, value); }
        }

        public String MalariaParasitesUnit
        {
            get { return GET(ref _malariaparasitesunit); }
            set { SET(ref _malariaparasitesunit, value); }
        }

        public String MalariaParasitesNor
        {
            get { return GET(ref _malariaparasitesnor); }
            set { SET(ref _malariaparasitesnor, value); }
        }

        public String BloodGroup
        {
            get { return GET(ref _bloodgroup); }
            set { SET(ref _bloodgroup, value); }
        }

        public String BloodGroupUnit
        {
            get { return GET(ref _bloodgroupunit); }
            set { SET(ref _bloodgroupunit, value); }
        }

        public String BloodGroupNor
        {
            get { return GET(ref _bloodgroupnor); }
            set { SET(ref _bloodgroupnor, value); }
        }

        public String RHFactor
        {
            get { return GET(ref _rhfactor); }
            set { SET(ref _rhfactor, value); }
        }

        public String RHFactorUnit
        {
            get { return GET(ref _rhfactorunit); }
            set { SET(ref _rhfactorunit, value); }
        }

        public String RHFactorNor
        {
            get { return GET(ref _rhfactornor); }
            set { SET(ref _rhfactornor, value); }
        }

        public String TotalRBC
        {
            get { return GET(ref _totalrbc); }
            set { SET(ref _totalrbc, value); }
        }

        public String TotalRBCUnit
        {
            get { return GET(ref _totalrbcunit); }
            set { SET(ref _totalrbcunit, value); }
        }

        public String TotalRBCNor
        {
            get { return GET(ref _totalrbcnor); }
            set { SET(ref _totalrbcnor, value); }
        }

        public String PVCHaematorcrit
        {
            get { return GET(ref _pvchaematorcrit); }
            set { SET(ref _pvchaematorcrit, value); }
        }

        public String PVCHaematorcritUnit
        {
            get { return GET(ref _pvchaematorcritunit); }
            set { SET(ref _pvchaematorcritunit, value); }
        }

        public String PVCHaematorcritNor
        {
            get { return GET(ref _pvchaematorcritnor); }
            set { SET(ref _pvchaematorcritnor, value); }
        }

        public String MCV
        {
            get { return GET(ref _mcv); }
            set { SET(ref _mcv, value); }
        }

        public String MCVUnit
        {
            get { return GET(ref _mcvunit); }
            set { SET(ref _mcvunit, value); }
        }

        public String MCVNor
        {
            get { return GET(ref _mcvnor); }
            set { SET(ref _mcvnor, value); }
        }

        public String MCH
        {
            get { return GET(ref _mch); }
            set { SET(ref _mch, value); }
        }

        public String MCHUnit
        {
            get { return GET(ref _mchunit); }
            set { SET(ref _mchunit, value); }
        }

        public String MCHNor
        {
            get { return GET(ref _mchnor); }
            set { SET(ref _mchnor, value); }
        }

        public String MCHC
        {
            get { return GET(ref _mchc); }
            set { SET(ref _mchc, value); }
        }

        public String MCHCUnit
        {
            get { return GET(ref _mchcunit); }
            set { SET(ref _mchcunit, value); }
        }

        public String MCHCNor
        {
            get { return GET(ref _mchcnor); }
            set { SET(ref _mchcnor, value); }
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

        private void InitializeCollectionProperties(Haematology haematologyModel)
        {
        }

        private void InitializeComplexProperties(Haematology haematologyModel)
        {
            // One To One
            if (haematologyModel.Patient != null)
            {
                PatientW = new PatientW(
                    haematologyModel.Patient);
            }
        }
    }
}