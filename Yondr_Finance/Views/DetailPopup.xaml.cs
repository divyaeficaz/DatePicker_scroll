using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yondr_Finance.Models;

namespace Yondr_Finance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPopup : PopupPage
    {
        CommonViewModel cvm = new CommonViewModel();
        public string rdb_sel = "";
        public bool midname = true;
        string territory = "";
        Dictionary<string, string> statelst = new Dictionary<string, string>
        {
            {"New South Wales","NSW"},{"Victoria","VIC"},
            {"Queensland", "QLD"},{"Tasmania", "TAS" },
            {"South Australia","SA"},{"Western Australia","WA"},
            {"Northern Territory","NT"},{"Australian Capital Territory","ACT"}
        };
        public DetailPopup(string type)
        {


            InitializeComponent();
            string platform = DeviceInfo.Platform.ToString();
            if (platform == "Android")
            {
                pkrState.IsVisible = false;
                txtsel.IsVisible = true;
            }
            else if (platform == "iOS")
            {
                pkrState.IsVisible = true;
                // pkrState.HorizontalOptions= "FillAndExpand";
                // pkrState.VerticalOptions = "FillAndExpand";
                txtsel.IsVisible = false;
            }
            txtsel.Focused += pkrselection;
            foreach (string state in statelst.Values)
            {
                pkrState.Items.Add(state);
            }
            loadcontrols(type);
        }
        public void loadcontrols(string type)
        {
            if (type == "stk_name")
            {
                stk_name.IsVisible = true;
            }
            else if (type == "stk_dob")
            {
                stk_dob.IsVisible = true;
            }
            else if (type == "stk_address")
            {
                stk_address.IsVisible = true;
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(600);
            txt_firstname.Focus();
            loadSaved();
        }
        public void loadSaved()
        {
            
        }
        private async void btnNext_clicked(object sender, EventArgs e)
        {
           
            btnNext.IsEnabled = true;
            ////Redirect to detail page///
            ///

            await PopupNavigation.PopAsync();

            await Navigation.PushAsync(new SignupDetailPage13());
           //  await Navigation.PopAsync();
          //  await PopupNavigation.RemovePageAsync(this);
        }
        private void checkvalidation(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            territory = selectedItem.ToString();
            validate();
            txtsel.Text = pkrState.SelectedItem.ToString();
        }
        private async void btnback_clicked(object sender, EventArgs e)
        {
            // await PopupNavigation.RemovePageAsync(this);
            await PopupNavigation.Instance.PopAsync();
        }

        private void rdbgenderchecked(object sender, CheckedChangedEventArgs e)
        {

            if (((RadioButton)sender).IsChecked == true)
            {
                rdb_sel = ((RadioButton)sender).Text;
                validate();
            }


        }

        /// <summary>
        /// ////page validation
        /// </summary>
        public void validate()
        {
            if (txt_firstname.Text != "" && txt_surname.Text != "" && rdb_sel != "")
            {
                if (midname == true)
                {
                    if (txt_middilename.Text != "")
                    {
                        cvm.validate_buttons(true, btnNext);
                    }
                    else
                    {
                        cvm.validate_buttons(false, btnNext);
                    }
                }
                else
                    cvm.validate_buttons(true, btnNext);
            }
            else
            {
                cvm.validate_buttons(false, btnNext);
            }
        }
        private void check_valid(object sender, TextChangedEventArgs e)
        {

            var isValid = Regex.IsMatch(e.NewTextValue, "^[a-zA-Z]+$");

            if (e.NewTextValue.Length > 0)
            {
                ((Entry)sender).Text = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
            }

            validate();
        }

        private void chkmidname_changed(object sender, CheckedChangedEventArgs e)
        {
            if (chkmidname.IsChecked == true)
            {
                middile_name.IsVisible = false;
                midname = false;
            }
            else
            {
                middile_name.IsVisible = true;
                midname = true;
            }
            validate();
        }

        private async void OnImageNameTapped(object sender, EventArgs e)
        {
            await PopupNavigation.RemovePageAsync(this);
            //await PopupNavigation.Instance.PopAsync();
        }

        private void pickerclick(object sender, EventArgs e)
        {
            pkrState.Focus();
        }


        private void firstname_focuschange(object sender, FocusEventArgs e)
        {
            if (txt_firstname.Text == "")
            {
                first_name.BorderColor = Color.Red;
            }
            else
            {
                first_name.BorderColor = Color.FromRgb(243, 243, 243);
            }
        }

        private void middle_focuschanged(object sender, FocusEventArgs e)
        {
            if (txt_middilename.Text == "")
            {
                fr_middile_name.BorderColor = Color.Red;
            }
            else
            {
                fr_middile_name.BorderColor = Color.FromRgb(243, 243, 243);
            }
        }

        private void surname_focuschanged(object sender, FocusEventArgs e)
        {
            if (txt_surname.Text == "")
            {
                sur_name.BorderColor = Color.Red;
            }
            else
            {
                sur_name.BorderColor = Color.FromRgb(243, 243, 243);
            }
        }

        private void checkmiddle_focus(object sender, FocusEventArgs e)
        {
            if (txt_firstname.Text == "")
            {
                first_name.BorderColor = Color.Red;
            }
            else
            {
                first_name.BorderColor = Color.FromRgb(243, 243, 243);
            }
        }

        private void surname_focus(object sender, FocusEventArgs e)
        {
            if (txt_middilename.Text == "")
            {
                fr_middile_name.BorderColor = Color.Red;
            }
            else
            {
                fr_middile_name.BorderColor = Color.FromRgb(243, 243, 243);
            }
            if (txt_firstname.Text == "")
            {
                first_name.BorderColor = Color.Red;
            }
            else
            {
                first_name.BorderColor = Color.FromRgb(243, 243, 243);
            }
        }

        private void pkrselection(object sender, FocusEventArgs e)
        {
            pkrState.Focus();
        }
       
    }
}