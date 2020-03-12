using FChat.DataAccess.Interfaces;
using FChat.DataModel.Entities;
using FChat.DataModel.Enums;
using FChat.DataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FChat.DataService.Services
{
    public class MessageService : BaseService, IMessageService
    {
        public MessageService(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }

        public void AddMessage(MessageEntity message)
        {
            if (message == null) throw new ArgumentNullException();
            this.DataAccessService.MessageRepository.Add(message);
        }

        public IEnumerable<MessageEntity> GetAll(GroupType type)
        {
            return this.DataAccessService.MessageRepository.GetAll(type);
        }
        public IEnumerable<MessageEntity> GetAll(GroupType type, DateTime after)
        {
            return this.DataAccessService.MessageRepository.GetAll(type, after);
        }
    }
}
