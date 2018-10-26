using BeThere.DAL.Configurations;

using BeThere.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.DAL
{
    public class BeThereDbContext : DbContext
    {
        public BeThereDbContext(DbContextOptions<BeThereDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
