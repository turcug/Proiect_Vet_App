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
            BindingContext = SavedAnimal;
            EnableSecondDate.IsToggled = false;
            SecondDatePicker.IsEnabled = false;
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime selectedDate = e.NewDate;
            if (EnableSecondDate.IsToggled)
            {
                Console.WriteLine($"Selected Date: {selectedDate}");
            }
            else
            {
                Console.WriteLine("Enable Second Date checkbox is not toggled.");
            }
        }

        private void OnEnableSecondDateToggled(object sender, ToggledEventArgs e)
        {
            SecondDatePicker.IsEnabled = e.Value; 
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Save button clicked");
            string nume = SavedAnimal.Nume;
            string specie = SavedAnimal.Specie;
            int varsta = SavedAnimal.Varsta;
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Delete button clicked");
        }
    }
}
