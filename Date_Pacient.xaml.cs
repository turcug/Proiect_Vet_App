using Proiect_Vet_App.Models;
using System;
using System.Collections.Generic;

namespace Proiect_Vet_App
{
    public partial class Date_Pacient : ContentPage
    {
        public Date_Pacient() { 
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var sanimal = (Animal)BindingContext;
            sanimal.Nume = Nume_Pacient.Text;
            sanimal.Specie = Specie_Pacient.Text;
            sanimal.DataNasterii = DataNasteriiPicker.Date;
            await App.Database.SaveAnimalAsync(sanimal);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var sanimal = (Animal)BindingContext;
            await App.Database.DeleteAnimalAsync(sanimal);
            await Navigation.PopAsync();
        }
        async void OnGoToAdaugareElementClicked(object sender, EventArgs e)
        {
            var sanimal = (Animal)BindingContext;
            await Navigation.PushAsync(new Adaugare_Element(sanimal));
        }
    }
}
/*
 private Animal currentAnimal;
        private DateTime? _selectedDataNasterii;

        public DateTime SelectedDataNasterii
        {
            get
            {
                return _selectedDataNasterii ?? currentAnimal?.DataNasterii ?? DateTime.Now;
            }
            set
            {
                _selectedDataNasterii = value;
                if (currentAnimal != null)
                {
                    currentAnimal.DataNasterii = value;
                }
                else
                {
                    DataNasteriiPicker.Date = _selectedDataNasterii ?? DateTime.Now;
                }
            }
        }

        public Date_Pacient()
        {
            InitializeComponent();

            currentAnimal = new Animal();
            BindingContext = currentAnimal;
            DataNasteriiPicker.SetBinding(DatePicker.DateProperty, new Binding(nameof(SelectedDataNasterii), BindingMode.TwoWay));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Load the animal from the database
            var savedAnimal = await App.Database.GetAnimalAsync(currentAnimal.ID);

            if (savedAnimal != null)
            {
                currentAnimal = savedAnimal;

                // Set BindingContext and SelectedDataNasterii after loading from the database
                BindingContext = currentAnimal;
                SelectedDataNasterii = currentAnimal.DataNasterii;
            }
        }


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var sanimal = (Animal)BindingContext;
            sanimal.Nume = Nume_Pacient.Text;
            sanimal.Specie = Specie_Pacient.Text;
            sanimal.DataNasterii = SelectedDataNasterii;

            // Save the selected date for next time
            _selectedDataNasterii = sanimal.DataNasterii;

            await App.Database.SaveAnimalAsync(sanimal);

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var sanimal = (Animal)BindingContext;
            await App.Database.DeleteAnimalAsync(sanimal);
            await Navigation.PopAsync();
        }

        async void OnGoToAdaugareElementClicked(object sender, EventArgs e)
        {
            var sanimal = (Animal)BindingContext;
            await Navigation.PushAsync(new Adaugare_Element(sanimal));
        }
 */