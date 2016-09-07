﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using ClinicalReporting.Data;
using ClinicalReporting.Data.Services;
using ClinicalReporting.Data.Wrapper;

namespace ClinicalReporting.Data.Wrapper
{
    public partial class DoctorW : CommonWrapper<Doctor>
    {
        public DoctorW(Doctor doctorModel):base(doctorModel)
        {
           
           InitializeComplexProperties(doctorModel);
           InitializeCollectionProperties(doctorModel);
           
           
        }
        
        private void InitializeCollectionProperties(Doctor doctorModel)
        {
        }
        
        private void InitializeComplexProperties(Doctor doctorModel)
        {
        
        }
          
        public DoctorW():base(null){}
        
        private System.Int64 _doctorid;
        public  System.Int64  DoctorID
        {
           get { return GET(ref _doctorid); }
           set { SET(ref  _doctorid,value); }
        }
        private System.String _doctorname;
        public  System.String  DoctorName
        {
           get { return GET(ref _doctorname); }
           set { SET(ref  _doctorname,value); }
        }
        
        
        
    }
}