using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UCSC.SWFS.SRV.Entity.Migrations
{
    /// <inheritdoc />
    public partial class AddedPlantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plants",
                columns: table => new
                {
                    plantid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    plantname = table.Column<string>(type: "text", nullable: false),
                    planttype = table.Column<string>(type: "text", nullable: false),
                    rowid = table.Column<int>(type: "integer", nullable: false),
                    columnid = table.Column<int>(type: "integer", nullable: false),
                    plantingdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    waterrequirement = table.Column<int>(type: "integer", nullable: false),
                    fertilizerrequirement = table.Column<int>(type: "integer", nullable: false),
                    rectemperaturemin = table.Column<int>(type: "integer", nullable: false),
                    rectemperaturemax = table.Column<int>(type: "integer", nullable: false),
                    reclightintensity = table.Column<int>(type: "integer", nullable: false),
                    recsoilmoisture = table.Column<int>(type: "integer", nullable: false),
                    healthstatus = table.Column<string>(type: "text", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    createdby = table.Column<int>(type: "integer", nullable: false),
                    createdon = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modifiedby = table.Column<int>(type: "integer", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plants", x => x.plantid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plants");
        }
    }
}
