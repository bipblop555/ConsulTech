using ConsulTech.Core.Entities.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsulTech.Core.Entities;

public sealed class Client : IEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nom { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Secteur { get; set; } = string.Empty;

    [Required]
    [StringLength(250)]
    public string Adresse { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Contact { get; set; } = string.Empty;
}
