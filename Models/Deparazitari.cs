using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Vet_App.Models
{
    public class Deparazitari
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(40)]
        public string Detalii { get; set; }
        public DateTime Data_Realizare { get; set; }
        public DateTime Data_Expirare { get; set; }
        public string Type { get; set; }
        [ForeignKey(typeof(Animal))]
        public int AnimalID { get; set; }
    }
}
