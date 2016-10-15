using AdmissionAndResult.Data.Wrapper;
using ServiceStack.DataAnnotations;
using System.Collections.Generic;
namespace AdmissionAndResult.Data
{


    [Alias("Admin")]
    public partial class Admin
    {
        
        public Admin()
        {
            VerifyingAgents = new List<VerifyingAgent>();
        }
        
        public Admin(AdminW adminw)
        {
           this.AdminId = adminw.AdminId;
           this.AdminName = adminw.AdminName;
           this.Password = adminw.Password;
           this.HireDate = adminw.HireDate;
           this.ChangeDate = adminw.ChangeDate;
           
           VerifyingAgents = new List<VerifyingAgent>();
           
        }

        [PrimaryKey]
        [Alias("Admin_Id")]
        public System.Int64 AdminId { get; set; }

        [Alias("Admin_Name")]
        public System.String AdminName { get; set; }

        [Alias("Password")]
        public System.String Password { get; set; }

        [Alias("Hire_Date")]
        public System.String HireDate { get; set; }

        [Alias("Change_Date")]
        public System.String ChangeDate { get; set; }

        [Ignore]
        public virtual List<VerifyingAgent> VerifyingAgents { get; set; }
         [Ignore]
         public bool IsNew
         {
                get
                {
         
                  return this.AdminId == default(int);
         
                }
                
          }
          [Ignore]
          public bool IsDeleted { get; set; }
    }
}