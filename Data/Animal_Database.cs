using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Proiect_Vet_App.Models;

namespace Proiect_Vet_App.Data
{
    public class Animal_Database
    {
        readonly SQLiteAsyncConnection _database;
        public Animal_Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Animal>().Wait();
        }

        public Task <List<Animal>> GetAnimalsAsync()
        {
            return _database.Table<Animal>().ToListAsync();
        }
        public Task <Animal> GetAnimalAsync(int id)
        {
            return _database.Table<Animal>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAnimalAsync(Animal sanimal) 
        {
            if(sanimal.ID != 0)
            {
                return _database.UpdateAsync(sanimal);
            }
            else
            {
                return _database.InsertAsync(sanimal);
            }
        }
        public Task<int> DeleteAnimalAsync(Animal sanimal)
        {
            return _database.DeleteAsync(sanimal);
        }
    }
}
