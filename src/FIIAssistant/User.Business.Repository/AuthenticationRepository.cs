﻿using System;
using EnsureThat;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using User.Data.Access;
using User.Data.Model.Entities;
using User.Data.Model.Interfaces.Repositories;

namespace User.Business.Repository
{
    public class AuthenticationRepository : BaseRepository<Authentication>, IAuthenticationRepository
    {
        private readonly IStudentContext _context;

        public AuthenticationRepository(StudentContext context) : base(context)
        {
            Ensure.That(context).IsNotNull();

            _context = context;
        }

    }
}