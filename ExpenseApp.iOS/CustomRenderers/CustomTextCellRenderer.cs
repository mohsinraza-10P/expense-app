using System;
using ExpenseApp.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
namespace ExpenseApp.iOS.CustomRenderers
{
	public class CustomTextCellRenderer : TextCellRenderer
	{
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            return base.GetCell(item, reusableCell, tv);
        }
    }
}

