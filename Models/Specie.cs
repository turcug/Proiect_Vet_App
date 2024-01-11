using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Vet_App.Models
{
    public class Specie
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Nume_Specie { get; set; }
        [ForeignKey(typeof(Animal))]
        public int AnimalID { get; set; }
    }
}
