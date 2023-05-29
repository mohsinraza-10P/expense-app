using ExpenseApp.Interfaces;
using ExpenseApp.Models;
using ExpenseApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ExpenseApp.ViewModels
{
    public class ExpenseVM
    {
        public ObservableCollection<Expense> Expenses { get; set; }

        public Command AddExpenseCommand { get; set; }

        public ExpenseVM()
        {
            AddExpenseCommand = new Command(OpenAddExpensePage);
            Expenses = new ObservableCollection<Expense>();
            FetchExpenses();
        }

        public void FetchExpenses()
        {
            var list = Expense.FetchExpenses();
            if (list != null)
            {
                Expenses.Clear();
                foreach (var item in list)
                {
                    Expenses.Add(item);
                }
            }
        }

        private async void OpenAddExpensePage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddExpensePage());
        }
    }
}
