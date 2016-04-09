using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;

namespace Clinical_Reporting.Services
{
    interface IUrineExaminationRepository
    {
        Task<List<UrineExamination>> GetAllUrineExaminationAsync();
        Task<UrineExamination> GetUrineExaminationAsync(long patientID);
        Task<UrineExamination> AddUrineExaminationAsync(UrineExamination urineExamination);
        Task<UrineExamination> UpdateUrineExaminationAsync(UrineExamination urineExamination);
        Task DeleteUrineExaminationAsync(long urineExaminationID);
    }
}
