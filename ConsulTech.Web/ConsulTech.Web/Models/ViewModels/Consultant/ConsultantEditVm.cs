using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsulTech.Web.Models.ViewModels.Consultant
{
    public class ConsultantEditVm
    {
        [Required, StringLength(50)] public string Nom { get; set; } = "";

        [DisplayName("Prénom")]
        [Required, StringLength(50)] public string Prenom { get; set; } = "";

        [DisplayName("Adresse Email")]
        [Required, EmailAddress(ErrorMessage = "Le format de l'adresse email n'est pas valide")] public string Email { get; set; } = "";

        [DisplayName("Date d'embauche")]
        [Required] public DateTime DateEmbauche { get; set; } = DateTime.Today;

        [DisplayName("Disponible")]
        public bool EstDisponible { get; set; } = true;
    }
}
