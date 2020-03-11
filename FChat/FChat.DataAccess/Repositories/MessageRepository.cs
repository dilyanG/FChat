using FChat.DataAccess.Interfaces;
using FChat.DataModel.Entities;
using FChat.DataModel.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FChat.DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public MessageRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(MessageEntity entity)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    entity.CreatedOn = DateTime.Now;
                    entity.ModifiedOn = DateTime.Now;
                    if (entity.User != null)
                        entity.User = Context.Users.Where(u => u.Id == entity.User.Id).Single();
                    Context.Messages.Add(entity);
                    Context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public MessageEntity Get(int id)
        {
            return Context.Messages.Include(m => m.User).Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<MessageEntity> GetAll()
        {
            return Context.Messages.Include(m=>m.User).OrderBy(c => c.CreatedOn);
        }

        public IEnumerable<MessageEntity> GetAll(GroupType type)
        {
            return Context.Messages.Where(m => m.GroupTypeId == type).Include(m => m.User).OrderBy(c => c.CreatedOn);
        }
        public IEnumerable<MessageEntity> GetAll(GroupType type, DateTime after)
        {
            return Context.Messages.Where(m => m.GroupTypeId == type && m.CreatedOn>after.AddSeconds(1)).Include(m => m.User).OrderBy(c => c.CreatedOn);
        }

        public void Remove(MessageEntity entity)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.Messages.Remove(entity);
                    Context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Update(MessageEntity entity)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    MessageEntity forUpdate = Get(entity.Id);
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
