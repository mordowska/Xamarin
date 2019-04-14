using System;

using Water.Models;

namespace Water.ViewModels
{
    public class UserDetailViewModel : BaseViewModel
    {
        public User User { get; set; }
        public UserDetailViewModel(User user = null)
        {
            string balance = "";
            string userBalance = user?.WaterBalance;
            char whitespace = ' ';
            float amount = 0;
            if (userBalance.Split(whitespace)[1] == "l")
            {
                amount = float.Parse(userBalance.Split(whitespace)[0]);
            }

            else if (userBalance.Split(whitespace)[1] == "ml")
            {
                 amount = float.Parse(userBalance.Split(whitespace)[0]);
                amount = amount / 1000;
            }


            else if (userBalance.Split(whitespace)[1] == "cup")
            {
                 amount = float.Parse(userBalance.Split(whitespace)[0]);
                amount = amount * 0.25f;
            }

            if (amount < 2) balance = "You should drink more!";
            else if (amount >= 2 && amount <= 3.5) balance = "It's ok :)";
            else balance = "You drink too much";

            Title = user.Name + " drinks: " + user.WaterBalance + " water. " + balance;
            User = user;
        }
    }
}
