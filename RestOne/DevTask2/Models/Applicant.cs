using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTask2.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        DateTime DateBirth { get; set; }
        string CityBirth { get; set; }
        string AddressBirth { get; set; }
        string AddressCurrent { get; set; }
        string INN { get; set; }
        string SNILS { get; set; }
        string PassNum { get; set; }
    }
}
