using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Project.EF.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Admins_Admin_Id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Admin_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Admin_Id",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Admin_Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Admin_Id",
                table: "Orders",
                column: "Admin_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Admins_Admin_Id",
                table: "Orders",
                column: "Admin_Id",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
