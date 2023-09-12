using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCSC.SWFS.SRV.Entity.Migrations
{
    /// <inheritdoc />
    public partial class renamed_sensorid_to_deviceid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sensorid",
                table: "sensordata");

            migrationBuilder.RenameColumn(
                name: "sensortype",
                table: "sensordata",
                newName: "devicetype");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "devicetype",
                table: "sensordata",
                newName: "sensortype");

            migrationBuilder.AddColumn<int>(
                name: "sensorid",
                table: "sensordata",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
