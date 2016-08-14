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


namespace AdmissionAndResult.ViewModel
{
    class AgentFormViewModel :ViewModelBase
    {
        private Verifying_Agent _verifyingAgent;
        private Student _student;
        private Qualification _qualification;
        private ObservableCollection<Student> students;
        private ObservableCollection<Qualification> qualifications;
        private ObservableCollection<Verifying_Agent> verifyingAgents;
        SQLiteConnection conn;



         public AgentFormViewModel()
        {
            conn= new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
            SendCommand = new RelayCommand(sendFunction);
            _student = new Student();
             _verifyingAgent = new Verifying_Agent();
             Qualification qualification = new Qualification();
           

            
           
            
        }

         private void sendFunction()
         {
            
         }




        public Student student
        {

            get { return _student; }

            set
            {
                Set(() => student, ref _student, value);
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
        public Verifying_Agent verifying_agent
        {

            get { return _verifyingAgent; }

            set
            {
                Set(() => verifying_agent, ref _verifyingAgent, value);
            }
        }








        public RelayCommand SendCommand { get; private set; }
        public RelayCommand ViewVerifiedStudentCommand { get; private set; }




        public void getStudentList()
        {
            students = new ObservableCollection<Student>(conn.GetAll<Student>());
            

        }
        public void getQualificationList()
        {
            qualifications = new ObservableCollection<Qualification>(conn.GetAll<Qualification>());

        }
        public void getVerifyingagentList()
        {
            verifyingAgents = new ObservableCollection<Verifying_Agent>(conn.GetAll<Verifying_Agent>());

        }
    }
}
