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
    public partial class TabbedSearchType : TabbedPage
    {
        string selectedBrand;
        string selectedBodyType;
        public TabbedSearchType()
        {
            InitializeComponent();

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

            findBrandIndiv.Items.Add("Honda");
            findBrandIndiv.Items.Add("Proton");
            findBrandIndiv.Items.Add("Perodua");
            findBrandIndiv.Items.Add("Toyota");
            findBrandIndiv.Items.Add("Mitsubishi");

            findBrandIndiv.SelectedIndexChanged += (sender, args) =>
            {
                if (findBrandIndiv.SelectedIndex == -1)
                {
                }
                else
                {
                    selectedBrand = findBrandIndiv.Items[findBrandIndiv.SelectedIndex];
                }
            };

            findBodyTypeIndiv.Items.Add("SUV");
            findBodyTypeIndiv.Items.Add("Sedan");
            findBodyTypeIndiv.Items.Add("Hatchback");
            findBodyTypeIndiv.Items.Add("MPV");

            findBodyTypeIndiv.SelectedIndexChanged += (sender, args) =>
            {
                if (findBodyTypeIndiv.SelectedIndex == -1)
                {
                }
                else
                {
                    selectedBodyType = findBodyTypeIndiv.Items[findBodyTypeIndiv.SelectedIndex];
                }
            };
        }

        async void ForwardAllResultIndividually(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllRequestIndividually());
        }

        async void ForwardAllResultComparison(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllResult());
        }

        async void SearchByKeyword(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompareSearchResultByKeyword(findKeyword.Text));
        }

        async void SearchByBrand(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompareSearchResultByBrand(selectedBrand));
        }

        async void SearchByBodyType(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CompareSearchResultByBodyType(selectedBodyType));
        }

        //individual tab
        async void SearchByKeywordIndiv(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IndividualSearchResultbyKeyword(findKeywordIndiv.Text));
        }

        async void SearchByBrandIndiv(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IndividualSearchResultbyBrand(selectedBrand));
        }

        async void SearchByBodyTypeIndiv(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IndividualSearchResultbyBodyType(selectedBodyType));
        }
    }
}