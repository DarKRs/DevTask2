using DevTask2.Utilities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DefaultValue(null)]
        public bool? ScoringStatus { get; set; }
        [DefaultValue(null)]
        public DateTime? ScoringDate { get; set; }

        public Application()
        {
            AppNum = Func.RandStr(8);
            AppDate = DateTime.Today;
            BranchBank = Func.RandStr(5);
            BranchBankAddr = Func.RandStr(12);
            CreditManagerId = Func.RandInt();
            applicant = new Applicant();
            RequestedCredit = new Credit();
            ScoringStatus = null;
            ScoringDate = null;
        }

        public void SetScoring(bool scStatus, DateTime scDate)
        {
           ScoringStatus = scStatus;
           ScoringDate = scDate;
        }

        public static explicit operator ApplicationDTO(Application a)
        {
            return new ApplicationDTO
            {
                ApplicationId = a.ApplicationId,
                AppNum = a.AppNum,
                AppDate = a.AppDate,
                BranchBank = a.BranchBank,
                BranchBankAddr = a.BranchBankAddr,
                CreditManagerId = a.CreditManagerId,
                applicant = a.applicant,
                RequestedCredit = a.RequestedCredit,
                ScoringStatus = a.ScoringStatus,
                ScoringDate = a.ScoringDate
            };
        }

    }
}
