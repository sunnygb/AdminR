using ServiceStack.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Services
{
    public interface IHaematologiesRepository
    {
        IDbConnectionFactory DbFactory { get; set; }
        Task<Haematology> AddHaematologyAsync(Haematology haematology);
        Task<List<Haematology>> GetAllHaematologyAsync();
        Task<Haematology> FindHaematologyAsync(long id);
        Task<Haematology> UpdateHaematologyAsync(Haematology haematology);
        Task RemoveHaematologyAsync(long id);

        Task<Haematology> GetHaematologyWithChildrenAsync(long id);
        Task<Haematology> SaveHaematologyAsync(Haematology haematology);
    }
}