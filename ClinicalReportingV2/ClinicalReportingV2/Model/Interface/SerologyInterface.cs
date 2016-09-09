using ServiceStack.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Services
{
    public interface ISerologiesRepository
    {
        IDbConnectionFactory DbFactory { get; set; }
        Task<Serology> AddSerologyAsync(Serology serology);
        Task<List<Serology>> GetAllSerologyAsync();
        Task<Serology> FindSerologyAsync(long id);
        Task<Serology> UpdateSerologyAsync(Serology serology);
        Task RemoveSerologyAsync(long id);

        Task<Serology> GetSerologyWithChildrenAsync(long id);
        Task<Serology> SaveSerologyAsync(Serology serology);
    }
}