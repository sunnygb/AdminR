using System;
using System.Linq;
using AdmissionAndResult.Model;
using System.ComponentModel.DataAnnotations;
using AdmissionAndResult.Services;

namespace AdmissionAndResult.Model.Wrapper
{
  class AdminW : ValidateModelCommon
  {
	public AdminW(Admin adminw)
	{
		this._Admin_Id = adminw.Admin_Id;
		this._Admin_Name = adminw.Admin_Name;
		this._Password = adminw.Password;
		this._Change_Date = DateTime.Parse(adminw.Change_Date);
		this._Hire_Date = DateTime.Parse(adminw.Hire_Date);
	}
    public AdminW()
    {

    }
	private System.Int64 _Admin_Id;
	public System.Int64 Admin_Id
	{
	  get { return _Admin_Id; }
	  set {  ChangeNvalidate(ref  _Admin_Id,value);  }
	}


	private System.String _Admin_Name;
	public System.String Admin_Name
	{
	  get { return _Admin_Name; }
	  set {  ChangeNvalidate(ref  _Admin_Name,value);  }
	}


	private System.String _Password;
	public System.String Password
	{
	  get { return _Password; }
	  set {  ChangeNvalidate(ref  _Password,value);  }
	}


	private System.DateTime _Hire_Date;
	public System.DateTime Hire_Date
	{
	  get { return _Hire_Date; }
	  set {  ChangeNvalidate(ref  _Hire_Date,value);  }
	}


	private System.DateTime _Change_Date;
	public System.DateTime Change_Date
	{
	  get { return _Change_Date; }
	  set {  ChangeNvalidate(ref  _Change_Date,value);  }
	}

  }
}
