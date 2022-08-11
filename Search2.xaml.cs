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
    public partial class Search2 : ContentPage
    {
        public static string FirstID = "null";
        public static string FirstName = "null";
        string selectedBrand;
        string selectedBodyType;

        public Search2(string ID1, string Name1)
        {
            InitializeComponent();
            FirstID = ID1;

            FirstName = Name1;

            YourLableName.Text = Name1;

            findBrand.Items.Add("Honda");
            findBrand.Items.Add("Proton");
            findBrand.Items.Add("Perodua");
            findBrand.Items.Add("Toyota");
            findBrand.Items.Add("Mitsubishi");

            findBrand.SelectedIndexChanged += (sender, args) =>
            {
                if (findBrand.SelectedIndex == -1)
                {
                }
                else
                {
                    selectedBrand = findBrand.Items[findBrand.SelectedIndex];
                }
            };

            findBodyType.Items.Add("SUV");
            findBodyType.Items.Add("Sedan");
            findBodyType.Items.Add("Hatchback");
            findBodyType.Items.Add("MPV");

            findBodyType.SelectedIndexChanged += (sender, args) =>
            {
                if (findBodyType.SelectedIndex == -1)
                {
                }
                else
                {
                    selectedBodyType = findBodyType.Items[findBodyType.SelectedIndex];
                }
            };

        }
        async void ForwardAllResultComparison(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondSearchResult(FirstID, FirstName));
        }

        async void SearchByKeyword(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompareSearchResult2ByKeyword(FirstID, FirstName, findKeyword.Text));
        }

        async void SearchByBrand(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompareSearchResult2ByBrand(FirstID, FirstName, selectedBrand));
        }

        async void SearchByBodyType(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompareSearchResult2ByBodyType(FirstID, FirstName, selectedBodyType));
        }

    }
}