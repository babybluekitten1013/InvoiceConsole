using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceConsole
{
    internal class HourlyEmployee : Employee
    {
        public decimal Wage { get; set; }
        public decimal HoursWorked { get; set; }

        public HourlyEmployee(string firstname, string lastname, string ssn, decimal wage, decimal hoursworked) : base(firstname, lastname, ssn)
        {
            this.Type = PayrollType.Hourly;
            this.Wage = wage;
            this.HoursWorked = hoursworked;
        }

        public override decimal getEarnings()
        {
            decimal earnings = 0m;

            if (HoursWorked > 40)
            {
                // we have overtime
                earnings = (HoursWorked * Wage) + ((HoursWorked - 40) * (Wage * 0.5m));

            } else
            {
                // no overtime
                earnings = Wage * HoursWorked;
            }

            return earnings;
        }

        public override string ToString()
        {
            return "Hourly Employee: " + this.Firstname + " " + this.Lastname + "\n" +
                            "SSN: " + this.SSN + "\n" +
                            "Hourly Wage: " + string.Format("{0:c}", this.Wage) + "\n" +
                            "Hours Worked: " + this.HoursWorked + "\n" +
                            "Earned: " + string.Format("{0:c}", GetPayableAmount());
        }
    }
}
