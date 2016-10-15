using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdmissionAndResult.Data.Services
{
    public interface IAdminsRepository
    {
       Task<Admin> AddAdminAsync(Admin admin);
       Task<List< Admin>> GetAllAdminAsync();
       Task<Admin> FindAdminAsync(long id);
       Task<Admin> UpdateAdminAsync(Admin admin);
       Task RemoveAdminAsync(long id); 
       
       Task<Admin> GetAdminWithChildrenAsync(long id);
       Task<Admin> SaveAdminAsync(Admin admin);
    }
}