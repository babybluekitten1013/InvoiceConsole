using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceConsole
{
    abstract class Employee : IPayable
    {

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SSN { get; set; }
        public PayrollType Type { get; set; }

        public Employee(string firstname, string lastname, string ssn)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.SSN = ssn;
        }

        public decimal GetPayableAmount()
        {
            return getEarnings();
        }

        public abstract decimal getEarnings();

    }
}
