using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ClinicalReporting.Model.Wrapper
{
    public class PatientW : CommonWrapper<Patient>
    {
        private String _age;
        private ObservableCollection<BiochemistryW> _biochemistriesw;
        private ObservableCollection<BloodGroupW> _bloodgroupsw;
        private ObservableCollection<ElisaHbsagW> _elisahbsagsw;
        private ObservableCollection<ElisaHcvW> _elisahcvsw;
        private ObservableCollection<ElisaTbW> _elisatbsw;
        private ObservableCollection<HaematologyW> _haematologiesw;
        private String _name;
        private Int64 _patientid;
        private String _refby;
        private ObservableCollection<SemenAnalysisW> _semenanalysesw;
        private ObservableCollection<SerologyW> _serologiesw;
        private String _sex;
        private ObservableCollection<UrineExaminationW> _urineexaminationsw;

        public PatientW(Patient patientModel) : base(patientModel)
        {
            InitializeComplexProperties(patientModel);
            InitializeCollectionProperties(patientModel);
        }

        public PatientW() : base(null)
        {
        }

        public Int64 PatientID
        {
            get { return GET(ref _patientid); }
            set { SET(ref _patientid, value); }
        }

        public String Name
        {
            get { return GET(ref _name); }
            set { SET(ref _name, value); }
        }

        public String Age
        {
            get { return GET(ref _age); }
            set { SET(ref _age, value); }
        }

        public String Sex
        {
            get { return GET(ref _sex); }
            set { SET(ref _sex, value); }
        }

        public String RefBy
        {
            get { return GET(ref _refby); }
            set { SET(ref _refby, value); }
        }

        // One To Many

        public ObservableCollection<HaematologyW> HaematologiesW
        {
            get { return _haematologiesw; }
            set { _haematologiesw = value; }
        }

        // One To Many

        public ObservableCollection<ElisaTbW> ElisaTbsW
        {
            get { return _elisatbsw; }
            set { _elisatbsw = value; }
        }

        // One To Many

        public ObservableCollection<ElisaHcvW> ElisaHcvsW
        {
            get { return _elisahcvsw; }
            set { _elisahcvsw = value; }
        }

        // One To Many

        public ObservableCollection<ElisaHbsagW> ElisaHbsagsW
        {
            get { return _elisahbsagsw; }
            set { _elisahbsagsw = value; }
        }

        // One To Many

        public ObservableCollection<BloodGroupW> BloodGroupsW
        {
            get { return _bloodgroupsw; }
            set { _bloodgroupsw = value; }
        }

        // One To Many

        public ObservableCollection<BiochemistryW> BiochemistriesW
        {
            get { return _biochemistriesw; }
            set { _biochemistriesw = value; }
        }

        // One To Many

        public ObservableCollection<SemenAnalysisW> SemenAnalysesW
        {
            get { return _semenanalysesw; }
            set { _semenanalysesw = value; }
        }

        // One To Many

        public ObservableCollection<UrineExaminationW> UrineExaminationsW
        {
            get { return _urineexaminationsw; }
            set { _urineexaminationsw = value; }
        }

        // One To Many

        public ObservableCollection<SerologyW> SerologiesW
        {
            get { return _serologiesw; }
            set { _serologiesw = value; }
        }

        private void InitializeCollectionProperties(Patient patientModel)
        {
            // One To Many
            if (patientModel.Haematologies != null)
            {
                _haematologiesw = new ObservableCollection<HaematologyW>(
                    patientModel.Haematologies.Select(e => new HaematologyW(e)));
                RegisterCollection(_haematologiesw, patientModel.Haematologies);
            }
            // One To Many
            if (patientModel.ElisaTbs != null)
            {
                _elisatbsw = new ObservableCollection<ElisaTbW>(
                    patientModel.ElisaTbs.Select(e => new ElisaTbW(e)));
                RegisterCollection(_elisatbsw, patientModel.ElisaTbs);
            }
            // One To Many
            if (patientModel.ElisaHcvs != null)
            {
                _elisahcvsw = new ObservableCollection<ElisaHcvW>(
                    patientModel.ElisaHcvs.Select(e => new ElisaHcvW(e)));
                RegisterCollection(_elisahcvsw, patientModel.ElisaHcvs);
            }
            // One To Many
            if (patientModel.ElisaHbsags != null)
            {
                _elisahbsagsw = new ObservableCollection<ElisaHbsagW>(
                    patientModel.ElisaHbsags.Select(e => new ElisaHbsagW(e)));
                RegisterCollection(_elisahbsagsw, patientModel.ElisaHbsags);
            }
            // One To Many
            if (patientModel.BloodGroups != null)
            {
                _bloodgroupsw = new ObservableCollection<BloodGroupW>(
                    patientModel.BloodGroups.Select(e => new BloodGroupW(e)));
                RegisterCollection(_bloodgroupsw, patientModel.BloodGroups);
            }
            // One To Many
            if (patientModel.Biochemistries != null)
            {
                _biochemistriesw = new ObservableCollection<BiochemistryW>(
                    patientModel.Biochemistries.Select(e => new BiochemistryW(e)));
                RegisterCollection(_biochemistriesw, patientModel.Biochemistries);
            }
            // One To Many
            if (patientModel.SemenAnalyses != null)
            {
                _semenanalysesw = new ObservableCollection<SemenAnalysisW>(
                    patientModel.SemenAnalyses.Select(e => new SemenAnalysisW(e)));
                RegisterCollection(_semenanalysesw, patientModel.SemenAnalyses);
            }
            // One To Many
            if (patientModel.UrineExaminations != null)
            {
                _urineexaminationsw = new ObservableCollection<UrineExaminationW>(
                    patientModel.UrineExaminations.Select(e => new UrineExaminationW(e)));
                RegisterCollection(_urineexaminationsw, patientModel.UrineExaminations);
            }
            // One To Many
            if (patientModel.Serologies != null)
            {
                _serologiesw = new ObservableCollection<SerologyW>(
                    patientModel.Serologies.Select(e => new SerologyW(e)));
                RegisterCollection(_serologiesw, patientModel.Serologies);
            }
        }

        private void InitializeComplexProperties(Patient patientModel)
        {
        }
    }
}