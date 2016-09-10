using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace ClinicalReporting.Model
{
    [Alias("Patient")]
    public class Patient
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
            UrineExaminations = new List<UrineExamination>();
            Serologies = new List<Serology>();
        }


        [PrimaryKey]
        [Alias("PatientID")]
        public Int64 PatientID { get; set; }

        [Alias("Name")]
        public String Name { get; set; }

        [Alias("Age")]
        public String Age { get; set; }

        [Alias("Sex")]
        public String Sex { get; set; }

        [Alias("Ref_by")]
        public String RefBy { get; set; }

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
        public virtual List<UrineExamination> UrineExaminations { get; set; }

        [Ignore]
        public virtual List<Serology> Serologies { get; set; }

        [Ignore]
        public bool IsNew
        {
            get { return PatientID == default(int); }
        }

        [Ignore]
        public bool IsDeleted { get; set; }
    }
}