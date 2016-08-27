using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionAndResult.Data.Services
{
    public interface IQualificationsRepository
    {
       Qualification Add(Qualification qualification);
       List< Qualification> GetAll();
       Qualification Find(long id);
       Qualification Update(Qualification qualification);
       void Remove(long id); 
       
       Qualification GetAllWithChildren(long id);
       Qualification Save(Qualification qualification);
    }
}