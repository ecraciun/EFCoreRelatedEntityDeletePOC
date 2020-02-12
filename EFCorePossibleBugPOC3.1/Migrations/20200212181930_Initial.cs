using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCorePossibleBugPOC3._1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Middles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Foo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Middles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AZLast2s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiddleId = table.Column<int>(nullable: true),
                    Bar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AZLast2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AZLast2s_Middles_MiddleId",
                        column: x => x.MiddleId,
                        principalTable: "Middles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AZLast3s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiddleId = table.Column<int>(nullable: true),
                    Bar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AZLast3s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AZLast3s_Middles_MiddleId",
                        column: x => x.MiddleId,
                        principalTable: "Middles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Firsts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiddleId = table.Column<int>(nullable: true),
                    Bar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firsts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Firsts_Middles_MiddleId",
                        column: x => x.MiddleId,
                        principalTable: "Middles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZFirst2s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiddleId = table.Column<int>(nullable: true),
                    Bar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZFirst2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZFirst2s_Middles_MiddleId",
                        column: x => x.MiddleId,
                        principalTable: "Middles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZFirst3s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiddleId = table.Column<int>(nullable: true),
                    Bar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZFirst3s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZFirst3s_Middles_MiddleId",
                        column: x => x.MiddleId,
                        principalTable: "Middles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZLasts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiddleId = table.Column<int>(nullable: true),
                    Bar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZLasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZLasts_Middles_MiddleId",
                        column: x => x.MiddleId,
                        principalTable: "Middles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AZLast2s_MiddleId",
                table: "AZLast2s",
                column: "MiddleId");

            migrationBuilder.CreateIndex(
                name: "IX_AZLast3s_MiddleId",
                table: "AZLast3s",
                column: "MiddleId");

            migrationBuilder.CreateIndex(
                name: "IX_Firsts_MiddleId",
                table: "Firsts",
                column: "MiddleId");

            migrationBuilder.CreateIndex(
                name: "IX_ZFirst2s_MiddleId",
                table: "ZFirst2s",
                column: "MiddleId");

            migrationBuilder.CreateIndex(
                name: "IX_ZFirst3s_MiddleId",
                table: "ZFirst3s",
                column: "MiddleId");

            migrationBuilder.CreateIndex(
                name: "IX_ZLasts_MiddleId",
                table: "ZLasts",
                column: "MiddleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AZLast2s");

            migrationBuilder.DropTable(
                name: "AZLast3s");

            migrationBuilder.DropTable(
                name: "Firsts");

            migrationBuilder.DropTable(
                name: "ZFirst2s");

            migrationBuilder.DropTable(
                name: "ZFirst3s");

            migrationBuilder.DropTable(
                name: "ZLasts");

            migrationBuilder.DropTable(
                name: "Middles");
        }
    }
}
