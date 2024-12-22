using OaoMmm.Controllers;
using OaoMmm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OaoMmm.Test
{
    public class AuthTests
    {
        AuthController controller;
        [SetUp]
        public void Setup()
        {
            controller = new AuthController();
            controller.Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "ivan.ivanov@example.com",
                    Password = "securepassword123",
                    RoleId = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    SecondName = "Иванович"
                },
                new User
                {
                    Id = 2,
                    Email = "petr.petrov@example.com",
                    Password = "anotherpassword456",
                    RoleId = 2,
                    FirstName = "Петр",
                    LastName = "Петров",
                    SecondName = "Петрович"
                }
            };

        }

        [Test]
        public void SignInTest()
        {
            var user = controller.SignIn("petr.petrov@example.com", "anotherpassword456");
            var expected_user = controller.Users.FirstOrDefault(u => u.Email == "petr.petrov@example.com");
            Assert.AreEqual(expected_user, user);
        }

        [Test]
        public void SignUpTest()
        {
            var user = new User()
            {
                Id = 3,
                Email = "user3@example.com",
                Password = "user3pass",
                RoleId = 2,
                FirstName = "Петр",
                LastName = "Петров",
                SecondName = "Петрович"
            };

            controller.SignUp(user);
            Assert.IsTrue(controller.Users.Contains(user));
        }

        [Test]
        public void DeleteUserTest()
        {
            var removed_user = controller.Users.FirstOrDefault(u => u.Id == 1);
            controller.DeleteUser(1);
            Assert.IsFalse(controller.Users.Contains(removed_user));
        }
    }
}
