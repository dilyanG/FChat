using FChat.DataModel.Enums;
using FChat.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FChat.DataModel.Entities
{
    public class MessageEntity : ITrack
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public GroupType GroupTypeId { get; set; }
        public virtual GroupTypeEntity GroupType { get; set; }

        [Required]
        public virtual UserEntity User { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
