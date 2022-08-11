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
    public partial class AllResult : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public AllResult()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            showFindRecord.ItemsSource = await firebaseHelper.GetAllCASRecord();

        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {


            var mydetails = e.Item as CarSpecs;
            await Navigation.PushAsync(new Search2(mydetails.ID, mydetails.Name));

        }
    }
}