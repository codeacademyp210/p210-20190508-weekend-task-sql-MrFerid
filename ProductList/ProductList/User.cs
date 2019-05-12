using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductList
{
    class User
    {
        public User()
        {

        }
        public User(int id,string Name,string Surname, string Username, string Email, string Password)
        {
            this.ID = id;
            this.Name = Name;
            this.Surname = Surname;
            this.Username = Username;
            this.Email = Email;
            this.password = Password;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
    }
}
