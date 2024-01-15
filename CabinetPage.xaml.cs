using Proiect_Vet_App.Models;

namespace Proiect_Vet_App;

public partial class CabinetPage : ContentPage
{
	public CabinetPage()
	{
		InitializeComponent();
	}

	async void OnSaveButton(object sender, EventArgs e)
	{
		var cabinet = (Cabinet)BindingContext;
		cabinet.Nume_Cabinet = NumeCabinet.Text;
		cabinet.Adresa_Cabinet = AdresaCabinet.Text;
		cabinet.Deschidere_Cabinet = OraDeschiderePicker.Time;
		cabinet.Inchidere_Cabinet = OraInchiderePicker.Time;
		await App.Database.SaveCabinetAsync(cabinet);
		await Navigation.PopAsync();
	}
    async void OnDeleteButton(object sender, EventArgs e)
    {
        var cabinet = (Cabinet)BindingContext;
        await App.Database.DeleteCabinetAsync(cabinet);
        await Navigation.PopAsync();
    }
    async void OnAfiseazaHarta(object sender, EventArgs e)
	{
		var cabinet = (Cabinet)BindingContext;
		var adresa = cabinet.Adresa_Cabinet;
		var locatii = await Geocoding.GetLocationsAsync(adresa);
		var optiuni = new MapLaunchOptions
		{
			Name = "Cabinet Veterinar"
		};
		var locatie = locatii?.FirstOrDefault();
		var locatia_mea = await Geolocation.GetLocationAsync();
		await Map.OpenAsync(locatie, optiuni);
	}
}