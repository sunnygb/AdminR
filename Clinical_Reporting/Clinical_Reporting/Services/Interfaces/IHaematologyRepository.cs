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
        Task<List<Haematology>> GetHaematologyAsync(long patientID);
        Task<Haematology> AddHaematologyAsync(Haematology haematology);
        Task<Haematology> UpdateHaematologyAsync(Haematology haematology);
        Task DeleteHaematologyAsync(long haematologyID);
    }
}
