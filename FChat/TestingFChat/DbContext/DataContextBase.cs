using AutoMapper;
using FChat.DataAccess;
using FChat.WebApp.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace FChat.Testing.DbContext
{
    public class DataContextBase : ControllerBase, IDisposable
    {
        protected readonly DataContext context;
        protected readonly IMapper mapper;

        public DataContextBase()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: new Guid().ToString())
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            this.context = new DataContext(options);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new MessageProfile());
            });
            mapper = mappingConfig.CreateMapper();

            context.Database.EnsureCreated();

            DataContextInitializer.Initialize(this.context);            
        }

        public void Dispose()
        {
            this.context.Database.EnsureDeleted();
            this.context.Dispose();
        }
    }
}
