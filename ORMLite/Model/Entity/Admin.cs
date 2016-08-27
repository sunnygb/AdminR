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

        [PrimaryKey]
        [AutoIncrement]  
        [Alias("Admin_Id")]
        public long AdminId { get; set; }

        [Alias("Admin_Name")]
        public string AdminName { get; set; }

        [Alias("Password")]
        public string Password { get; set; }

        [Alias("Hire_Date")]
        public string HireDate { get; set; }

        [Alias("Change_Date")]
        public string ChangeDate { get; set; }

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