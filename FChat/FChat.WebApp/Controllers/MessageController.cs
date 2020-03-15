using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FChat.DataModel.Entities;
using FChat.DataModel.Enums;
using FChat.DataService.Interfaces;
using FChat.DataService.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace FChat.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;
        private readonly IMapper mapper;


        public MessageController(IMessageService messageService, IMapper mapper)
        {
            this.messageService = messageService;
            this.mapper = mapper;
        }

        // GET: api/Message
        [HttpGet]
        [Route("all/{type}")]
        public IEnumerable<MessageViewModel> GetAll(GroupType type)
        {
            var messages = messageService.GetAll(type);
            return mapper.Map<IEnumerable<MessageViewModel>>(messages);
        }

        // GET: api/Message
        [HttpGet]
        [Route("sync")]
        public IEnumerable<MessageViewModel> Sync([FromQuery] GroupType type, string after)
        {
            DateTime date;
            if (DateTime.TryParse(after, out date))
                return mapper.Map<IEnumerable<MessageViewModel>>(messageService.GetAll(type, date));
            return null;
        }


        // POST: api/Message
        [HttpPost]
        [Route("add")]
        public StatusCodeResult AddMessage([FromBody] MessageViewModel message)
        {
            if (message==null || !Validator.TryValidateObject(message, new ValidationContext(message), new List<ValidationResult>())) return BadRequest();

            messageService.AddMessage(mapper.Map<MessageEntity>(message));
            return Ok();
        }

    }
}
