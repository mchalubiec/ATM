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
            AtmAdditionalService atmAdditionalService = new AtmAdditionalService();
            Customer customer = new Customer();
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(true, "Jan", "Kowalski", 1111000011110000, 1111, 1000.0m));
            customers.Add(new Customer(false, "Robert", "Wolny", 2222000022220000, 2222, 2000.0m));
            while (true)
            {
                atmService.SignIn(customer, customers);
                while (true)
                {
                    Console.Clear();
                    atmService.ShowMenu(customers);
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.Clear();
                                atmService.ShowAccountDetails(customers);
                                break;
                            }
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
                        case 4:
                            {
                                Console.Clear();
                                atmService.DepositCash(customer, customers);
                                break;
                            }
                        case 5:
                            {
                                Console.Clear();
                                atmService.ChangeCardPin(customer, customers);
                                break;
                            }
                        case 6:
                            {
                                Console.Clear();
                                atmService.Logout(customers);
                                break;
                            }
                        case 11:
                            {
                                Console.Clear();
                                atmAdditionalService.ShowAllCustomers(customers);
                                break;
                            }
                        case 22:
                            {
                                Console.Clear();
                                atmAdditionalService.AddCustomer(customer, customers);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }            
        }
    }
}
