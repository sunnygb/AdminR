
using MahApps.Metro.Controls;
using System.Windows;
using Clinical_Reporting.View;
using System;
using System.Configuration;
using Clinical_Reporting.Model;
using System.IO;
using System.Reflection;
using System.Windows.Navigation;

namespace Clinical_Reporting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            onload();
            InitializeComponent();
        }

        public NavigatedEventHandler navigationPanel_Navigated { get; private set; }

        private void onload()
        {

           
        }

        private void PatientTile_Click(object sender, EventArgs e)
        {
            var addParientPage = new AddPatient();
            navigationPanel.NavigationService.Navigate(addParientPage);
        }
    }
}
