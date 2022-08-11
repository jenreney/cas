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
    public partial class TabbedResultCompare : TabbedPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public static string FirstID = "null";
        public static string SecondID = "null";
        public TabbedResultCompare(string firstidreceive, string secondidreceive)
        {
            InitializeComponent();
            FirstID = firstidreceive;
            SecondID = secondidreceive;
            
        }

        async override protected void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            if (CurrentPage is ContentPage OverallRecordsTab)
            {
                base.OnAppearing();

            }
            else if (CurrentPage is ContentPage FindStatusTab)
            {
                base.OnAppearing();

            }

        }

        async void OnFindRecord2(object sender, EventArgs e)
        {
            displayRecord.ItemsSource = await firebaseHelper.GetFindRecordID(FirstID);
        }

        async void OnFindRecord(object sender, EventArgs e)
        {
            showFindRecord.ItemsSource = await firebaseHelper.GetFindRecordID2(SecondID);
        }
    }
}