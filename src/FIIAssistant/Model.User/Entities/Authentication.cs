using System.ComponentModel.DataAnnotations;
using Commons;

namespace Model.User.Entities {
    public class Authentication : Entity {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}