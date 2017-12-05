﻿using User.Data.Model.Entities;

namespace User.Data.Model.Interfaces.Repositories
{
    public interface IAuthenticationRepository : IBaseRepository<Authentication>
    {
        bool ValidateUserPassword(User user, string password);
    }
}