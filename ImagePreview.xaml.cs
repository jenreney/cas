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
    public partial class ImagePreview : ContentPage
    {

        public ImagePreview(string id, string imagefront, string imageback, string imageside)
        {
            InitializeComponent();

            List<Image> images = new List<Image>()
            {
                new Image(){Title= "Image 1", URL=imagefront},
                new Image(){Title= "Image 2", URL=imageback},
                new Image(){Title= "Image 3", URL=imageside}
            };

            Carousel.ItemsSource = images;
        }

        
    }
}