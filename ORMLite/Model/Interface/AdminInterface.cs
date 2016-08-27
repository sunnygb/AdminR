using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionAndResult.Data.Services
{
    public interface IAdminsRepository
    {
       Admin Add(Admin admin);
       List< Admin> GetAll();
       Admin Find(long id);
       Admin Update(Admin admin);
       void Remove(long id); 
       
       Admin GetAllWithChildren(long id);
       Admin Save(Admin admin);
    }
}