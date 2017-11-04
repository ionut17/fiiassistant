using System.ComponentModel.DataAnnotations;
using Commons;

namespace Model.User.Common {
    public abstract class User : Entity {
        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}