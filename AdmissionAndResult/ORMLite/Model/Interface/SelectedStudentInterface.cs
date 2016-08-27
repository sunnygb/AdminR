using System.Collections.Generic;

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
       SelectedStudent Save(SelectedStudent selectedstudent);
    }
}