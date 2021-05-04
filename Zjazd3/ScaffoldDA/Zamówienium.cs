using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Zjazd3.ScaffoldDA
{
    public partial class Zamówienium
    {
        public Zamówienium()
        {
            PozycjeZamówienia = new HashSet<PozycjeZamówienium>();
        }

        [Key]
        [Column("IDzamówienia")]
        public int Idzamówienia { get; set; }
        [Required]
        [Column("IDklienta")]
        [StringLength(5)]
        [Unicode(false)]
        public string Idklienta { get; set; }
        [Column("IDpracownika")]
        public int? Idpracownika { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataZamówienia { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataWymagana { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataWysyłki { get; set; }
        [Column("IDspedytora")]
        public int? Idspedytora { get; set; }
        [Column(TypeName = "money")]
        public decimal? Fracht { get; set; }
        [StringLength(40)]
        public string NazwaOdbiorcy { get; set; }
        [StringLength(60)]
        public string AdresOdbiorcy { get; set; }
        [StringLength(15)]
        public string MiastoOdbiorcy { get; set; }
        [StringLength(15)]
        public string RegionOdbiorcy { get; set; }
        [StringLength(10)]
        public string KodPocztowyOdbiorcy { get; set; }
        [StringLength(15)]
        public string KrajOdbiorcy { get; set; }

        [ForeignKey(nameof(Idklienta))]
        [InverseProperty(nameof(Klienci.Zamówienia))]
        public virtual Klienci IdklientaNavigation { get; set; }
        [ForeignKey(nameof(Idpracownika))]
        [InverseProperty(nameof(Pracownicy.Zamówienia))]
        public virtual Pracownicy IdpracownikaNavigation { get; set; }
        [ForeignKey(nameof(Idspedytora))]
        [InverseProperty(nameof(Spedytorzy.Zamówienia))]
        public virtual Spedytorzy IdspedytoraNavigation { get; set; }
        [InverseProperty(nameof(PozycjeZamówienium.IdzamówieniaNavigation))]
        public virtual ICollection<PozycjeZamówienium> PozycjeZamówienia { get; set; }
    }
}
