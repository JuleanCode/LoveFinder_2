using LoveFinder.Models;
using LoveFinder_2.Services;
using LoveFinder_2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LoveFinder_2.ViewModels
{
    public class RegisterViewModel : BindableObject
    {
        public User user = new User();

        public RegisterViewModel()
        {
            Register = new Command(OnRegister);
            Back = new Command(OnBack);
        }

        public ICommand Register { get; }
        public ICommand Back { get; }

        //Lists that are used by the pickers
        static List<string> genders;
        public List<string> Genders
        {
            get
            {
                if (genders == null)
                {
                    genders = new List<string>
                    {
                        "Male",
                        "Female"
                    };
                }

                return genders;
            }
        }

        static List<string> sexualOrientations;
        public List<string> SexualOrientations
        {
            get
            {
                if (sexualOrientations == null)
                {
                    sexualOrientations = new List<string>
                    {
                        "Hetero",
                        "Gay",
                        "Bi"
                    };
                }

                return sexualOrientations;
            }
        }

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
        public string LastName
        {
            get => user.LastName;
            set
            {
                if (value == user.LastName)
                    return;

                user.LastName = value;
                OnPropertyChanged();
            }
        }
        public int Age
        {
            get => user.Age;
            set
            {
                if (value == user.Age)
                    return;

                user.Age = value;
                OnPropertyChanged();
            }
        }
        public string Gender
        {
            get => user.Gender;
            set
            {
                if (value == user.Gender)
                    return;

                user.Gender = value;
                OnPropertyChanged();
            }
        }
        public string SexualOrientation
        {
            get => user.SexualOrientation;
            set
            {
                if (value == user.SexualOrientation)
                    return;

                user.SexualOrientation = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => user.Email;
            set
            {
                if (value == user.Email)
                    return;

                user.Email = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => user.Password;
            set
            {
                if (value == user.Password)
                    return;

                user.Password = value;
                OnPropertyChanged();
            }
        }

        string passwordCheck;
        public string PasswordCheck
        {
            get => passwordCheck;
            set
            {
                if (value == passwordCheck)
                    return;

                passwordCheck = value;
                OnPropertyChanged();
            }
        }

        void OnRegister()
        {
            if(user.FirstName != "" && user.LastName != "" && user.Gender != "" && user.SexualOrientation != "" && user.Email != "" && user.Password != "" && user.Password == passwordCheck)
            {
                if(user.Age >= 18)
                {
                    // get the users location
                    user.Location = Geolocation.GetLastKnownLocationAsync().ToString(); ;

                    UserService.CreateUser(user);

                    Application.Current.MainPage.Navigation.PushAsync(new ProfileEditPage());
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Age has to be 18 or above!!!", "OK");
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Alert", "All fields must be filled!!!", "OK");
            }
        }

        void OnBack()
        {
            Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}
