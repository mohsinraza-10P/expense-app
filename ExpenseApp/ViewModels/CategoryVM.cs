using ExpenseApp.Interfaces;
using ExpenseApp.Models;
using ExpenseApp.Resources;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseApp.ViewModels
{
    public class CategoryVM
    {
        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<CategoryExpenses> CategoryExpenses { get; set; }
        public Command ExportCommand { get; set; }

        public CategoryVM()
        {
            ExportCommand = new Command(ShareReportAsync);
            Categories = new ObservableCollection<string>();
            CategoryExpenses = new ObservableCollection<CategoryExpenses>();
            InitCategories();
            InitCategoryExpenses();
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

        public void InitCategoryExpenses()
        {
            CategoryExpenses.Clear();
            double totalExpensesAmount = Expense.TotalExpensesAmount();
            foreach (string c in Categories)
            {
                var expenses = Expense.FetchExpenses(c);
                double expensesAmountInCategory = expenses.Sum(e => e.Amount);

                var ce = new CategoryExpenses()
                {
                    CategoryName = c,
                    ExpensePercentage = expensesAmountInCategory / totalExpensesAmount
                };
                // CategoryExpenses.Add(ce);
            }
        }

        private async void ShareReportAsync()
        {
            var rootFolder = FileSystem.Current.LocalStorage;
            var reportsFolder = await rootFolder.CreateFolderAsync("reports", CreationCollisionOption.OpenIfExists);
            var txtFile = await reportsFolder.CreateFileAsync("reports.txt", CreationCollisionOption.ReplaceExisting);

            using(StreamWriter sw = new StreamWriter(txtFile.Path))
            {
                foreach (var ce in CategoryExpenses)
                {
                    sw.WriteLine(ce.CategoryName + " - " + ce.ExpensePercentage + "%");
                }
            }

            var dependency = DependencyService.Get<IShare>();
            await dependency.Show("Expense Report", "Expense Report by Xamarin", txtFile.Path);
        }
    }
}
