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
    public class TextViewModel : BindableObject
    {
        List<Text> texts = new List<Text>();
        public List<Text> Texts { get { return texts; } }

        public TextViewModel()
        {
            Message = new Command(OnMessage);
        }

        public ICommand Message { get; }

        void OnMessage()
        {
            //TextService.AddText(content, Chat_ID)
        }
    }
}
