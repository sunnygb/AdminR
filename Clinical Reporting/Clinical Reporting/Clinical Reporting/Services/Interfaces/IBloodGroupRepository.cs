using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;

namespace Clinical_Reporting.Services
{
    interface IBloodGroupRepository
    {
        Task<List<BloodGroup>> GetAllBloodGroupAsync();
        Task<BloodGroup> GetBloodGroupAsync(long PatientID);
        Task<BloodGroup> AddBloodGroupAsync(BloodGroup BloodGroupnt);
        Task<BloodGroup> UpdateBloodGroupAsync(BloodGroup BloodGroup);
        Task DeleteBloodGrouptAsync(long BloodGroup_ID);


    }
}
