using AdmissionAndResult.ViewModel;
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

namespace AdmissionAndResult.Views
{
    /// <summary>
    /// Interaction logic for SearchForm.xaml
    /// </summary>this
    public partial class SearchForm : UserControl
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DetailForm dfor = new DetailForm();
            
           var win= App.Current;

           MainWindow mw =(MainWindow) App.Current.MainWindow;
           mw.mainStack.NavigationService.Navigate(dfor);
           dfor.DataContext = new DetailFormViewModel(grid.SelectedItem);
        }
    }
}
