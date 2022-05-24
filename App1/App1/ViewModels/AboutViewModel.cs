using App1.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Command ClickCommand { get; }
        public AboutViewModel()
        {
            ClickCommand = new Command(OnClickCommand);
        }

        private async void OnClickCommand(object obj)
        {
            string type = (string)obj;
            switch (type) 
            {
                case "A":
                    await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
                    break;
                case "B":
                    await Shell.Current.GoToAsync($"//{nameof(UsersPage)}");
                    break;

            }
        }
    }
}