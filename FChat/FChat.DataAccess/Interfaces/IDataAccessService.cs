using System;
using System.Collections.Generic;
using System.Text;

namespace FChat.DataAccess.Interfaces
{
    public interface IDataAccessService
    {
        IUserRepository UserRepository { get; set; }
        IMessageRepository MessageRepository { get; set; }
    }
}
