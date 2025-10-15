using System.ComponentModel.DataAnnotations;

namespace ConsulTech.Api.Models
{
    public sealed class CategorieInput
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Titre { get; set; } = string.Empty;
    }
}
