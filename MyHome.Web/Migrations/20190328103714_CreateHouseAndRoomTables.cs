using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHome.Web.Migrations
{
    public partial class CreateHouseAndRoomTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    HouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_House_HouseId",
                        column: x => x.HouseId,
                        principalTable: "House",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "House",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Résidence principale" });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "HouseId", "Name" },
                values: new object[] { 1, 1, "Séjour" });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "HouseId", "Name" },
                values: new object[] { 2, 1, "Chambre 1" });

            migrationBuilder.CreateIndex(
                name: "IX_House_Name",
                table: "House",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_HouseId",
                table: "Room",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Name",
                table: "Room",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "House");
        }
    }
}
