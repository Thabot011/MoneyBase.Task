using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyBase.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ShiftType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentType = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaxChats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agent_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ChatStatus = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastPollAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_Agent_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Shift",
                columns: new[] { "Id", "EndTime", "ShiftType", "StartTime" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new TimeOnly(16, 0, 0), 0, new TimeOnly(8, 0, 0) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new TimeOnly(0, 0, 0), 1, new TimeOnly(16, 0, 0) },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new TimeOnly(8, 0, 0), 2, new TimeOnly(0, 0, 0) },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new TimeOnly(0, 0, 0), 3, new TimeOnly(0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "ShiftId", "TeamName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "Team A" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("22222222-2222-2222-2222-222222222222"), "Team B" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new Guid("33333333-3333-3333-3333-333333333333"), "Team C" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("44444444-4444-4444-4444-444444444444"), "Overflow team" }
                });

            migrationBuilder.InsertData(
                table: "Agent",
                columns: new[] { "Id", "AgentType", "MaxChats", "TeamId" },
                values: new object[,]
                {
                    { new Guid("1a44ed26-47e4-477b-8a03-bab0d8926311"), 1, 6, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("1ca1a930-a8af-4bff-b70c-d8dcb3375d39"), 2, 8, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("2d99f557-8671-4eff-b461-c50871e16cc5"), 0, 4, new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("63fcef60-59c8-4d7c-bf65-6b66d3d414f3"), 0, 4, new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("68c4ca08-3825-444b-bc73-e95d0ae574c1"), 0, 4, new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("6eda5f9c-9284-4702-b6e5-684bbc797032"), 0, 4, new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("7d7094b1-2fc1-4943-b473-28e9b88aa806"), 0, 4, new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("835c96b0-6056-473c-ad26-93ccb557e480"), 1, 6, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("8611e452-7928-4ca6-8ba8-6c4bfffc74f5"), 0, 4, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("a1dd117d-0c48-49ea-bf9c-109f5ca25705"), 1, 6, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("b9595f82-3cf4-46d3-b7e8-e27946f3f396"), 0, 4, new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("bfd5bf77-839d-412f-a96d-191c05a63b45"), 1, 6, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("d8f367c4-7c5d-4978-9132-28af793186d1"), 0, 4, new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("e5f8a12d-dc8d-48f8-a754-bf5d9eaf38ab"), 3, 5, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("fb8ae7f6-d7e0-4b4f-9dcf-1724359ef47e"), 0, 4, new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agent_TeamId",
                table: "Agent",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_AgentId",
                table: "Chat",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_ShiftId",
                table: "Team",
                column: "ShiftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Shift");
        }
    }
}
