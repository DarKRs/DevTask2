using DevTask2.Utilities;
using System;
using System.ComponentModel.DataAnnotations;

namespace DevTask2.Models
{
    public class Applicant : ApplicantDTO
    {
        [Key]
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateBirth { get; set; }
        public string CityBirth { get; set; }
        public string AddressBirth { get; set; }
        public string AddressCurrent { get; set; }
        public string INN { get; set; }
        public string SNILS { get; set; }
        public string PassNum { get; set; }

        public Applicant()
        {
            FirstName = Func.RandStr(6);
            MiddleName = Func.RandStr(12);
            LastName = Func.RandStr(12);
            DateBirth = Func.RandDay();
            CityBirth = Func.RandStr(8);
            AddressBirth = Func.RandStr(20);
            AddressCurrent = Func.RandStr(20);
            INN = Func.RandStr(11);
            SNILS = Func.RandStr(8);
            PassNum = Func.RandStr(20);
        }

    }
}
