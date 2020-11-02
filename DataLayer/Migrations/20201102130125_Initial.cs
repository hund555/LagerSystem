using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Discription", "ItemName", "UserId" },
                values: new object[,]
                {
                    { 1, "Cat6 netkabel 3 meter langt", "Cat6 3m", null },
                    { 2, "Cat6 netkabel 4 meter langt", "Cat6 4m", null },
                    { 3, "Cat6 netkabel 6 meter langt", "Cat6 6m", null },
                    { 4, "HP bærbar i5-4210M, 16GB ram", "HP bærbar", null },
                    { 5, "HDMI kabel 1 meter langt", "HDMI 1m", null },
                    { 6, "HDMI kabel 3 meter langt", "HDMI 3m", null },
                    { 7, "Logitech mus", "Logitech mus", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Name" },
                values: new object[] { 1, "Allan" });

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserId",
                table: "Items",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
