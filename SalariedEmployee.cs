using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceConsole
{
    internal class SalariedEmployee : Employee
    {
        public decimal WeeklySalary { get; set; }

        public SalariedEmployee(string firstname, string lastname, string ssn, decimal weeklySalary) : base(firstname, lastname, ssn)
        {
            this.Type = PayrollType.Salaried;
            WeeklySalary = weeklySalary;
        }

        public override decimal getEarnings()
        {
            return this.WeeklySalary;
        }

        public override string ToString()
        {
            return "Salaried Employee: " + this.Firstname + " " + this.Lastname + "\n" +
                            "SSN: " + this.SSN + "\n" +
                            "Weekly Salary: " + string.Format("{0:c}", this.WeeklySalary) + "\n" +
                            "Earned: " + string.Format("{0:c}", GetPayableAmount());
        }
    }
}
