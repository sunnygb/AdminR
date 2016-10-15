
using AdmissionAndResult.Services;
using ClinicalReporting.Model;
using ClinicalReporting.Model.Wrapper;
using Dapper.Contrib.Extensions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace AdmissionAndResult.ViewModel
{
    class VerifyingAgentViewModel :ViewModelBase
    {
        private VerifyingAgentW _verifyingAgent;
        private StudentW _student;
        private QualificationW _qualification;
        private ObservableCollection<StudentW> _students = new ObservableCollection<StudentW>();
        private ObservableCollection<QualificationW> _qualifications = new ObservableCollection<QualificationW>();
        private ObservableCollection<VerifyingAgentW> _verifyingAgents = new ObservableCollection<VerifyingAgentW>();
    



         public VerifyingAgentViewModel()
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

            

        }
        public void getQualificationList()
        {
 

        }
        public void getVerifyingagentList()
        {


        }
    }
}
