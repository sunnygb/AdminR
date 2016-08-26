﻿using AdmissionAndResult.Model;
using AdmissionAndResult.Model.Wrapper;
using AdmissionAndResult.Services;
using Dapper.Contrib.Extensions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;

namespace AdmissionAndResult.ViewModel
{

    class AdmitFormViewModel : ViewModelBase
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
            MessageBox.Show("Student has succesfully Added");

        }
    }
}
