using FChat.DataAccess.Interfaces;
using FChat.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FChat.DataAccess.Repositories
{
    public class UserRepository: IUserRepository
    {
        public UserRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(UserEntity entity)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.Users.Add(entity);
                    Context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public bool CheckUser(string name)
        {
            return Context.Users.Where(u => u.Name.Contains(name)).Any();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public UserEntity Get(int id)
        {
            return Context.Users.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return Context.Users.OrderBy(c => c.CreatedOn);
        }

        public UserEntity GetByName(string name)
        {
            return Context.Users.Where(u => u.Name == name).FirstOrDefault();
        }

        public UserEntity GetById(int id)
        {
            return Context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public void Remove(UserEntity entity)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.Users.Remove(entity);
                    Context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Update(UserEntity entity)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    UserEntity forUpdate = Get(entity.Id);
                    forUpdate.Name = entity.Name;
                    forUpdate.ModifiedOn = DateTime.Now;

                    Context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
