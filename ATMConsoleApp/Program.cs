using ATMClassLib;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ATMConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AtmService atmService = new AtmService();
            AtmSuperUser superUser = new AtmSuperUser();
            Customer customer = new Customer();
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(true, "Jan", "Kowalski", 1111000011110000, 1111, 1000.0m));
            customers.Add(new Customer(false, "Robert", "Wolny", 2222000022220000, 2222, 2000.0m));                        
            atmService.SignIn(customer, customers);
            while (true)
            {
                Console.Clear();
                atmService.ShowMenu(customers);
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 2:
                        {
                            Console.Clear();
                            atmService.ShowAccountBalance(customers);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            atmService.WithdrawCash(customer, customers);
                            break;
                        }

                    case 11:
                        {
                            Console.Clear();
                            superUser.ShowAllCustomers(customers);
                            break;
                        }
                    case 22:
                        {
                            Console.Clear();
                            superUser.AddCustomer(customer, customers);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
