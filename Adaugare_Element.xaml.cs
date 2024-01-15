using System;
using Proiect_Vet_App.Models;

namespace Proiect_Vet_App
{
    public partial class Adaugare_Element : ContentPage
    {
        private Animal SavedAnimal;


        public Adaugare_Element(Animal savedAnimal)
        {
            InitializeComponent();
            SavedAnimal = savedAnimal;
            BindingContext = new Proiect_Vet_App.Models.Element();
            Enable_Data_Repetare.IsToggled = false;
            Data_Repetare_Picker.IsEnabled = false;
        }
        private void OnEnableSecondDateToggled(object sender, ToggledEventArgs e)
        {
            Data_Repetare_Picker.IsEnabled = e.Value; 
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var elem = (Proiect_Vet_App.Models.Element)BindingContext;
            elem.AnimalID = SavedAnimal.ID;
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
