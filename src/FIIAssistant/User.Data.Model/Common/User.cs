using System.ComponentModel.DataAnnotations;

namespace User.Data.Model.Common
{
    public abstract class User : Entity
    {
        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}