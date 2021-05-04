using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Zjazd3.ScaffoldDA
{
    [Table("Pracownicy")]
    public partial class Pracownicy
    {
        public Pracownicy()
        {
            Zamówienia = new HashSet<Zamówienium>();
        }

        [Key]
        [Column("IDpracownika")]
        public int Idpracownika { get; set; }
        [Required]
        [StringLength(20)]
        public string Nazwisko { get; set; }
        [Required]
        [StringLength(15)]
        public string Imię { get; set; }
        [StringLength(40)]
        public string Stanowisko { get; set; }
        [StringLength(25)]
        public string ZwrotGrzecznościowy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataUrodzenia { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataZatrudnienia { get; set; }
        [StringLength(60)]
        public string Adres { get; set; }
        [StringLength(25)]
        public string Miasto { get; set; }
        [StringLength(15)]
        public string Region { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string KodPocztowy { get; set; }
        [StringLength(15)]
        public string Kraj { get; set; }
        [StringLength(24)]
        public string TelefonDomowy { get; set; }
        [StringLength(4)]
        public string TelefonWewnętrzny { get; set; }
        [Column(TypeName = "image")]
        public byte[] Fotografia { get; set; }
        public string Uwagi { get; set; }
        public int? Szef { get; set; }

        [InverseProperty(nameof(Zamówienium.IdpracownikaNavigation))]
        public virtual ICollection<Zamówienium> Zamówienia { get; set; }
    }
}
