using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceConsole
{
    internal interface IPayable
    {
        public decimal GetPayableAmount();
    }
}
