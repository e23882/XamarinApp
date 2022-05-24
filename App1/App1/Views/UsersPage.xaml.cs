using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        #region Declarations
        UsersViewModel _viewModel;
        #endregion

        #region Memberfunction
        public UsersPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new UsersViewModel();
        }
        #endregion
    }
}