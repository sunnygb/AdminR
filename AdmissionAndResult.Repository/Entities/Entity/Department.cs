﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities
{



    public partial class Department
    {
        public Department()
        {
            SelectedStudents = new List<SelectedStudent>();
        }

        public long DepartmentID { get; set; }
        public long StudentId { get; set; }
        public string DepartmentName { get; set; }
        public long StudentStrength { get; set; }
        public string HODName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<SelectedStudent> SelectedStudents { get; set; }
        public virtual Student Student { get; set; }
    }
}