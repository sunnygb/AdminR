﻿using System;
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
using AdmissionAndResult.Views.Header;
using AdmissionAndResult.ViewModel;

namespace AdmissionAndResult
{

    public partial class MainWindow : Window
    {
        private AdmitForm admitForm;
        private SearchForm searchForm;
        private MeritForm meritForm;
        private AgentsForm agentForm;
        private AdmitFormViewModel admitVM;
        private AgentFormViewModel agentVM;
        private SearchViewModel searchVM;
        private static SQLiteConnection  conn;
        
        public MainWindow()
        {
             conn = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
            
            InitializeComponent();
            admitForm = new AdmitForm();
            searchForm = new SearchForm();
            meritForm = new MeritForm();
            agentForm = new AgentsForm();

            MainHeader header = new MainHeader();
            this.headerFrame.NavigationService.Navigate(header);
        }

        private void Add_Student_Click(object sender, RoutedEventArgs e)
        {
           
            admitVM = new AdmitFormViewModel();
            admitForm.DataContext = admitVM;
            mainStack.NavigationService.Navigate(admitForm);
            

        }

        private void btnMerit_Click(object sender, RoutedEventArgs e)
        {
            
            mainStack.NavigationService.Navigate(meritForm);
        }

        private void Agents_Click(object sender, RoutedEventArgs e)
        {
            agentVM = new AgentFormViewModel();
            agentForm.DataContext = agentVM;
            mainStack.NavigationService.Navigate(agentForm);
        }

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            searchVM = new SearchViewModel();
            searchForm.DataContext = searchVM;
            mainStack.NavigationService.Navigate(searchForm);
        }
       
    }
}