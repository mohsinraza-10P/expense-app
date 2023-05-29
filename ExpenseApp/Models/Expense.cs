using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseApp.Models
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }

        public static int InsertExpense(Expense expense)
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>(); // Make sure table is created
                return conn.Insert(expense);
            }
        }

        public static List<Expense> FetchExpenses()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>(); // Make sure table is created
                return conn.Table<Expense>().ToList();
            }
        }

        public static List<Expense> FetchExpenses(string category)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().Where(e => e.Category == category).ToList();
            }
        }

        public static double TotalExpensesAmount()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().ToList().Sum(e => e.Amount);
            }
        }
    }
}
