using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Model;

namespace AdmissionAndResult.Model
{
      [Table("Course")]
    class WCourse
    {

        [Key]
        public long Course_Id { get; set; }
        public string Course_Name { get; set; }
        public long Student_Id { get; set; }
       
        public WCourse(Course course)
        {
            this.Course_Id=course.Course_Id  ;
            this.Course_Name = course.Course_Name;
            this.Student_Id=course.Student_Id  ;
            
        }










    }
}
