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
    using Dapper.Contrib.Extensions;
    [Table("Admin")]
    public partial class Admin:IDataErrorInfo
    {
       
        [Key]
        public long Admin_Id { get; set; }
        public string Admin_Name { get; set; }
        public string Password { get; set; }
        public DateTime Hire_Date { get; set; }
        public DateTime Change_Date { get; set; }

        
       
        public virtual IEnumerable<Verifying_Agent> Verifying_Agent { get; set; }

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
                    case "Admin_Name":
                        if (string.IsNullOrEmpty(Admin_Name))
                            return "Admin Name is required";
                        break;
                    case "Password":
                        if (string.IsNullOrEmpty(Password))
                            return "Password is Required";
                        break;
                      
                }
                return "";
            }
        }
    }
}
