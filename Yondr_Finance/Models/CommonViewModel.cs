using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Yondr_Finance.Annotations;

namespace Yondr_Finance.Models
{
    public class CommonViewModel: INotifyPropertyChanged
    {
        private DateTime? _date;
        public DateTime? Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public void validate_buttons(bool validate,Button btnNext)
        {
            if(validate)
            {
                btnNext.IsEnabled = true;
                btnNext.BackgroundColor = Color.FromRgb(179, 130, 242);
            }
            else
            {
                btnNext.IsEnabled = false;
                btnNext.BackgroundColor = Color.FromRgb(160, 160, 160);
            }
        }

        public bool validate_email(string email)
        {
            bool rslt;            
            var emailPattern = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            rslt = emailPattern.IsMatch(email);
            return rslt;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        
        protected virtual bool SetProperty<T>(ref T storage, T value, Action afterAction, [CallerMemberName] string propertyName = null)
        {
            if (SetProperty(ref storage, value, propertyName))
            {
                afterAction?.Invoke();
                return true;
            }

            return false;
        }
    }
}
