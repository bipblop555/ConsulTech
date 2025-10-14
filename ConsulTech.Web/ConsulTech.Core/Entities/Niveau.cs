using ConsulTech.Core.Entities.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsulTech.Core.Entities;

public sealed class Niveau : ICategorie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Titre { get; set; } = string.Empty;
}
