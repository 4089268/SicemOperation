using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SicemOperation.Entities
{

    [Table("Cat_Organismos", Schema = "Global")]
    public class Organismo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Nombre {get;set;} = default!;

        public string Direccion {get;set;} = default!;

        public string Municipio {get;set;} = default!;
    }
}