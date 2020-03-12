using FChat.DataAccess.Interfaces;
using FChat.DataModel.Entities;
using FChat.DataService.Interfaces;
using FChat.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FChat.DataService.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }

        public void AddUser(UserEntity user)
        {
            if (user == null) throw new ArgumentNullException();
            this.DataAccessService.UserRepository.Add(user);
            
        }

        public bool CheckUser(string name)
        {
            if (String.IsNullOrEmpty(name)) return false;
            return this.DataAccessService.UserRepository.CheckUser(name);
        }

        public IEnumerable<UserEntity> GetAll() 
        {
            return this.DataAccessService.UserRepository.GetAll();
        }

        public UserEntity GetByName(string name) 
        {
            if (String.IsNullOrEmpty(name)) return null;
            return this.DataAccessService.UserRepository.GetByName(name);
        }
        public UserEntity GetById(int id)
        {
            return this.DataAccessService.UserRepository.GetById(id);
        }
    }
}
