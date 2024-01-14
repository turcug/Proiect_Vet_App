using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Vet_App.Models
{
    public class Animal
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(25), Unique]
        public string Nume { get; set; }

        public string Specie { get; set; }

        public int Varsta { get; set; }
        public DateTime DataNasterii { get; set; }
    }
}
