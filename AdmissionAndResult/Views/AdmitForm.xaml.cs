using Microsoft.Win32;
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
using Model;
using AdmissionAndResult.Views.Degrees;
using System.Collections.ObjectModel;
using AdmissionAndResult.ViewModel;

namespace AdmissionAndResult.Views
{

    public partial class AdmitForm : UserControl
    {
        private PHDForm phdForm;
        private MSForm msForm;
        private BatchlorForm batForm;
        private AdmitFormViewModel viewModel;


        public AdmitForm()
        {
            if(viewModel==null)
            {
                this.viewModel = new AdmitFormViewModel();
            }
            batForm = new BatchlorForm();
            msForm = new MSForm();
            phdForm = new PHDForm();

            this.DataContext = viewModel;
            ObservableCollection<string> ob = new ObservableCollection<string>();
            ob.Add("Batchlor");
            ob.Add("Master");
            ob.Add("PHD");
            //admitList.ItemsSource = ob.ToList<string>();

            InitializeComponent();
            
            
            

        }





        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }


        }

        //private void admitList_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    if (admitList.SelectedIndex == 0)
        //    {
                
        //        frame.NavigationService.Navigate(batForm);


        //        scrol.ScrollToEnd();
        //    }
        //   else if (admitList.SelectedIndex == 1)
        //    {
                
              
                
        //        msForm.DataContext = viewModel;
        //        frame.NavigationService.Navigate(msForm);


        //        scrol.ScrollToEnd();

        //    }
        //   else
        //    {
            
                
               
        //        phdForm.DataContext = viewModel;
        //        frame.NavigationService.Navigate(phdForm);


        //        scrol.ScrollToEnd();

        //    }

        //}


        private bool IsValid(DependencyObject obj)
        {
            // The dependency object is valid if it has no errors and all
            // of its children (that are dependency objects) are error-free.
            return !Validation.GetHasError(obj) &&
            LogicalTreeHelper.GetChildren(obj)
            .OfType<DependencyObject>()
            .All(IsValid);
        }

   
    }

}
