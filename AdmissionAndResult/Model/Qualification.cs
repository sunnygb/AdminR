//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;

namespace Model
{
    using System;
    using System.Collections.Generic;
    using Dapper;
    [Table("Qualification")]
    public partial class Qualification : IDataErrorInfo
    {
        [Key]
        public long Qualification_Id { get; set; }
        public long NTS_Marks { get; set; }
        public long FSC_Marks { get; set; }
        public long Matric_Mark { get; set; }
        public string Year { get; set; }
        public string Institute_Name { get; set; }
        public string Roll_No { get; set; }
        public string Board_Name { get; set; }
        public long GAT_Marks { get; set; }
        public long Batchlor_CGPA { get; set; }
        public long MSC_CGPA { get; set; }
    
        public virtual Student Student { get; set; }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Nts_Marks":
                        if (string.IsNullOrEmpty(NTS_Marks.ToString()))
                            return "Nts marks is required";
                        break;
                    case "FSC_Marks":
                        if (string.IsNullOrEmpty(FSC_Marks.ToString()))
                            return "FSC marks is Required";
                        break;
                    case "Year":
                        if (string.IsNullOrEmpty(Year))
                            return "Year is required";
                        break;
                    case "Matric_Mark":
                        if (string.IsNullOrEmpty(Matric_Mark.ToString()))
                            return "Matric marks is Required";
                        break;
                    case "Institute_Name":
                        if (string.IsNullOrEmpty(Institute_Name))
                            return "Institute Name is required";
                        break;
                    case "Roll_No":
                        if (string.IsNullOrEmpty(Roll_No))
                            return "Roll No. is required";
                        break;
                    case "Board_Name":
                        if (string.IsNullOrEmpty(Board_Name))
                            return "Board Name is required";
                        break;
                    case "Gat_Mark":
                        if (string.IsNullOrEmpty(GAT_Marks.ToString()))
                            return "GAT marks is Required";
                        break;
                    case "Batchlor_CGPA":
                        if (string.IsNullOrEmpty(Batchlor_CGPA.ToString()))
                            return "Batchelor CGPA is Required";
                        break;
                    case "MSC_CGPA":
                        if (string.IsNullOrEmpty(MSC_CGPA.ToString()))
                            return "MSC CGPA is Required";
                        break;
                        
                }
                return "";
            }
        }
    }
}
