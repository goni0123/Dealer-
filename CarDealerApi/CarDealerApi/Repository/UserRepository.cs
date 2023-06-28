using CarDealerApi.Data;
using CarDealerApi.Interface;
using CarDealerApi.Models;

namespace CarDealerApi.Repository
{
    public class UserRepository:UserInterface
    {
        private readonly AppDBContext _context;
        public UserRepository(AppDBContext context)=> _context = context;
        public bool CreateUser(User user)
        {
            _context.Add(user); 
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public User GetUserByName(string user)
        {
            return _context.users.Where(u=>u.Username== user).FirstOrDefault()?? null;
        }
        public User GetUserById(int id)
        {
            return _context.users.Where(u => u.Id == id).FirstOrDefault() ?? null;
        }

        public ICollection<User> GetUsers()
        {
            return _context.users.OrderBy(u=>u.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool UserExitsByUser(string username)
        {
            return _context.users.Any(u=>u.Username == username);
        }

        public bool UserExitsById(int id)
        {
            return _context.users.Any(u => u.Id == id);
        }
    }
}
