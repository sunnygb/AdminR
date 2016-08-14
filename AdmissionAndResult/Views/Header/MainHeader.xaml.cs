using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AdmissionAndResult.Views.Header
{
    /// <summary>
    /// Interaction logic for MainHeader.xaml
    /// </summary>
    public partial class MainHeader : UserControl
    {
        public MainHeader()
        {
            Admin ad1= new Admin();
           ad1.Admin_Id=1;
            ad1.Admin_Name="Sunny";
            ad1.Password="123";
             Admin ad2= new Admin();
           ad2.Admin_Id=2;
            ad2.Admin_Name="Ali";
            ad2.Password="123";
           ObservableCollection<Admin> admins= new ObservableCollection<Admin>()
               {ad1,ad2
                   
               };
            InitializeComponent();
            this.adminList.ItemsSource=admins;
           
            
        }

        private void adminList_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
