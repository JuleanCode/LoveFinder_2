using LoveFinder.Models;
using LoveFinder_2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoveFinder_2.ViewModels
{
    public class ProfileEditViewModel : BindableObject
    {
        //Get user from the DB and fill this object
        public User user = new User()
        {
            FirstName = "Julean",
            Biography = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras vel leo nec turpis consectetur commodo ac at risus."
        };

        public ProfileEditViewModel()
        {
            Save = new Command(OnSave);
            Logout = new Command(OnLogout);
            DeleteProfile = new Command(OnDeleteProfile);
        }

        public ICommand Save { get; }
        public ICommand Logout { get; }
        public ICommand DeleteProfile { get; }

        public string FirstName
        {
            get => user.FirstName;
            set
            {
                if (value == user.FirstName)
                    return;

                user.FirstName = value;
                OnPropertyChanged();
            }
        }
        public string Biography
        {
            get => user.Biography;
            set
            {
                if (value == user.Biography)
                    return;

                user.Biography = value;
                OnPropertyChanged();
            }
        }

        void OnSave()
        {
            //Update the user in the DB
            Application.Current.MainPage.DisplayAlert("Alert", "Save!", "Ok");
        }
        void OnLogout()
        {
            //End session and go to login screen
            Application.Current.MainPage.DisplayAlert("Alert", "Logout", "Ok");
        }
        void OnDeleteProfile()
        {
            //Delete profile and go to login screen
            Application.Current.MainPage.DisplayAlert("Alert", "Delete profile", "Ok");
        }
    }
}
