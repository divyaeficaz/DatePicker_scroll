using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Yondr_Finance.Controls;

namespace Yondr_Finance.iOS
{
    public class ExtendedEntryRenderer : EntryRenderer
	{
		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (Control == null || this.Element == null) return;

			if (e.PropertyName == ExtendedEntry.IsBorderErrorVisibleProperty.PropertyName)
			{
				if (((ExtendedEntry)this.Element).IsBorderErrorVisible)
				{
					this.Control.Layer.BorderColor = ((ExtendedEntry)this.Element).BorderErrorColor.ToCGColor();
					this.Control.Layer.BorderWidth = new nfloat(0.8);
					this.Control.Layer.CornerRadius = 5;
				}
				else
				{
					this.Control.Layer.BorderColor = UIColor.LightGray.CGColor;
					this.Control.Layer.CornerRadius = 5;
					this.Control.Layer.BorderWidth = new nfloat(0.8);
				}

			}
		}

	}
}