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
            _database.CreateTableAsync<Proiect_Vet_App.Models.Element>().Wait();
            _database.CreateTableAsync<Cabinet>().Wait();
        }

        public Task<List<Cabinet>> GetCabinetsAsync()
        {
            return _database.Table<Cabinet>().ToListAsync();
        }
        public Task<int> SaveCabinetAsync(Cabinet cabinet)
        {
            if (cabinet.ID != 0)
            {
                return _database.UpdateAsync(cabinet);
            }
            else
            {
                return _database.InsertAsync(cabinet);
            }
        }
        public Task<int> DeleteCabinetAsync(Cabinet cabinet)
        {
            return _database.DeleteAsync(cabinet);
        }

        public async Task<List<Proiect_Vet_App.Models.Element>> GetElementsAsync(int animalId)
        {
            return await _database.Table<Proiect_Vet_App.Models.Element>().Where(x => x.AnimalID == animalId).ToListAsync();
        }


        public Task<Proiect_Vet_App.Models.Element> GetElementAsync(int id)
        {
            return _database.Table<Proiect_Vet_App.Models.Element>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveElementAsync(Proiect_Vet_App.Models.Element element)
        {
            if (element.ID != 0)
            {
                return _database.UpdateAsync(element);
            }
            else
            {
                return _database.InsertAsync(element);
            }
        }

        public Task<int> DeleteElementAsync(Proiect_Vet_App.Models.Element element)
        {
            return _database.DeleteAsync(element);
        }

        public Task<List<Animal>> GetAnimalsAsync()
        {
            return _database.Table<Animal>().ToListAsync();
        }

        public Task<Animal> GetAnimalAsync(int id)
        {
            return _database.Table<Animal>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAnimalAsync(Animal sanimal)
        {

            if (sanimal.ID != 0)
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
