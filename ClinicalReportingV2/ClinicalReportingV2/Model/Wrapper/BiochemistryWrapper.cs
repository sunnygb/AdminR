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
    public partial class BiochemistryW : CommonWrapper<Biochemistry>
    {
        public BiochemistryW(Biochemistry biochemistryModel):base(biochemistryModel)
        {
           
           InitializeComplexProperties(biochemistryModel);
           InitializeCollectionProperties(biochemistryModel);
           
           
        }
        
        private void InitializeCollectionProperties(Biochemistry biochemistryModel)
        {
        }
        
        private void InitializeComplexProperties(Biochemistry biochemistryModel)
        {
        
           // One To One
           if(biochemistryModel.Patient !=null)
           {
               this.PatientW = new PatientW(
               biochemistryModel.Patient);
           }
        }
          
        public BiochemistryW():base(null){}
        
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
        private System.String _bloodsugarfasting;
        public  System.String  BloodSugarFasting
        {
           get { return GET(ref _bloodsugarfasting); }
           set { SET(ref  _bloodsugarfasting,value); }
        }
        private System.String _bloodsugarfastingunit;
        public  System.String  BloodSugarFastingUnit
        {
           get { return GET(ref _bloodsugarfastingunit); }
           set { SET(ref  _bloodsugarfastingunit,value); }
        }
        private System.String _bloodsugarfastingnor;
        public  System.String  BloodSugarFastingNor
        {
           get { return GET(ref _bloodsugarfastingnor); }
           set { SET(ref  _bloodsugarfastingnor,value); }
        }
        private System.String _bloodsugar2hpp;
        public  System.String  BloodSugar2HPP
        {
           get { return GET(ref _bloodsugar2hpp); }
           set { SET(ref  _bloodsugar2hpp,value); }
        }
        private System.String _bloodsugar2hppunit;
        public  System.String  BloodSugar2HPPUnit
        {
           get { return GET(ref _bloodsugar2hppunit); }
           set { SET(ref  _bloodsugar2hppunit,value); }
        }
        private System.String _bloodsugar2hppnor;
        public  System.String  BloodSugar2HPPNor
        {
           get { return GET(ref _bloodsugar2hppnor); }
           set { SET(ref  _bloodsugar2hppnor,value); }
        }
        private System.String _bloodsugarrandom;
        public  System.String  BloodSugarRandom
        {
           get { return GET(ref _bloodsugarrandom); }
           set { SET(ref  _bloodsugarrandom,value); }
        }
        private System.String _bloodsugarrandomunit;
        public  System.String  BloodSugarRandomUnit
        {
           get { return GET(ref _bloodsugarrandomunit); }
           set { SET(ref  _bloodsugarrandomunit,value); }
        }
        private System.String _bloodsugarrandomnor;
        public  System.String  BloodSugarRandomNor
        {
           get { return GET(ref _bloodsugarrandomnor); }
           set { SET(ref  _bloodsugarrandomnor,value); }
        }
        private System.String _bloodurea;
        public  System.String  BloodUrea
        {
           get { return GET(ref _bloodurea); }
           set { SET(ref  _bloodurea,value); }
        }
        private System.String _bloodureaunit;
        public  System.String  BloodUreaUnit
        {
           get { return GET(ref _bloodureaunit); }
           set { SET(ref  _bloodureaunit,value); }
        }
        private System.String _bloodureanor;
        public  System.String  BloodUreaNor
        {
           get { return GET(ref _bloodureanor); }
           set { SET(ref  _bloodureanor,value); }
        }
        private System.String _bun;
        public  System.String  Bun
        {
           get { return GET(ref _bun); }
           set { SET(ref  _bun,value); }
        }
        private System.String _bununit;
        public  System.String  BUNUnit
        {
           get { return GET(ref _bununit); }
           set { SET(ref  _bununit,value); }
        }
        private System.String _bunnor;
        public  System.String  BUNNor
        {
           get { return GET(ref _bunnor); }
           set { SET(ref  _bunnor,value); }
        }
        private System.String _screatinine;
        public  System.String  SCreatinine
        {
           get { return GET(ref _screatinine); }
           set { SET(ref  _screatinine,value); }
        }
        private System.String _screatinineunit;
        public  System.String  SCreatinineUnit
        {
           get { return GET(ref _screatinineunit); }
           set { SET(ref  _screatinineunit,value); }
        }
        private System.String _screatininenor;
        public  System.String  SCreatinineNor
        {
           get { return GET(ref _screatininenor); }
           set { SET(ref  _screatininenor,value); }
        }
        private System.String _suricacid;
        public  System.String  SUricAcid
        {
           get { return GET(ref _suricacid); }
           set { SET(ref  _suricacid,value); }
        }
        private System.String _suricacidunit;
        public  System.String  SUricAcidUnit
        {
           get { return GET(ref _suricacidunit); }
           set { SET(ref  _suricacidunit,value); }
        }
        private System.String _suricacidnor;
        public  System.String  SUricAcidNor
        {
           get { return GET(ref _suricacidnor); }
           set { SET(ref  _suricacidnor,value); }
        }
        private System.String _scholestrol;
        public  System.String  SCholestrol
        {
           get { return GET(ref _scholestrol); }
           set { SET(ref  _scholestrol,value); }
        }
        private System.String _scholestrolunit;
        public  System.String  SCholestrolUnit
        {
           get { return GET(ref _scholestrolunit); }
           set { SET(ref  _scholestrolunit,value); }
        }
        private System.String _scholestrolnor;
        public  System.String  SCholestrolNor
        {
           get { return GET(ref _scholestrolnor); }
           set { SET(ref  _scholestrolnor,value); }
        }
        private System.String _striglycerides;
        public  System.String  STriglycerides
        {
           get { return GET(ref _striglycerides); }
           set { SET(ref  _striglycerides,value); }
        }
        private System.String _striglyceridesunit;
        public  System.String  STriglyceridesUnit
        {
           get { return GET(ref _striglyceridesunit); }
           set { SET(ref  _striglyceridesunit,value); }
        }
        private System.String _striglyceridesnor;
        public  System.String  STriglyceridesNor
        {
           get { return GET(ref _striglyceridesnor); }
           set { SET(ref  _striglyceridesnor,value); }
        }
        private System.String _hdlcholestrol;
        public  System.String  HDLCholestrol
        {
           get { return GET(ref _hdlcholestrol); }
           set { SET(ref  _hdlcholestrol,value); }
        }
        private System.String _hdlcholestrolunit;
        public  System.String  HDLCholestrolUnit
        {
           get { return GET(ref _hdlcholestrolunit); }
           set { SET(ref  _hdlcholestrolunit,value); }
        }
        private System.String _hdlcholestrolnor;
        public  System.String  HDLCholestrolNor
        {
           get { return GET(ref _hdlcholestrolnor); }
           set { SET(ref  _hdlcholestrolnor,value); }
        }
        private System.String _ldlcholestrol;
        public  System.String  LDLCholestrol
        {
           get { return GET(ref _ldlcholestrol); }
           set { SET(ref  _ldlcholestrol,value); }
        }
        private System.String _ldlcholestrolunit;
        public  System.String  LDLCholestrolUnit
        {
           get { return GET(ref _ldlcholestrolunit); }
           set { SET(ref  _ldlcholestrolunit,value); }
        }
        private System.String _ldlcholestrolnor;
        public  System.String  LDLCholestrolNor
        {
           get { return GET(ref _ldlcholestrolnor); }
           set { SET(ref  _ldlcholestrolnor,value); }
        }
        private System.String _sgotast;
        public  System.String  SgotAst
        {
           get { return GET(ref _sgotast); }
           set { SET(ref  _sgotast,value); }
        }
        private System.String _sgotastunit;
        public  System.String  SGOTASTUnit
        {
           get { return GET(ref _sgotastunit); }
           set { SET(ref  _sgotastunit,value); }
        }
        private System.String _sgotnor;
        public  System.String  SGOTNor
        {
           get { return GET(ref _sgotnor); }
           set { SET(ref  _sgotnor,value); }
        }
        private System.String _ldh;
        public  System.String  Ldh
        {
           get { return GET(ref _ldh); }
           set { SET(ref  _ldh,value); }
        }
        private System.String _ldhunit;
        public  System.String  LDHUnit
        {
           get { return GET(ref _ldhunit); }
           set { SET(ref  _ldhunit,value); }
        }
        private System.String _ldhnor;
        public  System.String  LDHNor
        {
           get { return GET(ref _ldhnor); }
           set { SET(ref  _ldhnor,value); }
        }
        private System.String _cpk;
        public  System.String  Cpk
        {
           get { return GET(ref _cpk); }
           set { SET(ref  _cpk,value); }
        }
        private System.String _cpkunit;
        public  System.String  CPKUnit
        {
           get { return GET(ref _cpkunit); }
           set { SET(ref  _cpkunit,value); }
        }
        private System.String _cpknor;
        public  System.String  CPKNor
        {
           get { return GET(ref _cpknor); }
           set { SET(ref  _cpknor,value); }
        }
        private System.String _ckmb;
        public  System.String  Ckmb
        {
           get { return GET(ref _ckmb); }
           set { SET(ref  _ckmb,value); }
        }
        private System.String _ckmbunit;
        public  System.String  CKMBUnit
        {
           get { return GET(ref _ckmbunit); }
           set { SET(ref  _ckmbunit,value); }
        }
        private System.String _ckmbnor;
        public  System.String  CKMBNor
        {
           get { return GET(ref _ckmbnor); }
           set { SET(ref  _ckmbnor,value); }
        }
        private System.String _sbilirubint;
        public  System.String  SBilirubinT
        {
           get { return GET(ref _sbilirubint); }
           set { SET(ref  _sbilirubint,value); }
        }
        private System.String _sbilirubintunit;
        public  System.String  SBilirubinTUnit
        {
           get { return GET(ref _sbilirubintunit); }
           set { SET(ref  _sbilirubintunit,value); }
        }
        private System.String _sbilirubintnor;
        public  System.String  SBilirubinTNor
        {
           get { return GET(ref _sbilirubintnor); }
           set { SET(ref  _sbilirubintnor,value); }
        }
        private System.String _sbilirubind;
        public  System.String  SBilirubinD
        {
           get { return GET(ref _sbilirubind); }
           set { SET(ref  _sbilirubind,value); }
        }
        private System.String _sbilirubindunit;
        public  System.String  SBilirubinDUnit
        {
           get { return GET(ref _sbilirubindunit); }
           set { SET(ref  _sbilirubindunit,value); }
        }
        private System.String _sbilirubindnor;
        public  System.String  SBilirubinDNor
        {
           get { return GET(ref _sbilirubindnor); }
           set { SET(ref  _sbilirubindnor,value); }
        }
        private System.String _sbilirubinind;
        public  System.String  SBilirubinInd
        {
           get { return GET(ref _sbilirubinind); }
           set { SET(ref  _sbilirubinind,value); }
        }
        private System.String _sbilirubinindunit;
        public  System.String  SBilirubinIndUnit
        {
           get { return GET(ref _sbilirubinindunit); }
           set { SET(ref  _sbilirubinindunit,value); }
        }
        private System.String _sbilirubinindnor;
        public  System.String  SBilirubinIndNor
        {
           get { return GET(ref _sbilirubinindnor); }
           set { SET(ref  _sbilirubinindnor,value); }
        }
        private System.String _salkphosphatase;
        public  System.String  SAlkPhosphatase
        {
           get { return GET(ref _salkphosphatase); }
           set { SET(ref  _salkphosphatase,value); }
        }
        private System.String _salkphosphataseunit;
        public  System.String  SAlkPhosphataseUnit
        {
           get { return GET(ref _salkphosphataseunit); }
           set { SET(ref  _salkphosphataseunit,value); }
        }
        private System.String _salkphosphatasenor;
        public  System.String  SAlkPhosphataseNor
        {
           get { return GET(ref _salkphosphatasenor); }
           set { SET(ref  _salkphosphatasenor,value); }
        }
        private System.String _sgptalt;
        public  System.String  SgptAlt
        {
           get { return GET(ref _sgptalt); }
           set { SET(ref  _sgptalt,value); }
        }
        private System.String _sgptaltunit;
        public  System.String  SGPTALTUnit
        {
           get { return GET(ref _sgptaltunit); }
           set { SET(ref  _sgptaltunit,value); }
        }
        private System.String _sgptaltnor;
        public  System.String  SGPTALTNor
        {
           get { return GET(ref _sgptaltnor); }
           set { SET(ref  _sgptaltnor,value); }
        }
        private System.String _ssodium;
        public  System.String  SSodium
        {
           get { return GET(ref _ssodium); }
           set { SET(ref  _ssodium,value); }
        }
        private System.String _ssodiumunit;
        public  System.String  SSodiumUnit
        {
           get { return GET(ref _ssodiumunit); }
           set { SET(ref  _ssodiumunit,value); }
        }
        private System.String _ssodiumnor;
        public  System.String  SSodiumNor
        {
           get { return GET(ref _ssodiumnor); }
           set { SET(ref  _ssodiumnor,value); }
        }
        private System.String _spotassium;
        public  System.String  SPotassium
        {
           get { return GET(ref _spotassium); }
           set { SET(ref  _spotassium,value); }
        }
        private System.String _spotassiumunit;
        public  System.String  SPotassiumUnit
        {
           get { return GET(ref _spotassiumunit); }
           set { SET(ref  _spotassiumunit,value); }
        }
        private System.String _spotassiumnor;
        public  System.String  SPotassiumNor
        {
           get { return GET(ref _spotassiumnor); }
           set { SET(ref  _spotassiumnor,value); }
        }
        private System.String _schloride;
        public  System.String  SChloride
        {
           get { return GET(ref _schloride); }
           set { SET(ref  _schloride,value); }
        }
        private System.String _schlorideunit;
        public  System.String  SChlorideUnit
        {
           get { return GET(ref _schlorideunit); }
           set { SET(ref  _schlorideunit,value); }
        }
        private System.String _schloridenor;
        public  System.String  SChlorideNor
        {
           get { return GET(ref _schloridenor); }
           set { SET(ref  _schloridenor,value); }
        }
        private System.String _scalcium;
        public  System.String  SCalcium
        {
           get { return GET(ref _scalcium); }
           set { SET(ref  _scalcium,value); }
        }
        private System.String _scalciumunit;
        public  System.String  SCalciumUnit
        {
           get { return GET(ref _scalciumunit); }
           set { SET(ref  _scalciumunit,value); }
        }
        private System.String _scalciumnor;
        public  System.String  SCalciumNor
        {
           get { return GET(ref _scalciumnor); }
           set { SET(ref  _scalciumnor,value); }
        }
        private System.String _sprotein;
        public  System.String  SProtein
        {
           get { return GET(ref _sprotein); }
           set { SET(ref  _sprotein,value); }
        }
        private System.String _sproteinunit;
        public  System.String  SProteinUnit
        {
           get { return GET(ref _sproteinunit); }
           set { SET(ref  _sproteinunit,value); }
        }
        private System.String _sproteinnor;
        public  System.String  SProteinNor
        {
           get { return GET(ref _sproteinnor); }
           set { SET(ref  _sproteinnor,value); }
        }
        private System.String _salbumin;
        public  System.String  SAlbumin
        {
           get { return GET(ref _salbumin); }
           set { SET(ref  _salbumin,value); }
        }
        private System.String _salbuminunit;
        public  System.String  SAlbuminUnit
        {
           get { return GET(ref _salbuminunit); }
           set { SET(ref  _salbuminunit,value); }
        }
        private System.String _salbuminnor;
        public  System.String  SAlbuminNor
        {
           get { return GET(ref _salbuminnor); }
           set { SET(ref  _salbuminnor,value); }
        }
        private System.String _agratio;
        public  System.String  AGRatio
        {
           get { return GET(ref _agratio); }
           set { SET(ref  _agratio,value); }
        }
        private System.String _agratiounit;
        public  System.String  AGRatioUnit
        {
           get { return GET(ref _agratiounit); }
           set { SET(ref  _agratiounit,value); }
        }
        private System.String _agrationor;
        public  System.String  AGRatioNor
        {
           get { return GET(ref _agrationor); }
           set { SET(ref  _agrationor,value); }
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