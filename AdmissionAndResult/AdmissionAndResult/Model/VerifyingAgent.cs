using AdmissionAndResult.Model.Wrapper;
using Dapper.Contrib.Extensions;

namespace AdmissionAndResult.Model
{
    [Table("Verifying_Agent")]

    class VerifyingAgent
    {
        public VerifyingAgent(VerifyingAgentW verifyingAgent)
        {
            this.Verifying_Agent_Id = verifyingAgent.Verifying_Agent_Id;
            this.Verifying_Agent_Name = verifyingAgent.Verifying_Agent_Name;
            this.Degree_Verification = verifyingAgent.Degree_Verification;
            this.Admin_Id = verifyingAgent.Admin_Id;
            this.Send_Date = verifyingAgent.Send_Date;
            this.Recive_Date = verifyingAgent.Recive_Date;
            this.Student_Id = verifyingAgent.Student_Id;
        }
        public VerifyingAgent() { }
















        [Key]
        public long Verifying_Agent_Id { get; set; }
        public string Verifying_Agent_Name { get; set; }
        //public long Verified_Marks { get; set; }
        //public long Verified_CGPA { get; set; }
        public string Degree_Verification { get; set; }
        public long Admin_Id { get; set; }
        //public string Degree { get; set; }
        //public long Eligible { get; set; }
        public string Send_Date { get; set; }
        public string Recive_Date { get; set; }
        public long Student_Id { get; set; }
    }
}
