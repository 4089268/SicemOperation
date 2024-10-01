using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SicemOperation.Models;

namespace SicemOperation.Entities
{

    [Table("Incidencia", Schema = "Operation")]
    public class Incidencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        
        public int FugaTomaDomiciliaria {get;set;}
        public int FugaLineaConduccion {get;set;}
        public int FugaLineaDistribucion {get;set;}
        
        public int FallaAguaPotableElectrica {get;set;}
        public int FallaAguaPotableCentroControl {get;set;}
        public int FallaAguaPotableBombeo {get;set;}

        public int FallaAguaResidualPotableElectrica {get;set;}
        public int FallaAguaResidualCentroControl {get;set;}
        public int FallaAguaResidualBombeo {get;set;}

        public int RecoleccionResidualAtendido {get;set;}
        public int RecoleccionResidualColector {get;set;}
        public int RecoleccionResidualVisita {get;set;}
        
        public int FallaTratamientoEquipos {get;set;}
        public int FallaTratamientoAereacion {get;set;}
        public int FallTratamientoRecirculacion {get;set;}
        public int FallTratamientoSedimentacion {get;set;}
        public int FallTratamientoDesinfeccion {get;set;}

        public DateTime Fecha {get;set;}
        public DateTime UltimaActualizacion {get;set;}
        public DateTime? Eliminado {get;set;}
        
        public virtual Oficina Oficina {get;set;} = default!;

        public static Incidencia FromRequest( NewRecordRequest recordRequest){
            var item = new Incidencia();
            item.FugaTomaDomiciliaria = recordRequest.FugaTomaDomiciliaria!.Value;
            item.FugaLineaConduccion = recordRequest.FugaLineaConduccion!.Value;
            item.FugaLineaDistribucion = recordRequest.FugaLineaDistribucion!.Value;
            item.FallaAguaPotableElectrica = recordRequest.FallaAguaPotableElectrica!.Value;
            item.FallaAguaPotableCentroControl = recordRequest.FallaAguaPotableCentroControl!.Value;
            item.FallaAguaPotableBombeo = recordRequest.FallaAguaPotableBombeo!.Value;
            item.FallaAguaResidualPotableElectrica = recordRequest.FallaAguaResidualPotableElectrica!.Value;
            item.FallaAguaResidualCentroControl = recordRequest.FallaAguaResidualCentroControl!.Value;
            item.FallaAguaResidualBombeo = recordRequest.FallaAguaResidualBombeo!.Value;
            item.RecoleccionResidualAtendido = recordRequest.RecoleccionResidualAtendido!.Value;
            item.RecoleccionResidualColector = recordRequest.RecoleccionResidualColector!.Value;
            item.RecoleccionResidualVisita = recordRequest.RecoleccionResidualVisita!.Value;
            item.FallaTratamientoEquipos = recordRequest.FallaTratamientoEquipos!.Value;
            item.FallaTratamientoAereacion = recordRequest.FallaTratamientoAereacion!.Value;
            item.FallTratamientoRecirculacion = recordRequest.FallTratamientoRecirculacion!.Value;
            item.FallTratamientoSedimentacion = recordRequest.FallTratamientoSedimentacion!.Value;
            item.FallTratamientoDesinfeccion = recordRequest.FallTratamientoDesinfeccion!.Value;
            item.Fecha = DateTime.Now;
            item.UltimaActualizacion = DateTime.Now;
            return item;
        }
    }
}