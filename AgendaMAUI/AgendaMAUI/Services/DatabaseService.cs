using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using AgendaMAUI.Models;

namespace AgendaMAUI.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AgendaMAUI.Models.Contact>().Wait(); // Crea la tabla si no existe
        }

        public Task<List<AgendaMAUI.Models.Contact>> GetContactsAsync()
        {
            return _database.Table<AgendaMAUI.Models.Contact>().ToListAsync();
        }

        public Task<int> SaveContactAsync(AgendaMAUI.Models.Contact contact)
        {
            if (contact.Id != 0)
                return _database.UpdateAsync(contact); // Actualizar
            else
                return _database.InsertAsync(contact); // Crear
        }

        public Task<int> DeleteContactAsync(AgendaMAUI.Models.Contact contact)
        {
            return _database.DeleteAsync(contact); // Eliminar
        }

        public Task<List<AgendaMAUI.Models.Contact>> SearchContactsAsync(string query)
        {
            return _database.Table<AgendaMAUI.Models.Contact>()
                            .Where(c => c.Name.Contains(query) || c.Phone.Contains(query))
                            .ToListAsync(); // Buscar
        }
    }
}
