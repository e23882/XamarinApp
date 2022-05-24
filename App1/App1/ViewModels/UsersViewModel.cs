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
    public class UsersViewModel : BaseViewModel
    {
        #region Declarations
        private User _SelectedItem = new User();
        private string _ID = string.Empty;
        private int _Age ;
        private string _Name = string.Empty;
        #endregion

        #region Property

        public Command ReadSQLCommand { get; set; }
        public ObservableCollection<User> Users { get; }

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

        
        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }
        
        public User SelectedItem 
        {
            get 
            {
                return _SelectedItem;
            }
            set 
            {
                SelectedItem = value;
                ID = value.ID;
                Age = value.Age;
                Name = value.Name;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Memberfunction
        public UsersViewModel()
        {
            Title = "Browse";
            Users = new ObservableCollection<User>();
            ReadSQLCommand = new Command(async () => await ExecuteReadSQLCommand());
        }

        async Task ExecuteReadSQLCommand()
        {
            IsBusy = true;

            try
            {
                Users.Clear();
                var dbData = ReadDBData();
                foreach (var item in dbData)
                {
                    Users.Add(new User
                    {
                        ID = item.ID.ToString(),
                        Name = item.Name,
                        Age = item.Age
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

        public List<User> ReadDBData()
        {
            List<User> result = new List<User>();
            try
            {
                string ConnectionString = @"Server=1.1.1.1;Database=TestDB;User Id=leo666;Password=leo666;";
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var sql = "SELECT [ID], [AGE], [NAME] FROM [dbo].[USER]";
                    List<dynamic> tempResult = conn.Query(sql).ToList();
                    foreach (dynamic item in tempResult)
                    {
                        User newUser = new User();
                        newUser.ID = item.ID;
                        newUser.Age = (int)item.AGE;
                        newUser.Name = item.NAME;
                    }
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