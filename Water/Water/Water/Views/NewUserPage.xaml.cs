using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Water.Models;
using Water.ViewModels;

namespace Water.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUserPage : ContentPage
    {
        MainPage RootPage => Application.Current.MainPage as MainPage;
        private UserViewModel viewModel;
        public NewUserPage()
        {
            InitializeComponent();
            viewModel = new UserViewModel();
            

            BindingContext = viewModel;
        }

        //async void Save_Clicked(object sender, EventArgs e)
        //{
        //    MessagingCenter.Send(this, "AddItem", Usr);
        //    await Navigation.PopModalAsync();
        //}

        //async void Cancel_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PopModalAsync();
        //}
    }
}