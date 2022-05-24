using App1.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
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
                var dbData = ReadDBData();
                foreach (var item in dbData)
                {
                    Items.Add(new Item
                    {
                        ID = item.ID.ToString(),
                        Text = item.Text,
                        Description = item.Description
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

        public List<Item> ReadDBData() 
        {
            List<Item> result = new List<Item>();
            try
            {
                string ConnectionString = @"Server=1.1.1.1;Database=TestDB;User Id=leo666;Password=leo666;";
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var sql = "SELECT ID, TEXT, DESCRIPTION FROM SAMPLE";
                    result = conn.Query<Item>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                //log here
            }
            return result;
        }
        #endregion
    }
}