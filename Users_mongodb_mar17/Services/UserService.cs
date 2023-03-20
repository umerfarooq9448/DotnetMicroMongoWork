using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Users_mongodb_mar17.Models;

namespace Users_mongodb_mar17.Services
{
    public class UserService
    {
        private readonly IMongoCollection<Users> _userCollection;

        public UserService(IOptions<UserStoreSettings> userStoreSettings)
        {
            var mongoClient = new MongoClient(userStoreSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(userStoreSettings.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<Users>(userStoreSettings.Value.UserDatabaseCollectionName);

        }


        public async Task<List<Users>> getAllUsers()
        {

            var result= await _userCollection.Find(_ => true).ToListAsync();
            return result;
        }


        public async Task<Users> getUserByID(string id)
        {

            return await _userCollection.Find(x=>x.id==id).FirstOrDefaultAsync();
        }

        public async Task addUser(Users user)
        {
           await _userCollection.InsertOneAsync(user);

        }
            

        public async Task updateUser(string id, Users user)
        {
            await _userCollection.ReplaceOneAsync(x => x.id == id, user);
        }
            

        public async Task deleteUser(string id)
        {
            await _userCollection.DeleteOneAsync(x => x.id == id);
        }


        public async Task<string> loginUser(Users user)
        {
           var current_user = await _userCollection.Find(x=>x.UserName==user.UserName && x.UserPassword==user.UserPassword).FirstOrDefaultAsync();
            
            if(current_user==null)
            {
                return "Login failed";
            }
            return "Login Success";
        }
            





    }
}
