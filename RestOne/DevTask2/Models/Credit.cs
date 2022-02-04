using System;
using DevTask2.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTask2.Models
{
    public class Credit
    {
        public int CreditId { get; set; }
        CreditType creditType { get; set; }
        long RequestedAmount { get; set; }
        string RequestedCurrency { get; set; }
        int AnnualSalary { get; set; }
        int MonthlySalary { get; set; }
        string CompanyName { get; set; }
        string Comment { get; set; }
    }
}
