using FChat.DataModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FChat.DataModel.Entities
{
    public class GroupTypeEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public GroupType Id { get; set; }
        public string Name { get; set; }
    }
}
