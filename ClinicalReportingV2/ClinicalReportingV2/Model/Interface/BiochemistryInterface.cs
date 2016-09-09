using ServiceStack.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Services
{
    public interface IBiochemistriesRepository
    {
        IDbConnectionFactory DbFactory { get; set; }
        Task<Biochemistry> AddBiochemistryAsync(Biochemistry biochemistry);
        Task<List<Biochemistry>> GetAllBiochemistryAsync();
        Task<Biochemistry> FindBiochemistryAsync(long id);
        Task<Biochemistry> UpdateBiochemistryAsync(Biochemistry biochemistry);
        Task RemoveBiochemistryAsync(long id);

        Task<Biochemistry> GetBiochemistryWithChildrenAsync(long id);
        Task<Biochemistry> SaveBiochemistryAsync(Biochemistry biochemistry);
    }
}