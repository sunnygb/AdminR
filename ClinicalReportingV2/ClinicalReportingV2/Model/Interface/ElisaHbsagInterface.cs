using ServiceStack.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Services
{
    public interface IElisaHbsagsRepository
    {
        IDbConnectionFactory DbFactory { get; set; }
        Task<ElisaHbsag> AddElisaHbsagAsync(ElisaHbsag elisahbsag);
        Task<List<ElisaHbsag>> GetAllElisaHbsagAsync();
        Task<ElisaHbsag> FindElisaHbsagAsync(long id);
        Task<ElisaHbsag> UpdateElisaHbsagAsync(ElisaHbsag elisahbsag);
        Task RemoveElisaHbsagAsync(long id);

        Task<ElisaHbsag> GetElisaHbsagWithChildrenAsync(long id);
        Task<ElisaHbsag> SaveElisaHbsagAsync(ElisaHbsag elisahbsag);
    }
}