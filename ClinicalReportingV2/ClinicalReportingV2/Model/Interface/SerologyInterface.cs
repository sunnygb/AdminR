using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Services
{
    public interface ISerologiesRepository
    {
       Task<Serology> AddSerologyAsync(Serology serology);
       Task<List< Serology>> GetAllSerologyAsync();
       Task<Serology> FindSerologyAsync(long id);
       Task<Serology> UpdateSerologyAsync(Serology serology);
       Task RemoveSerologyAsync(long id); 
       
       Task<Serology> GetSerologyWithChildrenAsync(long id);
       Task<Serology> SaveSerologyAsync(Serology serology);
    }
}