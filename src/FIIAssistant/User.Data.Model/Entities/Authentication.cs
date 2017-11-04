using System.ComponentModel.DataAnnotations;
using User.Data.Model.Common;

namespace User.Data.Model.Entities {
    public class Authentication : Entity {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}