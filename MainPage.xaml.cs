using Proiect_Vet_App.Models;

namespace Proiect_Vet_App
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetAnimalsAsync();
        }

        async void OnAnimalAddedClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Date_Pacient
            {
                BindingContext = new Animal()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Date_Pacient
                {
                    BindingContext = e.SelectedItem as Animal
                });
            }
        }
    }
}
