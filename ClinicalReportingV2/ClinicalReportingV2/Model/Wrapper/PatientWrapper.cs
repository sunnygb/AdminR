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
    public partial class PatientW : CommonWrapper<Patient>
    {
        public PatientW(Patient patientModel):base(patientModel)
        {
           
           InitializeComplexProperties(patientModel);
           InitializeCollectionProperties(patientModel);
           
           
        }
        
        private void InitializeCollectionProperties(Patient patientModel)
        {
           // One To Many
           if(patientModel.Haematologies !=null)
           {
              this._haematologiesw = new ObservableCollection<HaematologyW>(
              patientModel.Haematologies.Select(e=>new HaematologyW(e)));
              RegisterCollection(_haematologiesw,patientModel.Haematologies);
           }
           // One To Many
           if(patientModel.ElisaTbs !=null)
           {
              this._elisatbsw = new ObservableCollection<ElisaTbW>(
              patientModel.ElisaTbs.Select(e=>new ElisaTbW(e)));
              RegisterCollection(_elisatbsw,patientModel.ElisaTbs);
           }
           // One To Many
           if(patientModel.ElisaHcvs !=null)
           {
              this._elisahcvsw = new ObservableCollection<ElisaHcvW>(
              patientModel.ElisaHcvs.Select(e=>new ElisaHcvW(e)));
              RegisterCollection(_elisahcvsw,patientModel.ElisaHcvs);
           }
           // One To Many
           if(patientModel.ElisaHbsags !=null)
           {
              this._elisahbsagsw = new ObservableCollection<ElisaHbsagW>(
              patientModel.ElisaHbsags.Select(e=>new ElisaHbsagW(e)));
              RegisterCollection(_elisahbsagsw,patientModel.ElisaHbsags);
           }
           // One To Many
           if(patientModel.BloodGroups !=null)
           {
              this._bloodgroupsw = new ObservableCollection<BloodGroupW>(
              patientModel.BloodGroups.Select(e=>new BloodGroupW(e)));
              RegisterCollection(_bloodgroupsw,patientModel.BloodGroups);
           }
           // One To Many
           if(patientModel.Biochemistries !=null)
           {
              this._biochemistriesw = new ObservableCollection<BiochemistryW>(
              patientModel.Biochemistries.Select(e=>new BiochemistryW(e)));
              RegisterCollection(_biochemistriesw,patientModel.Biochemistries);
           }
           // One To Many
           if(patientModel.SemenAnalyses !=null)
           {
              this._semenanalysesw = new ObservableCollection<SemenAnalysisW>(
              patientModel.SemenAnalyses.Select(e=>new SemenAnalysisW(e)));
              RegisterCollection(_semenanalysesw,patientModel.SemenAnalyses);
           }
           // One To Many
           if(patientModel.Serologies !=null)
           {
              this._serologiesw = new ObservableCollection<SerologyW>(
              patientModel.Serologies.Select(e=>new SerologyW(e)));
              RegisterCollection(_serologiesw,patientModel.Serologies);
           }
           // One To Many
           if(patientModel.UrineExaminations !=null)
           {
              this._urineexaminationsw = new ObservableCollection<UrineExaminationW>(
              patientModel.UrineExaminations.Select(e=>new UrineExaminationW(e)));
              RegisterCollection(_urineexaminationsw,patientModel.UrineExaminations);
           }
        }
        
        private void InitializeComplexProperties(Patient patientModel)
        {
        
           
           
           
           
           
           
           
           
           
        }
          
        public PatientW():base(null){}
        
        private System.Int64 _patientid;
        public  System.Int64  PatientID
        {
           get { return GET(ref _patientid); }
           set { SET(ref  _patientid,value); }
        }
        private System.String _name;
        public  System.String  Name
        {
           get { return GET(ref _name); }
           set { SET(ref  _name,value); }
        }
        private System.String _age;
        public  System.String  Age
        {
           get { return GET(ref _age); }
           set { SET(ref  _age,value); }
        }
        private System.String _sex;
        public  System.String  Sex
        {
           get { return GET(ref _sex); }
           set { SET(ref  _sex,value); }
        }
        private System.String _refby;
        public  System.String  RefBy
        {
           get { return GET(ref _refby); }
           set { SET(ref  _refby,value); }
        }
        
        // One To Many
        private ObservableCollection<HaematologyW> _haematologiesw;
        public  ObservableCollection<HaematologyW>  HaematologiesW
        { 
          get { return _haematologiesw; }
          set { _haematologiesw = value; }
        }
        // One To Many
        private ObservableCollection<ElisaTbW> _elisatbsw;
        public  ObservableCollection<ElisaTbW>  ElisaTbsW
        { 
          get { return _elisatbsw; }
          set { _elisatbsw = value; }
        }
        // One To Many
        private ObservableCollection<ElisaHcvW> _elisahcvsw;
        public  ObservableCollection<ElisaHcvW>  ElisaHcvsW
        { 
          get { return _elisahcvsw; }
          set { _elisahcvsw = value; }
        }
        // One To Many
        private ObservableCollection<ElisaHbsagW> _elisahbsagsw;
        public  ObservableCollection<ElisaHbsagW>  ElisaHbsagsW
        { 
          get { return _elisahbsagsw; }
          set { _elisahbsagsw = value; }
        }
        // One To Many
        private ObservableCollection<BloodGroupW> _bloodgroupsw;
        public  ObservableCollection<BloodGroupW>  BloodGroupsW
        { 
          get { return _bloodgroupsw; }
          set { _bloodgroupsw = value; }
        }
        // One To Many
        private ObservableCollection<BiochemistryW> _biochemistriesw;
        public  ObservableCollection<BiochemistryW>  BiochemistriesW
        { 
          get { return _biochemistriesw; }
          set { _biochemistriesw = value; }
        }
        // One To Many
        private ObservableCollection<SemenAnalysisW> _semenanalysesw;
        public  ObservableCollection<SemenAnalysisW>  SemenAnalysesW
        { 
          get { return _semenanalysesw; }
          set { _semenanalysesw = value; }
        }
        // One To Many
        private ObservableCollection<SerologyW> _serologiesw;
        public  ObservableCollection<SerologyW>  SerologiesW
        { 
          get { return _serologiesw; }
          set { _serologiesw = value; }
        }
        // One To Many
        private ObservableCollection<UrineExaminationW> _urineexaminationsw;
        public  ObservableCollection<UrineExaminationW>  UrineExaminationsW
        { 
          get { return _urineexaminationsw; }
          set { _urineexaminationsw = value; }
        }
        
        
    }
}