using System.ComponentModel.DataAnnotations;

namespace ConsulTech.Web.Models.ViewModels.Niveaux;

public class NiveauxEditVm
{
    [Required, StringLength(25)]
    public string Titre { get; set; } = string.Empty;
}
