using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Yondr_Finance.Models;
using System.Threading.Tasks;


namespace Yondr_Finance.Data
{
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public UserDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserModel>().Wait();
        }

        public Task<List<UserModel>> GetNotesAsync()
        {
            return _database.Table<UserModel>().ToListAsync();
        }

        public Task<UserModel> GetNoteAsync(int id)
        {
            return _database.Table<UserModel>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<UserModel> GetUserAsync(string uniqueid)
        {
            return _database.Table<UserModel>()
                            .Where(i => i.UniqueID == uniqueid)
                            .FirstAsync();
        }

        public string SaveNoteAsync(UserModel user,string uid)
        {
           
            if (uid != "")
            {
                 _database.UpdateAsync(user);
                return user.UniqueID;
            }
            else
            {
                 _database.InsertAsync(user);               
                  return user.UniqueID;
            }
        }

        public Task<int> DeleteNoteAsync(UserModel user)
        {
            return _database.DeleteAsync(user);
        }


    }
}