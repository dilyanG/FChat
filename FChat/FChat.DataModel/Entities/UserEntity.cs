using FChat.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FChat.DataModel.Entities
{
    public class UserEntity: ITrack
    {
        public int Id { get; set; }

        [StringLength(450)]
        public string Name { get; set; }

        public List<MessageEntity> Messages { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
