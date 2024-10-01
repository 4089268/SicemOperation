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

            var newRecord  = Incidencia.FromRequest(request);
            newRecord.Oficina = sicemOperationContext.Oficinas.First();

            // * save the record
            sicemOperationContext.Incidencias.Add( newRecord);
            sicemOperationContext.SaveChanges();
        }

    }
}