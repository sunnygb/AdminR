//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    using Dapper;
    [Table("Selected_Student")]
    public partial class Selected_Student
    {
        [Key]
        public long Selected_Student_Id { get; set; }
        [Key]
        public string Student_Registeration_Number { get; set; }
        public double Aggregate { get; set; }
        public long Cource_Id { get; set; }
        public string CGPA_Text { get; set; }
        public string SGPA { get; set; }
        public long Department_ID { get; set; }
        public virtual Course Course { get; set; }
        public virtual Department Department { get; set; }
        public virtual Student Student { get; set; }
    }
}