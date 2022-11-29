// See https://aka.ms/new-console-template for more information

using InvoiceConsole;
using System.Xml.Schema;

List<IPayable> payables = new List<IPayable>();

Employee hourly1 = new HourlyEmployee("John", "Snow", "123-45-6789", 7.0m, 40);
Employee hourly2 = new HourlyEmployee("Diana", "White", "561-23-4789", 8.52m, 15);
Employee hourly3 = new HourlyEmployee("Froodoo", "Bombkins", "789-45-6123", 9.80m, 42);
Employee salary1 = new SalariedEmployee("Bob", "Burger", "987-65-4321", 1000.0m);
Employee salary2 = new SalariedEmployee("Luke", "Kinwakes", "123-65-4789", 890.5m);
Employee salary3 = new SalariedEmployee("Nancy", "Drawer", "987-45-6321", 1200.0m);
Invoice invoice1 = new Invoice("7811", 5, "Turtle Stuffies", 9.85m);
Invoice invoice2 = new Invoice("3422", 3, "Ninja Turtle RC Cars", 12.89m);
Invoice invoice3 = new Invoice("1233", 2, "Rob Zombie Dolls", 29.99m);

payables.Add(hourly1);
payables.Add(hourly2);
payables.Add(hourly3);
payables.Add(salary1);
payables.Add(salary2);
payables.Add(salary3);
payables.Add(invoice1);
payables.Add(invoice2);
payables.Add(invoice3);

bool IsRunning = true;

while (IsRunning)
{
    MainMenu();
}

void PrintPayables()
{
    decimal total = 0m;
    decimal totalinvoices = 0m;
    decimal totalsalary = 0m;
    decimal totalhourly = 0m;

    foreach (IPayable payable in payables)
    {
        Console.WriteLine(payable.ToString());
        Console.WriteLine();
        total += payable.GetPayableAmount();

        if (payable is Invoice)
        {
            totalinvoices += payable.GetPayableAmount();
        }

        if (payable is SalariedEmployee)
        {
            totalsalary += payable.GetPayableAmount();
        }

        if (payable is HourlyEmployee)
        {
            totalhourly += payable.GetPayableAmount();
        }
    }
    
    Console.WriteLine("Total Weekly Payout: " + string.Format("{0:c}", total));
    Console.WriteLine("Category Breakdown: ");
    Console.WriteLine("\t Invoices: " + string.Format("{0:c}", totalinvoices));
    Console.WriteLine("\t Salaried Payroll: " + string.Format("{0:c}", totalsalary));
    Console.WriteLine("\t Hourly Payroll: " + string.Format("{0:c}", totalhourly));
}

void AddPayable(PayrollType type)
{
    switch (type)
    {
        case (PayrollType.Salaried):
            Console.WriteLine("First Name: ");
            string firstname = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            string lastname = Console.ReadLine();
            Console.WriteLine("SSN: ");
            string ssn = Console.ReadLine();
            Console.WriteLine("Weekley Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            payables.Add(new SalariedEmployee(firstname, lastname, ssn, salary));
            break;
        case (PayrollType.Hourly):
            Console.WriteLine("First Name: ");
            string hourlyfirstname = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            string hourlylastname = Console.ReadLine();
            Console.WriteLine("SSN: ");
            string hourlyssn = Console.ReadLine();
            Console.WriteLine("Wage: ");
            decimal wage = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Hours Worked: ");
            int worked = int.Parse(Console.ReadLine());
            payables.Add(new HourlyEmployee(hourlyfirstname, hourlylastname, hourlyssn, wage, worked));
            break;
        case (PayrollType.Invoice):
            Console.WriteLine("Invoice Number: ");
            Console.WriteLine("Part Number: "); 
            string partnum = Console.ReadLine();
            Console.WriteLine("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Part Description: ");
            string partdescription = Console.ReadLine();
            Console.WriteLine("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            payables.Add(new Invoice(partnum, quantity, partdescription, price));
            break;
    }
}

void MainMenu()
{
    Console.WriteLine("1. Add a salary Employee");
    Console.WriteLine("2. Add a hourly Employee");
    Console.WriteLine("3. Add an Invoice");
    Console.WriteLine("4. Print Payable Invoice");
    Console.WriteLine("5. Exit");

    switch (Console.ReadLine())
    {
        case "1":
            AddPayable(PayrollType.Salaried);
            break;
        case "2":
            AddPayable(PayrollType.Hourly);
            break;
        case "3":
            AddPayable(PayrollType.Invoice);
            break;
        case "4":
            PrintPayables();
            break;
        case "5":
            IsRunning = false;
            break;
        default:  Console.WriteLine("Please make a valid selection.");
            break;
    }
}