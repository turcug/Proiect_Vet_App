using System;
using Proiect_Vet_App.Data;
using System.IO;

namespace Proiect_Vet_App
{
    public partial class App : Application
    {
        static Animal_Database database;
        public static Animal_Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                        Animal_Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "Animal.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
