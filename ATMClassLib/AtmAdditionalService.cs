using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClassLib
{
    public class AtmAdditionalService
    {
        public void ShowAllCustomers(List<Customer> customers)
        {
            foreach (Customer property in customers)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n\tId customer {property.idCustomer}, user logged: {property.IsLogged}");
                Console.ResetColor();
                Console.WriteLine(
                    "\tName: {0}\n" +
                    "\tSurname: {1}\n" +
                    "\tCard number: {2}\n" +
                    "\tCard PIN: {3}\n" +
                    "\tAccount balance: {4}\n",
                    property.name, property.surname, property.cardNumber, property.cardPin, property.AccountBalance
                );
            }
            Console.ReadKey();
        }
        public void AddCustomer(Customer customer, List<Customer> customers)
        {
            Console.Clear();
            Console.Write("\n\tEnter name: ");
            string name = Console.ReadLine();
            Console.Write("\n\tEntersurname: ");
            string surname = Console.ReadLine();
            Console.Write("\n\tEnter card PIN: ");
            int cardPin = int.Parse(Console.ReadLine());
            long newCardNumber = customer.GenerateCustomerNewCardNumber();
            customer = customer.CreateCustomer(name, surname, cardPin, newCardNumber);
            customers.Add(customer);
        }
        public void DeleteCustomer()
        {

        }
        public void EditCustomer()
        {

        }
    }
}
