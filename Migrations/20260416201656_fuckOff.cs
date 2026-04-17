using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class fuckOff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Activityys",
                columns: new[] { "ActivityId", "Duration", "Name", "Type" },
                values: new object[] { 5, 23, "BaseBall", "Compatable" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activityys",
                keyColumn: "ActivityId",
                keyValue: 5);
        }
    }
}
