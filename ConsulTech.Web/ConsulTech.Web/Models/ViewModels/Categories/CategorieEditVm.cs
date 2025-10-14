using System.ComponentModel.DataAnnotations;

namespace ConsulTech.Web.Models.ViewModels.Categories;

public class CategorieEditVm
{

    [Required, StringLength(25)]
    public string Titre { get; set; } = string.Empty;
}
