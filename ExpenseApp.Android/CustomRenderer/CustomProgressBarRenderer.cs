using System;
using Android.Content;
using ExpenseApp.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]

namespace ExpenseApp.Droid.CustomRenderer
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public CustomProgressBarRenderer(Context context) : base(context)
        {
        }

    }
}

