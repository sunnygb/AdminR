using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Data;

namespace ClinicalReporting.Data.Services
{
    public interface IElisaHcvsRepository
    {
       Task<ElisaHcv> AddElisaHcvAsync(ElisaHcv elisahcv);
       Task<List< ElisaHcv>> GetAllElisaHcvAsync();
       Task<ElisaHcv> FindElisaHcvAsync(long id);
       Task<ElisaHcv> UpdateElisaHcvAsync(ElisaHcv elisahcv);
       Task RemoveElisaHcvAsync(long id); 
       
       Task<ElisaHcv> GetElisaHcvWithChildrenAsync(long id);
       Task<ElisaHcv> SaveElisaHcvAsync(ElisaHcv elisahcv);
       IDbConnectionFactory DbFactory { get; set; }
    }
}