using System.Data.Entity;
using System.Security.Claims;
using SicemOperation.Data;
using SicemOperation.Entities;
using SicemOperation.Models;

namespace SicemOperation.Services
{

    public class IncidenceService( ILogger<IncidenceService> l, SicemOperationContext context, IHttpContextAccessor _httpContextAccessor) {

        private readonly ILogger<IncidenceService> logger = l;
        private readonly SicemOperationContext sicemOperationContext = context ;
        private readonly IHttpContextAccessor httpContextAccessor = _httpContextAccessor;

        public void RegisterIncidence( NewRecordRequest request){

            // * get current user id
            var userId = Convert.ToInt32(httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var usuario = this.sicemOperationContext.Usuarios.First( item => item.Id == userId);
            var oficina = sicemOperationContext.Oficinas.First();


            // * From the request make list of incidents
            var incidenceAdapter = new IncidenceAdapter( this.sicemOperationContext);
            IEnumerable<Incidencia> incidents = incidenceAdapter.GetIncidents(request, oficina, usuario);


            // * save the record
            sicemOperationContext.Incidencias.AddRange(incidents);
            sicemOperationContext.SaveChanges();
        }

        public IEnumerable<Dictionary<string,object>> IncidentsTypesGetIncidentsGrid(int year, int month ){
            var response = new List<Dictionary<string, object>>();

            var dateRange = SicemOperation.Helpers.RangeDate.GetRange(new DateTime(year, month, 1));
            var _desde = new DateTime(year, month, 1);
            var _hasta = new DateTime(year, month, dateRange[1]);

            // * get the incidents types
            var incidentTypes = this.sicemOperationContext.TiposIncidencia.ToList();
            foreach(var incidentType in incidentTypes){
                
                // * get the incidents of the current month and the current incidenty type
                var incidents = this.sicemOperationContext.Incidencias
                    .Include( item => item.TipoIncidencia)
                    .Where( item => item.Eliminado == null && item.Fecha.Date >= _desde && item.Fecha.Date <= _hasta)
                    .Where( item => item.TipoIncidencia == incidentType)
                    .GroupBy( item => item.Fecha.Date)
                    .ToList();

                // * created a array that represent the total days of the month and set the toal incidents
                var records = new int[dateRange[1]];
                foreach(var group in incidents){
                    records[ group.Key.Day - 1] = group.Sum( item => item.Valor);
                }

                response.Add( new Dictionary<string, object>{
                    {"group", incidentType.Grupo},
                    {"name", incidentType.Descripcion},
                    {"records", records}
                });
            }

            return response;
        }


        /// <summary>
        /// Fake data for testing
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="count"></param>
        public void FakeData(int year, int month, int count){

            var _rangedDate = SicemOperation.Helpers.RangeDate.GetRange( new DateTime(year, month,1));

            var random = new Random();

            var fakedData = new List<Incidencia>();

            var usuario = this.sicemOperationContext.Usuarios.First();
            var oficina = this.sicemOperationContext.Oficinas.First();
            var incidenceAdapter = new IncidenceAdapter(this.sicemOperationContext);

            for(int i = 0; i<count; i++){
                var _request =  new NewRecordRequest(){
                    Fecha = new DateTime( year, month, random.Next(_rangedDate[0],_rangedDate[1])),
                    FugaTomaDomiciliaria = random.Next(0,66),
                    FugaLineaConduccion = random.Next(0,66),
                    FugaLineaDistribucion = random.Next(0,66),
                    FallaAguaPotableElectrica = random.Next(0,66),
                    FallaAguaPotableCentroControl = random.Next(0,66),
                    FallaAguaPotableBombeo = random.Next(0,66),
                    FallaAguaResidualPotableElectrica = random.Next(0,66),
                    FallaAguaResidualCentroControl = random.Next(0,66),
                    FallaAguaResidualBombeo = random.Next(0,66),
                    RecoleccionResidualAtendido = random.Next(0,66),
                    RecoleccionResidualColector = random.Next(0,66),
                    RecoleccionResidualVisita = random.Next(0,66),
                    FallaTratamientoEquipos = random.Next(0,66),
                    FallaTratamientoAereacion = random.Next(0,66),
                    FallTratamientoRecirculacion = random.Next(0,66),
                    FallTratamientoSedimentacion = random.Next(0,66),
                    FallTratamientoDesinfeccion = random.Next(0,66),
                };
                
                IEnumerable<Incidencia> incidents = incidenceAdapter.GetIncidents(_request, oficina, usuario);

                fakedData.AddRange(incidents);
            }

            sicemOperationContext.Incidencias.AddRange(fakedData);
            sicemOperationContext.SaveChanges();
        }

    }

    public class IncidentsTypes {
        public static List<Dictionary<string,object>> GetIncidentsTypes(){
            return new List<Dictionary<string,object>>()
            {
                new Dictionary<string,object>
                {
                    { "columnName", "fugaTomaDomiciliaria" },
                    { "name", "Fugas en tomas domiciliarias" },
                    { "group", "Fugas" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "fugaLineaConduccion" },
                    { "name", "Fugas en lineas de conduccion" },
                    { "group", "Fugas" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "fugaLineaDistribucion" },
                    { "name", "Fugas en redes de distribucion" },
                    { "group", "Fugas" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "fallaAguaPotableElectrica" },
                    { "name", "Subestaciones electricas" },
                    { "group", "Falla de equipos  electromecanicos en agua potable" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "fallaAguaPotableCentroControl" },
                    { "name", "Centro de control de motores" },
                    { "group", "Falla de equipos  electromecanicos en agua potable" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "fallaAguaPotableBombeo" },
                    { "name", "Equipo de bombeo" },
                    { "group", "Falla de equipos  electromecanicos en agua potable" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "fallaAguaResidualPotableElectrica" },
                    { "name", "Subestaciones electricas" },
                    { "group", "Falla de equipos  electromecanicos en aguas residuales" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "fallaAguaResidualCentroControl" },
                    { "name", "Centro de control de motores" },
                    { "group", "Falla de equipos  electromecanicos en aguas residuales" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "fallaAguaResidualBombeo" },
                    { "name", "Equipo de bombeo" },
                    { "group", "Falla de equipos  electromecanicos en aguas residuales" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "recoleccionResidualAtendido" },
                    { "name", "No. De rebosamientos de agua residual atendidos" },
                    { "group", "Recoleccion aguas residuales" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "recoleccionResidualColector" },
                    { "name", "Colectores desasolvados" },
                    { "group", "Recoleccion aguas residuales" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "recoleccionResidualVisita" },
                    { "name", "Pozos de visita desasolvados" },
                    { "group", "Recoleccion aguas residuales" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "fallaTratamientoEquipos" },
                    { "name", "Equipos de pretratamiento" },
                    { "group", "Fallas en plantas de tratamiento de aguas residuales" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "fallaTratamientoAereacion" },
                    { "name", "Sistema de Aereacion" },
                    { "group", "Fallas en plantas de tratamiento de aguas residuales" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "fallTratamientoRecirculacion" },
                    { "name", "Equipos de Recirculacion" },
                    { "group", "Fallas en plantas de tratamiento de aguas residuales" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "fallTratamientoSedimentacion" },
                    { "name", "Sistemas de sedimentacion" },
                    { "group", "Fallas en plantas de tratamiento de aguas residuales" }
                },
                new Dictionary<string,object>
                {
                    { "columnName", "fallTratamientoDesinfeccion" },
                    { "name", "Sistemas de desinfeccion" },
                    { "group", "Fallas en plantas de tratamiento de aguas residuales" }
                }
            };
        }
    }
}