using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Zjazd3.ScaffoldDA
{
    [Table("Spedytorzy")]
    public partial class Spedytorzy
    {
        public Spedytorzy()
        {
            Zamówienia = new HashSet<Zamówienium>();
        }

        [Key]
        [Column("IDspedytora")]
        public int Idspedytora { get; set; }
        [Required]
        [StringLength(40)]
        public string NazwaFirmy { get; set; }
        [StringLength(24)]
        public string Telefon { get; set; }

        [InverseProperty(nameof(Zamówienium.IdspedytoraNavigation))]
        public virtual ICollection<Zamówienium> Zamówienia { get; set; }
    }
}
