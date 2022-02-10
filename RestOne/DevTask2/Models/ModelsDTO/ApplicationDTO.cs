using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTask2.Models
{
    public class ApplicationDTO
    {
        public int ApplicationId { get; set; }

        public string AppNum { get; set; }

        public DateTime AppDate { get; set; }

        public string BranchBank { get; set; }
        public string BranchBankAddr { get; set; }

        public int CreditManagerId { get; set; }

        public ApplicantDTO applicant { get; set; }
        public CreditDTO RequestedCredit { get; set; }
        public bool? ScoringStatus { get; set; }
        public DateTime? ScoringDate { get; set; }
    }
}
