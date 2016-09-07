using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Data;

namespace ClinicalReporting.Data.Services
{
    public interface IUrineExaminationsRepository
    {
       Task<UrineExamination> AddUrineExaminationAsync(UrineExamination urineexamination);
       Task<List< UrineExamination>> GetAllUrineExaminationAsync();
       Task<UrineExamination> FindUrineExaminationAsync(long id);
       Task<UrineExamination> UpdateUrineExaminationAsync(UrineExamination urineexamination);
       Task RemoveUrineExaminationAsync(long id); 
       
       Task<UrineExamination> GetUrineExaminationWithChildrenAsync(long id);
       Task<UrineExamination> SaveUrineExaminationAsync(UrineExamination urineexamination);
       IDbConnectionFactory DbFactory { get; set; }
    }
}