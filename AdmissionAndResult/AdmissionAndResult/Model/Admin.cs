//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using AdmissionAndResult.Model.Wrapper;

namespace AdmissionAndResult.Model
{

    [Table("Admin")]
     class Admin
    {

        public Admin(AdminW adminw)
        {
            this.Admin_Id = adminw.Admin_Id;
            this.Admin_Name = adminw.Admin_Name ;
            this.Password =  adminw.Password;
            this.Change_Date = adminw.Change_Date.ToString();
            this.Hire_Date = adminw.Hire_Date.ToString();
        }
        public Admin(){}
        [Key]
        public long Admin_Id { get; set; }
        public string Admin_Name { get; set; }
        public string Password { get; set; }
        public string Hire_Date { get; set; }
        public string Change_Date { get; set; }

        
                      
               
    }
}