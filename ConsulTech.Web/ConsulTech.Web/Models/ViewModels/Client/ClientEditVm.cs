using System.ComponentModel.DataAnnotations;

namespace ConsulTech.Web.Models.ViewModels.Client
{
    public class ClientEditVm
    {
        [Required, StringLength(120)]
        public string Nom { get; set; } = "";

        [Required, StringLength(120)]
        public string Secteur { get; set; } = "";

        [Required, StringLength(200)]
        public string Adresse { get; set; } = "";

        [Required, StringLength(120)]
        [EmailAddress(ErrorMessage = "Le format de l’adresse e-mail n’est pas valide.")]
        public string Contact { get; set; } = "";
    }
}
