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
            FugaTomaDomiciliaria = 0;
            FugaLineaConduccion = 0;
            FugaLineaDistribucion = 0;
            FallaAguaPotableElectrica = 0;
            FallaAguaPotableCentroControl = 0;
            FallaAguaPotableBombeo = 0;
            FallaAguaResidualPotableElectrica = 0;
            FallaAguaResidualCentroControl = 0;
            FallaAguaResidualBombeo = 0;
            RecoleccionResidualAtendido = 0;
            RecoleccionResidualColector = 0;
            RecoleccionResidualVisita = 0;
            FallaTratamientoEquipos = 0;
            FallaTratamientoAereacion = 0;
            FallTratamientoRecirculacion = 0;
            FallTratamientoSedimentacion = 0;
            FallTratamientoDesinfeccion = 0;
        }

    }
}