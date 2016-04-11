using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using Clinical_Reporting.ViewModel;

namespace Clinical_Reporting.View
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient :UserControl
    {
        private long nextID;
        public AddPatient()
        {
            
            
            InitializeComponent();
            this.DataContext = new AddPatientViewModel();
        }

       
    }
    
}
