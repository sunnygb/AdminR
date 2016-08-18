using AdmissionAndResult.ViewModel;
using System.Windows;
using System.Windows.Controls;

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
           //mw.mainStack.NavigationService.Navigate(dfor);
           dfor.DataContext = new DetailFormViewModel(grid.SelectedItem);
        }
    }
}
