using System.ComponentModel.DataAnnotations;

namespace ConsulTech.Web.Models.ViewModels.Niveaux;

public class NiveauxListVm
{
    public Guid Id { get; set; }

    [Required, StringLength(25)]
    public string Titre { get; set; } = string.Empty;
}
