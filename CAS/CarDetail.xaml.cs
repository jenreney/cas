using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CAS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarDetail : ContentPage
    {
        public static string ID="null";
        public static string imageTest="null";
        public static string favHere = "null";
        public static string fav = "null";

        public static string name = "null";
        public static string model = "null";
        public static string price = "null";
        public static string brand = "null";
        public static string bodytype = "null";
        public static string segment = "null";
        public static string engine = "null";
        public static string dimension = "null";
        public static string fueltank = "null";
        public static string topspeed = "null";
        public static string feature = "null";
        public static string imagefront = "null";
        public static string imageback = "null";
        public static string imageside = "null";
        public static string ytlink = "null";
        public static string website = "null";

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        static WebClient Client = new WebClient();
        public CarDetail(string idreceive, string imagereceive, string favoritereceive, string namereceive, string modelreceive, string pricereceive, string brandreceive, string bodytypereceive, string segmentreceive, string enginereceive, string dimensionreceive, string fueltankreceive, string topspeedreceive, string featurereceive, string imagefrontreceive, string imagebackreceive, string imagesidereceive, string ytlinkreceive, string websitereceive)
        {
            InitializeComponent();

            ID = idreceive;
            imageTest = imagereceive;
            favHere = favoritereceive;

            name = namereceive;
            model = modelreceive;
            price = pricereceive;
            brand = brandreceive;
            bodytype = bodytypereceive;
            segment = segmentreceive;
            engine = enginereceive;
            dimension = dimensionreceive;
            fueltank = fueltankreceive;
            topspeed = topspeedreceive;
            feature = featurereceive;
            imagefront = imagefrontreceive;
            imageback = imagebackreceive;
            imageside = imagesidereceive;
            ytlink = ytlinkreceive;
            website = websitereceive;


            var imageSource = new UriImageSource { Uri = new Uri(imageTest) };
            imageSource.CachingEnabled = false;
            imageSource.CacheValidity = TimeSpan.FromHours(1);
            img.Source = imageSource;

            YourLableName.Text = name;


            OnFindRecord(ID);


        }

        
        async void OnFindRecord(string ID)
        {

            showFindRecordID.ItemsSource = await firebaseHelper.GetFindRecordID(ID);
        }

        async void OnImageButtonClicked(object sender, EventArgs e)
        {
            if (favHere == "Yes")
            {
                fav = "No";
            }
            else if (favHere == "No")
            {
                fav = "Yes";
            }

            await firebaseHelper.UpdatePerson(ID, fav, name, model, price, brand, bodytype, segment, engine, dimension, fueltank, topspeed, feature, imagefront, imageback, imageside, imageTest, ytlink, website);

            await DisplayAlert("Success", "Your Favorited Cars list has been updated. Please restart the app for the updated list.", "OK");
        }

        private async void OnImageZoomButtonClicked(object sender, EventArgs e)
        {


            
            await Navigation.PushAsync(new ImagePreview(ID, imagefront, imageback, imageside));

        }

        private async void OnImageYoutubeButtonClicked(object sender, EventArgs e)
        {



            await Browser.OpenAsync(ytlink, BrowserLaunchMode.SystemPreferred);

        }

        private async void OnWebsiteButtonClicked(object sender, EventArgs e)
        {



            await Browser.OpenAsync(website, BrowserLaunchMode.SystemPreferred);

        }

    }
}