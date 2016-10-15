using AdmissionAndResult.Data;
using AdmissionAndResult.Data.Wrapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace ORMLite.Tests
{
    [TestClass]
    public class StudentWrapperTests
    {
        [TestMethod]
        public void WrapperClass_Should_Contain_StudentModel()
        {
            // Arrange

            Student student = new Student
            {
                FatherName = "Nasir Jamal",
                StudentName = "Abdullah farooq"
            };

            Qualification qualification = new Qualification
            {
                BoardName="Punjab Board",
                BSInstituteName="The Educators College",
                BSDegree="BSCS"
                
            };

            Course cource1 = new Course
            { 
              CourseName="MSCS",
            };
            Course cource2 = new Course
            {
                CourseName = "MS Psycology",
            };
            
            StudentW studentw;
            


            // Act
            student.Qualification = qualification;
            student.Courses.Add(cource1);
            student.Courses.Add(cource2);
            studentw= new StudentW(student);

            // Assert
            studentw.Model.FatherName.Should().Be("Nasir Jamal");
            studentw.Model.StudentName.Should().Be("Abdullah farooq");
            studentw.Model.Qualification.BoardName.Should().Be("Punjab Board");
            studentw.Model.Qualification.BSInstituteName.Should().Be("The Educators College");
            studentw.Model.Qualification.BSDegree.Should().Be("BSCS");
            studentw.Model.Courses.Count.Should().Be(2);
            studentw.Model.Courses[0].CourseName.Should().Be("MSCS");
            studentw.Model.Courses[1].CourseName.Should().Be("MS Psycology");


        }
        [TestMethod]
        public void WrapperClass_Should_Contain_Data()
        {
            // Arrange
            Student student = new Student
            {
                FatherName = "Nasir Jamal",
                StudentName = "Abdullah farooq"
            };

            Qualification qualification = new Qualification
            {
                BoardName="Punjab Board",
                BSInstituteName="The Educators College",
                BSDegree="BSCS"
                
            };

            Course cource1 = new Course
            { 
              CourseName="MSCS",
            };
            Course cource2 = new Course
            {
                CourseName = "MS Psycology",
            };
            StudentW studentw;

            // Act
            student.Qualification = qualification;
            student.Courses.Add(cource1);
            student.Courses.Add(cource2);
            studentw= new StudentW(student);

            // Assert
             studentw.FatherName.Should().Be("Nasir Jamal");
            studentw.StudentName.Should().Be("Abdullah farooq");
            studentw.QualificationW.BoardName.Should().Be("Punjab Board");
            studentw.QualificationW.BSInstituteName.Should().Be("The Educators College");
            studentw.QualificationW.BSDegree.Should().Be("BSCS");
            studentw.CoursesW.Count.Should().Be(2);
            studentw.CoursesW[0].CourseName.Should().Be("MSCS");
            studentw.CoursesW[1].CourseName.Should().Be("MS Psycology");

        }

        [TestMethod]
        public void Remove_Courses_In_Wrapper_Should_Also_Remove_Model_Cource()
        {

            // Arrange

            Student student = new Student
            {
                FatherName = "Nasir Jamal",
                StudentName = "Abdullah farooq"
            };

            Qualification qualification = new Qualification
            {
                BoardName = "Punjab Board",
                BSInstituteName = "The Educators College",
                BSDegree = "BSCS"

            };

            Course cource1 = new Course
            {
                CourseName = "MSCS",
            };
            Course cource2 = new Course
            {
                CourseName = "MS Psycology",
            };

            StudentW studentw;



            // Act
            student.Qualification = qualification;
            student.Courses.Add(cource1);
            student.Courses.Add(cource2);
            studentw = new StudentW(student);
            studentw.CoursesW.Remove(studentw.CoursesW.Where(a => a.Model== cource1).SingleOrDefault());

            // Assert
            studentw.CoursesW.Count.Should().Be(1);
            studentw.Model.Courses.Count.Should().Be(1);
        }

        [TestMethod]
        public void Change_In_Wrapper_Should_Also_Change_Model()
        {
            // Arrange
            QualificationW qualificationw = new QualificationW(new Qualification())
            {
                BoardName = "Punjab Board",
                BSInstituteName = "The Educators College",
                BSDegree = "BSCS"

            };

            CourseW courcew1 = new CourseW(new Course())
            {
                CourseName = "MSCS",
            };
            CourseW courcew2 = new CourseW(new Course())
            {
                CourseName = "MS Psycology",
            };

            
            StudentW studentw = new StudentW(new Student());
            
                studentw.FatherName = "Nasir Jamal";
                studentw.StudentName = "Abdullah farooq";
            




            // Act
            studentw.QualificationW = qualificationw;
            studentw.CoursesW.Add(courcew1);
            studentw.CoursesW.Add(courcew2);


            // Assert
            studentw.Model.FatherName.Should().Be("Nasir Jamal");
            studentw.Model.StudentName.Should().Be("Abdullah farooq");
            studentw.Model.Qualification.BoardName.Should().Be("Punjab Board");
            studentw.Model.Qualification.BSInstituteName.Should().Be("The Educators College");
            studentw.Model.Qualification.BSDegree.Should().Be("BSCS");
            studentw.Model.Courses.Count.Should().Be(2);
            studentw.Model.Courses[0].CourseName.Should().Be("MSCS");
            studentw.Model.Courses[1].CourseName.Should().Be("MS Psycology");



        }
    }
}
