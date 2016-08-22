using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities.Services
{
    public interface IVerifyingAgentsRepository
    {
    
      
      public List< VerifyingAgent> GetAll();
      public VerifyingAgent Find(int id);
      public VerifyingAgent Update(VerifyingAgent verifyingagent);
      public void Remove(int id); 
      public VerifyingAgent GetFull(int id);
      public void Save(VerifyingAgent verifyingagent);
      
      
    }
}