using AdmissionAndResult.Services;
using System.ComponentModel.DataAnnotations;

namespace AdmissionAndResult.Model.Wrapper
{
 class QualificationW : ValidateModelCommon
  {
	public QualificationW(Qualification qualificationW)
	{
		this._Qualification_Id = qualificationW.Qualification_Id;
		this._NTS_Max_Marks = qualificationW.NTS_Max_Marks;
		this._NTS_Obt_Marks = qualificationW.NTS_Obt_Marks;
		this._FSC_Institute_Name = qualificationW.FSC_Institute_Name;
		this._FSC_Max_Marks = qualificationW.FSC_Max_Marks;
		this._FSC_Obt_Marks = qualificationW.FSC_Obt_Marks;
		this._Matric_Institute_Name = qualificationW.Matric_Institute_Name;
		this._Matric_Max_Marks = qualificationW.Matric_Max_Marks;
		this._Matric_Obt_Marks = qualificationW.Matric_Obt_Marks;
		this._GAT_Max_Marks = qualificationW.GAT_Max_Marks;
		this._GAT_Obt_Marks = qualificationW.GAT_Obt_Marks;
		this._Matric_Year = qualificationW.Matric_Year;
		this._FSC_Year = qualificationW.FSC_Year;
		this._NTS_Year = qualificationW.NTS_Year;
		this._GAT_Year = qualificationW.GAT_Year;
		this._MS_Year = qualificationW.MS_Year;
		this._BS_Year = qualificationW.BS_Year;
		this._BS_Institute_Name = qualificationW.BS_Institute_Name;
		this._MS_Institute_Name = qualificationW.MS_Institute_Name;
		this._BS_Roll_No = qualificationW.BS_Roll_No;
		this._MS_Roll_No = qualificationW.MS_Roll_No;
		this._Fsc_Roll_No = qualificationW.Fsc_Roll_No;
		this._Matric_Roll_No = qualificationW.Matric_Roll_No;
		this._NTS_Roll_No = qualificationW.NTS_Roll_No;
		this._GAT_Roll_No = qualificationW.GAT_Roll_No;
		this._BS_Degree = qualificationW.BS_Degree;
		this._MS_Degree = qualificationW.MS_Degree;
		this._Batchlor_Max_CGPA = qualificationW.Batchlor_Max_CGPA;
		this._Batchlor_Obt_CGPA = qualificationW.Batchlor_Obt_CGPA;
		this._MSC_Max_CGPA = qualificationW.MSC_Max_CGPA;
		this._MSC_Obt_CGPA = qualificationW.MSC_Obt_CGPA;
		this._Verified_BS_CGPA = qualificationW.Verified_BS_CGPA;
		this._Verified_FSC_Marks = qualificationW.Verified_FSC_Marks;
		this._Verified_GAT_Marks = qualificationW.Verified_GAT_Marks;
		this._Verified_MSC_CGPA = qualificationW.Verified_MSC_CGPA;
		this._Verified_Matric_Marks = qualificationW.Verified_Matric_Marks;
		this._Verified_NTS_Marks = qualificationW.Verified_NTS_Marks;
	}
	public QualificationW()
	{

	}

	private System.Int64 _Qualification_Id;
	public System.Int64 Qualification_Id
	{
	  get { return _Qualification_Id; }
	  set {  ChangeNvalidate(ref  _Qualification_Id,value);  }
	}


	private System.Int64 _NTS_Obt_Marks;
	 [Required(ErrorMessage = "NTS Obt. Mark is required")]
	public System.Int64 NTS_Obt_Marks
	{
	  get { return _NTS_Obt_Marks; }
	  set {  ChangeNvalidate(ref  _NTS_Obt_Marks,value);  }
	}


	private System.Int64 _NTS_Max_Marks;
	 [Required(ErrorMessage = "NTS Max is required")]
	public System.Int64 NTS_Max_Marks
	{
	  get { return _NTS_Max_Marks; }
	  set {  ChangeNvalidate(ref  _NTS_Max_Marks,value);  }
	}


	private System.Int64 _FSC_Obt_Marks;
	 [Required(ErrorMessage = "FSC Obt. Mark is required")]
	public System.Int64 FSC_Obt_Marks
	{
	  get { return _FSC_Obt_Marks; }
	  set {  ChangeNvalidate(ref  _FSC_Obt_Marks,value);  }
	}


	private System.Int64 _FSC_Max_Marks;
	 [Required(ErrorMessage = "FSC Max mark is required")]
	public System.Int64 FSC_Max_Marks
	{
	  get { return _FSC_Max_Marks; }
	  set {  ChangeNvalidate(ref  _FSC_Max_Marks,value);  }
	}


	private System.Int64 _Matric_Obt_Marks;
	 [Required(ErrorMessage = "Martric obt. mark is required")]
	public System.Int64 Matric_Obt_Marks
	{
	  get { return _Matric_Obt_Marks; }
	  set {  ChangeNvalidate(ref  _Matric_Obt_Marks,value);  }
	}


	private System.Int64 _Matric_Max_Marks;
	 [Required(ErrorMessage = "Matric Max mark is required")]
	public System.Int64 Matric_Max_Marks
	{
	  get { return _Matric_Max_Marks; }
	  set {  ChangeNvalidate(ref  _Matric_Max_Marks,value);  }
	}


	private System.Int64 _GAT_Obt_Marks;
	 [Required(ErrorMessage = "Gat mark is required")]
	public System.Int64 GAT_Obt_Marks
	{
	  get { return _GAT_Obt_Marks; }
	  set {  ChangeNvalidate(ref  _GAT_Obt_Marks,value);  }
	}


	private System.Int64 _GAT_Max_Marks;
	 [Required(ErrorMessage = "Gat max mark is required")]
	public System.Int64 GAT_Max_Marks
	{
	  get { return _GAT_Max_Marks; }
	  set {  ChangeNvalidate(ref  _GAT_Max_Marks,value);  }
	}


	private System.String _Matric_Year;
	 [Required(ErrorMessage = "Matric year is required")]
	public System.String Matric_Year
	{
	  get { return _Matric_Year; }
	  set {  ChangeNvalidate(ref  _Matric_Year,value);  }
	}


	private System.String _FSC_Year;
	 [Required(ErrorMessage = "FSC year is required")]
	public System.String FSC_Year
	{
	  get { return _FSC_Year; }
	  set {  ChangeNvalidate(ref  _FSC_Year,value);  }
	}


	private System.String _NTS_Year;
	 [Required(ErrorMessage = "NTS year is required")]
	public System.String NTS_Year
	{
	  get { return _NTS_Year; }
	  set {  ChangeNvalidate(ref  _NTS_Year,value);  }
	}


	private System.String _BS_Year;
	 [Required(ErrorMessage = "BS year is required")]
	public System.String BS_Year
	{
	  get { return _BS_Year; }
	  set {  ChangeNvalidate(ref  _BS_Year,value);  }
	}


	private System.String _MS_Year;
	 [Required(ErrorMessage = "MS year is required")]
	public System.String MS_Year
	{
	  get { return _MS_Year; }
	  set {  ChangeNvalidate(ref  _MS_Year,value);  }
	}


	private System.String _GAT_Year;
	 [Required(ErrorMessage = "GAT year is required")]
	public System.String GAT_Year
	{
	  get { return _GAT_Year; }
	  set {  ChangeNvalidate(ref  _GAT_Year,value);  }
	}


	private System.String _MS_Institute_Name;
	 [Required(ErrorMessage = "MS institute name is required")]
	public System.String MS_Institute_Name
	{
	  get { return _MS_Institute_Name; }
	  set {  ChangeNvalidate(ref  _MS_Institute_Name,value);  }
	}


	private System.String _BS_Institute_Name;
	 [Required(ErrorMessage = "BS institute name is required")]
	public System.String BS_Institute_Name
	{
	  get { return _BS_Institute_Name; }
	  set {  ChangeNvalidate(ref  _BS_Institute_Name,value);  }
	}


	private System.String _FSC_Institute_Name;
	 [Required(ErrorMessage = "FSC institute name is required")]
	public System.String FSC_Institute_Name
	{
	  get { return _FSC_Institute_Name; }
	  set {  ChangeNvalidate(ref  _FSC_Institute_Name,value);  }
	}


	private System.String _Matric_Institute_Name;
	 [Required(ErrorMessage = "Matric institute name is required")]
	public System.String Matric_Institute_Name
	{
	  get { return _Matric_Institute_Name; }
	  set {  ChangeNvalidate(ref  _Matric_Institute_Name,value);  }
	}


	private System.String _MS_Roll_No;
	 [Required(ErrorMessage = "MS Roll no. is required")]
	public System.String MS_Roll_No
	{
	  get { return _MS_Roll_No; }
	  set {  ChangeNvalidate(ref  _MS_Roll_No,value);  }
	}


	private System.String _BS_Roll_No;
	 [Required(ErrorMessage = "BS roll no. is required")]
	public System.String BS_Roll_No
	{
	  get { return _BS_Roll_No; }
	  set {  ChangeNvalidate(ref  _BS_Roll_No,value);  }
	}


	private System.String _Fsc_Roll_No;
		  [Required(ErrorMessage = "FSC roll no. is required")]

	public System.String Fsc_Roll_No
	{
	  get { return _Fsc_Roll_No; }
	  set {  ChangeNvalidate(ref  _Fsc_Roll_No,value);  }
	}


	private System.String _Matric_Roll_No;
		  [Required(ErrorMessage = "Matric roll no. is required")]

	public System.String Matric_Roll_No
	{
	  get { return _Matric_Roll_No; }
	  set {  ChangeNvalidate(ref  _Matric_Roll_No,value);  }
	}


	private System.String _NTS_Roll_No;
		  [Required(ErrorMessage = "NTS roll no. is required")]

	public System.String NTS_Roll_No
	{
	  get { return _NTS_Roll_No; }
	  set {  ChangeNvalidate(ref  _NTS_Roll_No,value);  }
	}


	private System.String _GAT_Roll_No;
		  [Required(ErrorMessage = "GAT roll no. is required")]

	public System.String GAT_Roll_No
	{
	  get { return _GAT_Roll_No; }
	  set {  ChangeNvalidate(ref  _GAT_Roll_No,value);  }
	}


	private System.String _BS_Degree;
		  [Required(ErrorMessage = "BS Degree name is required")]

	public System.String BS_Degree
	{
	  get { return _BS_Degree; }
	  set {  ChangeNvalidate(ref  _BS_Degree,value);  }
	}


	private System.String _MS_Degree;
			   [Required(ErrorMessage = "MS Degree name is required")]

	public System.String MS_Degree
	{
	  get { return _MS_Degree; }
	  set {  ChangeNvalidate(ref  _MS_Degree,value);  }
	}


	private System.String _Board_Name;
	public System.String Board_Name
	{
	  get { return _Board_Name; }
	  set {  ChangeNvalidate(ref  _Board_Name,value);  }
	}


	private System.Int64 _Batchlor_Obt_CGPA;
			   [Required(ErrorMessage = "Batchelor obtained CGPA is required")]

	public System.Int64 Batchlor_Obt_CGPA
	{
	  get { return _Batchlor_Obt_CGPA; }
	  set {  ChangeNvalidate(ref  _Batchlor_Obt_CGPA,value);  }
	}


	private System.Int64 _Batchlor_Max_CGPA;
	 [Required(ErrorMessage = "Batchelor Max CGPA is required")]
	public System.Int64 Batchlor_Max_CGPA
	{
	  get { return _Batchlor_Max_CGPA; }
	  set {  ChangeNvalidate(ref  _Batchlor_Max_CGPA,value);  }
	}


	private System.Int64 _MSC_Obt_CGPA;
	 [Required(ErrorMessage = "MS obtained CGPA is required")]
	public System.Int64 MSC_Obt_CGPA
	{
	  get { return _MSC_Obt_CGPA; }
	  set {  ChangeNvalidate(ref  _MSC_Obt_CGPA,value);  }
	}


	private System.Int64 _MSC_Max_CGPA;
	 [Required(ErrorMessage = "MS Max CGPA is required")]
	public System.Int64 MSC_Max_CGPA
	{
	  get { return _MSC_Max_CGPA; }
	  set {  ChangeNvalidate(ref  _MSC_Max_CGPA,value);  }
	}


	private System.Int64 _Verified_NTS_Marks;
	public System.Int64 Verified_NTS_Marks
	{
	  get { return _Verified_NTS_Marks; }
	  set {  ChangeNvalidate(ref  _Verified_NTS_Marks,value);  }
	}


	private System.Int64 _Verified_FSC_Marks;
	public System.Int64 Verified_FSC_Marks
	{
	  get { return _Verified_FSC_Marks; }
	  set {  ChangeNvalidate(ref  _Verified_FSC_Marks,value);  }
	}


	private System.Int64 _Verified_Matric_Marks;
	public System.Int64 Verified_Matric_Marks
	{
	  get { return _Verified_Matric_Marks; }
	  set {  ChangeNvalidate(ref  _Verified_Matric_Marks,value);  }
	}


	private System.Int64 _Verified_GAT_Marks;
	public System.Int64 Verified_GAT_Marks
	{
	  get { return _Verified_GAT_Marks; }
	  set {  ChangeNvalidate(ref  _Verified_GAT_Marks,value);  }
	}


	private System.Int64 _Verified_MSC_CGPA;
	public System.Int64 Verified_MSC_CGPA
	{
	  get { return _Verified_MSC_CGPA; }
	  set {  ChangeNvalidate(ref  _Verified_MSC_CGPA,value);  }
	}


	private System.Int64 _Verified_BS_CGPA;
	public System.Int64 Verified_BS_CGPA
	{
	  get { return _Verified_BS_CGPA; }
	  set {  ChangeNvalidate(ref  _Verified_BS_CGPA,value);  }
	}

  }
}
