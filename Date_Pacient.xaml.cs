﻿using Proiect_Vet_App.Models;
using System;
using System.Collections.Generic;

namespace Proiect_Vet_App
{
    public partial class Date_Pacient : ContentPage
    {

        private Proiect_Vet_App.Models.Element selectedElement;
        public Date_Pacient() { 
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var animal = (Animal)BindingContext;
            var elements = await App.Database.GetElementsAsync(animal.ID);
            elements = elements.OrderByDescending(e => e.Data_Realizare).ToList();
            Istoric_Elemente.ItemsSource = elements;
            var cabinete = await App.Database.GetCabinetsAsync();
            Cabinet_Picker.ItemsSource = (System.Collections.IList)cabinete;
            Cabinet_Picker.ItemDisplayBinding = new Binding("Detalii_Cabinet");
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
        async void OnIstoricElementSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null && e.SelectedItem is Proiect_Vet_App.Models.Element selectedElement)
            {
                await Navigation.PushAsync(new Editare_Element(selectedElement));
                ((ListView)sender).SelectedItem = null;
            }
        }



    }
}