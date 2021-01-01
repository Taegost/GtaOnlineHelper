using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WebFrontEnd.Data.Migrations
{
    public partial class SeedVcVehicleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(r => r.EndsWith("VcVehicleSeedData.sql"));
            string sqlToRun = "";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                sqlToRun = reader.ReadToEnd();
            }
            migrationBuilder.Sql(sqlToRun);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
