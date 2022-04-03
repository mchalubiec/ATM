using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATMClassLib
{
    public class ATM
    {
        public string InputUser(string inputUser)
        {
            return inputUser;
        }
        public void SignIn(Customer customer, List<Customer> customers)
        {
            long userCardNumber;
            int userCardPin;
            while (true)
            {
                Console.Clear();
                Console.Write("\n\tEnter the card number: ");
                bool isCardNumber = long.TryParse(Console.ReadLine(), out userCardNumber);
                if (!isCardNumber)
                {
                    Console.WriteLine("wprowadzony numer karty zawiera niedozwolone znaki - wpisz jeszcze raz!");
                    break;
                }
                else
                {
                    bool isExistCardNumber = customer.IsExistCardNumber(customers, userCardNumber);
                    if (!isExistCardNumber)
                    {
                        Console.WriteLine("brak numeru karty w bazie - skontaktuj się z administratorem");
                        break;
                    }
                    else
                    {
                        Console.Write("\n\tEnter the card PIN: ");
                        bool isCardPin = int.TryParse(Console.ReadLine(), out userCardPin);
                        if (!isCardPin)
                        {
                            Console.WriteLine("wprowadzony PIN zawiera niedozwolone znaki - nieudana próba zalogowania się!");
                            break;
                        }
                        else
                        {
                            bool isCorrectCardPin = customer.IsCorrectCardPin(customers, userCardPin, userCardNumber);
                            if (!isCorrectCardPin)
                            {
                                Console.WriteLine("kod PIN niepoprawny!");
                                break;
                            }

                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\n\tLOGGED\n\tloading menu..");
                                Thread.Sleep(3000);
                                break;
                            }
                        }
                    }
                }
                
            }
        }
        public void AddCustomer(Customer customer, List<Customer> customers)
        {
            Console.Clear();
            Console.Write("name: ");
            string name = Console.ReadLine();
            Console.Write("surname: ");
            string surname = Console.ReadLine();
            Console.Write("card PIN: ");
            int cardPin = int.Parse(Console.ReadLine());
            long newCardNumber = GenerateNewCardNumber();
            customer = customer.CreateCustomer(name, surname, cardPin, newCardNumber);
            customers.Add(customer);
        }
        public long GenerateNewCardNumber()
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
        public void WithdrawCash(Customer customer, List<Customer> customers)
        {

        }
        public void DepositCash(Customer customer, List<Customer> customers)
        {

        }
        public void ShowAccountBalance(Customer customer, List<Customer> customers)
        {

        }
        public void ShowMenuCustomer(List<Customer> customers)
        {
            foreach (Customer property in customers)
            {
                if (property.isLogged)
                {
                    Console.WriteLine("\n\tATM Menu\n");
                    Console.WriteLine("\n\t1. Account details");
                    Console.WriteLine("\n\t2. Account balance");
                    Console.WriteLine("\n\t3. Withdrawn cash");
                    Console.WriteLine("\n\t4. Deposit cash");
                    Console.WriteLine("\n\t5. Logout");
                    if (property.isSuperUser)
                    {
                        Console.WriteLine("\n\n\tadditional services");
                        Console.WriteLine("\t6. Add user");
                        Console.WriteLine("\t7. Show all users");
                    }
                    Console.Write("\n\tOption: ");
                }
            }
        }
    }
}
