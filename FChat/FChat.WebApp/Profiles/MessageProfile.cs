using AutoMapper;
using FChat.DataModel.Entities;
using FChat.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FChat.WebApp.Profiles
{
    public class MessageProfile: Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageEntity, MessageViewModel>();
            CreateMap<MessageViewModel, MessageEntity>();
        }
    }
}
