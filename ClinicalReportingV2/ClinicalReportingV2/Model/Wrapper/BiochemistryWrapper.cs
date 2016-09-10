using System;

namespace ClinicalReporting.Model.Wrapper
{
    public class BiochemistryW : CommonWrapper<Biochemistry>
    {
        private String _agratio;
        private String _agrationor;
        private String _agratiounit;
        private String _bloodsugar2hpp;
        private String _bloodsugar2hppnor;
        private String _bloodsugar2hppunit;
        private String _bloodsugarfasting;
        private String _bloodsugarfastingnor;
        private String _bloodsugarfastingunit;
        private String _bloodsugarrandom;
        private String _bloodsugarrandomnor;
        private String _bloodsugarrandomunit;
        private String _bloodurea;
        private String _bloodureanor;
        private String _bloodureaunit;
        private String _bun;
        private String _bunnor;
        private String _bununit;
        private String _ckmb;
        private String _ckmbnor;
        private String _ckmbunit;
        private String _cpk;
        private String _cpknor;
        private String _cpkunit;
        private Int32 _fee;
        private String _hdlcholestrol;
        private String _hdlcholestrolnor;
        private String _hdlcholestrolunit;
        private String _ldh;
        private String _ldhnor;
        private String _ldhunit;
        private String _ldlcholestrol;
        private String _ldlcholestrolnor;
        private String _ldlcholestrolunit;
        private Int64 _patientid;
        private PatientW _patientw;
        private String _salbumin;
        private String _salbuminnor;
        private String _salbuminunit;
        private String _salkphosphatase;
        private String _salkphosphatasenor;
        private String _salkphosphataseunit;
        private String _sbilirubind;
        private String _sbilirubindnor;
        private String _sbilirubindunit;
        private String _sbilirubinind;
        private String _sbilirubinindnor;
        private String _sbilirubinindunit;
        private String _sbilirubint;
        private String _sbilirubintnor;
        private String _sbilirubintunit;
        private String _scalcium;
        private String _scalciumnor;
        private String _scalciumunit;
        private String _schloride;
        private String _schloridenor;
        private String _schlorideunit;
        private String _scholestrol;
        private String _scholestrolnor;
        private String _scholestrolunit;
        private String _screatinine;
        private String _screatininenor;
        private String _screatinineunit;
        private Int64 _serialno;
        private String _sgotast;
        private String _sgotastunit;
        private String _sgotnor;
        private String _sgptalt;
        private String _sgptaltnor;
        private String _sgptaltunit;
        private String _spotassium;
        private String _spotassiumnor;
        private String _spotassiumunit;
        private String _sprotein;
        private String _sproteinnor;
        private String _sproteinunit;
        private String _ssodium;
        private String _ssodiumnor;
        private String _ssodiumunit;
        private String _striglycerides;
        private String _striglyceridesnor;
        private String _striglyceridesunit;
        private String _suricacid;
        private String _suricacidnor;
        private String _suricacidunit;
        private DateTime _tdate;

        public BiochemistryW(Biochemistry biochemistryModel) : base(biochemistryModel)
        {
            InitializeComplexProperties(biochemistryModel);
            InitializeCollectionProperties(biochemistryModel);
        }

        public BiochemistryW() : base(null)
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

        public String BloodSugarFasting
        {
            get { return GET(ref _bloodsugarfasting); }
            set { SET(ref _bloodsugarfasting, value); }
        }

        public String BloodSugarFastingUnit
        {
            get { return GET(ref _bloodsugarfastingunit); }
            set { SET(ref _bloodsugarfastingunit, value); }
        }

        public String BloodSugarFastingNor
        {
            get { return GET(ref _bloodsugarfastingnor); }
            set { SET(ref _bloodsugarfastingnor, value); }
        }

        public String BloodSugar2HPP
        {
            get { return GET(ref _bloodsugar2hpp); }
            set { SET(ref _bloodsugar2hpp, value); }
        }

        public String BloodSugar2HPPUnit
        {
            get { return GET(ref _bloodsugar2hppunit); }
            set { SET(ref _bloodsugar2hppunit, value); }
        }

        public String BloodSugar2HPPNor
        {
            get { return GET(ref _bloodsugar2hppnor); }
            set { SET(ref _bloodsugar2hppnor, value); }
        }

        public String BloodSugarRandom
        {
            get { return GET(ref _bloodsugarrandom); }
            set { SET(ref _bloodsugarrandom, value); }
        }

        public String BloodSugarRandomUnit
        {
            get { return GET(ref _bloodsugarrandomunit); }
            set { SET(ref _bloodsugarrandomunit, value); }
        }

        public String BloodSugarRandomNor
        {
            get { return GET(ref _bloodsugarrandomnor); }
            set { SET(ref _bloodsugarrandomnor, value); }
        }

        public String BloodUrea
        {
            get { return GET(ref _bloodurea); }
            set { SET(ref _bloodurea, value); }
        }

        public String BloodUreaUnit
        {
            get { return GET(ref _bloodureaunit); }
            set { SET(ref _bloodureaunit, value); }
        }

        public String BloodUreaNor
        {
            get { return GET(ref _bloodureanor); }
            set { SET(ref _bloodureanor, value); }
        }

        public String Bun
        {
            get { return GET(ref _bun); }
            set { SET(ref _bun, value); }
        }

        public String BUNUnit
        {
            get { return GET(ref _bununit); }
            set { SET(ref _bununit, value); }
        }

        public String BUNNor
        {
            get { return GET(ref _bunnor); }
            set { SET(ref _bunnor, value); }
        }

        public String SCreatinine
        {
            get { return GET(ref _screatinine); }
            set { SET(ref _screatinine, value); }
        }

        public String SCreatinineUnit
        {
            get { return GET(ref _screatinineunit); }
            set { SET(ref _screatinineunit, value); }
        }

        public String SCreatinineNor
        {
            get { return GET(ref _screatininenor); }
            set { SET(ref _screatininenor, value); }
        }

        public String SUricAcid
        {
            get { return GET(ref _suricacid); }
            set { SET(ref _suricacid, value); }
        }

        public String SUricAcidUnit
        {
            get { return GET(ref _suricacidunit); }
            set { SET(ref _suricacidunit, value); }
        }

        public String SUricAcidNor
        {
            get { return GET(ref _suricacidnor); }
            set { SET(ref _suricacidnor, value); }
        }

        public String SCholestrol
        {
            get { return GET(ref _scholestrol); }
            set { SET(ref _scholestrol, value); }
        }

        public String SCholestrolUnit
        {
            get { return GET(ref _scholestrolunit); }
            set { SET(ref _scholestrolunit, value); }
        }

        public String SCholestrolNor
        {
            get { return GET(ref _scholestrolnor); }
            set { SET(ref _scholestrolnor, value); }
        }

        public String STriglycerides
        {
            get { return GET(ref _striglycerides); }
            set { SET(ref _striglycerides, value); }
        }

        public String STriglyceridesUnit
        {
            get { return GET(ref _striglyceridesunit); }
            set { SET(ref _striglyceridesunit, value); }
        }

        public String STriglyceridesNor
        {
            get { return GET(ref _striglyceridesnor); }
            set { SET(ref _striglyceridesnor, value); }
        }

        public String HDLCholestrol
        {
            get { return GET(ref _hdlcholestrol); }
            set { SET(ref _hdlcholestrol, value); }
        }

        public String HDLCholestrolUnit
        {
            get { return GET(ref _hdlcholestrolunit); }
            set { SET(ref _hdlcholestrolunit, value); }
        }

        public String HDLCholestrolNor
        {
            get { return GET(ref _hdlcholestrolnor); }
            set { SET(ref _hdlcholestrolnor, value); }
        }

        public String LDLCholestrol
        {
            get { return GET(ref _ldlcholestrol); }
            set { SET(ref _ldlcholestrol, value); }
        }

        public String LDLCholestrolUnit
        {
            get { return GET(ref _ldlcholestrolunit); }
            set { SET(ref _ldlcholestrolunit, value); }
        }

        public String LDLCholestrolNor
        {
            get { return GET(ref _ldlcholestrolnor); }
            set { SET(ref _ldlcholestrolnor, value); }
        }

        public String SgotAst
        {
            get { return GET(ref _sgotast); }
            set { SET(ref _sgotast, value); }
        }

        public String SGOTASTUnit
        {
            get { return GET(ref _sgotastunit); }
            set { SET(ref _sgotastunit, value); }
        }

        public String SGOTNor
        {
            get { return GET(ref _sgotnor); }
            set { SET(ref _sgotnor, value); }
        }

        public String Ldh
        {
            get { return GET(ref _ldh); }
            set { SET(ref _ldh, value); }
        }

        public String LDHUnit
        {
            get { return GET(ref _ldhunit); }
            set { SET(ref _ldhunit, value); }
        }

        public String LDHNor
        {
            get { return GET(ref _ldhnor); }
            set { SET(ref _ldhnor, value); }
        }

        public String Cpk
        {
            get { return GET(ref _cpk); }
            set { SET(ref _cpk, value); }
        }

        public String CPKUnit
        {
            get { return GET(ref _cpkunit); }
            set { SET(ref _cpkunit, value); }
        }

        public String CPKNor
        {
            get { return GET(ref _cpknor); }
            set { SET(ref _cpknor, value); }
        }

        public String Ckmb
        {
            get { return GET(ref _ckmb); }
            set { SET(ref _ckmb, value); }
        }

        public String CKMBUnit
        {
            get { return GET(ref _ckmbunit); }
            set { SET(ref _ckmbunit, value); }
        }

        public String CKMBNor
        {
            get { return GET(ref _ckmbnor); }
            set { SET(ref _ckmbnor, value); }
        }

        public String SBilirubinT
        {
            get { return GET(ref _sbilirubint); }
            set { SET(ref _sbilirubint, value); }
        }

        public String SBilirubinTUnit
        {
            get { return GET(ref _sbilirubintunit); }
            set { SET(ref _sbilirubintunit, value); }
        }

        public String SBilirubinTNor
        {
            get { return GET(ref _sbilirubintnor); }
            set { SET(ref _sbilirubintnor, value); }
        }

        public String SBilirubinD
        {
            get { return GET(ref _sbilirubind); }
            set { SET(ref _sbilirubind, value); }
        }

        public String SBilirubinDUnit
        {
            get { return GET(ref _sbilirubindunit); }
            set { SET(ref _sbilirubindunit, value); }
        }

        public String SBilirubinDNor
        {
            get { return GET(ref _sbilirubindnor); }
            set { SET(ref _sbilirubindnor, value); }
        }

        public String SBilirubinInd
        {
            get { return GET(ref _sbilirubinind); }
            set { SET(ref _sbilirubinind, value); }
        }

        public String SBilirubinIndUnit
        {
            get { return GET(ref _sbilirubinindunit); }
            set { SET(ref _sbilirubinindunit, value); }
        }

        public String SBilirubinIndNor
        {
            get { return GET(ref _sbilirubinindnor); }
            set { SET(ref _sbilirubinindnor, value); }
        }

        public String SAlkPhosphatase
        {
            get { return GET(ref _salkphosphatase); }
            set { SET(ref _salkphosphatase, value); }
        }

        public String SAlkPhosphataseUnit
        {
            get { return GET(ref _salkphosphataseunit); }
            set { SET(ref _salkphosphataseunit, value); }
        }

        public String SAlkPhosphataseNor
        {
            get { return GET(ref _salkphosphatasenor); }
            set { SET(ref _salkphosphatasenor, value); }
        }

        public String SgptAlt
        {
            get { return GET(ref _sgptalt); }
            set { SET(ref _sgptalt, value); }
        }

        public String SGPTALTUnit
        {
            get { return GET(ref _sgptaltunit); }
            set { SET(ref _sgptaltunit, value); }
        }

        public String SGPTALTNor
        {
            get { return GET(ref _sgptaltnor); }
            set { SET(ref _sgptaltnor, value); }
        }

        public String SSodium
        {
            get { return GET(ref _ssodium); }
            set { SET(ref _ssodium, value); }
        }

        public String SSodiumUnit
        {
            get { return GET(ref _ssodiumunit); }
            set { SET(ref _ssodiumunit, value); }
        }

        public String SSodiumNor
        {
            get { return GET(ref _ssodiumnor); }
            set { SET(ref _ssodiumnor, value); }
        }

        public String SPotassium
        {
            get { return GET(ref _spotassium); }
            set { SET(ref _spotassium, value); }
        }

        public String SPotassiumUnit
        {
            get { return GET(ref _spotassiumunit); }
            set { SET(ref _spotassiumunit, value); }
        }

        public String SPotassiumNor
        {
            get { return GET(ref _spotassiumnor); }
            set { SET(ref _spotassiumnor, value); }
        }

        public String SChloride
        {
            get { return GET(ref _schloride); }
            set { SET(ref _schloride, value); }
        }

        public String SChlorideUnit
        {
            get { return GET(ref _schlorideunit); }
            set { SET(ref _schlorideunit, value); }
        }

        public String SChlorideNor
        {
            get { return GET(ref _schloridenor); }
            set { SET(ref _schloridenor, value); }
        }

        public String SCalcium
        {
            get { return GET(ref _scalcium); }
            set { SET(ref _scalcium, value); }
        }

        public String SCalciumUnit
        {
            get { return GET(ref _scalciumunit); }
            set { SET(ref _scalciumunit, value); }
        }

        public String SCalciumNor
        {
            get { return GET(ref _scalciumnor); }
            set { SET(ref _scalciumnor, value); }
        }

        public String SProtein
        {
            get { return GET(ref _sprotein); }
            set { SET(ref _sprotein, value); }
        }

        public String SProteinUnit
        {
            get { return GET(ref _sproteinunit); }
            set { SET(ref _sproteinunit, value); }
        }

        public String SProteinNor
        {
            get { return GET(ref _sproteinnor); }
            set { SET(ref _sproteinnor, value); }
        }

        public String SAlbumin
        {
            get { return GET(ref _salbumin); }
            set { SET(ref _salbumin, value); }
        }

        public String SAlbuminUnit
        {
            get { return GET(ref _salbuminunit); }
            set { SET(ref _salbuminunit, value); }
        }

        public String SAlbuminNor
        {
            get { return GET(ref _salbuminnor); }
            set { SET(ref _salbuminnor, value); }
        }

        public String AGRatio
        {
            get { return GET(ref _agratio); }
            set { SET(ref _agratio, value); }
        }

        public String AGRatioUnit
        {
            get { return GET(ref _agratiounit); }
            set { SET(ref _agratiounit, value); }
        }

        public String AGRatioNor
        {
            get { return GET(ref _agrationor); }
            set { SET(ref _agrationor, value); }
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

        private void InitializeCollectionProperties(Biochemistry biochemistryModel)
        {
        }

        private void InitializeComplexProperties(Biochemistry biochemistryModel)
        {
            // One To One
            if (biochemistryModel.Patient != null)
            {
                PatientW = new PatientW(
                    biochemistryModel.Patient);
            }
        }
    }
}