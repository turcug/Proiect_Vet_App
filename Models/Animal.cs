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
        [MaxLength(25)]
        public string Nume { get; set; }
        public string Specie { get; set; }
        public string Rasa {  get; set; }
        public DateTime Data_Nastere { get; set; }
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SQLite;
//using SQLiteNetExtensions.Attributes;

//namespace Proiect_Vet_App.Models
//{
//    public class Animal
//    {
//        [PrimaryKey, AutoIncrement]
//        public int ID { get; set; }
//        [MaxLength(25)]
//        public string Nume { get; set; }
//        [OneToMany(CascadeOperations = CascadeOperation.All)]
//        public string Specie { get; set; }
//        public string Rasa { get; set; }
//        public DateTime Data_Nastere { get; set; }
//        public string Culoare { get; set; }
//        public double Greutate { get; set; }
//        public string Interventii { get; set; }

//        public List<Vaccinari> Vaccinari { get; set; }

//        public List<Deparazitari> Deparazitari { get; set; }
//    }
//}
