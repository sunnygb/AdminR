using ServiceStack.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Services
{
    public interface IUrineExaminationsRepository
    {
        IDbConnectionFactory DbFactory { get; set; }
        Task<UrineExamination> AddUrineExaminationAsync(UrineExamination urineexamination);
        Task<List<UrineExamination>> GetAllUrineExaminationAsync();
        Task<UrineExamination> FindUrineExaminationAsync(long id);
        Task<UrineExamination> UpdateUrineExaminationAsync(UrineExamination urineexamination);
        Task RemoveUrineExaminationAsync(long id);

        Task<UrineExamination> GetUrineExaminationWithChildrenAsync(long id);
        Task<UrineExamination> SaveUrineExaminationAsync(UrineExamination urineexamination);
    }
}