using ConsulTech.Web.Models.Dtos.Categorie;
using ConsulTech.Web.Models.Dtos.Niveau;

namespace ConsulTech.Web.Models.Dtos.Competence;

public record CompetenceDto
{
    public Guid Id { get; set; }

    public string Titre { get; set; } = string.Empty;

    public string CategorieName { get; set; } = string.Empty;

    public string NiveauName { get; set; } = string.Empty;

    public Guid CategorieId { get; set; }

    public Guid NiveauId { get; set; }

    public Guid ConsultantsId { get; set; }
}
