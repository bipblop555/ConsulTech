using System.ComponentModel.DataAnnotations;

namespace ConsulTech.Api.Models
{
    public class MissionInput
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Titre { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime Debut { get; set; }

        [Required]
        public DateTime Fin { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Le budget doit être un nombre positif.")]
        public float Budget { get; set; }
        public Guid ClientId { get; set; }
    }
}
