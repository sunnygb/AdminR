﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionAndResult.Data
{



    public partial class Admin
    {
    
        public Admin()
        {
            VerifyingAgents = new List<VerifyingAgent>();
        }

        public long AdminId { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
        public string HireDate { get; set; }
        public string ChangeDate { get; set; }

        public virtual List<VerifyingAgent> VerifyingAgents { get; set; }

         public bool IsNew
         {
                get
                {
         
                  return this.AdminId == default(int);
         
                }
                
          }
          public bool IsDeleted { get; set; }
    }
}