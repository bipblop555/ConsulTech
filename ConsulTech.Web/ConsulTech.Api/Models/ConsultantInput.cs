using System.ComponentModel.DataAnnotations;

namespace ConsulTech.Api.Models
{
    public class ConsultantInput
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Prenom { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime DateEmbauche { get; set; }

        [Required]
        public bool EstDisponible { get; set; }
    }
}
