using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Table("Serology")]
    public partial class Serology
    {
        
        public Serology()
        {
        }
        

        [Key]
        [Column("SERIALNO")]
        public System.Int64 Serialno { get; set; }

        [Column("PATIENTID")]
        public System.Int64 Patientid { get; set; }

        [Column("TDATE")]
        public System.String Tdate { get; set; }

        [Column("WIDAL_TEST")]
        public System.String WidalTest { get; set; }

        [Column("S_TYPHI_TO")]
        public System.String STyphiTo { get; set; }

        [Column("S_TYPHI_TH")]
        public System.String STyphiTh { get; set; }

        [Column("PARA_THYPHI_AH")]
        public System.String ParaThyphiAh { get; set; }

        [Column("PARA_THYPHI_BH")]
        public System.String ParaThyphiBh { get; set; }

        [Column("TYPHOID")]
        public System.String Typhoid { get; set; }

        [Column("I_G_M")]
        public System.String IGM { get; set; }

        [Column("I_G_G")]
        public System.String IGG { get; set; }

        [Column("HBS_AG")]
        public System.String HbsAg { get; set; }

        [Column("ASO_TITRE")]
        public System.String AsoTitre { get; set; }

        [Column("PREGNANCY_TEST")]
        public System.String PregnancyTest { get; set; }

        [Column("RA_FACTOR")]
        public System.String RaFactor { get; set; }

        [Column("ANTI_HCV")]
        public System.String AntiHcv { get; set; }

        [Column("MANTOEX")]
        public System.String Mantoex { get; set; }

        [Column("KAHNS_VDRL")]
        public System.String KahnsVdrl { get; set; }

        [Column("TB_PLUS")]
        public System.String TbPlus { get; set; }

        [Column("IGM")]
        public System.String Igm { get; set; }

        [Column("IGG")]
        public System.String Igg { get; set; }

        [Column("HELICOBACTER_PYLORI")]
        public System.String HelicobacterPylori { get; set; }

        [Column("HIV")]
        public System.String Hiv { get; set; }

        [Column("FEE")]
        public System.Int64 Fee { get; set; }

        [NotMapped]
        public virtual Patient Patient { get; set; }
         [NotMapped]
         public bool IsNew
         {
                get
                {
         
                  return this.Serialno == default(int);
         
                }
                
          }
          [NotMapped]
          public bool IsDeleted { get; set; }
    }
}