using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Yondr_Finance.Controls;

namespace Yondr_Finance.Behaviors
{
    public class EmptyEntryValidatorBehavior : Behavior<ExtendedEntry>
    {
        ExtendedEntry control;
        string _placeHolder;
        Xamarin.Forms.Color _placeHolderColor;

        protected override void OnAttachedTo(ExtendedEntry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            bindable.PropertyChanged += OnPropertyChanged;
            control = bindable;
            _placeHolder = bindable.Placeholder;
            _placeHolderColor = bindable.PlaceholderColor;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                ((ExtendedEntry)sender).IsBorderErrorVisible = false;
            }

            bool IsValid = false;
            IsValid = e.NewTextValue!=null?true:false;
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;

            // LABEL CODE
            Label errorLabel = ((Entry)sender).FindByName<Label>("errorMessage");
            if (IsValid)
            {
                errorLabel.Text = "Passowrd Invalid or whatever!";
            }
            else
            {
                errorLabel.Text = "";
            }
        }

        protected override void OnDetachingFrom(ExtendedEntry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            bindable.PropertyChanged -= OnPropertyChanged;
        }

        void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == ExtendedEntry.IsBorderErrorVisibleProperty.PropertyName && control != null)
            {
                if (control.IsBorderErrorVisible)
                {
                    control.Placeholder = control.ErrorText;
                    control.PlaceholderColor = control.BorderErrorColor;
                    control.Text = string.Empty;
                }

                else
                {
                    control.Placeholder = _placeHolder;
                    control.PlaceholderColor = _placeHolderColor;
                }

            }
        }
    }
}
