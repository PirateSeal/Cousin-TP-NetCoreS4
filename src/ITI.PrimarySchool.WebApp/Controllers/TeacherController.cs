using System.Threading.Tasks;
using ITI.PrimarySchool.DAL;
using ITI.PrimarySchool.WebApp.Authentication;
using ITI.PrimarySchool.WebApp.Models.TeacherViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI.PrimarySchool.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]
    public class TeacherController : Controller
    {
        private readonly ClassGateway _classGateway;
        private readonly TeacherGateway _teacherGateway;

        public TeacherController( TeacherGateway teacherGateway, ClassGateway classGateway )
        {
            _teacherGateway = teacherGateway;
            _classGateway = classGateway;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeacherList()
        {
            var result = await _teacherGateway.GetAll();
            return Ok( result );
        }

        [HttpPost( "{id}/changeAvailability" )]
        public async Task<IActionResult> ChangeAvailability( int id )
        {
            Result result = await _teacherGateway.ChangeAvailability( id );
            return Ok( result );
        }

        [HttpGet( "{id}", Name = "GetTeacher" )]
        public async Task<IActionResult> GetTeacherById( int id )
        {
            var result = await _teacherGateway.FindById( id );
            return this.CreateResult( result );
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher( [FromBody] TeacherViewModel model )
        {
            var result = await _teacherGateway.Create( model.FirstName, model.LastName );
            return this.CreateResult( result, o =>
            {
                o.RouteName = "GetTeacher";
                o.RouteValues = id => new {id};
            } );
        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdateTeacher( int id, [FromBody] TeacherViewModel model )
        {
            Result result = await _teacherGateway.Update( id, model.FirstName, model.LastName );
            return this.CreateResult( result );
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeleteTeacher( int id )
        {
            Result result = await _teacherGateway.Delete( id );
            return this.CreateResult( result );
        }

        [HttpPost( "{id}/assignClass" )]
        public async Task<IActionResult> AssignClass( int id, [FromBody] AssignClassViewModel model )
        {
            Result result = await _teacherGateway.AssignClass( id, model.ClassId );
            return this.CreateResult( result );
        }

        [HttpGet( "{id}/assignedClass" )]
        public async Task<IActionResult> AssignedClass( int id )
        {
            var result = await _classGateway.AssignedClass( id );
            return this.CreateResult( result );
        }
    }
}
