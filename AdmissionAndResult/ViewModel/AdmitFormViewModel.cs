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
using Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AdmissionAndResult.ViewModel
{
    class AdmitFormViewModel : ViewModelBase
    {
        // PrivateFeilds
        private Student _student;
        private Course _course;
        private Qualification _qualification;
        private ObservableCollection<string> _school;
        private ObservableCollection<string> _intermediate;
        private ObservableCollection<Course> _courses;
        SQLiteConnection conn; 


        //Constructor
         public AdmitFormViewModel()
        {
            conn= new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
           
            SubmitCommand = new RelayCommand(saveFunction);
            Student student = new Student();
             Course course =new Course();
             Qualification qualification = new Qualification();
            
            
           
            
        }



        //Getter and Setters
        public Student student
        {

            get { return _student; }

            set
            {
                Set(() => student, ref _student, value);
            }
        }
        public Course course
        {

            get { return _course; }

            set
            {
                Set(() => course, ref _course, value);
            }
        }
        public Qualification qualification
        {

            get { return _qualification; }

            set
            {
                Set(() => qualification, ref _qualification, value);
            }
        }
        public RelayCommand SubmitCommand{ get; private set; }


        //Functions
        public void getCourseList()
        {
            _courses = new ObservableCollection<Course>(conn.GetList<Course>());

        }
        public void saveFunction()
        {
            conn.Insert<Student>(this.student);
        }

    }





    
}
