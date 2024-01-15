using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Vet_App.Models
{
    public class Cabinet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nume_Cabinet { get; set; }
        public string Adresa_Cabinet {  get; set; }
        public TimeSpan Deschidere_Cabinet { get; set; }
        public TimeSpan Inchidere_Cabinet { get; set; }
        public string Detalii_Cabinet {
            get
            {
                return Nume_Cabinet + " " + Adresa_Cabinet + "Deschidere Cabinet " + Deschidere_Cabinet + " Inchidere cabinet: " + Inchidere_Cabinet;

            }
        }
        [OneToMany]
        public List<Animal> Animals { get; set; }
    }
}
