using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Telegram.Bot.Types;

namespace TelegramAlbionFarmAlert
{
    public class UserManager
    {
        private readonly ObservableCollection<CustomUser> _users;
        private readonly object _lock = new object();

        public UserManager()
        {
            _users = new ObservableCollection<CustomUser>();
            _users.CollectionChanged += _users_CollectionChanged;
        }

        private void _users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            lock (_lock)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    var currentUser = e.NewItems[0] as CustomUser;
                    if (currentUser != null)
                    {
                        Console.WriteLine($"User {currentUser.Username} connected");
                    }
                }
            }
        }

        public CustomUser FindUser(User user)
        {
            return _users.FirstOrDefault(x => x.Id == user.Id);
        }

        public void ConnectUser(User user)
        {
            lock (_lock)
            {
                if (_users.All(x => x.Id != user.Id))
                {
                    _users.Add(new CustomUser(user));
                }
            }
        }
    }
}
