using Proiect_Vet_App.Models;

namespace Proiect_Vet_App;

public partial class Adaugare_Cabinete : ContentPage
{
	public Adaugare_Cabinete()
	{
		InitializeComponent();
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		listView.ItemsSource = await App.Database.GetCabinetsAsync();
	}
	async void OnCabinetAdded(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CabinetPage
			{
			BindingContext = new Cabinet()
		});
	}
	async void OnListViewItem(object sender, SelectedItemChangedEventArgs e)
	{
		if (e.SelectedItem != null)
		{
			await Navigation.PushAsync(new CabinetPage
			{
				BindingContext = e.SelectedItem as Cabinet
			});
		}
	}
}