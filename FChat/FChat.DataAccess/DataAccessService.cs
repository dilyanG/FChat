using FChat.DataAccess.Interfaces;
using FChat.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FChat.DataAccess
{
    public class DataAccessService: IDataAccessService
    {
        public DataAccessService()
        {
            DataContext context = new DataContext();
            UserRepository = new UserRepository(context);
            MessageRepository = new MessageRepository(context);
        }

        public IUserRepository UserRepository { get; set; }
        public IMessageRepository MessageRepository { get; set; }
    }
}
