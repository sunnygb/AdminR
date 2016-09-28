using System.Collections.ObjectModel;
using System.Linq;

namespace ClinicalReporting.Model.Wrapper
{
    public partial class HaematologyW : CommonWrapper<Haematology>
    {
        public HaematologyW(Haematology haematologyModel):base(haematologyModel)
        {
           
           InitializeComplexProperties(haematologyModel);
           InitializeCollectionProperties(haematologyModel);
           
           
        }
        
        private void InitializeCollectionProperties(Haematology haematologyModel)
        {
        }
        
        private void InitializeComplexProperties(Haematology haematologyModel)
        {
        
           // One To One
           if(haematologyModel.Patient !=null)
           {
               this.PatientW = new PatientW(
               haematologyModel.Patient);
           }
        }
          
        public HaematologyW():base(null){}
        
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
        private System.String _hb;
        public  System.String  Hb
        {
           get { return GET(ref _hb); }
           set { SET(ref  _hb,value); }
        }
        private System.String _hbunit;
        public  System.String  HBUnit
        {
           get { return GET(ref _hbunit); }
           set { SET(ref  _hbunit,value); }
        }
        private System.String _hbnor;
        public  System.String  HBNor
        {
           get { return GET(ref _hbnor); }
           set { SET(ref  _hbnor,value); }
        }
        private System.String _tlc;
        public  System.String  Tlc
        {
           get { return GET(ref _tlc); }
           set { SET(ref  _tlc,value); }
        }
        private System.String _tlcunit;
        public  System.String  TLCUnit
        {
           get { return GET(ref _tlcunit); }
           set { SET(ref  _tlcunit,value); }
        }
        private System.String _tlcnor;
        public  System.String  TLCNor
        {
           get { return GET(ref _tlcnor); }
           set { SET(ref  _tlcnor,value); }
        }
        private System.String _esr;
        public  System.String  Esr
        {
           get { return GET(ref _esr); }
           set { SET(ref  _esr,value); }
        }
        private System.String _esrunit;
        public  System.String  ESRUnit
        {
           get { return GET(ref _esrunit); }
           set { SET(ref  _esrunit,value); }
        }
        private System.String _esrnor;
        public  System.String  ESRNor
        {
           get { return GET(ref _esrnor); }
           set { SET(ref  _esrnor,value); }
        }
        private System.String _bt;
        public  System.String  Bt
        {
           get { return GET(ref _bt); }
           set { SET(ref  _bt,value); }
        }
        private System.String _btunit;
        public  System.String  BTUnit
        {
           get { return GET(ref _btunit); }
           set { SET(ref  _btunit,value); }
        }
        private System.String _btnor;
        public  System.String  BTNor
        {
           get { return GET(ref _btnor); }
           set { SET(ref  _btnor,value); }
        }
        private System.String _ct;
        public  System.String  Ct
        {
           get { return GET(ref _ct); }
           set { SET(ref  _ct,value); }
        }
        private System.String _ctunit;
        public  System.String  CTUnit
        {
           get { return GET(ref _ctunit); }
           set { SET(ref  _ctunit,value); }
        }
        private System.String _ctnor;
        public  System.String  CTNor
        {
           get { return GET(ref _ctnor); }
           set { SET(ref  _ctnor,value); }
        }
        private System.String _plateletscount;
        public  System.String  PlateletsCount
        {
           get { return GET(ref _plateletscount); }
           set { SET(ref  _plateletscount,value); }
        }
        private System.String _plateletscountunit;
        public  System.String  PlateletsCountUnit
        {
           get { return GET(ref _plateletscountunit); }
           set { SET(ref  _plateletscountunit,value); }
        }
        private System.String _plateletscountnor;
        public  System.String  PlateletsCountNor
        {
           get { return GET(ref _plateletscountnor); }
           set { SET(ref  _plateletscountnor,value); }
        }
        private System.String _pt;
        public  System.String  Pt
        {
           get { return GET(ref _pt); }
           set { SET(ref  _pt,value); }
        }
        private System.String _ptunit;
        public  System.String  PTUnit
        {
           get { return GET(ref _ptunit); }
           set { SET(ref  _ptunit,value); }
        }
        private System.String _ptnor;
        public  System.String  PTNor
        {
           get { return GET(ref _ptnor); }
           set { SET(ref  _ptnor,value); }
        }
        private System.String _dlc;
        public  System.String  Dlc
        {
           get { return GET(ref _dlc); }
           set { SET(ref  _dlc,value); }
        }
        private System.String _dlcunit;
        public  System.String  DLCUnit
        {
           get { return GET(ref _dlcunit); }
           set { SET(ref  _dlcunit,value); }
        }
        private System.String _dlcnor;
        public  System.String  DLCNor
        {
           get { return GET(ref _dlcnor); }
           set { SET(ref  _dlcnor,value); }
        }
        private System.String _polymorphs;
        public  System.String  Polymorphs
        {
           get { return GET(ref _polymorphs); }
           set { SET(ref  _polymorphs,value); }
        }
        private System.String _polymorphsunit;
        public  System.String  PolymorphsUnit
        {
           get { return GET(ref _polymorphsunit); }
           set { SET(ref  _polymorphsunit,value); }
        }
        private System.String _polymorphsnor;
        public  System.String  PolymorphsNor
        {
           get { return GET(ref _polymorphsnor); }
           set { SET(ref  _polymorphsnor,value); }
        }
        private System.String _lymphocytes;
        public  System.String  Lymphocytes
        {
           get { return GET(ref _lymphocytes); }
           set { SET(ref  _lymphocytes,value); }
        }
        private System.String _lymphocytesunit;
        public  System.String  LymphocytesUnit
        {
           get { return GET(ref _lymphocytesunit); }
           set { SET(ref  _lymphocytesunit,value); }
        }
        private System.String _lymphocytesnor;
        public  System.String  LymphocytesNor
        {
           get { return GET(ref _lymphocytesnor); }
           set { SET(ref  _lymphocytesnor,value); }
        }
        private System.String _monocyte;
        public  System.String  Monocyte
        {
           get { return GET(ref _monocyte); }
           set { SET(ref  _monocyte,value); }
        }
        private System.String _monocyteunit;
        public  System.String  MonocyteUnit
        {
           get { return GET(ref _monocyteunit); }
           set { SET(ref  _monocyteunit,value); }
        }
        private System.String _monocytenor;
        public  System.String  MonocyteNor
        {
           get { return GET(ref _monocytenor); }
           set { SET(ref  _monocytenor,value); }
        }
        private System.String _eosinophil;
        public  System.String  Eosinophil
        {
           get { return GET(ref _eosinophil); }
           set { SET(ref  _eosinophil,value); }
        }
        private System.String _eosinophilunit;
        public  System.String  EosinophilUnit
        {
           get { return GET(ref _eosinophilunit); }
           set { SET(ref  _eosinophilunit,value); }
        }
        private System.String _eosinophilnor;
        public  System.String  EosinophilNor
        {
           get { return GET(ref _eosinophilnor); }
           set { SET(ref  _eosinophilnor,value); }
        }
        private System.String _basophil;
        public  System.String  Basophil
        {
           get { return GET(ref _basophil); }
           set { SET(ref  _basophil,value); }
        }
        private System.String _basophilunit;
        public  System.String  BasophilUnit
        {
           get { return GET(ref _basophilunit); }
           set { SET(ref  _basophilunit,value); }
        }
        private System.String _basophilnor;
        public  System.String  BasophilNor
        {
           get { return GET(ref _basophilnor); }
           set { SET(ref  _basophilnor,value); }
        }
        private System.String _malariaparasites;
        public  System.String  MalariaParasites
        {
           get { return GET(ref _malariaparasites); }
           set { SET(ref  _malariaparasites,value); }
        }
        private System.String _malariaparasitesunit;
        public  System.String  MalariaParasitesUnit
        {
           get { return GET(ref _malariaparasitesunit); }
           set { SET(ref  _malariaparasitesunit,value); }
        }
        private System.String _malariaparasitesnor;
        public  System.String  MalariaParasitesNor
        {
           get { return GET(ref _malariaparasitesnor); }
           set { SET(ref  _malariaparasitesnor,value); }
        }
        private System.String _bloodgroup;
        public  System.String  BloodGroup
        {
           get { return GET(ref _bloodgroup); }
           set { SET(ref  _bloodgroup,value); }
        }
        private System.String _bloodgroupunit;
        public  System.String  BloodGroupUnit
        {
           get { return GET(ref _bloodgroupunit); }
           set { SET(ref  _bloodgroupunit,value); }
        }
        private System.String _bloodgroupnor;
        public  System.String  BloodGroupNor
        {
           get { return GET(ref _bloodgroupnor); }
           set { SET(ref  _bloodgroupnor,value); }
        }
        private System.String _rhfactor;
        public  System.String  RHFactor
        {
           get { return GET(ref _rhfactor); }
           set { SET(ref  _rhfactor,value); }
        }
        private System.String _rhfactorunit;
        public  System.String  RHFactorUnit
        {
           get { return GET(ref _rhfactorunit); }
           set { SET(ref  _rhfactorunit,value); }
        }
        private System.String _rhfactornor;
        public  System.String  RHFactorNor
        {
           get { return GET(ref _rhfactornor); }
           set { SET(ref  _rhfactornor,value); }
        }
        private System.String _totalrbc;
        public  System.String  TotalRBC
        {
           get { return GET(ref _totalrbc); }
           set { SET(ref  _totalrbc,value); }
        }
        private System.String _totalrbcunit;
        public  System.String  TotalRBCUnit
        {
           get { return GET(ref _totalrbcunit); }
           set { SET(ref  _totalrbcunit,value); }
        }
        private System.String _totalrbcnor;
        public  System.String  TotalRBCNor
        {
           get { return GET(ref _totalrbcnor); }
           set { SET(ref  _totalrbcnor,value); }
        }
        private System.String _pvchaematorcrit;
        public  System.String  PVCHaematorcrit
        {
           get { return GET(ref _pvchaematorcrit); }
           set { SET(ref  _pvchaematorcrit,value); }
        }
        private System.String _pvchaematorcritunit;
        public  System.String  PVCHaematorcritUnit
        {
           get { return GET(ref _pvchaematorcritunit); }
           set { SET(ref  _pvchaematorcritunit,value); }
        }
        private System.String _pvchaematorcritnor;
        public  System.String  PVCHaematorcritNor
        {
           get { return GET(ref _pvchaematorcritnor); }
           set { SET(ref  _pvchaematorcritnor,value); }
        }
        private System.String _mcv;
        public  System.String  MCV
        {
           get { return GET(ref _mcv); }
           set { SET(ref  _mcv,value); }
        }
        private System.String _mcvunit;
        public  System.String  MCVUnit
        {
           get { return GET(ref _mcvunit); }
           set { SET(ref  _mcvunit,value); }
        }
        private System.String _mcvnor;
        public  System.String  MCVNor
        {
           get { return GET(ref _mcvnor); }
           set { SET(ref  _mcvnor,value); }
        }
        private System.String _mch;
        public  System.String  MCH
        {
           get { return GET(ref _mch); }
           set { SET(ref  _mch,value); }
        }
        private System.String _mchunit;
        public  System.String  MCHUnit
        {
           get { return GET(ref _mchunit); }
           set { SET(ref  _mchunit,value); }
        }
        private System.String _mchnor;
        public  System.String  MCHNor
        {
           get { return GET(ref _mchnor); }
           set { SET(ref  _mchnor,value); }
        }
        private System.String _mchc;
        public  System.String  MCHC
        {
           get { return GET(ref _mchc); }
           set { SET(ref  _mchc,value); }
        }
        private System.String _mchcunit;
        public  System.String  MCHCUnit
        {
           get { return GET(ref _mchcunit); }
           set { SET(ref  _mchcunit,value); }
        }
        private System.String _mchcnor;
        public  System.String  MCHCNor
        {
           get { return GET(ref _mchcnor); }
           set { SET(ref  _mchcnor,value); }
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