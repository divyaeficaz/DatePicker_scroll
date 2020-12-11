using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yondr_Finance.Models;

namespace Yondr_Finance.Views
{
   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupDetailPage3 : ContentPage
    { 
        CommonViewModel cvm = new CommonViewModel();
        
        public SignupDetailPage3()
        {
            InitializeComponent();
            BindingContext = cvm;
            cvm.PropertyChanged += OnPropertyChanged;
            dtpDob.BindingContextChanged += mnthchange;
            dtpDob.DateSelected += Date_DateSelected;
            var cntDate = DateTime.Now;
            var newDate = cntDate.AddYears(-18);
            dtpDob.MaxDate = newDate;    
            cvm.Date = newDate;

           // cvm.validate_buttons(false, btnNext);
            
            
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(cvm.Date))
            {
                date_unfocus();
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(600);
            //dtpDob.Focus();
        }
        private async void btnNext_clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new SignupDetailPage13());
        }
        private async void btnback_clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        void Date_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (dtpDob.ToString() != null)
            {
                cvm.validate_buttons(true, btnNext);
            }
            else
            {
                cvm.validate_buttons(false, btnNext);
            }
        }
        private void date_changed(object sender, DateChangedEventArgs e)
        {
            //this all time will have true!!!
            if (dtpDob.ToString()!=null)
            {
                cvm.validate_buttons(true, btnNext);
            }
            else
            {
                cvm.validate_buttons(false, btnNext);
            }
        }

        private void date_unfocus()
        {
            //this all time will have true!!!
            //cvm.validate_buttons(dtpDob.ToString() != null, btnNext);
            cvm.validate_buttons(cvm.Date.HasValue, btnNext);
        }

        private void mnthchange(object sender, EventArgs e)
        {
            if (dtpDob.ToString() != null)
            {
                cvm.validate_buttons(true, btnNext);
            }
            else
            {
                cvm.validate_buttons(false, btnNext);
            }
        }
    }
}
