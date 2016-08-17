using System;
using System.Linq;
using AdmissionAndResult.Model;
using System.ComponentModel.DataAnnotations;
using AdmissionAndResult.Services;

namespace AdmissionAndResult.Model.Wrapper
{
  class StudentW : ValidateModelCommon
  {
	public StudentW(Student student)
	{
		this._Student_Id = student.Student_Id;
		this._Student_Name = student.Student_Name;
		this._Student_Email = student.Student_Email;
		this._Father_Name = student.Father_Name;
		this._Fathers_Number = student.Fathers_Number;
		this._Father_Monthly_Income = student.Father_Monthly_Income;
		this._Father_Occupation = student.Father_Occupation;
		this._Postal_Address = student.Postal_Address;
		this._Permanent_Address = student.Permanent_Address;
		this._Date_Of_Birth = student.Date_Of_Birth;
		this._NIC_No = student.NIC_No;
		this._Blood_Group = student.Blood_Group;
		this._Phone_Number = student.Phone_Number;
		this._Residental_Phone_Number = student.Residental_Phone_Number;
		this._Date = student.Date;
		this._Verified_Bachelor_CGPA = student.Verified_Bachelor_CGPA;
		this._Verified_FSC_Marks = student.Verified_FSC_Marks;
		this._Verified_GAT_Marks = student.Verified_GAT_Marks;
		this._Verified_Matric_Marks = student.Verified_Matric_Marks;
		this._Verified_NTS_Marks = student.Verified_NTS_Marks;
	}
    public StudentW()
    {

    }
	private System.Int64 _Student_Id;
	public System.Int64 Student_Id
	{
	  get { return _Student_Id; }
	  set {  ChangeNvalidate(ref  _Student_Id,value);  }
	}


	private System.String _Student_Name;
	public System.String Student_Name
	{
	  get { return _Student_Name; }
	  set {  ChangeNvalidate(ref  _Student_Name,value);  }
	}


	private System.String _Student_Email;
	public System.String Student_Email
	{
	  get { return _Student_Email; }
	  set {  ChangeNvalidate(ref  _Student_Email,value);  }
	}


	private System.String _Father_Name;
	public System.String Father_Name
	{
	  get { return _Father_Name; }
	  set {  ChangeNvalidate(ref  _Father_Name,value);  }
	}


	private System.String _Fathers_Number;
	public System.String Fathers_Number
	{
	  get { return _Fathers_Number; }
	  set {  ChangeNvalidate(ref  _Fathers_Number,value);  }
	}


	private System.String _Father_Monthly_Income;
	public System.String Father_Monthly_Income
	{
	  get { return _Father_Monthly_Income; }
	  set {  ChangeNvalidate(ref  _Father_Monthly_Income,value);  }
	}


	private System.String _Father_Occupation;
	public System.String Father_Occupation
	{
	  get { return _Father_Occupation; }
	  set {  ChangeNvalidate(ref  _Father_Occupation,value);  }
	}


	private System.String _Postal_Address;
	public System.String Postal_Address
	{
	  get { return _Postal_Address; }
	  set {  ChangeNvalidate(ref  _Postal_Address,value);  }
	}


	private System.String _Permanent_Address;
	public System.String Permanent_Address
	{
	  get { return _Permanent_Address; }
	  set {  ChangeNvalidate(ref  _Permanent_Address,value);  }
	}


	private System.String _Date_Of_Birth;
	public System.String Date_Of_Birth
	{
	  get { return _Date_Of_Birth; }
	  set {  ChangeNvalidate(ref  _Date_Of_Birth,value);  }
	}


	private System.String _NIC_No;
	public System.String NIC_No
	{
	  get { return _NIC_No; }
	  set {  ChangeNvalidate(ref  _NIC_No,value);  }
	}


	private System.String _Blood_Group;
	public System.String Blood_Group
	{
	  get { return _Blood_Group; }
	  set {  ChangeNvalidate(ref  _Blood_Group,value);  }
	}


	private System.String _Phone_Number;
	public System.String Phone_Number
	{
	  get { return _Phone_Number; }
	  set {  ChangeNvalidate(ref  _Phone_Number,value);  }
	}


	private System.String _Residental_Phone_Number;
	public System.String Residental_Phone_Number
	{
	  get { return _Residental_Phone_Number; }
	  set {  ChangeNvalidate(ref  _Residental_Phone_Number,value);  }
	}


	private System.String _Date;
	public System.String Date
	{
	  get { return _Date; }
	  set {  ChangeNvalidate(ref  _Date,value);  }
	}


	private System.Int64 _Verified_Matric_Marks;
	public System.Int64 Verified_Matric_Marks
	{
	  get { return _Verified_Matric_Marks; }
	  set {  ChangeNvalidate(ref  _Verified_Matric_Marks,value);  }
	}


	private System.Int64 _Verified_FSC_Marks;
	public System.Int64 Verified_FSC_Marks
	{
	  get { return _Verified_FSC_Marks; }
	  set {  ChangeNvalidate(ref  _Verified_FSC_Marks,value);  }
	}


	private System.Int64 _Verified_NTS_Marks;
	public System.Int64 Verified_NTS_Marks
	{
	  get { return _Verified_NTS_Marks; }
	  set {  ChangeNvalidate(ref  _Verified_NTS_Marks,value);  }
	}


	private System.Int64 _Verified_GAT_Marks;
	public System.Int64 Verified_GAT_Marks
	{
	  get { return _Verified_GAT_Marks; }
	  set {  ChangeNvalidate(ref  _Verified_GAT_Marks,value);  }
	}


	private System.Int64 _Verified_Bachelor_CGPA;
	public System.Int64 Verified_Bachelor_CGPA
	{
	  get { return _Verified_Bachelor_CGPA; }
	  set {  ChangeNvalidate(ref  _Verified_Bachelor_CGPA,value);  }
	}

  }
}
