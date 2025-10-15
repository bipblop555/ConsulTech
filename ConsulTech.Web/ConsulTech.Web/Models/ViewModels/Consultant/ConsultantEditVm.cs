using System.ComponentModel.DataAnnotations;

namespace ConsulTech.Web.Models.ViewModels.Consultant
{
    public class ConsultantEditVm
    {
        [Required, StringLength(50)] public string Nom { get; set; } = "";
        [Required, StringLength(50)] public string Prenom { get; set; } = "";
        [Required, EmailAddress] public string Email { get; set; } = "";
        [Required] public DateTime DateEmbauche { get; set; } = DateTime.Today;
        public bool EstDisponible { get; set; } = true;
    }
}
