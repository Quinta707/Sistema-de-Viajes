using Academia.Proyecto.API._Features.ViajesDetalles.Dtos;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;

namespace Academia.Proyecto.API._Features.Viajes.Dtos
{
    public class ViajesListDto
    {
        public int ViajeId { get; set; }

        public int? TransportistaId { get; set; }

        public string? TransportistaNombre { get; set; }

        public string? TransportistaApellido { get; set; }

        public bool? Estado { get; set; }

        public DateTime? FechaViaje { get; set; }

        public decimal? TarifaPorKm { get; set; }

        public List<ViajesDetallesListDto> ViajesDetalles { get; set; } = new List<ViajesDetallesListDto>();

    }
}
