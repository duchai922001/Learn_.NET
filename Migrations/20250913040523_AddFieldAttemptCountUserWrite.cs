using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learn_Net.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldAttemptCountUserWrite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttemptCount",
                table: "UserWrites",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttemptCount",
                table: "UserWrites");
        }
    }
}
