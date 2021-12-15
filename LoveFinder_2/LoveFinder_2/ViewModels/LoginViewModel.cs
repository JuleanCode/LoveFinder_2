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
    public class LoginViewModel : BindableObject
    {
        public LoginViewModel()
        {
            Login = new Command(OnLogin);
            Register = new Command(OnRegister);
        }

        public ICommand Login { get; }
        public ICommand Register { get; }

        string email = "";
        public string Email
        {
            get => email;
            set
            {
                if (value == email)
                    return;

                email = value;
                OnPropertyChanged();
            }
        }

        string password = "";
        public string Password
        {
            get => password;
            set
            {
                if (value == password)
                    return;

                password = value;
                OnPropertyChanged();
            }
        }

        void OnLogin()
        {
            //UserService.DeleteAllUsers();
            //UserService.GetAllUser();
            if(email != "" && password != "")
            {
                if(UserService.CheckUser(email, password))
                {
                    Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Login credentials are incorrect ", "Ok");
                }

            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Alert", "All fields must be filled!!!", "Ok");
            }
        }

        void OnRegister()
        {
            Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
