﻿

using ClinicalReporting.Model;
using ClinicalReporting.Model.Wrapper;
using Dapper.Contrib.Extensions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using AdmissionAndResult.Views;

namespace AdmissionAndResult.ViewModel
{
    class StudentSearchViewModel : ViewModelBase
    {
        private ObservableCollection<VerifyingAgentW> _agents = new ObservableCollection<VerifyingAgentW>();
        private ObservableCollection<StudentW> _students = new ObservableCollection<StudentW>();
        private Student _selectedStudent;
        private VerifyingAgentW _selectedAgent;

        public StudentSearchViewModel()
        {
            searchFunction();
            SearchCommand = new RelayCommand(searchFunction);
            

            _selectedStudent = new Student();
            _selectedAgent = new VerifyingAgentW();
            detailCommand = new RelayCommand(showDetail, () => _selectedItem != null);

        }

        public RelayCommand detailCommand
        {
            get;
            private set;
        }


        private object _selectedItem;
        public object SelectedItem
        {

            get { return _selectedItem; }

            set
            {
                Set(() => SelectedItem, ref _selectedItem, value);
                detailCommand.RaiseCanExecuteChanged();
            }
        }



        public Student student
        {

            get { return _selectedStudent; }

            set
            {
                Set(() => student, ref _selectedStudent, value);
            }
        }


        public ObservableCollection<StudentW> students
        {
            get { return _students; }

            set
            {
                Set(() => students, ref _students, value);
            }
        }

        public RelayCommand SearchCommand { get; private set; }



        public void searchFunction()
        {

           
        }

        public void showDetail()
        {


            if (this.SelectedItem.GetType() == typeof(StudentW))
            {
                var c = Convert.ChangeType(_selectedItem, typeof(StudentW));
                
               
            }
            else if (this.SelectedItem.GetType() == typeof(VerifyingAgentW))
            {
                var c = Convert.ChangeType(_selectedItem, typeof(VerifyingAgentW));
            }
            //{
            //    _ESTContext.Templates.Remove(SelectedTemplate);
            //} 
        }

    }
}
