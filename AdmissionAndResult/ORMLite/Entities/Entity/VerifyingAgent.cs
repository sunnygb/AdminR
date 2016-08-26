using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionAndResult.Data
{



    public partial class VerifyingAgent
    {
    
        public VerifyingAgent()
        {
        }

        public long VerifyingAgentId { get; set; }
        public string VerifyingAgentName { get; set; }
        public string DegreeVerification { get; set; }
        public long AdminId { get; set; }
        public string SendDate { get; set; }
        public string ReciveDate { get; set; }
        public long StudentId { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Student Student { get; set; }

         public bool IsNew
         {
                get
                {
         
                  return this.VerifyingAgentId == default(int);
         
                }
                
          }
          public bool IsDeleted { get; set; }
    }
}