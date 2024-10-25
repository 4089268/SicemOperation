using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SicemOperation.Models;

namespace SicemOperation.Entities
{

    [Table("Opr_Incidencia", Schema = "Operation")]
    public class Incidencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public int Valor {get;set;}
        public DateTime Fecha {get;set;}
        public DateTime UltimaActualizacion {get;set;}
        public DateTime? Eliminado {get;set;}

        public TipoIncidencia TipoIncidencia {get;set;} = default!;
        public virtual Oficina Oficina {get;set;} = default!;
        public virtual Usuario Usuario {get;set;} = default!;

    }
}
