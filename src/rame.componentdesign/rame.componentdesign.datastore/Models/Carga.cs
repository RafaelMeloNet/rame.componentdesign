using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rame.componentdesign.datastore.Models;

public partial class Carga
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Tipo { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Peso { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Dimensoes { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Valor { get; set; }

    public bool Seguro { get; set; }

    [Unicode(false)]
    public string? Descricao { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Altura { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Largura { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Profundidade { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataCriacao { get; set; }

    [Unicode(false)]
    public string? Observacoes { get; set; }

    [InverseProperty("Carga")]
    public virtual ICollection<Despacho> Despacho { get; set; } = [];
}
