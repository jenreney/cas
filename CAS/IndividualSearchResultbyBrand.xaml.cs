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
    public partial class IndividualSearchResultbyBrand : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public IndividualSearchResultbyBrand(string br)
        {
            InitializeComponent();
            OnFindRecord(br);
        }


        async void OnFindRecord(string search)
        {

            showFindRecord.ItemsSource = await firebaseHelper.GetFindBrand(search);
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {


            var mydetails = e.Item as CarSpecs;
            await Navigation.PushAsync(new CarDetail(mydetails.ID, mydetails.Image1, mydetails.Favorite, mydetails.Name, mydetails.Model, mydetails.Price, mydetails.Brand, mydetails.BodyType, mydetails.Segment, mydetails.Engine, mydetails.Dimension, mydetails.Fueltank, mydetails.TopSpeed, mydetails.Feature, mydetails.ImageFront, mydetails.ImageBack, mydetails.ImageSide, mydetails.Ytlink, mydetails.Website));

        }
    }
}