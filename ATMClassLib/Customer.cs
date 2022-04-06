using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClassLib
{
    public class Customer
    {
        private string idCustomer { get; set; }
        public string IdCustomer
        {
            get { return idCustomer; }
            set { idCustomer = value; }
        }
        public string name { get; set; }
        public string surname { get; set; }
        public long cardNumber { get; set; }
        public int cardPin { get; set; }
        private decimal accountBalance;
        public decimal AccountBalance
        {
            get { return accountBalance; }
            private set { accountBalance = value; }
        }
        private bool isLogged;
        public bool IsLogged
        {
            get { return isLogged; }
            private set { isLogged = value; }
        }
        public bool isSuperUser { get; }
        public Customer()
        {

        }
        public Customer(bool isSuperUser, string name, string surname, long cardNumber, int cardPin, decimal accountBalance)
        {
            this.isSuperUser = isSuperUser;
            this.name = name;
            this.surname = surname;
            this.cardNumber = cardNumber;
            this.cardPin = cardPin;
            this.accountBalance = accountBalance;
        }
        private void IsCustomerLogged(List<Customer> customers, long userCardNumber, int userCardPin)
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
                        IsCustomerLogged(customers, userCardNumber, userCardPin);
                    }
                }
            }
            return isCorrectCardPin;
        }
        public Customer CreateCustomer(string idCustomer, string name, string surname, int cardPin, long newCardNumber)
        {
            Customer customer = new Customer();
            customer.idCustomer = idCustomer;
            customer.name = name;
            customer.surname = surname;
            customer.cardPin = cardPin;
            customer.cardNumber = newCardNumber;
            return customer;
        }
        public long GenerateCustomerNewCardNumber()
        {
            var generateNumber = new Random();
            string cos = "";
            string[] tabCardNumbers = new string[16];
            for (int i = 0; i < tabCardNumbers.Length; i++)
            {
                tabCardNumbers[i] += generateNumber.Next(0, 10).ToString();
                cos += tabCardNumbers[i];
            }
            return long.Parse(cos);
        }
        public void ReduceCustomerAccountBalance(List<Customer> customers, decimal amount)
        {
            foreach (var property in customers)
            {
                if (property.IsLogged)
                {
                    property.AccountBalance -= amount;
                }
            }
        }
        public void IncreaseCustomerAccountBalance(List<Customer> customers, decimal amount)
        {
            foreach (var property in customers)
            {
                if (property.IsLogged)
                {
                    property.AccountBalance += amount;
                }
            }
        }
        public string GenerateIdCustomer()
        {
            string cos = "";
            return cos;
        }
    }
}
