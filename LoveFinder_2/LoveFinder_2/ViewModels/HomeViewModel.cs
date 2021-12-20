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
        public ProfileImage profileImage = new ProfileImage();
        public int DisplayUserPosition;

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

        public ProfileImage ProfileImage
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
                    DisplayUser = Users[DisplayUserPosition];
                    List<ProfileImage> profileImages = ProfileImageService.GetUserProfileImages(DisplayUser.ID);
                    ProfileImage = profileImages[0];
                    DisplayUserPosition++;
                }
                catch
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Something went wrong", "OK");
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

            Application.Current.MainPage.DisplayAlert("Alert", "Liked", "OK");
        }
        void OnDisLike()
        {
            SwipeService.Swipe(Int32.Parse(Application.Current.Properties["CurentUser_id"].ToString()), DisplayUser.ID, false);

            Application.Current.MainPage.DisplayAlert("Alert", "Disliked", "OK");
        }
    }
}
