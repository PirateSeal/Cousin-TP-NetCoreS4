using System.Collections.Generic;
using System.Threading.Tasks;
using ITI.PrimarySchool.DAL;

namespace ITI.PrimarySchool.WebApp.Services
{
    public class GitHubService
    {
        private readonly GitHubClient _gitHubClient;
        private readonly StudentGateway _studentGateway;
        private readonly UserGateway _userGateway;

        public GitHubService( GitHubClient gitHubClient, StudentGateway studentGateway, UserGateway userGateway )
        {
            _gitHubClient = gitHubClient;
            _studentGateway = studentGateway;
            _userGateway = userGateway;
        }

        public async Task<Result<IEnumerable<FollowedStudentData>>> GetFollowedStudents( int userId )
        {
            var user = await _userGateway.FindGitHubUser( userId );
            if( user.HasError )
                return Result.Failure<IEnumerable<FollowedStudentData>>( user.Status, user.ErrorMessage );

            var logins = await _gitHubClient.GetFollowedUsers( user.Content.GithubAccessToken );
            var students = await _studentGateway.GetByGitHubLogin( logins );

            return Result.Success( students );
        }
    }
}
