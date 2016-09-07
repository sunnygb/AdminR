using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Data;

namespace ClinicalReporting.Data.Services
{
    public interface IBloodGroupsRepository
    {
       Task<BloodGroup> AddBloodGroupAsync(BloodGroup bloodgroup);
       Task<List< BloodGroup>> GetAllBloodGroupAsync();
       Task<BloodGroup> FindBloodGroupAsync(long id);
       Task<BloodGroup> UpdateBloodGroupAsync(BloodGroup bloodgroup);
       Task RemoveBloodGroupAsync(long id); 
       
       Task<BloodGroup> GetBloodGroupWithChildrenAsync(long id);
       Task<BloodGroup> SaveBloodGroupAsync(BloodGroup bloodgroup);
       IDbConnectionFactory DbFactory { get; set; }
    }
}