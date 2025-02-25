using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rame.componentdesign.datastore.Models;

public partial class Motorista
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(25)]
    public string? Telefone { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Cnh { get; set; }

    public DateOnly? DataNascimento { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Endereco { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Salario { get; set; }

    [Unicode(false)]
    public string? Observacoes { get; set; }

    [InverseProperty("IdMotoristaNavigation")]
    public virtual ICollection<Veiculo> Veiculo { get; set; } = [];
}
