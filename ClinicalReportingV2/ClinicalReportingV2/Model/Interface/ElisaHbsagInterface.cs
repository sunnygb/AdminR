using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Data;

namespace ClinicalReporting.Data.Services
{
    public interface IElisaHbsagsRepository
    {
       Task<ElisaHbsag> AddElisaHbsagAsync(ElisaHbsag elisahbsag);
       Task<List< ElisaHbsag>> GetAllElisaHbsagAsync();
       Task<ElisaHbsag> FindElisaHbsagAsync(long id);
       Task<ElisaHbsag> UpdateElisaHbsagAsync(ElisaHbsag elisahbsag);
       Task RemoveElisaHbsagAsync(long id); 
       
       Task<ElisaHbsag> GetElisaHbsagWithChildrenAsync(long id);
       Task<ElisaHbsag> SaveElisaHbsagAsync(ElisaHbsag elisahbsag);
       IDbConnectionFactory DbFactory { get; set; }
    }
}