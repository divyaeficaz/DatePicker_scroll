using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Yondr_Finance.CustomRenderer
{
    public class BorderlessPicker : Picker
    {
        public BorderlessPicker() : base()
        {
        }

        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create(nameof(Image), typeof(string), typeof(BorderlessPicker), string.Empty);

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
    }
}
