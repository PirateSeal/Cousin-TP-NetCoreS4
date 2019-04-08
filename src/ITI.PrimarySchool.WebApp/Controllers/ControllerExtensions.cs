using System;
using ITI.PrimarySchool.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ITI.PrimarySchool.WebApp.Controllers
{
    public static class ControllerExtensions
    {
        public static IActionResult CreateResult<T>( this Controller @this, Result<T> result )
        {
            return CreateResult( @this, result, new ActionResultOptions<T>( @this ) );
        }

        public static IActionResult CreateResult<T>(
            this Controller @this,
            Result<T> result,
            Action<ActionResultOptions<T>> options )
        {
            var o = new ActionResultOptions<T>( @this );
            options( o );
            return @this.CreateResult( result, o );
        }

        public static IActionResult CreateResult<T>(
            this Controller @this,
            Result<T> result,
            ActionResultOptions<T> options )
        {
            object value;
            if( !result.HasError ) value = result.Content;
            else value = result.ErrorMessage;

            switch( result.Status )
            {
                case Status.Ok:
                    return @this.Ok( value );
                case Status.NotFound:
                    return @this.NotFound( value );
                case Status.BadRequest:
                    return @this.BadRequest( value );
                case Status.Created:
                    return @this.CreatedAtRoute( options.RouteName, options.RouteValues( result.Content ), value );
                default:
                    throw new ArgumentException( "Unknown status.", nameof(result) );
            }
        }

        public static IActionResult CreateResult( this Controller @this, Result result )
        {
            switch( result.Status )
            {
                case Status.Ok:
                    return @this.Ok();
                case Status.NotFound:
                    return @this.NotFound( result.ErrorMessage );
                case Status.BadRequest:
                    return @this.BadRequest( result.ErrorMessage );
                default:
                    throw new ArgumentException( "Unknown status.", nameof(result) );
            }
        }
    }
}
