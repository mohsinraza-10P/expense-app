using System;
using ExpenseApp.iOS.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]
namespace ExpenseApp.iOS.CustomRenderers
{
	public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);
        }
    }
}

