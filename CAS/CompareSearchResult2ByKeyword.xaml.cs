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
    public partial class CompareSearchResult2ByKeyword : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public static string FirstID = "null";
        public CompareSearchResult2ByKeyword(string firstid, string name, string kw)
        {
            InitializeComponent();
            YourLableName.Text = name;
            FirstID = firstid;

            OnFindRecord(kw);
        }

        async void OnFindRecord(string search)
        {

            showFindRecord.ItemsSource = await firebaseHelper.GetFindBrand(search);
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {


            var mydetails = e.Item as CarSpecs;
            await Navigation.PushAsync(new TabbedResultCompare(FirstID, mydetails.ID));

        }
    }
}