using ClinicalReporting.Data.Services;
using System;

namespace ClinicalReporting.Data.Wrapper
{
    public class DoctorW : CommonWrapper<Doctor>
    {
        private Int64 _doctorid;
        private String _doctorname;

        public DoctorW(Doctor doctorModel) : base(doctorModel)
        {
            InitializeComplexProperties(doctorModel);
            InitializeCollectionProperties(doctorModel);
        }

        public DoctorW() : base(null)
        {
        }

        public Int64 DoctorID
        {
            get { return GET(ref _doctorid); }
            set { SET(ref _doctorid, value); }
        }

        public String DoctorName
        {
            get { return GET(ref _doctorname); }
            set { SET(ref _doctorname, value); }
        }

        private void InitializeCollectionProperties(Doctor doctorModel)
        {
        }

        private void InitializeComplexProperties(Doctor doctorModel)
        {
        }
    }
}