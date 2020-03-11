using FChat.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FChat.DataAccess.Interfaces
{
    public interface IUserRepository : IDisposable, IBaseRepository<UserEntity>
    {
        bool CheckUser(string name);
        UserEntity GetByName(string name);
        UserEntity GetById(int id);
    }
}
