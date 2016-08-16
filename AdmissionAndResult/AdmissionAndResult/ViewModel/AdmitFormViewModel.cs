using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using AdmissionAndResult.Views.Header;
using Dapper.Contrib.Extensions;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Data.Linq;
using AdmissionAndResult.Model;
using AdmissionAndResult.Services;

using AdmissionAndResult.Model.Wrapper;

namespace AdmissionAndResult.ViewModel
{

    class AdmitFormViewModel : ValidateViewModelCommon
    {
        // PrivateFeilds
        private StudentW _student;
        private QualificationW _qualification;
        private ObservableCollection<CourseW> _courses = new ObservableCollection<CourseW>();
        private CourseW _selectedcourse;



        //Constructor
        public AdmitFormViewModel()
        {


            getCourseList();
            SubmitCommand = new RelayCommand(saveFunction);
            _student = new StudentW();
            _selectedcourse = new CourseW();
            _qualification = new QualificationW();


        }



        //Getter and Setters
        public StudentW student
        {

            get { return _student; }

            set
            {
                Set(() => student, ref _student, value);

            }
        }

        public QualificationW qualification
        {

            get { return _qualification; }

            set
            {
                Set(() => qualification, ref _qualification, value);

            }
        }

        public CourseW selectedcourse
        {

            get { return _selectedcourse; }

            set
            {
                Set(() => selectedcourse, ref _selectedcourse, value);
            }
        }

        public ObservableCollection<CourseW> courses
        {

            get { return _courses; }

            set
            {
                Set(() => courses, ref _courses, value);
            }
        }

        public RelayCommand SubmitCommand { get; private set; }


        //Functions
        public void getCourseList()
        {
           var courses = Sqlite.GetConnection().GetAll<Course>();

            foreach(var course in courses)
            {
                _courses.Add(new CourseW(course));
            }
        }
        public void saveFunction()
        {


        }
    }
}
