using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rame.componentdesign.datastore.Models;

public partial class Cliente
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
    public string? Email { get; set; }

    [InverseProperty("Cliente")]
    public virtual ICollection<Despacho> Despacho { get; set; } = [];
}
