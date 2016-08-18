using AdmissionAndResult.Model.Wrapper;
using Dapper.Contrib.Extensions;

namespace AdmissionAndResult.Model
{
      [Table("Course")]
    class Course
    {

        [Key]
        public long Course_Id { get; set; }
        public string Course_Name { get; set; }
        public long Student_Id { get; set; }

        public Course() { }
       
        public Course(CourseW course)
        {
            this.Course_Id=course.Course_Id  ;
            this.Course_Name = course.Course_Name;
            this.Student_Id=course.Student_Id  ;
            
        }










    }
}
