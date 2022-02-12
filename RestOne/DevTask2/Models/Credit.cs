using DevTask2.Models.Enums;
using DevTask2.Utilities;

namespace DevTask2.Models
{
    public class Credit : CreditDTO
    {
        public int CreditId { get; set; }
        public int AnnualSalary { get; set; }
        public int MonthlySalary { get; set; }
        public string CompanyName { get; set; }
        public string Comment { get; set; }

        public Credit()
        {
            creditType = CreditType.Standart;
            RequestedAmount = Func.RandInt(10000000);
            RequestedCurrency = "rur";
            AnnualSalary = Func.RandInt(RequestedAmount);
            MonthlySalary = AnnualSalary / 12;
            CompanyName = Func.RandStr(12);
            Comment = Func.RandStr(30);
        }

    }
}
