using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eductional_Management_System
{
    public class Person
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Person() { }
        public int Id { get; set; }
        public Person(string name,string username,string password,int id)
        {
            this.Name = name;
            this.Username = username;
            this.Password = password;
            this.Id = id;
        }

        public bool checkLogin(string username,string password)
        {
            if(username == this.Username && password == this.Password) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
