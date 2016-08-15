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
using AdmissionAndResult.Views.Header;
using Dapper.Contrib.Extensions;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Data.Linq;
using AdmissionAndResult.Model;

namespace AdmissionAndResult.ViewModel
{
    class AdmitFormViewModel : ViewModelBase
    {
        // PrivateFeilds
        private Student _student;
        private Course _course;
        private Qualification _qualification;

        private ObservableCollection<Course> _courses;
        private Course _selectedcourse = new Course();
        SQLiteConnection conn;
        Course wrpaSelecetedCource;
        Qualification wrapQualification;


        //Constructor
         public AdmitFormViewModel()
        {
            conn= new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
            
             getCourseList();
            SubmitCommand = new RelayCommand(saveFunction);
            _student = new Student();
           
            _course = new Course();
          
            _qualification = new Qualification();

            _course.Course_Name = "CS";
            
           
            
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
        public Course cource
        {

            get { return _course; }

            set
            {
                Set(() => cource, ref _course, value);
            }
        }
        public Qualification qualification
        {

            get { return _qualification; }

            set
            {
                Set(() => qualification, ref _qualification, value);
                this.wrapQualification = this._qualification;
               
            }
        }

        public Course selectedcourse
        {

            get { return _selectedcourse; }

            set
            {
                Set(() => selectedcourse, ref _selectedcourse, value);
            }
        }

        public ObservableCollection<Course> courses
        {

            get { return _courses; }

            set
            {
                Set(() => courses, ref _courses, value);
                this.wrpaSelecetedCource = this._selectedcourse;
            }
        }
           
        public RelayCommand SubmitCommand{ get; private set; }


        //Functions
        public void getCourseList()
        {
            _courses = new ObservableCollection<Course>(conn.GetAll<Course>());

        }
        public void saveFunction()
        {

            //this.student.Student_Id = 1005;
            //conn.Open();
            //    conn.Insert<Student>(this.student);
            //    _course.Course_Id = 1009;
            //    _course.Course_Name = "hello";
            //    _course.Student_Id = 10000;

            //   conn.Query("insert into Course VALUES(6,\"AB\",1002)");

            //    conn.Close();
            wAdmin admin = new wAdmin()
            {
                Admin_Id = 1005,
                Admin_Name = "Abdullah",
                Password = "1234",
                Change_Date = DateTime.Now,
                Hire_Date = DateTime.Now


            };

            Admin wadmin =new  Admin();
            wadmin.setAdmin(admin);
            conn.Insert<Admin>(wadmin);

            var Q = this._selectedcourse;
            var C = this._qualification;
        }

        private void CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = IsValid(sender as DependencyObject);
        }

        private bool IsValid(DependencyObject obj)
        {
            // The dependency object is valid if it has no errors and all
            // of its children (that are dependency objects) are error-free.
            return !Validation.GetHasError(obj) &&
            LogicalTreeHelper.GetChildren(obj)
            .OfType<DependencyObject>()
            .All(IsValid);
        }

    }





    
}
