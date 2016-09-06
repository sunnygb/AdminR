using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Services
{
    public interface IElisaTbsRepository
    {
       Task<ElisaTb> AddElisaTbAsync(ElisaTb elisatb);
       Task<List< ElisaTb>> GetAllElisaTbAsync();
       Task<ElisaTb> FindElisaTbAsync(long id);
       Task<ElisaTb> UpdateElisaTbAsync(ElisaTb elisatb);
       Task RemoveElisaTbAsync(long id); 
       
       Task<ElisaTb> GetElisaTbWithChildrenAsync(long id);
       Task<ElisaTb> SaveElisaTbAsync(ElisaTb elisatb);
    }
}