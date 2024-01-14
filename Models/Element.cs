using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Vet_App.Models
{
    public class Element
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(30)]
        public string Tip_Element { get; set; }
        public DateTime Data_Realizare { get; set; }
        public DateTime Data_Repetare { get; set; }
        [MaxLength(150)]
        public string Observatii { get; set; }

    }
}
