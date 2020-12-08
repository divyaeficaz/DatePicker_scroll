using Newtonsoft.Json;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yondr_Finance.Models;

namespace Yondr_Finance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupDetailPage13 : ContentPage
    {
        //string UserID = (Application.Current.Properties["userId"].ToString());
        CommonViewModel cvm = new CommonViewModel();
        public SignupDetailPage13()
        {
            InitializeComponent();
            cvm.validate_buttons(true, btnNext);
            LoadData();

        }
        public void LoadData()
        {
            
        }
        private async void btnNext_clicked(object sender, EventArgs e)
        {

            Task rslt = AddCustomer();
            if (rslt.Status.ToString() == "Success")
            {
                ////Redirect to congratulation page///
                //await Navigation.PushAsync(new SignupDetailPage14());
            }
            else
            {
                ////Redirect to failure page///
               // await Navigation.PushAsync(new SignupDetailPage15());
            }

        }


        ///api callng
        ///
        private async Task AddCustomer()
        {
            
        }

        private async void name_edit(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new DetailPopup("stk_name")).ConfigureAwait(true);
        }

        private async void address_edit(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new DetailPopup("stk_name")).ConfigureAwait(true);
        }

        private async void licNum_clicked(object sender, EventArgs e)
        {
             await PopupNavigation.Instance.PushAsync(new DetailPopup("stk_name")).ConfigureAwait(true);
        }

        private void licState_edit(object sender, EventArgs e)
        {

        }

        private void licexpiry_edit(object sender, EventArgs e)
        {

        }

        private void btnback_clicked(object sender, EventArgs e)
        {

        }
    }
}