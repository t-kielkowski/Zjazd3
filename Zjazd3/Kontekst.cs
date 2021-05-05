using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;


namespace Zjazd3
{
    public class Kontekst : DbContext
    {
        static IConfigurationBuilder  builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
        static IConfiguration  configuration = builder.Build();
            
        string connectionString = configuration.GetConnectionString("myDb1");
        
        
        public DbSet<MyUser> MyUsers { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}