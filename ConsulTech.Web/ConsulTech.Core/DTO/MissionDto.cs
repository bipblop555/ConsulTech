using ConsulTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulTech.Core.DTO
{
    public sealed class MissionDto
    {
        public Guid Id { get; set; }

        public string Titre { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime Debut { get; set; }

        public DateTime Fin { get; set; }

        public float Budget { get; set; }

        public Guid ClientId { get; set; }
    }
}
