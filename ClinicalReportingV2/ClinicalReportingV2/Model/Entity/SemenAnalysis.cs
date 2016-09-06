using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Data.Wrapper;
namespace ClinicalReporting.Data
{


    [Alias("SemenAnalysis")]
    public partial class SemenAnalysis
    {
        
        public SemenAnalysis()
        {
        }
        
        public SemenAnalysis(SemenAnalysisW semenanalysisw)
        {
           this.SerialNo = semenanalysisw.SerialNo;
           this.PatientID = semenanalysisw.PatientID;
           this.TDate = semenanalysisw.TDate;
           this.Colour = semenanalysisw.Colour;
           this.Quantity = semenanalysisw.Quantity;
           this.Ph = semenanalysisw.Ph;
           this.TimeOfCollection = semenanalysisw.TimeOfCollection;
           this.TimeOfExamination = semenanalysisw.TimeOfExamination;
           this.TotalCount = semenanalysisw.TotalCount;
           this.ActiveMotility = semenanalysisw.ActiveMotility;
           this.Sluggish = semenanalysisw.Sluggish;
           this.NonMotile = semenanalysisw.NonMotile;
           this.Abnormal = semenanalysisw.Abnormal;
           this.PusCells = semenanalysisw.PusCells;
           this.Rbc = semenanalysisw.Rbc;
           this.EpithelialCell = semenanalysisw.EpithelialCell;
           this.Fee = semenanalysisw.Fee;
           
           
        }

        [PrimaryKey]
        [Alias("SerialNo")]
        public System.Int64 SerialNo { get; set; }

        [Alias("PatientID")]
        public System.Int64 PatientID { get; set; }

        [Alias("TDate")]
        public System.DateTime TDate { get; set; }

        [Alias("Colour")]
        public System.String Colour { get; set; }

        [Alias("Quantity")]
        public System.String Quantity { get; set; }

        [Alias("PH")]
        public System.String Ph { get; set; }

        [Alias("Time_Of_Collection")]
        public System.String TimeOfCollection { get; set; }

        [Alias("Time_Of_Examination")]
        public System.String TimeOfExamination { get; set; }

        [Alias("Total_Count")]
        public System.String TotalCount { get; set; }

        [Alias("Active_Motility")]
        public System.String ActiveMotility { get; set; }

        [Alias("Sluggish")]
        public System.String Sluggish { get; set; }

        [Alias("Non_Motile")]
        public System.String NonMotile { get; set; }

        [Alias("Abnormal")]
        public System.String Abnormal { get; set; }

        [Alias("Pus_Cells")]
        public System.String PusCells { get; set; }

        [Alias("RBC")]
        public System.String Rbc { get; set; }

        [Alias("Epithelial_Cell")]
        public System.String EpithelialCell { get; set; }

        [Alias("Fee")]
        public System.Int32 Fee { get; set; }

        [Ignore]
        public virtual Patient Patient { get; set; }
         [Ignore]
         public bool IsNew
         {
                get
                {
         
                  return this.SerialNo == default(int);
         
                }
                
          }
          [Ignore]
          public bool IsDeleted { get; set; }
    }
}