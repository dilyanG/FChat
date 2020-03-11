using FChat.DataModel.Entities;
using FChat.DataModel.Enums;
using FChat.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FChat.DataService.Interfaces
{
    public interface IMessageService
    {
        void AddMessage(MessageEntity message);
        IEnumerable<MessageEntity> GetAll(GroupType type);
        IEnumerable<MessageEntity> GetAll(GroupType type, DateTime after);

    }
}
