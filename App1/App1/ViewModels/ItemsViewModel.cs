using App1.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        #region Declarations
        private Item _SelectedItem;
        private string _ID;
        private string _Text;
        private string _Description;
        private Item _selectedItem;
        #endregion

        #region Property

        public ObservableCollection<Item> Items { get; }
        public Command ReadSQLCommand { get; }
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                OnPropertyChanged();
            }
        }
        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
                OnPropertyChanged();
            }
        }
        public Item SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                ID = value.ID;
                Text = value.Text;
                Description = value.Description;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Memberfunction

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            ReadSQLCommand = new Command(async () => await ExecuteReadSQLCommand());
        }

        async Task ExecuteReadSQLCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                for (int i = 0; i < 10; i++)
                {
                    Items.Add(new Item
                    {
                        ID = i.ToString(),
                        Text = $"Data{i}",
                        Description = $"Its data {i}"
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}