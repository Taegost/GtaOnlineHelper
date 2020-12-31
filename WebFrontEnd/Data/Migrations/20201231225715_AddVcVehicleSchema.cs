using Microsoft.EntityFrameworkCore.Migrations;

namespace WebFrontEnd.Data.Migrations
{
    public partial class AddVcVehicleSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VcCollectionTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VcCollectionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VcRangeTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VcRangeTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VcVehicles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VcVehicles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VcPlates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    RangeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VcPlates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VcPlates_VcRangeTypes_RangeId",
                        column: x => x.RangeId,
                        principalTable: "VcRangeTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VcPlates_VcVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VcVehicles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVcVehicles",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    PlateId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVcVehicles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserVcVehicles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVcVehicles_VcPlates_PlateId",
                        column: x => x.PlateId,
                        principalTable: "VcPlates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VcCollections",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlateId = table.Column<int>(type: "INTEGER", nullable: false),
                    CollectionTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VcCollections", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VcCollections_VcCollectionTypes_CollectionTypeID",
                        column: x => x.CollectionTypeID,
                        principalTable: "VcCollectionTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VcCollections_VcPlates_PlateId",
                        column: x => x.PlateId,
                        principalTable: "VcPlates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserVcVehicles_PlateId",
                table: "UserVcVehicles",
                column: "PlateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVcVehicles_UserId",
                table: "UserVcVehicles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VcCollections_CollectionTypeID",
                table: "VcCollections",
                column: "CollectionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_VcCollections_PlateId",
                table: "VcCollections",
                column: "PlateId");

            migrationBuilder.CreateIndex(
                name: "IX_VcPlates_RangeId",
                table: "VcPlates",
                column: "RangeId");

            migrationBuilder.CreateIndex(
                name: "IX_VcPlates_VehicleId",
                table: "VcPlates",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVcVehicles");

            migrationBuilder.DropTable(
                name: "VcCollections");

            migrationBuilder.DropTable(
                name: "VcCollectionTypes");

            migrationBuilder.DropTable(
                name: "VcPlates");

            migrationBuilder.DropTable(
                name: "VcRangeTypes");

            migrationBuilder.DropTable(
                name: "VcVehicles");
        }
    }
}
