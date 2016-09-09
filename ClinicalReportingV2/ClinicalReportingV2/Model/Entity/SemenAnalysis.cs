using ClinicalReporting.Data.Wrapper;
using ServiceStack.DataAnnotations;
using System;

namespace ClinicalReporting.Data
{
    [Alias("SemenAnalysis")]
    public class SemenAnalysis
    {
        public SemenAnalysis()
        {
        }

        public SemenAnalysis(SemenAnalysisW semenanalysisw)
        {
            SerialNo = semenanalysisw.SerialNo;
            PatientID = semenanalysisw.PatientID;
            TDate = semenanalysisw.TDate;
            Colour = semenanalysisw.Colour;
            Quantity = semenanalysisw.Quantity;
            Ph = semenanalysisw.Ph;
            TimeOfCollection = semenanalysisw.TimeOfCollection;
            TimeOfExamination = semenanalysisw.TimeOfExamination;
            TotalCount = semenanalysisw.TotalCount;
            ActiveMotility = semenanalysisw.ActiveMotility;
            Sluggish = semenanalysisw.Sluggish;
            NonMotile = semenanalysisw.NonMotile;
            Abnormal = semenanalysisw.Abnormal;
            PusCells = semenanalysisw.PusCells;
            Rbc = semenanalysisw.Rbc;
            EpithelialCell = semenanalysisw.EpithelialCell;
            Fee = semenanalysisw.Fee;
        }

        [PrimaryKey]
        [Alias("SerialNo")]
        public Int64 SerialNo { get; set; }

        [Alias("PatientID")]
        public Int64 PatientID { get; set; }

        [Alias("TDate")]
        public DateTime TDate { get; set; }

        [Alias("Colour")]
        public String Colour { get; set; }

        [Alias("Quantity")]
        public String Quantity { get; set; }

        [Alias("PH")]
        public String Ph { get; set; }

        [Alias("Time_Of_Collection")]
        public String TimeOfCollection { get; set; }

        [Alias("Time_Of_Examination")]
        public String TimeOfExamination { get; set; }

        [Alias("Total_Count")]
        public String TotalCount { get; set; }

        [Alias("Active_Motility")]
        public String ActiveMotility { get; set; }

        [Alias("Sluggish")]
        public String Sluggish { get; set; }

        [Alias("Non_Motile")]
        public String NonMotile { get; set; }

        [Alias("Abnormal")]
        public String Abnormal { get; set; }

        [Alias("Pus_Cells")]
        public String PusCells { get; set; }

        [Alias("RBC")]
        public String Rbc { get; set; }

        [Alias("Epithelial_Cell")]
        public String EpithelialCell { get; set; }

        [Alias("Fee")]
        public Int32 Fee { get; set; }

        [Ignore]
        public virtual Patient Patient { get; set; }

        [Ignore]
        public bool IsNew
        {
            get { return SerialNo == default(int); }
        }

        [Ignore]
        public bool IsDeleted { get; set; }
    }
}