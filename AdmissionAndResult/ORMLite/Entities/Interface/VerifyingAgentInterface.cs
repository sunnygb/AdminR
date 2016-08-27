using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionAndResult.Data.Services
{
    public interface IVerifyingAgentsRepository
    {
       VerifyingAgent Add(VerifyingAgent verifyingagent);
       List< VerifyingAgent> GetAll();
       VerifyingAgent Find(long id);
       VerifyingAgent Update(VerifyingAgent verifyingagent);
       void Remove(long id); 
       
       VerifyingAgent GetAllWithChildren(long id);
       VerifyingAgent Save(VerifyingAgent verifyingagent);
    }
}