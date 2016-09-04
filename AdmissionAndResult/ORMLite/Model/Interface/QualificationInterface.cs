using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionAndResult.Data.Services
{
    public interface IQualificationsRepository
    {
       Task<Qualification> AddQualificationAsync(Qualification qualification);
       Task<List< Qualification>> GetAllQualificationAsync();
       Task<Qualification> FindQualificationAsync(long id);
       Task<Qualification> UpdateQualificationAsync(Qualification qualification);
       Task RemoveQualificationAsync(long id); 
       
       Task<Qualification> GetQualificationWithChildrenAsync(long id);
       Task<Qualification> SaveQualificationAsync(Qualification qualification);
    }
}