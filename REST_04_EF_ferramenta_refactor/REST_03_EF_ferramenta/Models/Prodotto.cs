using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_03_EF_ferramenta.Models;

[Table("Prodotto")]
public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public string prodottoCOD { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string? Descrizione { get; set; }

    public decimal? Prezzo { get; set; }

    public int Quantita { get; set; }

    [ForeignKey("Reparto")]
    public int RepartoRif { get; set; }

    public virtual Reparto Reparto { get; set; } = null!;

    
}
