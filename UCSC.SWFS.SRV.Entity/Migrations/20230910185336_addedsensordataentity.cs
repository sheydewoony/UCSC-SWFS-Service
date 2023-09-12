using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UCSC.SWFS.SRV.Entity.Migrations
{
    /// <inheritdoc />
    public partial class addedsensordataentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sensordata",
                columns: table => new
                {
                    sensordataid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sensorid = table.Column<int>(type: "integer", nullable: false),
                    sensortype = table.Column<string>(type: "text", nullable: false),
                    port = table.Column<int>(type: "integer", nullable: false),
                    plantid = table.Column<int>(type: "integer", nullable: false),
                    deviceid = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<double>(type: "double precision", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    createdby = table.Column<int>(type: "integer", nullable: false),
                    createdon = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modifiedby = table.Column<int>(type: "integer", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensordata", x => x.sensordataid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sensordata");
        }
    }
}
