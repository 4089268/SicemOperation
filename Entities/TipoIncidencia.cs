using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SicemOperation.Models;

namespace SicemOperation.Entities
{

    [Table("Cat_Incidencia", Schema = "Operation")]
    public class TipoIncidencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Nombre {get;set;} = default!;
        public string Descripcion {get;set;} = default!;
        public string Grupo {get;set;} = default!;

    }
}
