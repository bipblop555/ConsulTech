using ConsulTech.Core.Entities.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsulTech.Core.Entities;

public sealed class Consultant : IEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nom { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Prenom { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public DateTime DateEmbauche { get; set; }

    [Required]
    public bool EstDisponible { get; set; }

    public List<Competence> Competences { get; set; } = null!;
    public List<Mission> Missions { get; set; } = null!;
}
