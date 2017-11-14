using System;
using System.ComponentModel.DataAnnotations;
using User.Data.Model.Common;

namespace User.Data.Model.Entities
{
    public class Authentication : Entity
    {
        public Guid Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public byte[] Salt { get; set; }

        public string Token { get; set; }
    }
}