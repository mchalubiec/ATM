using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClassLib
{
    public class Customer
    {
        private string name { get; set; }
        private string surname { get; set; }
        private long cardNumber { get; set; }
        private int cardPin { get; set; }
        private decimal accountBalance { get; set; }
        public bool isLogged { get; set; }
        public bool isSuperUser { get; }
        public Customer()
        {
            isSuperUser = isSuperUser;
            name = name;
            surname = surname;
            cardNumber = cardNumber;
            cardPin = cardPin;
            accountBalance = 0.0m;
            isLogged = false;
        }
        public Customer(bool isSuperUser, string name, string surname, long cardNumber, int cardPin)
        {
            this.isSuperUser = isSuperUser;
            this.name = name;
            this.surname = surname;
            this.cardNumber = cardNumber;
            this.cardPin = cardPin;
        }
        private void IsLogged(List<Customer> customers, long userCardNumber, int userCardPin)
        {
            foreach (Customer property in customers)
            {
                if (property.cardNumber == userCardNumber)
                {
                    if (property.cardPin == userCardPin)
                    {
                        property.isLogged = true;
                    }
                }
            }
        }
        public bool IsExistCardNumber(List<Customer> customers, long userCardNumber)
        {
            bool isExistCardNumber = false;
            foreach (Customer property in customers)
            {
                if (property.cardNumber == userCardNumber)
                {
                    isExistCardNumber = true;
                }
            }
            return isExistCardNumber;
        }
        public bool IsCorrectCardPin(List<Customer> customers, int userCardPin, long userCardNumber)
        {
            bool isCorrectCardPin = false;
            foreach (Customer property in customers)
            {
                if (property.cardNumber == userCardNumber)
                {
                    if (property.cardPin == userCardPin)
                    {
                        isCorrectCardPin = true;
                        IsLogged(customers, userCardNumber, userCardPin);
                    }
                }
            }
            return isCorrectCardPin;
        }
        public Customer CreateCustomer(string name, string surname, int cardPin, long newCardNumber)
        {
            Customer customer = new Customer();
            this.name = name;
            this.surname = surname;
            this.cardPin = cardPin;
            cardNumber = newCardNumber;
            return customer;
        }
        public void ShowCustomerDetails(List<Customer> customers)
        {
            foreach (Customer property in customers)
            {
                if (property.isLogged)
                {
                    Console.WriteLine("Szczegóły konta klienta");
                    Console.WriteLine(
                        "Imię..........:{0}\n" +
                        "Nazwisko......:{1}\n" +
                        "Numer karty...:{2}\n" +
                        "Kod PIN.......:{3}\n",
                        property.name, property.surname, property.cardNumber, property.cardPin
                    );
                }
            }
            Console.ReadKey();
        }
        public void ShowCustomersDetails(List<Customer> customers)
        {
            foreach (Customer property in customers)
            {
                Console.WriteLine("Szczegóły konta klienta");
                Console.WriteLine(
                    "Imię..........:{0}\n" +
                    "Nazwisko......:{1}\n" +
                    "Numer karty...:{2}\n" +
                    "Kod PIN.......:{3}\n",
                    property.name, property.surname, property.cardNumber, property.cardPin
                );
            }
            Console.ReadKey();
        }
    }
}
