using System;
using System.Linq;
using AdmissionAndResult.Model;
using System.ComponentModel.DataAnnotations;
using AdmissionAndResult.Services;

namespace AdmissionAndResult.Model.Wrapper
{
   class SelectedStudentW : ValidateModelCommon
  {
	public SelectedStudentW(SelectedStudent selectedStudent)
	{
		this._Selected_Student_Id = selectedStudent.Selected_Student_Id;
		this._Student_Registeration_Number = selectedStudent.Student_Registeration_Number;
		this._Aggregate = selectedStudent.Aggregate;
		this._Cource_Id = selectedStudent.Cource_Id;
		this._CGPA_Text = selectedStudent.CGPA_Text;
		this._SGPA = selectedStudent.SGPA;
		this._Department_ID = selectedStudent.Department_ID;
	}
    public SelectedStudentW()
    {

    }
	private System.Int64 _Selected_Student_Id;
	public System.Int64 Selected_Student_Id
	{
	  get { return _Selected_Student_Id; }
	  set {  ChangeNvalidate(ref  _Selected_Student_Id,value);  }
	}


	private System.String _Student_Registeration_Number;
       [Required(ErrorMessage = "Student Reg No.  is required")]
	public System.String Student_Registeration_Number
	{
	  get { return _Student_Registeration_Number; }
	  set {  ChangeNvalidate(ref  _Student_Registeration_Number,value);  }
	}


	private System.Double _Aggregate;
       [Required(ErrorMessage = "Aggregate  is required")]
	public System.Double Aggregate
	{
	  get { return _Aggregate; }
	  set {  ChangeNvalidate(ref  _Aggregate,value);  }
	}


	private System.Int64 _Cource_Id;
       [Required(ErrorMessage = "Course Id is required")]
	public System.Int64 Cource_Id
	{
	  get { return _Cource_Id; }
	  set {  ChangeNvalidate(ref  _Cource_Id,value);  }
	}


	private System.String _CGPA_Text;
	public System.String CGPA_Text
	{
	  get { return _CGPA_Text; }
	  set {  ChangeNvalidate(ref  _CGPA_Text,value);  }
	}


	private System.String _SGPA;
	public System.String SGPA
	{
	  get { return _SGPA; }
	  set {  ChangeNvalidate(ref  _SGPA,value);  }
	}


	private System.Int64 _Department_ID;
              [Required(ErrorMessage = "Department Id  is required")]

	public System.Int64 Department_ID
	{
	  get { return _Department_ID; }
	  set {  ChangeNvalidate(ref  _Department_ID,value);  }
	}

  }
}
