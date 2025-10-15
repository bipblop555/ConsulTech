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
        public string Contact { get; set; } = "";
    }
}
