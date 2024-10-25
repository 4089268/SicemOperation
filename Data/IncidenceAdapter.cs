using System;
using SicemOperation.Entities;
using SicemOperation.Models;

namespace SicemOperation.Data;

public class IncidenceAdapter
{
    private readonly SicemOperationContext context;

    public IncidenceAdapter(SicemOperationContext context){
        this.context = context;
    }

    public IEnumerable<Incidencia> GetIncidents(NewRecordRequest request, Oficina oficina, Usuario usuario){
        var response = new List<Incidencia>();

        if(request.FugaTomaDomiciliaria != null && request.FugaTomaDomiciliaria.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fugaTomaDomiciliaria");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FugaTomaDomiciliaria.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.FugaLineaConduccion != null && request.FugaLineaConduccion.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fugaLineaConduccion");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FugaLineaConduccion.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.FugaLineaDistribucion != null && request.FugaLineaDistribucion.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fugaLineaDistribucion");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FugaLineaDistribucion.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.FallaAguaPotableElectrica != null && request.FallaAguaPotableElectrica.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fallaAguaPotableElectrica");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FallaAguaPotableElectrica.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.FallaAguaPotableCentroControl != null && request.FallaAguaPotableCentroControl.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fallaAguaPotableCentroControl");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FallaAguaPotableCentroControl.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.FallaAguaPotableBombeo != null && request.FallaAguaPotableBombeo.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fallaAguaPotableBombeo");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FallaAguaPotableBombeo.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.FallaAguaResidualPotableElectrica != null && request.FallaAguaResidualPotableElectrica.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fallaAguaResidualElectrica");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FallaAguaResidualPotableElectrica.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.FallaAguaResidualCentroControl != null && request.FallaAguaResidualCentroControl.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fallaAguaResidualCentroControl");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FallaAguaResidualCentroControl.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.FallaAguaResidualBombeo != null && request.FallaAguaResidualBombeo.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fallaAguaResidualBombeo");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FallaAguaResidualBombeo.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.RecoleccionResidualAtendido != null && request.RecoleccionResidualAtendido.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "recoleccionResidualAtendido");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.RecoleccionResidualAtendido.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.RecoleccionResidualColector != null && request.RecoleccionResidualColector.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "recoleccionResidualColector");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.RecoleccionResidualColector.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.RecoleccionResidualVisita != null && request.RecoleccionResidualVisita.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "recoleccionResidualVisita");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.RecoleccionResidualVisita.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.FallaTratamientoEquipos != null && request.FallaTratamientoEquipos.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fallaTratamientoEquipos");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FallaTratamientoEquipos.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.FallaTratamientoAereacion != null && request.FallaTratamientoAereacion.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fallaTratamientoAereacion");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FallaTratamientoAereacion.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.FallTratamientoRecirculacion != null && request.FallTratamientoRecirculacion.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fallaTratamientoRecirculacion");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FallTratamientoRecirculacion.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.FallTratamientoSedimentacion != null && request.FallTratamientoSedimentacion.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fallaTratamientoSedimentacion");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FallTratamientoSedimentacion.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        if(request.FallTratamientoDesinfeccion != null && request.FallTratamientoDesinfeccion.Value > 0){
            var incidenType = this.context.TiposIncidencia.FirstOrDefault( item => item.Nombre == "fallaTratamientoDesinfeccion");
            if( incidenType != null){
                var incidencia = new Incidencia(){
                    Valor = request.FallTratamientoDesinfeccion.Value,
                    Fecha = request.Fecha,
                    UltimaActualizacion = DateTime.Now,
                    Oficina = oficina,
                    Usuario = usuario,
                    TipoIncidencia = incidenType
                };
                response.Add(incidencia);
            }
        }

        return response;
    }

}
