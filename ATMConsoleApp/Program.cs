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
            ATM aTM = new ATM();
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(true, "Jan", "Kowalski", 1111000011110000, 1111));
            customers.Add(new Customer(false, "Robert", "Wolny", 2222000022220000, 2222));
            Customer customer = new Customer();
            aTM.SignIn(customer, customers);
            while (true)
            {
                Console.Clear();
                aTM.ShowMenuCustomer(customers);
                int choice = int.Parse(Console.ReadLine());
                if (choice > 0 && choice <= 3)
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.Clear();
                                customer.ShowCustomerDetails(customers);
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                aTM.AddCustomer(customer, customers);
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                customer.ShowCustomersDetails(customers);
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("przypatrz się opcją jeszcze raz..");
                    Thread.Sleep(5000);
                }

            }
        }
    }
}
