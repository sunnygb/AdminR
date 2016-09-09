using ServiceStack.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Services
{
    public interface IElisaHcvsRepository
    {
        IDbConnectionFactory DbFactory { get; set; }
        Task<ElisaHcv> AddElisaHcvAsync(ElisaHcv elisahcv);
        Task<List<ElisaHcv>> GetAllElisaHcvAsync();
        Task<ElisaHcv> FindElisaHcvAsync(long id);
        Task<ElisaHcv> UpdateElisaHcvAsync(ElisaHcv elisahcv);
        Task RemoveElisaHcvAsync(long id);

        Task<ElisaHcv> GetElisaHcvWithChildrenAsync(long id);
        Task<ElisaHcv> SaveElisaHcvAsync(ElisaHcv elisahcv);
    }
}