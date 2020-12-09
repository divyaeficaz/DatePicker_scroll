using System;
using System.Collections.Generic;
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
            dtpDob.BindingContextChanged += mnthchange;
            dtpDob.DateSelected += Date_DateSelected;
            var cntDate = DateTime.Now;
            var newDate = cntDate.AddYears(-18);
            dtpDob.MaxDate = newDate;           

           // cvm.validate_buttons(false, btnNext);
            
            
        }
        protected async override void OnAppearing()
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
           
            if (dtpDob.ToString()!=null)
            {
                cvm.validate_buttons(true, btnNext);
            }
            else
            {
                cvm.validate_buttons(false, btnNext);
            }
        }

        private void date_unfocus(object sender, FocusEventArgs e)
        {
            //var xx = dtpDob.Date;
            if (dtpDob.ToString() != null)
            {
                cvm.validate_buttons(true, btnNext);
            }
            else
            {
                cvm.validate_buttons(false, btnNext);
            }
        }

        private void dtfocus(object sender, FocusEventArgs e)
        {
            
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