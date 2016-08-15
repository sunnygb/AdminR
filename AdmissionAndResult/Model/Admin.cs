using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Model;

namespace AdmissionAndResult.Model
{
    [Table("Admin")]
    public class Admin
    {

        public void setAdmin(wAdmin wadmin)
        {
            wadmin.Admin_Id = this.Admin_Id;
            wadmin.Admin_Name = this.Admin_Name;
            wadmin.Password = this.Password;
            wadmin.Change_Date = this.Hire_Date;
            wadmin.Change_Date = this.Change_Date;
        }
        
        
        
        
        
        [Key]
        public long Admin_Id { get; set; }
        public string Admin_Name { get; set; }
        public string Password { get; set; }
        public DateTime Hire_Date { get; set; }
        public DateTime Change_Date { get; set; }


       
    }
}
