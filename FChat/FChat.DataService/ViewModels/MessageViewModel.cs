using FChat.DataModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FChat.DataService.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public UserViewModel User { get; set; }
        public int GroupTypeId { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
