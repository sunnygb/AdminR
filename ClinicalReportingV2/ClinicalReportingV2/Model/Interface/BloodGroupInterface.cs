using ServiceStack.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Services
{
    public interface IBloodGroupsRepository
    {
        IDbConnectionFactory DbFactory { get; set; }
        Task<BloodGroup> AddBloodGroupAsync(BloodGroup bloodgroup);
        Task<List<BloodGroup>> GetAllBloodGroupAsync();
        Task<BloodGroup> FindBloodGroupAsync(long id);
        Task<BloodGroup> UpdateBloodGroupAsync(BloodGroup bloodgroup);
        Task RemoveBloodGroupAsync(long id);

        Task<BloodGroup> GetBloodGroupWithChildrenAsync(long id);
        Task<BloodGroup> SaveBloodGroupAsync(BloodGroup bloodgroup);
    }
}