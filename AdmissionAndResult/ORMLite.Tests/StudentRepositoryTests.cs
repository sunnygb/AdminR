using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdmissionAndResult.Data.Repository;
using AdmissionAndResult.Data.Services;
using AdmissionAndResult.Data;
using FluentAssertions;
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
            var students = repo.GetAll();

            // Assert
            students[0].StudentName.Should().Be("Muhammad Ahmad");
            students.Should().NotBeNull();
            students.Count.Should().Be(5);
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
            var result = repo.Add(student);


            // Assert
            result.StudentId.Should().NotBe(0, "coz ID has been assigned by Database");
            Console.WriteLine("New ID: "+ result.StudentId);
            id = student.StudentId;
        }

        [TestMethod]
        public void Find_should_retrieve_existing_entity()
        {
            // Arrange
            IStudentsRepository repo = CreateRepository();

            // Act
           var result= repo.Find(id);
           

            //Assert
           result.Should().NotBeNull();
           result.StudentId.Should().Be(id);
           result.StudentName.Should().Be("Abdullah Farooq");
           result.StudentEmail.Should().Be("abc@Gmail.com");
           result.PermanentAddress.Should().Be("Millat Town Faisalabad");



        }

        [TestMethod]
        public void Modify_should_update_existing_entity()
        {
            // Arrange
            IStudentsRepository repo = CreateRepository();

            // Act
            var student = repo.Find(id);
            student.StudentName = "Anas Farooq";
            repo.Update(student);


            IStudentsRepository repo2 = CreateRepository();
            var result= repo2.Find(id);

            // Assert
            result.StudentName.Should().Be("Anas Farooq");

        }

        [TestMethod]
        public void Delete_should_remove_entity()
        {
            // Arrange
            IStudentsRepository repo = CreateRepository();

            // Act
            repo.Remove(id);


            IStudentsRepository repo2 = CreateRepository();
            var result = repo2.Find(id);


            // Assert
            result.Should().BeNull();
        }

        static long ID;
        [TestMethod]
        public void Insert_withChildren()
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

            student.SelectedStudents.Add(selected);

            // Act
            var result= repo.Save(student);
            
            

            // Assert
            
            result.StudentId.Should().NotBe(0, "Identity shoud be assigned by Database");
            Console.WriteLine("New ID: " + student.StudentId);
            ID = student.StudentId;
        }
        [TestMethod]
        public void Get_With_Children()
        {
            // Arrange
            var repo = CreateRepository();


            // Act
           var student= repo.GetAllWithChildren(ID);

            // Assert
           student.Should().NotBeNull();
           student.StudentId.Should().Be(ID);
           student.StudentName.Should().Be("Abdullah Farooq");
           student.SelectedStudents.Count.Should().Be(1);
           student.SelectedStudents[0].StudentRegisterationNumber.Should().Be("15-NTU-1050");
           student.SelectedStudents[0].Aggregate.Should().Be(66);
        }

        private IStudentsRepository CreateRepository()
        {
            return new StudentRepository();
        }   
    }
}
