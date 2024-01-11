using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Vet_App.Models
{
    public class Vaccinari
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime Data_Realizare { get; set; }
        public DateTime Data_Expirare { get; set; }
        [ForeignKey(typeof(Animal))]
        public int AnimalID { get; set; }
    }
}
