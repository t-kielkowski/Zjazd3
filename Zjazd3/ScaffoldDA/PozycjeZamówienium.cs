using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Zjazd3.ScaffoldDA
{
    public partial class PozycjeZamówienium
    {
        [Key]
        [Column("IDzamówienia")]
        public int Idzamówienia { get; set; }
        [Key]
        [Column("IDproduktu")]
        public int Idproduktu { get; set; }
        [Column(TypeName = "money")]
        public decimal CenaJednostkowa { get; set; }
        public short Ilość { get; set; }
        public float Rabat { get; set; }

        [ForeignKey(nameof(Idproduktu))]
        [InverseProperty(nameof(Produkty.PozycjeZamówienia))]
        public virtual Produkty IdproduktuNavigation { get; set; }
        [ForeignKey(nameof(Idzamówienia))]
        [InverseProperty(nameof(Zamówienium.PozycjeZamówienia))]
        public virtual Zamówienium IdzamówieniaNavigation { get; set; }
    }
}
