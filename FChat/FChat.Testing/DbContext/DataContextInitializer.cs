using FChat.DataAccess;
using FChat.DataModel.Entities;
using FChat.DataModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FChat.Testing.DbContext
{
    public static class DataContextInitializer
    {
        public static void Initialize(DataContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            Seed(context);
        }

        private static void Seed(DataContext context)
        {
            var users = new[]
            {
                new UserEntity
                {
                    Name = "Ivan",
                    Messages = new[]
                    {
                        new MessageEntity { GroupTypeId = GroupType.Family, Message = "Hello, Family!" },
                        new MessageEntity { GroupTypeId = GroupType.Work, Message = "Hello!" },
                        new MessageEntity { GroupTypeId = GroupType.Friends, Message = "Hello!" },
                        new MessageEntity { GroupTypeId = GroupType.Friends, Message = "I am Ivan" }
                    }.ToList()
                },
                new UserEntity
                {
                    Name = "Metodi",
                    Messages = new[]
                    {
                        new MessageEntity { GroupTypeId = GroupType.Family, Message = "Hi, I am Metodi!" },
                        new MessageEntity { GroupTypeId = GroupType.Work, Message = "Metodi here!" },
                        new MessageEntity { GroupTypeId = GroupType.Friends, Message = "Hello!" },
                        new MessageEntity { GroupTypeId = GroupType.Friends, Message = "I am Metodi" },
                        new MessageEntity { GroupTypeId = GroupType.Family, Message = "How are you today?" }
                    }.ToList()
                },
                new UserEntity
                {
                    Name = "Claudia",
                    Messages = new[]
                    {
                        new MessageEntity { GroupTypeId = GroupType.Family, Message = "Hi, I am Claudia!" },
                        new MessageEntity { GroupTypeId = GroupType.Work, Message = "Claudia here!" },
                        new MessageEntity { GroupTypeId = GroupType.Friends, Message = "Hello!" },
                        new MessageEntity { GroupTypeId = GroupType.Work, Message = "We are here to work" },
                    }.ToList()
                },
                new UserEntity
                {
                    Name = "Patricia",
                    Messages = new[]
                    {
                        new MessageEntity { GroupTypeId = GroupType.Family, Message = "Hi, I am Patricia!" },
                        new MessageEntity { GroupTypeId = GroupType.Work, Message = "Patricia here!" }
                    }.ToList()
                },
                new UserEntity
                {
                    Name = "Mellony",
                    Messages = new[]
                    {
                        new MessageEntity { GroupTypeId = GroupType.Family, Message = "Hi, Mel here!" }
                    }.ToList()
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
