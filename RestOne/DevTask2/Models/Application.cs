using System;
using DevTask2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTask2.Models
{
    public class Application
    {
        public int ApplicationId { get;set }
        string AppNum { get; set; }
        DateTime AppDate { get; set; }
        string BranchBank { get; set; }
        string BranchBankAddr { get; set; }
        long CreditManagerId { get; set; }
        Applicant applicant { get; set; }
        Credit RequestedCredit { get; set; }
        bool ScoringStatus { get; set; }
        DateTime ScoringDate { get; set; }

    }
}
