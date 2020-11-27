using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    public class Membre
    {
        private int _id;
        private string _username;
        private string _email;
        private bool _enabled;
        private string _password;
        private DateTime _lastLogin;
        private string _pseudo;
        private DateTime _entryDate;

        public Membre(int id, string username, string email, bool enabled, string password, DateTime lastLogin, string pseudo, DateTime entryDate)
        {
            Id = id;
            Username = username;
            Email = email;
            Enabled = enabled;
            Password = password;
            LastLogin = lastLogin;
            Pseudo = pseudo;
            EntryDate = entryDate;
        }

        public int Id { get => _id; set => _id = value; }
        public string Username { get => _username; set => _username = value; }
        public string Email { get => _email; set => _email = value; }
        public bool Enabled { get => _enabled; set => _enabled = value; }
        public string Password { get => _password; set => _password = value; }
        public DateTime LastLogin { get => _lastLogin; set => _lastLogin = value; }
        public string Pseudo { get => _pseudo; set => _pseudo = value; }
        public DateTime EntryDate { get => _entryDate; set => _entryDate = value; }

    }
}
