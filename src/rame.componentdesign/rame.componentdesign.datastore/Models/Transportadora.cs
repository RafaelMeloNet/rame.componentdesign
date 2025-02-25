using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rame.componentdesign.datastore.Models;

public partial class Transportadora
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(25)]
    public string? Telefone { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Endereco { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Cnpj { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? InscricaoEstadual { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataCadastro { get; set; }

    [Unicode(false)]
    public string? Observacoes { get; set; }

    [InverseProperty("Transportadora")]
    public virtual ICollection<Despacho> Despacho { get; set; } = [];
}
