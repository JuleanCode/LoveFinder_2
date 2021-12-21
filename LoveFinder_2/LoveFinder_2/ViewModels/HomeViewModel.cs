using LoveFinder.Models;
using LoveFinder_2.Services;
using LoveFinder_2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace LoveFinder_2.ViewModels
{
    public class HomeViewModel : BindableObject
    {
        //Get all users from the DB
        public List<User> Users = UserService.GetAllUser();
        public User DisplayUser = new User();
        public string profileImage;
        public int DisplayUserPosition = 0;

        public HomeViewModel()
        {
            Profile = new Command(OnProfile);
            Like = new Command(OnLike);
            Dislike = new Command(OnDisLike);
            SetDisplayUser();
        }

        public ICommand Profile { get; }
        public ICommand Like { get; }
        public ICommand Dislike { get; }

        public string ProfileImage
        {
            get => profileImage;
            set
            {
                if (value == profileImage)
                    return;

                profileImage = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => DisplayUser.FirstName;
            set
            {
                if (value == DisplayUser.FirstName)
                    return;

                DisplayUser.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string Biography
        {
            get => DisplayUser.Biography;
            set
            {
                if (value == DisplayUser.Biography)
                    return;

                DisplayUser.Biography = value;
                OnPropertyChanged();
            }
        }

        void SetDisplayUser()
        {
            if(DisplayUserPosition <= Users.Count)
            {
                try
                {
                    FirstName = Users[DisplayUserPosition].FirstName;
                    Biography = Users[DisplayUserPosition].Biography;
                    DisplayUser = Users[DisplayUserPosition];
                    List<ProfileImage> profileImages = ProfileImageService.GetUserProfileImages(Users[DisplayUserPosition].ID);
                    ProfileImage = profileImages[0].ImageUrl;
                    DisplayUserPosition++;
                }
                catch
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "No matches left", "OK");
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Alert", "No matches left", "OK");
            }
        }
        void OnProfile()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ProfileEditPage());
        }
        void OnLike()
        {
            SwipeService.Swipe(Int32.Parse(Application.Current.Properties["CurentUser_id"].ToString()), DisplayUser.ID, true);

            SetDisplayUser();
            Application.Current.MainPage.DisplayAlert("Alert", "Liked", "OK");
        }
        void OnDisLike()
        {
            SwipeService.Swipe(Int32.Parse(Application.Current.Properties["CurentUser_id"].ToString()), DisplayUser.ID, false);

            SetDisplayUser();
            Application.Current.MainPage.DisplayAlert("Alert", "Disliked", "OK");
        }
    }
}
