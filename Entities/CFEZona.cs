using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SicemOperation.Entities
{

    [Table("Cat_Zonas", Schema = "CFE")]
    public class CFEZona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Zona {get;set;} = default!;
    }
}