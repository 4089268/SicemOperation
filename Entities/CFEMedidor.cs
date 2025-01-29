using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SicemOperation.Entities
{

    [Table("Cat_Medidores", Schema = "CFE")]
    public class CFEMedidor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public int IdOrganismo {get;set;}
        public string RPU {get;set;} = default!;
        public string NumMedidor {get;set;} = default!;
        public string Ubicacion {get;set;} = default!;
        public string? Latitud {get;set;}
        public string? Longitud {get;set;}
        public int CargaConectada {get;set;}
        public int DemandaContratada {get;set;}
        public int IdTarifa {get;set;}
        public int IdProceso {get;set;}
        public int IdZona {get;set;}
        public bool Inactivo {get;set;}


        [ForeignKey("IdOrganismo")]
        public Organismo Organismo {get;set;} = default!;

        [ForeignKey("IdTarifa")]
        public CFETarifa Tarifa {get;set;} = default!;

        [ForeignKey("IdProceso")]
        public CFEProceso Proceso {get;set;} = default!;

        [ForeignKey("IdZona")]
        public CFEZona Zona {get;set;} = default!;

    }
}