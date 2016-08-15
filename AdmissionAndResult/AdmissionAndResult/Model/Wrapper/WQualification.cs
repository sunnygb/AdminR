using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Model;

namespace AdmissionAndResult.Model
{
     [Table("Qualification")]
    class WQualification
    {
        
        public WQualification(Qualification qualification)
        {
  
            this.Qualification_Id = qualification.Qualification_Id;
            this.NTS_Max_Marks = qualification.NTS_Max_Marks;
            this.NTS_Obt_Marks = qualification.NTS_Obt_Marks;
            this.FSC_Institute_Name = qualification.FSC_Institute_Name;
            this.FSC_Max_Marks = qualification.FSC_Max_Marks;
             this.FSC_Obt_Marks=qualification.FSC_Obt_Marks;
              this.Matric_Institute_Name=qualification.Matric_Institute_Name;
             this.Matric_Max_Marks = qualification.Matric_Max_Marks;
             this.Matric_Obt_Marks=qualification.Matric_Obt_Marks;
             this.GAT_Max_Marks= qualification.GAT_Max_Marks;
              this.GAT_Obt_Marks=qualification.GAT_Obt_Marks;
              this.Matric_Year=qualification.Matric_Year;
              this.FSC_Year=qualification.FSC_Year;
              this.NTS_Year=qualification.NTS_Year;
              this.GAT_Year=qualification.GAT_Year;
             this.MS_Year=qualification.MS_Year;
             this.BS_Year=qualification.BS_Year;
              this.BS_Institute_Name=qualification.BS_Institute_Name;
              this.MS_Institute_Name=qualification.MS_Institute_Name;
             this.BS_Roll_No=qualification.BS_Roll_No ;
              this.MS_Roll_No=qualification.MS_Roll_No;
              this.Fsc_Roll_No=qualification.Fsc_Roll_No;
              this.Matric_Roll_No=qualification.Matric_Roll_No;
              this.NTS_Roll_No=qualification.NTS_Roll_No;
             this.GAT_Roll_No=qualification.GAT_Roll_No;
            this.BS_Degree= qualification.BS_Degree;
              this.MS_Degree=qualification.MS_Degree;
             this.Batchlor_Max_CGPA= qualification.Batchlor_Max_CGPA;
              this.Batchlor_Obt_CGPA=qualification.Batchlor_Obt_CGPA;
             this.MSC_Max_CGPA=qualification.MSC_Max_CGPA;
              this.MSC_Obt_CGPA=qualification.MSC_Obt_CGPA;
              this.Verified_BS_CGPA=qualification.Verified_BS_CGPA;
            this.Verified_FSC_Marks= qualification.Verified_FSC_Marks;
              this.Verified_GAT_Marks=qualification.Verified_GAT_Marks;
              this.Verified_MSC_CGPA=qualification.Verified_MSC_CGPA;
             this.Verified_Matric_Marks=qualification.Verified_Matric_Marks ;
             this.Verified_NTS_Marks=qualification.Verified_NTS_Marks ;
             


































        }
        
        
        
        
        
        
        
        [Key]
        public long Qualification_Id { get; set; }
        public long NTS_Obt_Marks { get; set; }
        public long NTS_Max_Marks { get; set; }
        public long FSC_Obt_Marks { get; set; }
        public long FSC_Max_Marks { get; set; }


        public long Matric_Obt_Marks { get; set; }
        public long Matric_Max_Marks { get; set; }

        public long GAT_Obt_Marks { get; set; }
        public long GAT_Max_Marks { get; set; }

        public string Matric_Year { get; set; }

        public string FSC_Year { get; set; }
        public string NTS_Year { get; set; }
        public string BS_Year { get; set; }
        public string MS_Year { get; set; }
        public string GAT_Year { get; set; }







        public string MS_Institute_Name { get; set; }
        public string BS_Institute_Name { get; set; }
        public string FSC_Institute_Name { get; set; }
        public string Matric_Institute_Name { get; set; }




        public string MS_Roll_No { get; set; }
        public string BS_Roll_No { get; set; }
        public string Fsc_Roll_No { get; set; }
        public string Matric_Roll_No { get; set; }
        public string NTS_Roll_No { get; set; }
        public string GAT_Roll_No { get; set; }

        public string BS_Degree { get; set; }
        public string MS_Degree { get; set; }




        public string Board_Name { get; set; }
        //public long GAT_Marks { get; set; }
        public long Batchlor_Obt_CGPA { get; set; }
        public long Batchlor_Max_CGPA { get; set; }

        public long MSC_Obt_CGPA { get; set; }
        public long MSC_Max_CGPA { get; set; }

        public long Verified_NTS_Marks { get; set; }
        public long Verified_FSC_Marks { get; set; }
        public long Verified_Matric_Marks { get; set; }
        public long Verified_GAT_Marks { get; set; }
        public long Verified_MSC_CGPA { get; set; }
        public long Verified_BS_CGPA { get; set; }

    }
}
