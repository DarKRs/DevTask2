using DevTask2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTask2.Models
{
    public class CreditDTO
    {
        public CreditType creditType { get; set; }
        public int RequestedAmount { get; set; }
        public string RequestedCurrency { get; set; }
    }
}
