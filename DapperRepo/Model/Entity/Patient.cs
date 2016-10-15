using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Table("Patient")]
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
            UrineExaminations = new List<UrineExamination>();
            Serologies = new List<Serology>();
        }
        

        [Key]
        [Column("PatientID")]
        public System.Int64 PatientID { get; set; }

        [Column("Name")]
        public System.String Name { get; set; }

        [Column("Age")]
        public System.String Age { get; set; }

        [Column("Sex")]
        public System.String Sex { get; set; }

        [Column("Ref_by")]
        public System.String RefBy { get; set; }

        [NotMapped]
        public virtual List<Haematology> Haematologies { get; set; }
        [NotMapped]
        public virtual List<ElisaTb> ElisaTbs { get; set; }
        [NotMapped]
        public virtual List<ElisaHcv> ElisaHcvs { get; set; }
        [NotMapped]
        public virtual List<ElisaHbsag> ElisaHbsags { get; set; }
        [NotMapped]
        public virtual List<BloodGroup> BloodGroups { get; set; }
        [NotMapped]
        public virtual List<Biochemistry> Biochemistries { get; set; }
        [NotMapped]
        public virtual List<SemenAnalysis> SemenAnalyses { get; set; }
        [NotMapped]
        public virtual List<UrineExamination> UrineExaminations { get; set; }
        [NotMapped]
        public virtual List<Serology> Serologies { get; set; }
         [NotMapped]
         public bool IsNew
         {
                get
                {
         
                  return this.PatientID == default(int);
         
                }
                
          }
          [NotMapped]
          public bool IsDeleted { get; set; }
    }
}