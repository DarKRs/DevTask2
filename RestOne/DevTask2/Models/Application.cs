using System;
using DevTask2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DevTask2.Utilities;

namespace DevTask2.Models
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        
        [MaxLength(250)]
        [Required]
        public string AppNum { get; set; }

        [Required]
        public DateTime AppDate { get; set; }

        [Required]
        public string BranchBank { get; set; }
        public string BranchBankAddr { get; set; }

        [Required]
        public int CreditManagerId { get; set; }

        [Required]
        public Applicant applicant { get; set; }

        [Required]
        public Credit RequestedCredit { get; set; }
        public bool ScoringStatus { get; set; }
        public DateTime ScoringDate { get; set; }

        public Application()
        {
            AppNum = Func.RandStr(8);
            AppDate = DateTime.Today;
            BranchBank = Func.RandStr(5);
            BranchBankAddr = Func.RandStr(12);
            CreditManagerId = Func.RandInt();
            applicant = new Applicant();
            RequestedCredit = new Credit();
        }

    }
}
