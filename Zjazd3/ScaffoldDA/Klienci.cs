using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Zjazd3.ScaffoldDA
{
    [Table("Klienci")]
    public partial class Klienci
    {
        public Klienci()
        {
            Zamówienia = new HashSet<Zamówienium>();
        }

        [Key]
        [Column("IDklienta")]
        [StringLength(5)]
        [Unicode(false)]
        public string Idklienta { get; set; }
        [Required]
        [StringLength(40)]
        public string NazwaFirmy { get; set; }
        [StringLength(30)]
        public string Przedstawiciel { get; set; }
        [StringLength(35)]
        public string StanowiskoPrzedstawiciela { get; set; }
        [StringLength(60)]
        public string Adres { get; set; }
        [StringLength(15)]
        public string Miasto { get; set; }
        [StringLength(15)]
        public string Region { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string KodPocztowy { get; set; }
        [StringLength(15)]
        public string Kraj { get; set; }
        [StringLength(24)]
        public string Telefon { get; set; }
        [StringLength(24)]
        public string Faks { get; set; }

        [InverseProperty(nameof(Zamówienium.IdklientaNavigation))]
        public virtual ICollection<Zamówienium> Zamówienia { get; set; }
    }
}
