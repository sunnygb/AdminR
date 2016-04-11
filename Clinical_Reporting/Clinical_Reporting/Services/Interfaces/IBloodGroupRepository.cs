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
        Task<List<BloodGroup>> GetBloodGroupAsync(long patientID);
        Task<BloodGroup> AddBloodGroupAsync(BloodGroup bloodGroupnt);
        Task<BloodGroup> UpdateBloodGroupAsync(BloodGroup bloodGroup);
        Task DeleteBloodGrouptAsync(long bloodGroup_ID);


    }
}
