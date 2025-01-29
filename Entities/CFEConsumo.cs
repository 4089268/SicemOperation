using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SicemOperation.Entities
{

    [Table("Opr_Consumos", Schema = "CFE")]
    public class CFEConsumo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public int IdMedidor {get;set;}
        public DateTime FechaInicio {get;set;}
        public DateTime FechaFin {get;set;}
        public int Consumo {get;set;}
        public decimal Importe {get;set;}
        public int Demanda {get;set;}
        public int Af {get;set;}
        public int Mf {get;set;}
        public decimal Kvarh {get;set;}
        public double FpPorc {get;set;}
        public decimal FpMon {get;set;}
        public decimal DapMon {get;set;}

        [ForeignKey("IdMedidor")]
        public CFEMedidor Medidor {get;set;} = default!;
    }
}