using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Zjazd3.ScaffoldDA
{
    [Table("Kategorie", Schema = "mg")]
    public partial class Kategorie
    {
        public Kategorie()
        {
            Produkties = new HashSet<Produkty>();
        }

        [Key]
        [Column("IDkategorii")]
        public int Idkategorii { get; set; }
        [Required]
        [StringLength(20)]
        public string NazwaKategorii { get; set; }
        public string Opis { get; set; }
        [Column(TypeName = "image")]
        public byte[] Rysunek { get; set; }

        [InverseProperty(nameof(Produkty.IdkategoriiNavigation))]
        public virtual ICollection<Produkty> Produkties { get; set; }
    }
}
