using System.Threading.Tasks;
using ITI.PrimarySchool.DAL;

namespace ITI.PrimarySchool.WebApp.Services
{
    public class UserService
    {
        private readonly PasswordHasher _passwordHasher;
        private readonly UserGateway _userGateway;

        public UserService( UserGateway userGateway, PasswordHasher passwordHasher )
        {
            _userGateway = userGateway;
            _passwordHasher = passwordHasher;
        }

        public Task<Result<int>> CreatePasswordUser( string email, string password )
        {
            return _userGateway.CreatePasswordUser( email, _passwordHasher.HashPassword( password ) );
        }

        public async Task<UserData> FindUser( string email, string password )
        {
            UserData user = await _userGateway.FindByEmail( email );
            if( user != null && _passwordHasher.VerifyHashedPassword( user.Password, password ) ==
                PasswordVerificationResult.Success ) return user;

            return null;
        }
    }
}
