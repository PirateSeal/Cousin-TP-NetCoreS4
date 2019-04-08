using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ITI.PrimarySchool.DAL.Tests
{
    public static class TestHelpers
    {
        private static readonly Random Random = new Random();
        private static IConfiguration _configuration;

        public static string ConnectionString => Configuration["ConnectionStrings:PrimarySchoolDB"];

        private static IConfiguration Configuration
        {
            get
            {
                if( _configuration == null )
                    _configuration = new ConfigurationBuilder()
                        .SetBasePath( Directory.GetCurrentDirectory() )
                        .AddJsonFile( "appsettings.json", true )
                        .AddEnvironmentVariables()
                        .Build();

                return _configuration;
            }
        }

        public static string RandomTestName()
        {
            return string.Format( "Test-{0}", Guid.NewGuid().ToString().Substring( 24 ) );
        }

        public static DateTime RandomBirthDate( int age )
        {
            return DateTime.UtcNow.AddYears( -age ).AddMonths( Random.Next( -11, 0 ) ).Date;
        }

        public static string RandomLevel()
        {
            int levelIdx = Random.Next( 5 );
            if( levelIdx == 0 ) return "CP";
            if( levelIdx == 1 ) return "CE1";
            if( levelIdx == 2 ) return "CE2";
            if( levelIdx == 3 ) return "CM1";
            return "CM2";
        }
    }
}
