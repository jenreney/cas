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
    public partial class CompareSearchResult2ByBodyType : ContentPage
    {
        public static string FirstID = "null";
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public CompareSearchResult2ByBodyType(string firstid, string name1, string bt)
        {
            InitializeComponent();

            YourLableName.Text = name1;
            FirstID = firstid;

            OnFindRecord(bt);
        }


        async void OnFindRecord(string search)
        {

            showFindRecord.ItemsSource = await firebaseHelper.GetFindBodyType(search);
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {


            var mydetails = e.Item as CarSpecs;
            await Navigation.PushAsync(new TabbedResultCompare(FirstID, mydetails.ID));

        }
    }
}