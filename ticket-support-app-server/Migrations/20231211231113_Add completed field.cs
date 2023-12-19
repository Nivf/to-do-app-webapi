using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ticket_support_app_server.Migrations
{
    /// <inheritdoc />
    public partial class Addcompletedfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Ticket",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Ticket");
        }
    }
}
