using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SicemOperation.Entities
{

    [Table("Oficinas", Schema = "System")]

    public class Oficina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Nombre {get;set;} = default!;
        public string? Alias { get; set; }
        public bool? Inactivo { get; set; }
        public DateTime UltimaActualizacion {get;set;}

    }
}