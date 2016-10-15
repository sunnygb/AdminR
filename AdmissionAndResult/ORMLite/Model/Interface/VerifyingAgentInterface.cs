using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdmissionAndResult.Data.Services
{
    public interface IVerifyingAgentsRepository
    {
       Task<VerifyingAgent> AddVerifyingAgentAsync(VerifyingAgent verifyingagent);
       Task<List< VerifyingAgent>> GetAllVerifyingAgentAsync();
       Task<VerifyingAgent> FindVerifyingAgentAsync(long id);
       Task<VerifyingAgent> UpdateVerifyingAgentAsync(VerifyingAgent verifyingagent);
       Task RemoveVerifyingAgentAsync(long id); 
       
       Task<VerifyingAgent> GetVerifyingAgentWithChildrenAsync(long id);
       Task<VerifyingAgent> SaveVerifyingAgentAsync(VerifyingAgent verifyingagent);
    }
}