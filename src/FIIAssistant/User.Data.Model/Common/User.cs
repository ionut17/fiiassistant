using System.ComponentModel.DataAnnotations;
using User.Data.Model.Common;

namespace User.Data.Model
{
    public abstract class User : Entity
    {
        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}