using Proiect_Vet_App.Models;

namespace Proiect_Vet_App;

public partial class Date_Pacient : ContentPage
{
	public Date_Pacient()
	{
		InitializeComponent();
	}
	async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		var sanimal = (Animal)BindingContext;
		sanimal.Data_Nastere = DateTime.UtcNow;
		await App.Database.SaveAnimalAsync(sanimal);
		await Navigation.PopAsync();
	}
	async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		var sanimal = (Animal)BindingContext;
		await App.Database.DeleteAnimalAsync(sanimal);
		await Navigation.PopAsync();
	}
}