using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Zjazd3.ScaffoldDA
{
    [Table("Dostawcy", Schema = "mg")]
    public partial class Dostawcy
    {
        public Dostawcy()
        {
            Produkties = new HashSet<Produkty>();
        }

        [Key]
        [Column("IDdostawcy")]
        public int Iddostawcy { get; set; }
        [Required]
        [StringLength(40)]
        public string NazwaFirmy { get; set; }
        [StringLength(30)]
        public string Przedstawiciel { get; set; }
        [StringLength(30)]
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
        public string StronaMacierzysta { get; set; }

        [InverseProperty(nameof(Produkty.IddostawcyNavigation))]
        public virtual ICollection<Produkty> Produkties { get; set; }
    }
}
