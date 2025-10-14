using System.ComponentModel.DataAnnotations;

namespace ConsulTech.Api.Models;

public sealed class ClientInput
{
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
