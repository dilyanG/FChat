using FChat.DataModel.Entities;
using FChat.DataModel.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FChat.DataAccess
{
    public class DataContext: DbContext
    {

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<GroupTypeEntity> GroupTypes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=FChat.Database;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users")
                                            .Property(c => c.CreatedOn)
                                            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<UserEntity>(entity => {
                                               entity.HasIndex(e => e.Name).IsUnique();
                                           });

            modelBuilder.Entity<MessageEntity>().ToTable("Messages")
                                            .Property(r => r.CreatedOn)
                                            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<MessageEntity>().HasOne(m => m.User).WithMany(u => u.Messages);

            modelBuilder.Entity<GroupTypeEntity>().ToTable("Groups");

            var groupTypes = Enum.GetValues(typeof(GroupType))
               .Cast<GroupType>()
               .Select(t => new GroupTypeEntity
               {
                   Id = t,
                   Name = t.ToString()
               });

            modelBuilder.Entity<GroupTypeEntity>().HasData(groupTypes);
        }
    }
}
