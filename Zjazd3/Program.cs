// Stwórz nową aplikację i dodaj do niej EF Core. Użyj Code First from Database i wygeneruj klasę DBContext z bazy Northwind (zalecam w jakimś podfolderze). Następnie dodaj do kontekstu nową tabelę, np. MyUsers z kolumnami int Id, string Name, DateTime RegistrationDate i przygotuj migrację.

using System;
using System.Linq;
using Zjazd3.ScaffoldDA;
using Microsoft.Extensions.Configuration;

namespace Zjazd3
{
    class Program
    {
      
        static void Main(string[] args)
        {
            // var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
            // var configuration = builder.Build();
            //
            // string str = configuration.GetConnectionString("myDb1");

            using var db = new ZNorthwindContext();
            
            var zm = db.Kliencis.Where(x => x.Kraj.Length>5);
            
            foreach (var klienci in zm)
            {
                Console.WriteLine(klienci.Idklienta + " " + klienci.Kraj);

            }

            var db2 = new Kontekst();
            db2.Database.EnsureCreated();
            
            db2.MyUsers.Add(new MyUser() {Name = "Jola", RegistrationDate = new DateTime(1985, 12, 31)});
            db2.SaveChanges();
        }
    }
}