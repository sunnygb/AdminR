
using AdmissionAndResult.ViewModel;
using AdmissionAndResult.Views.Degrees;
using ClinicalReporting.Model;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AdmissionAndResult.Views
{

    public partial class StudentAdmitView : UserControl,ICommonView
    {
        private PHDForm phdForm;
        private MSForm msForm;
        private BatchlorForm batForm;
        private StudentAdmitViewModel viewModel;
        private Student student;


        public StudentAdmitView()
        {
            if(viewModel==null)
            {
                this.viewModel = new StudentAdmitViewModel();
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


        //private void SaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = ValidationEngine.Validate(student);
        //}

        //private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        //{
        //    CurrentCustomer.Save();
        //}

   
    }

}
