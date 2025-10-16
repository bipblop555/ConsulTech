using System.ComponentModel.DataAnnotations;

namespace ConsulTech.Web.Models.ViewModels.Mission
{
    public class MissionEditVm
    {
        [Required, StringLength(25)]
        public string Titre { get; set; } = "";

        [Required, StringLength(250)]
        public string Description { get; set; } = "";

        [Required] public DateTime Debut { get; set; } = DateTime.Today;
        [Required] public DateTime Fin {  get; set; } = DateTime.Today.AddDays(30);

        [Range(0, float.MaxValue, ErrorMessage ="Le budget doit être positif.")]
        public float Budget { get; set; }

        [Required] public Guid ClientId { get; set; }

        public List<(string Value, string Label)> ClientOptions { get; set; } = new();

        public List<(string Value, string Label)> ConsultantOptions { get; set; } = new();
        public List<Guid> ConsultantIds { get; set; } = new();
    }
}
