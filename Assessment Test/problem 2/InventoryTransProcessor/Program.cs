using System;
using System.Collections.Generic;

class Program
{
    // Transaction class to store transaction details
    class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }

    // In-memory list to store transactions
    static List<Transaction> transactions = new List<Transaction>();
    static int transactionCounter = 1; // Auto-increment transaction ID

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nInventory Transaction Processor");
            Console.WriteLine("1. Add Transaction");
            Console.WriteLine("2. View Transactions");
            Console.WriteLine("3. Summary Report");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddTransaction();
                    break;
                case "2":
                    ViewTransactions();
                    break;
                case "3":
                    SummaryReport();
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddTransaction()
    {
        Console.Write("Enter Category Name: ");
        string category = Console.ReadLine();
        category = category.ToLower();

        Console.Write("Enter Date (yyyy-MM-dd): ");
        string input = Console.ReadLine();

        if (DateTime.TryParse(input, out DateTime date))
        {
            Console.WriteLine($"You entered: {date.ToString("yyyy-MM-dd")}");
            Console.Write("Enter Amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                transactions.Add(new Transaction
                {
                    Id = transactionCounter++,
                    Category = category,
                    Date = date,
                    Amount = amount
                });
                Console.WriteLine("Transaction added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a valid number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid date format. Please enter in yyyy-MM-dd format.");
        }

    }

    static void ViewTransactions()
    {
        if (transactions.Count == 0)
        {
            Console.WriteLine("No transactions available.");
            return;
        }

        Console.WriteLine("\nTransaction List:");

        Console.WriteLine("ID\tCategory\tAmount\t\tDate");
        Console.WriteLine("---------------------------------------------------");
        foreach (var tx in transactions)
        {
            Console.WriteLine($"{tx.Id}\t{tx.Category}\t\t{tx.Amount}\t\t{tx.Date.ToString("yyyy-MM-dd")}");
        }
    }

    static void SummaryReport()
    {
        if (transactions.Count == 0)
        {
            Console.WriteLine("No transactions available.");
            return;
        }

        Console.WriteLine("\nSummary Report:");

        Console.WriteLine("------------------------------------------");

        // Group by Category and calculate total amount
        var summary = transactions
            .GroupBy(t => t.Category)
            .Select(g => new
            {
                Category = g.Key,
                TotalAmount = g.Sum(t => t.Amount)
            });

        // Display results
        foreach (var item in summary)
        {
            Console.WriteLine($"Category: {item.Category}, Total Amount: {item.TotalAmount}");
        }
    }
}