using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamProjectAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeamMemberName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "jack.baker@student.edu", "Jack Baker" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "alex.johnson@student.edu", "Alex Johnson" });
        }
    }
}
