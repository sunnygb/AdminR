using Clinical_Reporting.View;
using MahApps.Metro.Controls;
using System.Windows;

namespace Clinical_Reporting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       

       

        private void PatientTile_Click(object sender, System.EventArgs e)
        {
            var addParientPage = new AddPatient();
            navigationPanel.NavigationService.Navigate(addParientPage);

        }

            
    }
}
