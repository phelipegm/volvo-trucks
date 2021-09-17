using Microsoft.EntityFrameworkCore.Migrations;

namespace VolvoTruck.Data.Migrations
{
    public partial class AddTruck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TruckModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckModelId = table.Column<int>(type: "int", nullable: false),
                    ManufactureYear = table.Column<int>(type: "int", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trucks_TruckModels_TruckModelId",
                        column: x => x.TruckModelId,
                        principalTable: "TruckModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_TruckModelId",
                table: "Trucks",
                column: "TruckModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropTable(
                name: "TruckModels");
        }
    }
}
