using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rame.componentdesign.datastore.Models;

public partial class Despacho
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataPartida { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataProcessamento { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataEntrega { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string EnderecoOrigem { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string EnderecoDestino { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? CoordenadasOrigem { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? CoordenadasDestino { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Unicode(false)]
    public string? Log { get; set; }

    public int ClienteId { get; set; }

    public int CargaId { get; set; }

    public int VeiculoId { get; set; }

    public int TransportadoraId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ValorFrete { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? DistanciaKM { get; set; }

    public int? Rota { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PrevisaoEntrega { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Responsavel { get; set; }

    public int? Prioridade { get; set; }

    [Unicode(false)]
    public string? Observacoes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataCriacao { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataAtualizacao { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataCancelamento { get; set; }

    [ForeignKey("CargaId")]
    [InverseProperty("Despacho")]
    public virtual Carga Carga { get; set; } = null!;

    [ForeignKey("ClienteId")]
    [InverseProperty("Despacho")]
    public virtual Cliente Cliente { get; set; } = null!;

    [ForeignKey("TransportadoraId")]
    [InverseProperty("Despacho")]
    public virtual Transportadora Transportadora { get; set; } = null!;

    [ForeignKey("VeiculoId")]
    [InverseProperty("Despacho")]
    public virtual Veiculo Veiculo { get; set; } = null!;
}
