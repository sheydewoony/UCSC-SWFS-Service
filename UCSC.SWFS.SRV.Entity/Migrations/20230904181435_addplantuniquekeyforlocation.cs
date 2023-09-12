using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCSC.SWFS.SRV.Entity.Migrations
{
    /// <inheritdoc />
    public partial class addplantuniquekeyforlocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_plants_rowid_columnid",
                table: "plants",
                columns: new[] { "rowid", "columnid" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_plants_rowid_columnid",
                table: "plants");
        }
    }
}
