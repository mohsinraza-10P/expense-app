using System;
using Android.Content;
using Android.Views;
using ExpenseApp.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
namespace ExpenseApp.Droid.CustomRenderer
{
	public class CustomTextCellRenderer : TextCellRenderer
	{
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            return base.GetCellCore(item, convertView, parent, context);
        }
    }
}

