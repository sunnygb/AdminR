using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionAndResult.Data.Services
{
    public interface ISelectedStudentsRepository
    {
       SelectedStudent Add(SelectedStudent selectedstudent);
       List< SelectedStudent> GetAll();
       SelectedStudent Find(long id);
       SelectedStudent Update(SelectedStudent selectedstudent);
       void Remove(long id); 
       
       SelectedStudent GetAllWithChildren(long id);
       void Save(SelectedStudent selectedstudent);
    }
}