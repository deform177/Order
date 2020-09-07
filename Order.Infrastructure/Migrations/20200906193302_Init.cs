using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Order.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Source = table.Column<string>(nullable: true),
                    OperatorId = table.Column<string>(nullable: true),
                    OperationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    СustomerId = table.Column<int>(nullable: false),
                    ExecutorId = table.Column<int>(nullable: false),
                    Ditails = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    IsPayment = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityAuditInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedId = table.Column<int>(nullable: true),
                    UpdatedId = table.Column<int>(nullable: true),
                    DeletedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityAuditInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityAuditInfo_OperationLog_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "OperationLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityAuditInfo_OperationLog_DeletedId",
                        column: x => x.DeletedId,
                        principalTable: "OperationLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityAuditInfo_OperationLog_UpdatedId",
                        column: x => x.UpdatedId,
                        principalTable: "OperationLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntityModificationInfoId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Balance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_EntityAuditInfo_EntityModificationInfoId",
                        column: x => x.EntityModificationInfoId,
                        principalTable: "EntityAuditInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityAuditInfo_CreatedId",
                table: "EntityAuditInfo",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityAuditInfo_DeletedId",
                table: "EntityAuditInfo",
                column: "DeletedId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityAuditInfo_UpdatedId",
                table: "EntityAuditInfo",
                column: "UpdatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EntityModificationInfoId",
                table: "Users",
                column: "EntityModificationInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EntityAuditInfo");

            migrationBuilder.DropTable(
                name: "OperationLog");
        }
    }
}
