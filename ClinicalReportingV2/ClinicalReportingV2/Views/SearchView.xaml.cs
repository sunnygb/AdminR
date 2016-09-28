using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ClinicalReporting.Views
{
    /// <summary>
    ///     Interaction logic for SearchForm.xaml
    /// </summary>
    /// this
    public partial class SearchView : UserControl,ICommonView
    {
        public SearchView()
        {
            InitializeComponent();
            
        }

        private void TreeViewLostFocus(object sender, RoutedEventArgs e)
        {
            Blood.IsExpanded = false;
            bio.IsExpanded = false;
            hbsa.IsExpanded = false;
            hcv.IsExpanded = false;
            tb.IsExpanded = false;
            hae.IsExpanded = false;
            se.IsExpanded = false;
            ser.IsExpanded = false;

        }
    }
}