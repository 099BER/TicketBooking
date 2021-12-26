using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketBookingServer.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChosenSeats_Orders_OrderId",
                table: "ChosenSeats");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ChosenSeats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenSeats_Orders_OrderId",
                table: "ChosenSeats",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChosenSeats_Orders_OrderId",
                table: "ChosenSeats");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ChosenSeats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenSeats_Orders_OrderId",
                table: "ChosenSeats",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
