using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Water.Models;
using Water.ViewModels;

namespace Water.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailPage : ContentPage
    {
        UserDetailViewModel viewModel;

        public UserDetailPage(UserDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

       
    }
}