using SicemOperation.Data;
using SicemOperation.Entities;
using SicemOperation.Models;

namespace SicemOperation.Services
{

    public class AuthService( ILogger<AuthService> l, SicemOperationContext context) {

        private readonly ILogger<AuthService> logger = l;
        private readonly SicemOperationContext sicemOperationContext = context ;


        public Usuario? ValidateUser(LoginRequest loginRequest){
            return this.sicemOperationContext.Usuarios
                .Where( element => element.Correo == loginRequest.User)
                .ToList()
                .FirstOrDefault( user => BCrypt.Net.BCrypt.Verify( loginRequest.Password, user.Password) );
        }

    }
}