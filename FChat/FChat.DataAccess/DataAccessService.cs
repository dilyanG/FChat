using FChat.DataAccess.Interfaces;
using FChat.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FChat.DataAccess
{
    public class DataAccessService: IDataAccessService
    {
        public DataAccessService()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=FChat.Database;Trusted_Connection=True;");
            DataContext context = new DataContext(optionsBuilder.Options);
            UserRepository = new UserRepository(context);
            MessageRepository = new MessageRepository(context);
        }

        public DataAccessService(DataContext context)
        {
            UserRepository = new UserRepository(context);
            MessageRepository = new MessageRepository(context);
        }

        public IUserRepository UserRepository { get; set; }
        public IMessageRepository MessageRepository { get; set; }
    }
}
