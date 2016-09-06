using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Data.Wrapper;
namespace ClinicalReporting.Data
{


    [Alias("Serology")]
    public partial class Serology
    {
        
        public Serology()
        {
        }
        
        public Serology(SerologyW serologyw)
        {
           this.SerialNo = serologyw.SerialNo;
           this.PatientID = serologyw.PatientID;
           this.TDate = serologyw.TDate;
           this.WidalTest = serologyw.WidalTest;
           this.STyphiTO = serologyw.STyphiTO;
           this.STyphiTH = serologyw.STyphiTH;
           this.ParaThyphiAh = serologyw.ParaThyphiAh;
           this.ParaThyphiBh = serologyw.ParaThyphiBh;
           this.HBSAg = serologyw.HBSAg;
           this.ASOTitre = serologyw.ASOTitre;
           this.PregnancyTest = serologyw.PregnancyTest;
           this.RAFactor = serologyw.RAFactor;
           this.AntiHcv = serologyw.AntiHcv;
           this.Mantoex = serologyw.Mantoex;
           this.KahnsVDRL = serologyw.KahnsVDRL;
           this.TBPlus = serologyw.TBPlus;
           this.Hiv = serologyw.Hiv;
           this.Fee = serologyw.Fee;
           
           
        }

        [PrimaryKey]
        [Alias("SerialNo")]
        public System.Int64 SerialNo { get; set; }

        [Alias("PatientID")]
        public System.Int64 PatientID { get; set; }

        [Alias("TDate")]
        public System.DateTime TDate { get; set; }

        [Alias("Widal_Test")]
        public System.String WidalTest { get; set; }

        [Alias("S_Typhi_TO")]
        public System.String STyphiTO { get; set; }

        [Alias("S_Typhi_TH")]
        public System.String STyphiTH { get; set; }

        [Alias("Para_Thyphi_Ah")]
        public System.String ParaThyphiAh { get; set; }

        [Alias("Para_Thyphi_Bh")]
        public System.String ParaThyphiBh { get; set; }

        [Alias("HBS_Ag")]
        public System.String HBSAg { get; set; }

        [Alias("ASO_Titre")]
        public System.String ASOTitre { get; set; }

        [Alias("Pregnancy_Test")]
        public System.String PregnancyTest { get; set; }

        [Alias("RA_Factor")]
        public System.String RAFactor { get; set; }

        [Alias("Anti_Hcv")]
        public System.String AntiHcv { get; set; }

        [Alias("Mantoex")]
        public System.String Mantoex { get; set; }

        [Alias("Kahns_VDRL")]
        public System.String KahnsVDRL { get; set; }

        [Alias("TB_Plus")]
        public System.String TBPlus { get; set; }

        [Alias("HIV")]
        public System.String Hiv { get; set; }

        [Alias("Fee")]
        public System.Int32 Fee { get; set; }

        [Ignore]
        public virtual Patient Patient { get; set; }
         [Ignore]
         public bool IsNew
         {
                get
                {
         
                  return this.SerialNo == default(int);
         
                }
                
          }
          [Ignore]
          public bool IsDeleted { get; set; }
    }
}