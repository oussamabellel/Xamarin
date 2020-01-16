using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Xamarin.Models
{
    public enum MenuItemType
    {
        Messages,
        Favoris
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
