using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SalarDb.CodeGen.Entities
{

	
	[Table("Selected_Student")]
	public partial class Selected_Student 
	{

		[Key]
		[Column("Selected_Student_Id")]
		public Int64 Selected_Student_Id { get; set; }

	
		[Column("Student_Registeration_Number")]
		public String Student_Registeration_Number { get; set; }

	
		[Column("Aggregate")]
		public Double Aggregate { get; set; }

		[Column("Degree_Name")]
		public String Degree_Name { get; set; }


		
		
		public virtual IEnumerable<Qualification> Qualification { get; set; }

		
		
		public virtual IEnumerable<Student> Student { get; set; }

	
	
		public virtual IEnumerable<Admin> Admin { get; set; }



	}

	
	[Table("Verifying_Agent")]
	public partial class Verifying_Agent 
	{

	
		[Key]
		[Column("Verifying_Agent_Id")]
		public Int64 Verifying_Agent_Id { get; set; }

		[Column("Verifying_Agent_Name")]
		public String Verifying_Agent_Name { get; set; }

	
		[Column("Verified_FSC_Marks")]
		public String Verified_FSC_Marks { get; set; }

	
		[Column("Verified_NTS_Marks")]
		public String Verified_NTS_Marks { get; set; }


	
		public virtual IEnumerable<Admin> Admin { get; set; }



	}


	[Table("Qualification")]
	public partial class Qualification 
	{

	
		[Key]
		[Column("Qualification_Id")]
		public Int64 Qualification_Id { get; set; }

	
		[Column("Selected_Student_Id")]
		public Int64? Selected_Student_Id { get; set; }

		[Column("NTS_Marks")]
		public Int64 NTS_Marks { get; set; }


		[Column("FSC_Marks")]
		public Int64 FSC_Marks { get; set; }


		[Column("Matric_Mark")]
		public Int64 Matric_Mark { get; set; }


		[Column("Year")]
		public String Year { get; set; }


		[Column("Institute_Name")]
		public String Institute_Name { get; set; }


		[Column("Roll_No")]
		public String Roll_No { get; set; }

		[Column("Board_Name")]
		public String Board_Name { get; set; }



		
		public virtual Selected_Student Selected_Student { get; set; }



	}


	[Table("Department")]
	public partial class Department 
	{


		[Key]
		[Column("Department_ID")]
		public Int64 Department_ID { get; set; }

		[Column("Student_Id")]
		public Int64 Student_Id { get; set; }

		[Column("Department_Name")]
		public String Department_Name { get; set; }

		[Column("Student_Strength")]
		public Int64 Student_Strength { get; set; }

		[Column("HOD_Name")]
		public String HOD_Name { get; set; }

		[Column("Location")]
		public String Location { get; set; }



		
		public virtual Student Student { get; set; }



	}


	[Table("Student")]
	public partial class Student
	{

		[Key]
		[Column("Student_Id")]
		public Int64 Student_Id { get; set; }


		[Column("Student_Registeration_Number")]
		public Int64 Student_Registeration_Number { get; set; }


		[Column("Course_Id")]
		public Int64 Course_Id { get; set; }

		[Column("Student_Name")]
		public String Student_Name { get; set; }

		[Column("Student_Email")]
		public String Student_Email { get; set; }

		[Column("Father_Name")]
		public String Father_Name { get; set; }

		[Column("Father_Monthly_Income")]
		public String Father_Monthly_Income { get; set; }


		[Column("Father_Occupation")]
		public String Father_Occupation { get; set; }

		[Column("Postal_Address")]
		public String Postal_Address { get; set; }


		[Column("Permanent_Address")]
		public String Permanent_Address { get; set; }


		[Column("Date_Of_Birth")]
		public String Date_Of_Birth { get; set; }

		[Column("NIC_No.")]
		public String NIC_No_ { get; set; }


		[Column("Blood_Group")]
		public String Blood_Group { get; set; }

		[Column("Phone_Number")]
		public String Phone_Number { get; set; }


		[Column("Residental_Phone_Number")]
		public String Residental_Phone_Number { get; set; }



		
		public virtual IEnumerable<Department> Department { get; set; }

		public virtual Course Course { get; set; }


		
		public virtual Selected_Student Selected_Student { get; set; }

		
		public virtual IEnumerable<Registered_Student> Registered_Student { get; set; }


		
		public virtual IEnumerable<Course> Course_ { get; set; }



	}


	[Table("Admin")]
	public partial class Admin 
	{

		[Key]
		[Column("Admin_Id")]
		public Int64 Admin_Id { get; set; }

		[Column("Verifying_Agent_Id")]
		public Int64 Verifying_Agent_Id { get; set; }

		[Column("Selected_Student_Id")]
		public Int64 Selected_Student_Id { get; set; }


		[Column("Registered_Student_Id")]
		public Int64 Registered_Student_Id { get; set; }

		[Column("Admin_Name")]
		public String Admin_Name { get; set; }

		[Column("Password")]
		public String Password { get; set; }



		
		public virtual Registered_Student Registered_Student { get; set; }

		
		public virtual Selected_Student Selected_Student { get; set; }


		
		public virtual Verifying_Agent Verifying_Agent { get; set; }



	}

	
	[Table("Registered_Student")]
	public partial class Registered_Student 
	{

	
		[Key]
		[Column("Registered_Student_Id")]
		public Int64 Registered_Student_Id { get; set; }


		[Column("Student_Id")]
		public Int64 Student_Id { get; set; }


		[Column("FSC_Marks")]
		public String FSC_Marks { get; set; }

		[Column("NTS_Marks")]
		public String NTS_Marks { get; set; }



		
		public virtual IEnumerable<Admin> Admin { get; set; }


		
		public virtual Student Student { get; set; }



	}


	[Table("Course")]
	public partial class Course 
	{

	
		[Key]
		[Column("Course_Id")]
		public Int64 Course_Id { get; set; }

		[Column("Course_Name")]
		public String Course_Name { get; set; }

		[Column("Student_Id")]
		public Int64? Student_Id { get; set; }


		
		public virtual IEnumerable<Student> Student { get; set; }

	
		
		public virtual Student Student_ { get; set; }



	}

}
