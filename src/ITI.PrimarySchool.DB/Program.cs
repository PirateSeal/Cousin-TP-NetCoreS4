﻿using System;
using System.IO;
using System.Reflection;
using DbUp;
using DbUp.Engine;
using Microsoft.Extensions.Configuration;

namespace ITI.PrimarySchool.DB
{
    public class Program
    {
        private static IConfiguration _configuration;

        private static IConfiguration Configuration
        {
            get
            {
                if( _configuration == null )
                    _configuration = new ConfigurationBuilder()
                        .SetBasePath( Directory.GetCurrentDirectory() )
                        .AddJsonFile( "appsettings.json", false )
                        .AddEnvironmentVariables()
                        .Build();

                return _configuration;
            }
        }

        public static int Main( string[] args )
        {
            string connectionString = Configuration["ConnectionStrings:PrimarySchoolDB"];

            EnsureDatabase.For.SqlDatabase( connectionString );

            UpgradeEngine upgrader =
                DeployChanges.To
                    .SqlDatabase( connectionString )
                    .WithScriptsEmbeddedInAssembly( Assembly.GetExecutingAssembly() )
                    .LogToConsole()
                    .Build();

            DatabaseUpgradeResult result = upgrader.PerformUpgrade();

            if( !result.Successful )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine( result.Error );
                Console.ResetColor();

                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( "Success!" );
            Console.ResetColor();
            return 0;
        }
    }
}
