using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        #region Declarations
        ItemsViewModel _viewModel;
        #endregion

        #region Memberfunction
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            //base.OnAppearing();
            //_viewModel.OnAppearing();
        }
        #endregion

    }
}