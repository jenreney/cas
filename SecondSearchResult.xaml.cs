using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CAS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondSearchResult : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public static string FirstID = "null";
        public static string Name1 = "null";
        public SecondSearchResult(string firstidreceive, string firstname)
        {
            InitializeComponent();
            FirstID = firstidreceive;
            Name1 = firstname;

            YourLableName.Text = Name1;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            showFindRecord.ItemsSource = await firebaseHelper.GetAllCASRecord();

        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {


            var mydetails = e.Item as CarSpecs;
            await Navigation.PushAsync(new TabbedResultCompare(FirstID , mydetails.ID ));

        }
    }
}