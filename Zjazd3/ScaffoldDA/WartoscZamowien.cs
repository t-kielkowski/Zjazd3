using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Zjazd3.ScaffoldDA
{
    [Keyless]
    public partial class WartoscZamowien
    {
        [StringLength(15)]
        public string KrajOdbiorcy { get; set; }
        [StringLength(15)]
        public string MiastoOdbiorcy { get; set; }
        [Column("Suma zamówień", TypeName = "money")]
        public decimal? SumaZamówień { get; set; }
    }
}
