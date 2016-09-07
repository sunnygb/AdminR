using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Data;

namespace ClinicalReporting.Data.Services
{
    public interface IBiochemistriesRepository
    {
       Task<Biochemistry> AddBiochemistryAsync(Biochemistry biochemistry);
       Task<List< Biochemistry>> GetAllBiochemistryAsync();
       Task<Biochemistry> FindBiochemistryAsync(long id);
       Task<Biochemistry> UpdateBiochemistryAsync(Biochemistry biochemistry);
       Task RemoveBiochemistryAsync(long id); 
       
       Task<Biochemistry> GetBiochemistryWithChildrenAsync(long id);
       Task<Biochemistry> SaveBiochemistryAsync(Biochemistry biochemistry);
       IDbConnectionFactory DbFactory { get; set; }
    }
}