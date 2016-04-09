using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;

namespace Clinical_Reporting.Services
{
    interface IHaematologyRepository
    {
        Task<List<Haematology>> GetAllHaematologyAsync();
        Task<Haematology> GetHaematologyAsync(long PatientID);
        Task<Haematology> AddHaematologyAsync(Haematology Haematology);
        Task<Haematology> UpdateHaematologyAsync(Haematology Haematology);
        Task DeleteHaematologyAsync(long HaematologyID);
    }
}
