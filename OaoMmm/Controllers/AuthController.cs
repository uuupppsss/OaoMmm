using OaoMmm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OaoMmm.Controllers
{
    public class AuthController
    {
        public List<User> Users { get; set; }

        public User SignIn(string email, string password)
        {
            User found_user = Users.FirstOrDefault(u => u.Email == email);
            if (found_user != null && found_user.Password == password) return found_user;
            else return null;
        }

        public void SignUp(User user)
        {
            Users.Add(user);
        }

        public void DeleteUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user != null) Users.Remove(user);
        }
    }
}
