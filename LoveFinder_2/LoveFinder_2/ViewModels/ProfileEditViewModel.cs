using LoveFinder.Models;
using LoveFinder_2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;
using LoveFinder_2.Services;

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
            ChangeProfileImage = new Command(OnChangeProfileImage);
        }

        public ICommand Save { get; }
        public ICommand Logout { get; }
        public ICommand DeleteProfile { get; }
        public ICommand ChangeProfileImage { get; }

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

            UserService.UpdateUser(user);
            Application.Current.MainPage.Navigation.PushAsync(new HomePage());
        }
        void OnLogout()
        {
            //End session and go to login screen
            Application.Current.Properties["CurentUser_id"] = null;

            Application.Current.MainPage.DisplayAlert("Alert", "Logout", "Ok");
            Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
        void OnDeleteProfile()
        {
            //Delete profile and go to login screen

            UserService.DeleteUser(Int32.Parse(Application.Current.Properties["CurentUser_id"].ToString()));

            Application.Current.MainPage.DisplayAlert("Alert", "Deleted profile", "Ok");
            Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        async void OnChangeProfileImage()
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick your new profile photo"
            });

            ProfileImageService.UpdateUserProfileImages(result.FullPath);

            await Application.Current.MainPage.DisplayAlert("Alert", "Profile image updated", "Ok");
        }
    }
}
