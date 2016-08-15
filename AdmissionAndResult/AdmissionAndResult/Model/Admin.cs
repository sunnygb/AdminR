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



        [Key]
        public long Admin_Id { get; set; }
        public string Admin_Name { get; set; }
        public string Password { get; set; }
        public DateTime Hire_Date { get; set; }
        public DateTime Change_Date { get; set; }


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
