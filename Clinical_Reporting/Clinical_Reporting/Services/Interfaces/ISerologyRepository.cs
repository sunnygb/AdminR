using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;

namespace Clinical_Reporting.Services
{
    interface ISerologyRepository
    {
        Task<List<Serology>> GetAllSerologyAsync();
        Task<List<Serology>> GetSerologyAsync(long patientID);
        Task<Serology> AddSerologyAsync(Serology serology);
        Task<Serology> UpdateSerologyAsync(Serology serology);
        Task DeleteSerologyAsync(long serologyID);
    }
}
