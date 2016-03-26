//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clinical_Reporting.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SemenAnalysi
    {
        public long SerialNo { get; set; }
        public long PatientID { get; set; }
        public Nullable<System.DateTime> TDate { get; set; }
        public string Colour { get; set; }
        public string Quantity { get; set; }
        public string PH { get; set; }
        public string Time_Of_Collection { get; set; }
        public string Time_Of_Examination { get; set; }
        public string Total_Count { get; set; }
        public string Active_Motility { get; set; }
        public string Sluggish { get; set; }
        public string Non_Motile { get; set; }
        public string Abnormal { get; set; }
        public string Pus_Cells { get; set; }
        public string RBC { get; set; }
        public string Epithelial_Cell { get; set; }
        public Nullable<int> Fee { get; set; }
    
        public virtual Patient Patient { get; set; }
    }
}