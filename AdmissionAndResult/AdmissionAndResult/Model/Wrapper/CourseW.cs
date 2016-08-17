using System;
using System.Linq;
using AdmissionAndResult.Model;
using System.ComponentModel.DataAnnotations;
using AdmissionAndResult.Services;

namespace AdmissionAndResult.Model.Wrapper
{
  class CourseW : ValidateModelCommon
  {
	public CourseW(Course course)
	{
		this._Course_Id = course.Course_Id;
		this._Course_Name = course.Course_Name;
		this._Student_Id = course.Student_Id;
	}
    public CourseW()
    {

    }
	private System.Int64 _Course_Id;
	public System.Int64 Course_Id
	{
	  get { return _Course_Id; }
	  set {  ChangeNvalidate(ref  _Course_Id,value);  }
	}


	private System.String _Course_Name;
	public System.String Course_Name
	{
	  get { return _Course_Name; }
	  set {  ChangeNvalidate(ref  _Course_Name,value);  }
	}


	private System.Int64 _Student_Id;
	public System.Int64 Student_Id
	{
	  get { return _Student_Id; }
	  set {  ChangeNvalidate(ref  _Student_Id,value);  }
	}

  }
}
