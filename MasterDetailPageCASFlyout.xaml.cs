using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CAS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageCASFlyout : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageCASFlyout()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageCASFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MasterDetailPageCASFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageCASFlyoutMenuItem> MenuItems { get; set; }

            public MasterDetailPageCASFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageCASFlyoutMenuItem>(new[]
                {
                    new MasterDetailPageCASFlyoutMenuItem { Id = 0, Title = "Home", TargetType=typeof(MainPage) },
                    new MasterDetailPageCASFlyoutMenuItem { Id = 1, Title = "Search Cars", TargetType=typeof(TabbedSearchType) },
                    new MasterDetailPageCASFlyoutMenuItem { Id = 2, Title = "About", TargetType=typeof(About) },

                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}