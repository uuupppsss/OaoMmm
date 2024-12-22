using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OaoMmm.Model
{
    public class User
    {

        public int Id { get; set; } // Идентификатор пользователя
        public string Email { get; set; } // Электронная почта пользователя
        public string Password { get; set; } // Пароль
        public int RoleId { get; set; } // Идентификатор роли пользователя
        public string FirstName { get; set; } // Имя пользователя
        public string LastName { get; set; } // Фамилия пользователя
        public string SecondName { get; set; } // Отчество пользователя
    }
}
