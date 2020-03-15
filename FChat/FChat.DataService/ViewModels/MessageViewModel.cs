using FChat.DataModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FChat.DataService.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public UserViewModel User { get; set; }
        [Required]
        public int GroupTypeId { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
