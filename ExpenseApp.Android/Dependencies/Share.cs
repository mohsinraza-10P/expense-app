using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using ExpenseApp.Droid.Dependencies;
using ExpenseApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace ExpenseApp.Droid.Dependencies
{
    public class Share : IShare
    {
        public Task Show(string title, string message, string filePath)
        {
            var intent = new Intent(Intent.ActionSend);
            var documentUri = FileProvider.GetUriForFile(Forms.Context.ApplicationContext, "com.companyname.expenseapp.fileprovider", new Java.IO.File(filePath));
            
            intent.SetType("text/plain");
            intent.PutExtra(Intent.ExtraStream, documentUri);
            intent.PutExtra(Intent.ExtraText, title);
            intent.PutExtra(Intent.ExtraSubject, message);

            var chooser = Intent.CreateChooser(intent, title);
            chooser.SetFlags(ActivityFlags.GrantReadUriPermission);
            Android.App.Application.Context.StartActivity(chooser);

            return Task.FromResult(true);
        }
    }
}