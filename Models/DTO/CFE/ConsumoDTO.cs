using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using SicemOperation.Entities;

namespace SicemOperation.Models.DTO.CFE
{
    public class ConsumoDTO
    {
        [Display(Name = "Año")]
        [Range(2000, 2025)]
        public int Af { get; set; }

        [Display(Name = "Mes")]
        [Range(1, 12)]
        public int Mf { get; set; }
        
        [Display(Name = "Medidor")]
        public int MedidorId { get; set; }
        public IEnumerable<SelectListItem> MedidoresListItems { get; set; } = default!;

        public CFEMedidor? Medidor {get;set;}
        public CFEConsumo? Consumo {get;set;}
    }
}