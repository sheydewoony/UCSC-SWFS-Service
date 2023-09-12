using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UCSC.SWFS.SRV.Entity.Migrations
{
    /// <inheritdoc />
    public partial class addeddeviceandsensors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task");

            migrationBuilder.DropColumn(
                name: "configuration",
                table: "devices");

            migrationBuilder.DropColumn(
                name: "isonline",
                table: "devices");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "devices",
                newName: "unit");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "devices",
                newName: "status");

            migrationBuilder.AddColumn<string>(
                name: "devicename",
                table: "devices",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "devicetype",
                table: "devices",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "maxvalue",
                table: "devices",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "minvalue",
                table: "devices",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "plantid",
                table: "devices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "port",
                table: "devices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "planttask",
                columns: table => new
                {
                    taskid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scheduleid = table.Column<int>(type: "integer", nullable: false),
                    deviceid = table.Column<int>(type: "integer", nullable: false),
                    taskname = table.Column<string>(type: "text", nullable: false),
                    taskdescription = table.Column<string>(type: "text", nullable: false),
                    starttime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    nextiterationtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    endtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    interval = table.Column<TimeSpan>(type: "interval", nullable: false),
                    volume = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    createdby = table.Column<int>(type: "integer", nullable: false),
                    createdon = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modifiedby = table.Column<int>(type: "integer", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planttask", x => x.taskid);
                    table.ForeignKey(
                        name: "FK_planttask_devices_deviceid",
                        column: x => x.deviceid,
                        principalTable: "devices",
                        principalColumn: "deviceid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_planttask_schedule_scheduleid",
                        column: x => x.scheduleid,
                        principalTable: "schedule",
                        principalColumn: "scheduleid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_planttask_deviceid",
                table: "planttask",
                column: "deviceid");

            migrationBuilder.CreateIndex(
                name: "IX_planttask_scheduleid",
                table: "planttask",
                column: "scheduleid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "planttask");

            migrationBuilder.DropColumn(
                name: "devicename",
                table: "devices");

            migrationBuilder.DropColumn(
                name: "devicetype",
                table: "devices");

            migrationBuilder.DropColumn(
                name: "maxvalue",
                table: "devices");

            migrationBuilder.DropColumn(
                name: "minvalue",
                table: "devices");

            migrationBuilder.DropColumn(
                name: "plantid",
                table: "devices");

            migrationBuilder.DropColumn(
                name: "port",
                table: "devices");

            migrationBuilder.RenameColumn(
                name: "unit",
                table: "devices",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "devices",
                newName: "name");

            migrationBuilder.AddColumn<string>(
                name: "configuration",
                table: "devices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isonline",
                table: "devices",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    taskid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    deviceid = table.Column<int>(type: "integer", nullable: false),
                    createdby = table.Column<int>(type: "integer", nullable: false),
                    createdon = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    endtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    interval = table.Column<TimeSpan>(type: "interval", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    modifiedby = table.Column<int>(type: "integer", nullable: false),
                    modifiedon = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    nextiterationtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    scheduleid = table.Column<int>(type: "integer", nullable: false),
                    starttime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    taskdescription = table.Column<string>(type: "text", nullable: false),
                    taskname = table.Column<string>(type: "text", nullable: false),
                    volume = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.taskid);
                    table.ForeignKey(
                        name: "FK_task_devices_deviceid",
                        column: x => x.deviceid,
                        principalTable: "devices",
                        principalColumn: "deviceid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_task_schedule_scheduleid",
                        column: x => x.scheduleid,
                        principalTable: "schedule",
                        principalColumn: "scheduleid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_task_deviceid",
                table: "task",
                column: "deviceid");

            migrationBuilder.CreateIndex(
                name: "IX_task_scheduleid",
                table: "task",
                column: "scheduleid");
        }
    }
}
