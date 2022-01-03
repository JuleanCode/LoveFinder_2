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
using System.Collections.ObjectModel;

namespace LoveFinder_2.ViewModels
{
    public class ChatsViewModel : BindableObject
    {
        List<Chat> chats = ChatService.GetChats();
        public List<Chat> Chats { get { return chats; } }

        public ChatsViewModel()
        {
            Chat = new Command(OnChat);
        }

        public ICommand Chat { get; }

        void OnChat()
        {

        }
    }
}
