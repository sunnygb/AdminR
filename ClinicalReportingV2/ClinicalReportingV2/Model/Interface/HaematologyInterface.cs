using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Data;

namespace ClinicalReporting.Data.Services
{
    public interface IHaematologiesRepository
    {
       Task<Haematology> AddHaematologyAsync(Haematology haematology);
       Task<List< Haematology>> GetAllHaematologyAsync();
       Task<Haematology> FindHaematologyAsync(long id);
       Task<Haematology> UpdateHaematologyAsync(Haematology haematology);
       Task RemoveHaematologyAsync(long id); 
       
       Task<Haematology> GetHaematologyWithChildrenAsync(long id);
       Task<Haematology> SaveHaematologyAsync(Haematology haematology);
       IDbConnectionFactory DbFactory { get; set; }
    }
}