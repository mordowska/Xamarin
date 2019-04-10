using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Water.Models;
using Water.Views;
using Water.ViewModels;

namespace Water.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        UsersViewModel viewModel;

        public UsersPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new UsersViewModel();
        }

        async void OnUserSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var user = args.SelectedItem as User;
            if (user == null)
                return;

            await Navigation.PushAsync(new UserDetailPage(new UserDetailViewModel(user)));

            // Manually deselect item.
            UsersListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewUserPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (viewModel.Items.Count == 0)
            viewModel.LoadUsersCommand.Execute(null);
        }
    }
}