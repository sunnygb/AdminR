using AdmissionAndResult.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AdmissionAndResult.Views
{
    /// <summary>
    /// Interaction logic for StudentSearchView.xaml
    /// </summary>this
    public partial class StudentSearchView : UserControl, ICommonView
    {
        public StudentSearchView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentDetailView dfor = new StudentDetailView();
            
           var win= App.Current;

           MainWindow mw =(MainWindow) App.Current.MainWindow;
           //mw.mainStack.NavigationService.Navigate(dfor);
           dfor.DataContext = new StudentDetailViewModel(grid.SelectedItem);
        }

    

  
    }
}
