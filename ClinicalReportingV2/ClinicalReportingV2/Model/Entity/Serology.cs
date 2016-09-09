using ClinicalReporting.Data.Wrapper;
using ServiceStack.DataAnnotations;
using System;

namespace ClinicalReporting.Data
{
    [Alias("Serology")]
    public class Serology
    {
        public Serology()
        {
        }

        public Serology(SerologyW serologyw)
        {
            Serialno = serologyw.Serialno;
            Patientid = serologyw.Patientid;
            Tdate = serologyw.Tdate;
            WidalTest = serologyw.WidalTest;
            STyphiTo = serologyw.STyphiTo;
            STyphiTh = serologyw.STyphiTh;
            ParaThyphiAh = serologyw.ParaThyphiAh;
            ParaThyphiBh = serologyw.ParaThyphiBh;
            Typhoid = serologyw.Typhoid;
            IGM = serologyw.IGM;
            IGG = serologyw.IGG;
            HbsAg = serologyw.HbsAg;
            AsoTitre = serologyw.AsoTitre;
            PregnancyTest = serologyw.PregnancyTest;
            RaFactor = serologyw.RaFactor;
            AntiHcv = serologyw.AntiHcv;
            Mantoex = serologyw.Mantoex;
            KahnsVdrl = serologyw.KahnsVdrl;
            TbPlus = serologyw.TbPlus;
            Igm = serologyw.Igm;
            Igg = serologyw.Igg;
            HelicobacterPylori = serologyw.HelicobacterPylori;
            Hiv = serologyw.Hiv;
            Fee = serologyw.Fee;
        }

        [PrimaryKey]
        [Alias("SERIALNO")]
        public Int64 Serialno { get; set; }

        [Alias("PATIENTID")]
        public Int64 Patientid { get; set; }

        [Alias("TDATE")]
        public String Tdate { get; set; }

        [Alias("WIDAL_TEST")]
        public String WidalTest { get; set; }

        [Alias("S_TYPHI_TO")]
        public String STyphiTo { get; set; }

        [Alias("S_TYPHI_TH")]
        public String STyphiTh { get; set; }

        [Alias("PARA_THYPHI_AH")]
        public String ParaThyphiAh { get; set; }

        [Alias("PARA_THYPHI_BH")]
        public String ParaThyphiBh { get; set; }

        [Alias("TYPHOID")]
        public String Typhoid { get; set; }

        [Alias("I_G_M")]
        public String IGM { get; set; }

        [Alias("I_G_G")]
        public String IGG { get; set; }

        [Alias("HBS_AG")]
        public String HbsAg { get; set; }

        [Alias("ASO_TITRE")]
        public String AsoTitre { get; set; }

        [Alias("PREGNANCY_TEST")]
        public String PregnancyTest { get; set; }

        [Alias("RA_FACTOR")]
        public String RaFactor { get; set; }

        [Alias("ANTI_HCV")]
        public String AntiHcv { get; set; }

        [Alias("MANTOEX")]
        public String Mantoex { get; set; }

        [Alias("KAHNS_VDRL")]
        public String KahnsVdrl { get; set; }

        [Alias("TB_PLUS")]
        public String TbPlus { get; set; }

        [Alias("IGM")]
        public String Igm { get; set; }

        [Alias("IGG")]
        public String Igg { get; set; }

        [Alias("HELICOBACTER_PYLORI")]
        public String HelicobacterPylori { get; set; }

        [Alias("HIV")]
        public String Hiv { get; set; }

        [Alias("FEE")]
        public Int64 Fee { get; set; }

        [Ignore]
        public virtual Patient Patient { get; set; }

        [Ignore]
        public bool IsNew
        {
            get { return Serialno == default(int); }
        }

        [Ignore]
        public bool IsDeleted { get; set; }
    }
}