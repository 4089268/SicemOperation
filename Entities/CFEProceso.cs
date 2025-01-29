using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SicemOperation.Entities
{

    [Table("Cat_Procesos", Schema = "CFE")]
    public class CFEProceso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Proceso {get;set;} = default!;
    }
}