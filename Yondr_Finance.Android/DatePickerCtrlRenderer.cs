using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Yondr_Finance.CustomRenderer;
using Yondr_Finance.Droid;
using DatePicker = Xamarin.Forms.DatePicker;

[assembly: ExportRenderer(typeof(DatePickerCtrl), typeof(DatePickerCtrlRenderer))]
namespace Yondr_Finance.Droid
{
   public class DatePickerCtrlRenderer : DatePickerRenderer  
    {  
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)  
        {  
            base.OnElementChanged(e);  
          
            DatePickerCtrl element = Element as DatePickerCtrl;  
  
            if (!string.IsNullOrWhiteSpace(element.Placeholder))  
            {  
                Control.Text = element.Placeholder;  
            }  
  
            this.Control.TextChanged += (sender, arg) => {  
                var selectedDate = arg.Text.ToString();  
                if (selectedDate == element.Placeholder)  
                {  
                    Control.Text = DateTime.Now.ToString("dd/MMM/yyyy");  
                }  
            };  
        }  
    }  
}  