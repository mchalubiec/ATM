using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATMClassLib
{
    public class AtmService
    {
        decimal amount;
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
                                Console.WriteLine("\n\tSucced login\n\tloading menu..");
                                Thread.Sleep(3000);
                                break;
                            }
                        }
                    }
                }

            }
        }
        public void ShowAccountBalance(List<Customer> customers)
        {
            foreach (var property in customers)
            {
                if (property.IsLogged)
                {
                    Console.WriteLine($"\n\tAccount balance: {property.AccountBalance:C}");
                }
            }
            Console.ReadKey();
        }
        public void ShowAccountDetails(List<Customer> customers)
        {
            foreach (var property in customers)
            {
                if (property.IsLogged)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Id customer {property.IdCustomer}, user logged: {property.IsLogged}");
                    Console.ResetColor();
                    Console.WriteLine(
                        "\tName: {0}\n" +
                        "\tSurname: {1}\n" +
                        "\tCard number: {2}\n" +
                        "\tCard PIN: {3}\n" +
                        "\tAccount balance: {4:C}\n",
                        property.name, property.surname, property.cardNumber, property.cardPin, property.AccountBalance
                    );
                }
            }
            Console.ReadKey();
        }
        public void WithdrawCash(Customer customer, List<Customer> customers)
        {
            bool end = true;
            while (end)
            {
                foreach (var property in customers)
                {
                    if (property.IsLogged)
                    {
                        Console.Clear();
                        Console.Write("\n\tEnter the amount to withdrawn: ");
                        bool isAmount = decimal.TryParse(Console.ReadLine(), out amount);
                        if (!isAmount)
                        {
                            Console.WriteLine("\n\tbłędna kwota..");
                            break;
                        }
                        else
                        {
                            if (!(property.AccountBalance >= amount))
                            {
                                Console.WriteLine("\n\tbrak środków na koncie..");
                                Console.Write("\n\tWant to return to main menu or enter different amount?\n\t(press ENTER to continue or press ESC to return)");
                                if (Console.ReadKey().Key == ConsoleKey.Escape)
                                {
                                    end = false;
                                    break;
                                }
                                if (Console.ReadKey().Key == ConsoleKey.Enter) break;
                            }
                            else
                            {
                                customer.ReduceCustomerAccountBalance(customers, amount);
                                Console.WriteLine($"\n\tWithdrawn cash: {amount:C}");
                                Console.WriteLine("\ntpress ENTER to continue..");
                                Console.ReadKey();
                                end = false;
                            }
                        }
                    }
                }
            }
        }
        public void DepositCash(Customer customer, List<Customer> customers)
        {
            bool end = true;
            while (end)
            {
                foreach (var property in customers)
                {
                    if (property.IsLogged)
                    {
                        Console.Clear();
                        Console.Write("\n\tEnter the amount to deposit: ");
                        bool isAmount = decimal.TryParse(Console.ReadLine(), out amount);
                        if (!isAmount)
                        {
                            Console.WriteLine("\n\tbłędna kwota..");
                            break;
                        }
                        else
                        {
                            customer.IncreaseCustomerAccountBalance(customers, amount);
                            Console.WriteLine($"\n\tDeposit cash: {amount:C}");
                            Console.WriteLine("\ntpress ENTER to continue..");
                            Console.ReadKey();
                            end = false;
                            break;
                        }
                    }
                }
            }
        }
        public void ChangeCardPin(Customer customer, List<Customer> customers)
        {

        }
        public void Logout(List<Customer> customers)
        {
            bool logout;
            foreach (var property in customers)
            {
                if (property.IsLogged)
                {
                    logout = true;
                }
            }
        }
        public void ShowMenu(List<Customer> customers)
        {
            foreach (Customer property in customers)
            {
                if (property.IsLogged)
                {
                    Console.WriteLine("\n\tATM Menu\n");
                    Console.WriteLine("\n\t1. Account details");
                    Console.WriteLine("\n\t2. Account balance");
                    Console.WriteLine("\n\t3. Withdrawn cash");
                    Console.WriteLine("\n\t4. Deposit cash");
                    Console.WriteLine("\n\t5. Change card PIN");
                    Console.WriteLine("\n\t6. Logout");
                    if (property.isSuperUser)
                    {
                        Console.WriteLine("\n\n\tadditional services");
                        Console.WriteLine("\t11. Show all users");
                        Console.WriteLine("\t22. Add user");
                        Console.WriteLine("\t33. Edit user");
                        Console.WriteLine("\t44. Delete user");
                    }
                    Console.Write("\n\tOption: ");
                }
            }
        }
    }
}
