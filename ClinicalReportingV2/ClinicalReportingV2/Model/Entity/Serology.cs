﻿using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Alias("Serology")]
    public partial class Serology
    {
        
        public Serology()
        {
        }
        

        [PrimaryKey]
        [Alias("SERIALNO")]
        public System.Int64 Serialno { get; set; }

        [Alias("PATIENTID")]
        public System.Int64 Patientid { get; set; }

        [Alias("TDATE")]
        public DateTime Tdate { get; set; }

        [Alias("WIDAL_TEST")]
        public System.String WidalTest { get; set; }

        [Alias("S_TYPHI_TO")]
        public System.String STyphiTo { get; set; }

        [Alias("S_TYPHI_TH")]
        public System.String STyphiTh { get; set; }

        [Alias("PARA_THYPHI_AH")]
        public System.String ParaThyphiAh { get; set; }

        [Alias("PARA_THYPHI_BH")]
        public System.String ParaThyphiBh { get; set; }

        [Alias("TYPHOID")]
        public System.String Typhoid { get; set; }

        [Alias("I_G_M")]
        public System.String IGM { get; set; }

        [Alias("I_G_G")]
        public System.String IGG { get; set; }

        [Alias("HBS_AG")]
        public System.String HbsAg { get; set; }

        [Alias("ASO_TITRE")]
        public System.String AsoTitre { get; set; }

        [Alias("PREGNANCY_TEST")]
        public System.String PregnancyTest { get; set; }

        [Alias("RA_FACTOR")]
        public System.String RaFactor { get; set; }

        [Alias("ANTI_HCV")]
        public System.String AntiHcv { get; set; }

        [Alias("MANTOEX")]
        public System.String Mantoex { get; set; }

        [Alias("KAHNS_VDRL")]
        public System.String KahnsVdrl { get; set; }

        [Alias("TB_PLUS")]
        public System.String TbPlus { get; set; }

        [Alias("IGM")]
        public System.String Igm { get; set; }

        [Alias("IGG")]
        public System.String Igg { get; set; }

        [Alias("HELICOBACTER_PYLORI")]
        public System.String HelicobacterPylori { get; set; }

        [Alias("HIV")]
        public System.String Hiv { get; set; }

        [Alias("FEE")]
        public System.Int64 Fee { get; set; }

        [Ignore]
        public virtual Patient Patient { get; set; }
         [Ignore]
         public bool IsNew
         {
                get
                {
         
                  return this.Serialno == default(int);
         
                }
                
          }
          [Ignore]
          public bool IsDeleted { get; set; }
    }
}