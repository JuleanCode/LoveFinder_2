using LoveFinder.Models;
using LoveFinder_2.Services;
using LoveFinder_2.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
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

            GetChuckNorrisJoke();
        }

        public ICommand Login { get; }
        public ICommand Register { get; }

        public string quote = "";
        public string Quote
        {
            get => quote;
            set
            {
                if (value == quote)
                    return;

                quote = value;
                OnPropertyChanged();
            }
        }

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
            HelperService.FreshInstall();
            var users = UserService.GetAllUser();

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

        void GetChuckNorrisJoke()
        {
            WebRequest request = HttpWebRequest.Create("https://api.chucknorris.io/jokes/random");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string Joke_JSON = reader.ReadToEnd();

            Joke joke = Newtonsoft.Json.JsonConvert.DeserializeObject<Joke>(Joke_JSON);

            quote = joke.value;
        }
    }

    public class Joke
    {
        public List<object> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }
}
