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

using System.Xml;
using Telerik.Reporting.XmlSerialization;
using Telerik.Reporting;

namespace AdmissionAndResult.Views
{

    public partial class StudentverifyingReport : UserControl, ICommonView
    {


        
        public StudentverifyingReport()
        {
           
            
            
            InitializeComponent();
          
            
                

        }

        //public static VerifyingReport ChangeConnectionString()
        //{
            //VerifyingReport report;
            //XmlReaderSettings settings;
            //XmlReader xmlReader;
            //ReportXmlSerializer xmlSerializer;
            //SqlDataSource sqlDataSource;

            //settings = new XmlReaderSettings();
            //settings.IgnoreWhitespace = true;
            //using (xmlReader = XmlReader.Create(@"..\..\VerifyingReport.trdx", settings))
            //{
            //    xmlSerializer = new ReportXmlSerializer();
            //    report = (VerifyingReport)xmlSerializer.Deserialize(xmlReader);
            //}
            //sqlDataSource = (SqlDataSource)report.DataSource;
            //sqlDataSource.ConnectionString = "Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db";
            //report.DataSource = sqlDataSource;
            ////report.ReportParameters["ParamName"].Value = "Addr";
            //return report;
           
           
        //}

    }
}
