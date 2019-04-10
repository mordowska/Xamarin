using System;
using System.Collections.Generic;
using System.Text;

namespace Water.Models
{
    public enum MenuItemType
    {
        Browse,
        Add,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
