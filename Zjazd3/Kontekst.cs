using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;


namespace Zjazd3
{
    public class Kontekst : DbContext
    {
        public DbSet<MyUser> MyUsers { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "...");
            base.OnConfiguring(optionsBuilder);
        }
    }
}