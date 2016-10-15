using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Alias("Verifying_Agent")]
    public partial class VerifyingAgent
    {
        
        public VerifyingAgent()
        {
        }
        

        [PrimaryKey]
        [Alias("Verifying_Agent_Id")]
        public System.Int64 VerifyingAgentId { get; set; }

        [Alias("Verifying_Agent_Name")]
        public System.String VerifyingAgentName { get; set; }

        [Alias("Degree_Verification")]
        public System.String DegreeVerification { get; set; }

        [Alias("Admin_Id")]
        public System.Int64 AdminId { get; set; }

        [Alias("Send_Date")]
        public System.String SendDate { get; set; }

        [Alias("Recive_Date")]
        public System.String ReciveDate { get; set; }

        [Alias("Student_Id")]
        public System.Int64 StudentId { get; set; }

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