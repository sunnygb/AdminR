using System;
using System.Linq;
using AdmissionAndResult.Model;
using System.ComponentModel.DataAnnotations;
using AdmissionAndResult.Services;

namespace AdmissionAndResult.Model.Wrapper
{
 class DepartmentW : ValidateModelCommon
  {
	public DepartmentW(Department department)
	{
		this._Department_ID = department.Department_ID;
		this._Department_Name = department.Department_Name;
		this._HOD_Name = department.HOD_Name;
		this._Location = department.Location;

		this._Student_Id = department.Student_Id;
		this._Student_Strength = department.Student_Strength;
	}
    public DepartmentW()
    {

    }
	private System.Int64 _Department_ID;
	public System.Int64 Department_ID
	{
	  get { return _Department_ID; }
	  set {  ChangeNvalidate(ref  _Department_ID,value);  }
	}


	private System.Int64 _Student_Id;
	public System.Int64 Student_Id
	{
	  get { return _Student_Id; }
	  set {  ChangeNvalidate(ref  _Student_Id,value);  }
	}


	private System.String _Department_Name;
	public System.String Department_Name
	{
	  get { return _Department_Name; }
	  set {  ChangeNvalidate(ref  _Department_Name,value);  }
	}


	private System.Int64 _Student_Strength;
	public System.Int64 Student_Strength
	{
	  get { return _Student_Strength; }
	  set {  ChangeNvalidate(ref  _Student_Strength,value);  }
	}


	private System.String _HOD_Name;
	public System.String HOD_Name
	{
	  get { return _HOD_Name; }
	  set {  ChangeNvalidate(ref  _HOD_Name,value);  }
	}


	private System.String _Location;
	public System.String Location
	{
	  get { return _Location; }
	  set {  ChangeNvalidate(ref  _Location,value);  }
	}

  }
}
