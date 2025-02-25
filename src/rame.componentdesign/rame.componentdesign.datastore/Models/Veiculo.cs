using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rame.componentdesign.datastore.Models;

public partial class Veiculo
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Placa { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Modelo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Cor { get; set; }

    public int IdMotorista { get; set; }

    public int? AnoFabricacao { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CapacidadeCarga { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataRevisao { get; set; }

    [Unicode(false)]
    public string? Observacoes { get; set; }

    [InverseProperty("Veiculo")]
    public virtual ICollection<Despacho> Despacho { get; set; } = [];

    [ForeignKey("IdMotorista")]
    [InverseProperty("Veiculo")]
    public virtual Motorista IdMotoristaNavigation { get; set; } = null!;
}
