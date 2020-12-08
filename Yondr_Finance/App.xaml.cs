using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yondr_Finance.Data;
using Yondr_Finance.Views;


[assembly: ExportFont("SuisseIntl-Black.otf", Alias = "Black-succi")]
[assembly: ExportFont("SuisseIntl-Bold.otf", Alias = "Bold-succi")]
[assembly: ExportFont("SuisseIntl-Book.otf", Alias = "Book-succi")]
[assembly: ExportFont("SuisseIntl-Light_0.otf", Alias = "Light-succi")]
[assembly: ExportFont("SuisseIntl-Regular.otf", Alias = "Regular-succi")]
[assembly: ExportFont("SuisseIntl-SemiBold.otf", Alias = "Semibold-succi")]


namespace Yondr_Finance
{
    public partial class App : Application
    {
        public App()
        {

           
            InitializeComponent();
            Device.SetFlags(new string[] { "RadioButton_Experimental" });
           
            MainPage = new NavigationPage(new SignupDetailPage3());
        }

        protected override void OnStart()
        {
            CrossConnectivity.Current.ConnectivityChanged += HandleConnectivityChanged;
            Device.BeginInvokeOnMainThread(async () =>
            {
                var isConnected = CrossConnectivity.Current.IsConnected;
                if (!isConnected)
                {
                    await MainPage.DisplayAlert("Connection", "Please check your internet connection", "OK");
                }
            });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {

            Type currentPage = this.MainPage.GetType();
            if (e.IsConnected )
            {

            }             
            else if (!e.IsConnected )
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var isConnected = CrossConnectivity.Current.IsConnected;

                    await MainPage.DisplayAlert("Connection", "Please check your internet connection", "OK");
                });
            }
                
        }
        static UserDatabase database;

        public static UserDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db3"));
                }
                return database;
            }
        }
      

    }
}
