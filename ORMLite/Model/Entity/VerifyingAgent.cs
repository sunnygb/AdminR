using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;

namespace AdmissionAndResult.Data
{


    [Alias("Verifying_Agent")]
    public partial class VerifyingAgent
    {
        
        public VerifyingAgent()
        {
        }

        [PrimaryKey]
        [Alias("Verifying_Agent_Id")]
        public long VerifyingAgentId { get; set; }

        [Alias("Verifying_Agent_Name")]
        public string VerifyingAgentName { get; set; }

        [Alias("Degree_Verification")]
        public string DegreeVerification { get; set; }

        [Alias("Admin_Id")]
        public long AdminId { get; set; }

        [Alias("Send_Date")]
        public string SendDate { get; set; }

        [Alias("Recive_Date")]
        public string ReciveDate { get; set; }

        [Alias("Student_Id")]
        public long StudentId { get; set; }

        [Ignore]
        public virtual Admin Admin { get; set; }
        [Ignore]
        public virtual Student Student { get; set; }
         [Ignore]
         public bool IsNew
         {
                get
                {
         
                  return this.VerifyingAgentId == default(int);
         
                }
                
          }
          [Ignore]
          public bool IsDeleted { get; set; }
    }
}