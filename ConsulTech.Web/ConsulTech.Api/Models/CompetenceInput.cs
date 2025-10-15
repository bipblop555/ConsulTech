using ConsulTech.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsulTech.Api.Models;

public class CompetenceInput
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Titre { get; set; } = string.Empty;

    public Guid CategorieId { get; set; }
    public Guid NiveauId { get; set; }

    public List<Guid> ConsultantsId { get; set; } = null!;
}
