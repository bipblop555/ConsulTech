using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace ConsulTech.Web.Models.ViewModels.Competence;

public class CompetenceEditViewModel
{
    [HiddenInput]
    public Guid Id { get; set; }
    public string Titre { get; set; } = string.Empty;

    [ValidateNever]
    public List<SelectListItem> Categories { get; set; } = new();
    
    [ValidateNever]
    [DisplayName("Catégorie")]
    public Guid CategorieId { get; set; }

    [ValidateNever]
    public List<SelectListItem> Niveaux { get; set; } = new();

    [ValidateNever]
    [DisplayName("Niveau")]
    public Guid NiveauId { get; set; }
}
