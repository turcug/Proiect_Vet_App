using System;
using Proiect_Vet_App.Models;

namespace Proiect_Vet_App
{
    public partial class Editare_Element : ContentPage
    {
        private Animal SavedAnimal;
        private Proiect_Vet_App.Models.Element element;

        public Editare_Element(Proiect_Vet_App.Models.Element selectedElement)
        {
            InitializeComponent();
            element = selectedElement;
            BindingContext = element;
            Enable_Data_Repetare.IsToggled = false;
            Data_Repetare_Picker.IsEnabled = false;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var el = (Proiect_Vet_App.Models.Element)BindingContext;

        }
        private void OnEnableSecondDateToggled(object sender, ToggledEventArgs e)
        {
            Data_Repetare_Picker.IsEnabled = e.Value;
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var elem = (Proiect_Vet_App.Models.Element)BindingContext;
            elem.Tip_Element = Tip_Element.Text;
            elem.Observatii = Element_Observatii.Text;
            elem.Data_Realizare = Data_Realizare_Picker.Date;
            if (Enable_Data_Repetare.IsToggled)
            {
                elem.Data_Repetare = Data_Repetare_Picker.Date;
            }
            else
            {
                elem.Data_Repetare = Data_Realizare_Picker.Date;
            }
            await App.Database.SaveElementAsync(elem);
            await Navigation.PopAsync();
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var elementToDelete = (Proiect_Vet_App.Models.Element)BindingContext;

            if (elementToDelete.ID != 0)
            {
                await App.Database.DeleteElementAsync(elementToDelete);
            }
            await Navigation.PopAsync();
        }
    }
}
