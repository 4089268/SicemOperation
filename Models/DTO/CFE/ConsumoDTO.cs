using System.ComponentModel.DataAnnotations;
using SicemOperation.Entities;

namespace SicemOperation.Models.DTO.CFE
{
    public class ConsumoDTO
    {
        public int Af { get; set; }
        public int Mf { get; set; }
        
        [Display(Name = "Medidor")]
        public int MedidorId { get; set; }

        public CFEMedidor? Medidor {get;set;}
        public CFEConsumo? Consumo {get;set;}
    }
}