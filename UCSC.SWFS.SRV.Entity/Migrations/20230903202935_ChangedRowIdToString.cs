using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCSC.SWFS.SRV.Entity.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRowIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "rowid",
                table: "plants",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "rowid",
                table: "plants",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
