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
    [Table("Department")]
    public partial class Department
    {
        [Key]
        public long Department_ID { get; set; }
        public string Department_Name { get; set; }
        public long Student_Strength { get; set; }
        public string HOD_Name { get; set; }
        public string Location { get; set; }
        public virtual IEnumerable<Selected_Student> Selected_Student { get; set; }
    }
}
