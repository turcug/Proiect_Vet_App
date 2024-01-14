using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Vet_App.Models
{
    internal class Element_Animal
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Animal))]
        public int AnimalID { get; set; }
        public int ElementID { get; set; }
    }
}
