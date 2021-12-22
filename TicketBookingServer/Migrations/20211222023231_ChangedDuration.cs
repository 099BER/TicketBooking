using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketBookingServer.Migrations
{
    public partial class ChangedDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Movies",
                newName: "Duration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Movies",
                newName: "duration");
        }
    }
}
