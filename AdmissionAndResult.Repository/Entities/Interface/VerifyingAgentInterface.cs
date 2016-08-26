using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface IVerifyingAgentsRepository
    {
    
      
       List< VerifyingAgent> GetAll();
       VerifyingAgent Find(int id);
       VerifyingAgent Update(VerifyingAgent verifyingagent);
       void Remove(int id); 
       VerifyingAgent GetFull(int id);
       void Save(VerifyingAgent verifyingagent);
      
      
    }
}