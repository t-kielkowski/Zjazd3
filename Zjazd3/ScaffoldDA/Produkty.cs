using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Zjazd3.ScaffoldDA
{
    [Table("Produkty", Schema = "mg")]
    public partial class Produkty
    {
        public Produkty()
        {
            PozycjeZamówienia = new HashSet<PozycjeZamówienium>();
        }

        [Key]
        [Column("IDproduktu")]
        public int Idproduktu { get; set; }
        [Required]
        [StringLength(40)]
        public string NazwaProduktu { get; set; }
        [Column("IDdostawcy")]
        public int? Iddostawcy { get; set; }
        [Column("IDkategorii")]
        public int? Idkategorii { get; set; }
        [StringLength(255)]
        public string IlośćJednostkowa { get; set; }
        [Column(TypeName = "money")]
        public decimal? CenaJednostkowa { get; set; }
        public short? StanMagazynu { get; set; }
        public short? IlośćZamówiona { get; set; }
        public short? StanMinimum { get; set; }
        public bool Wycofany { get; set; }

        [ForeignKey(nameof(Iddostawcy))]
        [InverseProperty(nameof(Dostawcy.Produkties))]
        public virtual Dostawcy IddostawcyNavigation { get; set; }
        [ForeignKey(nameof(Idkategorii))]
        [InverseProperty(nameof(Kategorie.Produkties))]
        public virtual Kategorie IdkategoriiNavigation { get; set; }
        [InverseProperty(nameof(PozycjeZamówienium.IdproduktuNavigation))]
        public virtual ICollection<PozycjeZamówienium> PozycjeZamówienia { get; set; }
    }
}
