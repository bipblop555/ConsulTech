using ConsulTech.Web.Models.Dtos.Competence;

namespace ConsulTech.Web.Models.ViewModels.Competence;

public class CompetenceBaseViewModel
{
    public Guid Id { get; set; }
    public string Titre { get; set; } = string.Empty;
    public string Categorie { get; set; } = string.Empty;
    public string Niveau { get; set; } = string.Empty;

    public string Consultant { get; set; } = string.Empty;

}
