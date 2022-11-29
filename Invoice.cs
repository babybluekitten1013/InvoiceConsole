using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceConsole
{
    internal class Invoice : IPayable
    {
        private string partnum;
        private int quantity;
        private string partdescription;
        private decimal price;
        public PayrollType Type;
        private string invoicenumber;

        public Invoice(string partnum, int quantity, string partdescription, decimal price)
        {
            this.partnum = partnum;
            this.quantity = quantity;
            this.partdescription = partdescription;
            this.price = price;
            this.Type = PayrollType.Invoice;

            Random random = new Random();
            string r = random.Next(0, 999999).ToString();

            this.invoicenumber = r + "-" + partnum;
        }

        public decimal GetPayableAmount()
        {
            return quantity * price;
        }

        public override string ToString()
        {
            return "Invoice: " + this.invoicenumber + "\n" +
                            "Quantity: " + this.quantity + "\n" +
                            "Part Description: " + this.partdescription + "\n" +
                            "Unit Price: " + string.Format("{0:c}", this.price) + "\n" +
                            "Extended Price: " + string.Format("{0:c}", GetPayableAmount());
        }
    }
}
