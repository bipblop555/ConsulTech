using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsulTech.Web.Models.ViewModels.Competence;

public class CompetenceEditViewModel
{
    [HiddenInput]
    public Guid Id { get; set; }

    [Required]
    public string Titre { get; set; } = string.Empty;

    [DisplayName("Catégorie")]
    [Required]
    public Guid CategorieId { get; set; }

    [ValidateNever]
    public List<SelectListItem> Categories { get; set; } = new();

    [DisplayName("Niveau")]
    [Required]
    public Guid NiveauId { get; set; }

    [ValidateNever]
    public List<SelectListItem> Niveaux { get; set; } = new();

    [DisplayName("Consultant")]
    [Required]
    public Guid ConsultantId { get; set; }

    [ValidateNever]
    public List<SelectListItem> Consultants { get; set; } = new();
}

