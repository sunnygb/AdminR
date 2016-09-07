using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Data.Wrapper;
namespace ClinicalReporting.Data
{


    [Alias("Patient")]
    public partial class Patient
    {
        
        public Patient()
        {
            Haematologies = new List<Haematology>();
            ElisaTbs = new List<ElisaTb>();
            ElisaHcvs = new List<ElisaHcv>();
            ElisaHbsags = new List<ElisaHbsag>();
            BloodGroups = new List<BloodGroup>();
            Biochemistries = new List<Biochemistry>();
            SemenAnalyses = new List<SemenAnalysis>();
            Serologies = new List<Serology>();
            UrineExaminations = new List<UrineExamination>();
        }
        
        public Patient(PatientW patientw)
        {
           this.PatientID = patientw.PatientID;
           this.Name = patientw.Name;
           this.Age = patientw.Age;
           this.Sex = patientw.Sex;
           this.RefBy = patientw.RefBy;
           
           Haematologies = new List<Haematology>();
           ElisaTbs = new List<ElisaTb>();
           ElisaHcvs = new List<ElisaHcv>();
           ElisaHbsags = new List<ElisaHbsag>();
           BloodGroups = new List<BloodGroup>();
           Biochemistries = new List<Biochemistry>();
           SemenAnalyses = new List<SemenAnalysis>();
           Serologies = new List<Serology>();
           UrineExaminations = new List<UrineExamination>();
           
        }

        [PrimaryKey]
        [Alias("PatientID")]
        public System.Int64 PatientID { get; set; }

        [Alias("Name")]
        public System.String Name { get; set; }

        [Alias("Age")]
        public System.String Age { get; set; }

        [Alias("Sex")]
        public System.String Sex { get; set; }

        [Alias("Ref_by")]
        public System.String RefBy { get; set; }

        [Ignore]
        public virtual List<Haematology> Haematologies { get; set; }
        [Ignore]
        public virtual List<ElisaTb> ElisaTbs { get; set; }
        [Ignore]
        public virtual List<ElisaHcv> ElisaHcvs { get; set; }
        [Ignore]
        public virtual List<ElisaHbsag> ElisaHbsags { get; set; }
        [Ignore]
        public virtual List<BloodGroup> BloodGroups { get; set; }
        [Ignore]
        public virtual List<Biochemistry> Biochemistries { get; set; }
        [Ignore]
        public virtual List<SemenAnalysis> SemenAnalyses { get; set; }
        [Ignore]
        public virtual List<Serology> Serologies { get; set; }
        [Ignore]
        public virtual List<UrineExamination> UrineExaminations { get; set; }
         [Ignore]
         public bool IsNew
         {
                get
                {
         
                  return this.PatientID == default(int);
         
                }
                
          }
          [Ignore]
          public bool IsDeleted { get; set; }
    }
}