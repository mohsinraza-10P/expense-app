using ExpenseApp.Models;
using ExpenseApp.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ExpenseApp.ViewModels
{
    public class AddExpenseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _expenseName;
        public string ExpenseName
        {
            get { return _expenseName; }
            set
            {
                _expenseName = value;
                OnPropertyChanged(nameof(ExpenseName));
            }
        }

        private double _expenseAmount;
        public double ExpenseAmount
        {
            get { return _expenseAmount; }
            set
            {
                _expenseAmount = value;
                OnPropertyChanged(nameof(ExpenseAmount));
            }
        }

        private string _expenseDescription;
        public string ExpenseDescription
        {
            get { return _expenseDescription; }
            set
            {
                _expenseDescription = value;
                OnPropertyChanged(nameof(ExpenseDescription));
            }
        }

        private DateTime _expenseDate;
        public DateTime ExpenseDate
        {
            get { return _expenseDate; }
            set
            {
                _expenseDate = value;
                OnPropertyChanged(nameof(ExpenseDate));
            }
        }

        private string _expenseCategory;
        public string ExpenseCategory
        {
            get { return _expenseCategory; }
            set
            {
                _expenseCategory = value;
                OnPropertyChanged(nameof(ExpenseCategory));
            }
        }

        public Command SaveExpenseCommand { get; set; }
        public ObservableCollection<string> Categories { get; set; }

        public AddExpenseVM()
        {
            Categories = new ObservableCollection<string>();
            ExpenseDate = DateTime.Now;
            SaveExpenseCommand = new Command(InsertExpense);
            InitCategories();
        }

        private void OnPropertyChanged(string propertyName)
        {
            var args = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, args);
        }

        private async void InsertExpense()
        {
            if (string.IsNullOrEmpty(ExpenseName) || string.IsNullOrEmpty(ExpenseCategory))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please provide expense name and category.", "OK");
                return;
            }

            var expense = new Expense()
            {
                Name = ExpenseName,
                Amount = ExpenseAmount,
                Description = ExpenseDescription,
                Date = ExpenseDate,
                Category = ExpenseCategory
            };

            var id = Expense.InsertExpense(expense);
            if (id > 0)
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Could not insert expense data, please try again.", "OK");
            }
        }

        private void InitCategories()
        {
            Categories.Clear();
            Categories.Add(AppResources.housing);
            Categories.Add(AppResources.debt);
            Categories.Add(AppResources.health);
            Categories.Add(AppResources.food);
            Categories.Add(AppResources.personal);
            Categories.Add(AppResources.travel);
            Categories.Add(AppResources.other);
        }
    }
}
