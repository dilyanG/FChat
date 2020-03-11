using FChat.DataModel.Entities;
using FChat.DataModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FChat.DataAccess.Interfaces
{
    public interface IMessageRepository : IDisposable, IBaseRepository<MessageEntity>
    {
        IEnumerable<MessageEntity> GetAll(GroupType type);
        IEnumerable<MessageEntity> GetAll(GroupType type, DateTime after);
    }
}
