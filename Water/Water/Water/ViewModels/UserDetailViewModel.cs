using System;

using Water.Models;

namespace Water.ViewModels
{
    public class UserDetailViewModel : BaseViewModel
    {
        public User User { get; set; }
        public UserDetailViewModel(User user = null)
        {
            Title = user.Name + " water to drink: " + user.WaterBalance;
            User = user;
        }
    }
}
