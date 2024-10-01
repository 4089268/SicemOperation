using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SicemOperation.Models
{
    public class NewRecordRequest
    {
        public DateTime Fecha {get;set;}
    
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

    }
}