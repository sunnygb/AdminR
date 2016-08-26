
using AdmissionAndResult.ViewModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace AdmissionAndResult.Views
{
    /// <summary>
    /// Interaction logic for MainHeader.xaml
    /// </summary>
    public partial class MainHeader : UserControl
    {
        public MainHeader()
        {
           
            InitializeComponent();
            this.DataContext = new HeaderViewModel();
           
            
        }

        
    }
}
