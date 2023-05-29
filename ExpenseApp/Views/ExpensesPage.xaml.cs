using ExpenseApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesPage : ContentPage
    {
        private ExpenseVM ViewModel;

        public ExpensesPage()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as ExpenseVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.FetchExpenses();
        }
    }
}