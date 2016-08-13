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
using AdmissionAndResult.Views;
using System.Data.SQLite;
using Dapper;
using Model;

namespace AdmissionAndResult
{

    public partial class MainWindow : Window
    {
        private AdmitForm admitForm;
        private SearchForm searchForm;
        private MeritForm meritForm;
        private AgentsForm agentForm;
        public MainWindow()
        {
            InitializeComponent();
            admitForm = new AdmitForm();
            searchForm = new SearchForm();
            meritForm = new MeritForm();
            agentForm = new AgentsForm();
        }

        private void Add_Student_Click(object sender, RoutedEventArgs e)
        {

            SQLiteConnection conn = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
            
            mainStack.NavigationService.Navigate(admitForm);

        }

        private void btnMerit_Click(object sender, RoutedEventArgs e)
        {
            mainStack.NavigationService.Navigate(meritForm);
        }

        private void Agents_Click(object sender, RoutedEventArgs e)
        {
            mainStack.NavigationService.Navigate(agentForm);
        }

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            mainStack.NavigationService.Navigate(searchForm);
        }
    }
}
