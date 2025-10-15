using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsulTech.Api.Models
{
    public sealed class NiveauInput
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Titre { get; set; } = string.Empty;
    }
}
