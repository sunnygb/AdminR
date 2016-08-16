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
using AdmissionAndResult.Model.Wrapper;
using AdmissionAndResult.Services;
using AdmissionAndResult.Model;

namespace AdmissionAndResult.ViewModel
{
    class AgentFormViewModel :ViewModelBase
    {
        private VerifyingAgentW _verifyingAgent;
        private StudentW _student;
        private QualificationW _qualification;
        private ObservableCollection<StudentW> _students = new ObservableCollection<StudentW>();
        private ObservableCollection<QualificationW> _qualifications = new ObservableCollection<QualificationW>();
        private ObservableCollection<VerifyingAgentW> _verifyingAgents = new ObservableCollection<VerifyingAgentW>();
    



         public AgentFormViewModel()
        {
           
            SendCommand = new RelayCommand(sendFunction);
            _student = new StudentW();
             _verifyingAgent = new VerifyingAgentW();
             QualificationW qualification = new QualificationW();
           

            
           
            
        }

         private void sendFunction()
         {
            
         }




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
        public VerifyingAgentW verifying_agent
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
           var students =Sqlite.GetConnection().GetAll<Student>();
            foreach( var student in students)
            {
                _students.Add(new StudentW(student));
            }
            

        }
        public void getQualificationList()
        {
            var qualifications = Sqlite.GetConnection().GetAll<Qualification>();
            foreach(var qualification in qualifications)
            {
                _qualifications.Add(new QualificationW(qualification));
            }

        }
        public void getVerifyingagentList()
        {
            var agents = Sqlite.GetConnection().GetAll<VerifyingAgent>();
            foreach(var agent in agents)
            {
                _verifyingAgents.Add(new VerifyingAgentW(agent));
            }

        }
    }
}
