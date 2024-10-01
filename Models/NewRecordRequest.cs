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

        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FugaTomaDomiciliaria {get;set;}
        
        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FugaLineaConduccion {get;set;}
        
        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FugaLineaDistribucion {get;set;}
        
        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FallaAguaPotableElectrica {get;set;}
        
        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FallaAguaPotableCentroControl {get;set;}
        
        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FallaAguaPotableBombeo {get;set;}

        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FallaAguaResidualPotableElectrica {get;set;}

        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FallaAguaResidualCentroControl {get;set;}

        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FallaAguaResidualBombeo {get;set;}

        [Required(ErrorMessage = "El elemento es requerido")]
        public int? RecoleccionResidualAtendido {get;set;}

        [Required(ErrorMessage = "El elemento es requerido")]
        public int? RecoleccionResidualColector {get;set;}

        [Required(ErrorMessage = "El elemento es requerido")]
        public int? RecoleccionResidualVisita {get;set;}
        
        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FallaTratamientoEquipos {get;set;}

        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FallaTratamientoAereacion {get;set;}

        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FallTratamientoRecirculacion {get;set;}

        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FallTratamientoSedimentacion {get;set;}

        [Required(ErrorMessage = "El elemento es requerido")]
        public int? FallTratamientoDesinfeccion {get;set;}

        public NewRecordRequest(){
            Fecha = DateTime.Now;
            FugaTomaDomiciliaria = 666;
            FugaLineaConduccion = 666;
            FugaLineaDistribucion = 666;
            FallaAguaPotableElectrica = 666;
            FallaAguaPotableCentroControl = 666;
            FallaAguaPotableBombeo = 666;
            FallaAguaResidualPotableElectrica = 666;
            FallaAguaResidualCentroControl = 666;
            FallaAguaResidualBombeo = 666;
            RecoleccionResidualAtendido = 666;
            RecoleccionResidualColector = 666;
            RecoleccionResidualVisita = 666;
            FallaTratamientoEquipos = 666;
            FallaTratamientoAereacion = 666;
            FallTratamientoRecirculacion = 666;
            FallTratamientoSedimentacion = 666;
            FallTratamientoDesinfeccion = 666;
        }

    }
}