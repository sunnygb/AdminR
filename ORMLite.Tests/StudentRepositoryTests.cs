using System;   
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdmissionAndResult.Data.Repository;
using AdmissionAndResult.Data.Services;
using AdmissionAndResult.Data;
using FluentAssertions;
using ServiceStack.OrmLite;
using System.Linq;
using System.Threading.Tasks;
namespace ORMLite.Tests
{
    [TestClass]
    public class StudentRepositoryTests
    {
        
        [TestMethod]
        public void GetAll_return_5_Results()
        {
            // Arrange
            IStudentsRepository repo = CreateRepository();

            // Act
            var students = repo.GetAllStudentAsync();

            // Assert
            
            students.Result[0].StudentName.Should().Be("Muhammad Ahmad");
            students.Should().NotBeNull();
            students.Result.Count.Should().Be(4);
        }

        static long id;
        [TestMethod]
        public void Insert_should_Assign_new_Identity_To_Entity()
        {
            // Arrange
            IStudentsRepository repo = CreateRepository();
            var student = new Student()
            {
                StudentName = "Abdullah Farooq",
                FatherName = "Nasir Jama",
                StudentEmail = "abc@Gmail.com",
                PermanentAddress = "Millat Town Faisalabad"

            };

            // Act
            var result = repo.AddStudentAsync(student);


            // Assert
            result.Result.StudentId.Should().NotBe(0, "coz ID has been assigned by Database");
            Console.WriteLine("New ID: " + result.Result.StudentId);
            id = student.StudentId;
        }

        [TestMethod]
        public void Find_should_retrieve_existing_entity()
        {
            // Arrange
            IStudentsRepository repo = CreateRepository();

            // Act
           var result= repo.FindStudentAsync(id);
           

            //Assert
           result.Should().NotBeNull();
           result.Result.StudentId.Should().Be(id);
           result.Result.StudentName.Should().Be("Abdullah Farooq");
           result.Result.StudentEmail.Should().Be("abc@Gmail.com");
           result.Result.PermanentAddress.Should().Be("Millat Town Faisalabad");



        }

        [TestMethod]
        public async Task Modify_should_update_existing_entity()
        {
            // Arrange
            IStudentsRepository repo = CreateRepository();

            // Act
            var student = repo.FindStudentAsync(id);
            student.Result.StudentName = "Anas Farooq";
           await repo.UpdateStudentAsync(student.Result);


            IStudentsRepository repo2 = CreateRepository();
            var result= repo2.FindStudentAsync(id);

            // Assert
            result.Result.StudentName.Should().Be("Anas Farooq");

        }

        [TestMethod]
        public void Delete_should_remove_entity()
        {
            // Arrange
            IStudentsRepository repo = CreateRepository();

            // Act
            repo.RemoveStudentAsync(id);


            IStudentsRepository repo2 = CreateRepository();
            var result = repo2.FindStudentAsync(id);


            // Assert
            result.Result.Should().BeNull();
        }

        static long ID;
        [TestMethod]
        public async Task Insert_withChildren()
        {
            // Arrange
            IStudentsRepository repo = CreateRepository();

            var student = new Student()
            {
                StudentName = "Abdullah Farooq",
                FatherName = "Nasir Jama",
                StudentEmail = "abc@Gmail.com",
                PermanentAddress = "Millat Town Faisalabad"

            };

            var selected= new SelectedStudent()
            {
                StudentRegisterationNumber="15-NTU-1050",
                Aggregate=66,

            };

            student.SelectedStudent = selected;

            // Act
            var result= repo.SaveStudentAsync(student);
            
            

            // Assert

            result.Result.StudentId.Should().NotBe(0, "Identity shoud be assigned by Database");
            Console.WriteLine("New ID: " + student.StudentId);
            ID = student.StudentId;
        }
        [TestMethod]
        public void Get_With_Children()
        {
            // Arrange
            var repo = CreateRepository();


            // Act
           var student= repo.GetStudentWithChildrenAsync(ID);

            // Assert
           student.Should().NotBeNull();
           student.Result.StudentId.Should().Be(ID);
               student.Result.StudentName.Should().Be("Abdullah Farooq");
           student.Result.SelectedStudent.StudentRegisterationNumber.Should().Be("15-NTU-1050");
           student.Result.SelectedStudent.Aggregate.Should().Be(66);
        }

        [TestMethod]
        public async Task Modify_With_Children_Should_Modify_Children()
        {
            // Arrange
            var repo = CreateRepository();
            var student = repo.GetStudentWithChildrenAsync(ID);


            // Act
            student.Result.SelectedStudent.StudentRegisterationNumber = "15-NTU-1070";
           var s= await repo.SaveStudentAsync(student.Result);

            // Assert
            var repo2 = CreateRepository();
            var student2 = repo2.GetStudentWithChildrenAsync(ID);

            student2.Result.SelectedStudent.StudentRegisterationNumber.Should().Be("15-NTU-1070");


        }

        [TestMethod]
        public async Task Delete_With_Children_Should_Delete_Children()
        {
            // Arrange
            var repo = CreateRepository();
            var student = repo.GetStudentWithChildrenAsync(ID);


            // Act
            student.Result.SelectedStudent.IsDeleted = true;
            await repo.SaveStudentAsync(student.Result);

            // Assert
            var repo2 = CreateRepository();
            var student2 = repo2.GetStudentWithChildrenAsync(ID);

            student2.Result.SelectedStudent.Should().BeNull();
        }

        private IStudentsRepository CreateRepository()
        {
            StudentRepository repo =new StudentRepository();
            var db = new OrmLiteConnectionFactory("D://AdmissionAndResult//ORMLite.Tests//bin//Debug//SystemDB.db",SqliteDialect.Provider);
            repo.DbFactory = db;
            return repo;
        }   
    }
}
