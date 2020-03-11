using FChat.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FChat.DataService.Interfaces
{
    public interface IUserService
    {
        void AddUser(UserEntity user);
        bool CheckUser(string name);
        IEnumerable<UserEntity> GetAll();

        UserEntity GetByName(string name);
        UserEntity GetById(int id);
    }
}
