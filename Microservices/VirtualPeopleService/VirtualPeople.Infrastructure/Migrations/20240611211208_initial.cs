using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualPeople.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedCustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookCount = table.Column<int>(type: "int", nullable: false),
                    ImageGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsModerated = table.Column<bool>(type: "bit", nullable: false),
                    DataCreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataLastDeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataLastEditTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranslationTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembersCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationTeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranslationTeamMemberRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationTeamMemberRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamBookTranslationTeam",
                columns: table => new
                {
                    InPlansBooksId = table.Column<int>(type: "int", nullable: false),
                    InPlansTeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamBookTranslationTeam", x => new { x.InPlansBooksId, x.InPlansTeamsId });
                    table.ForeignKey(
                        name: "FK_TeamBookTranslationTeam_TeamBooks_InPlansBooksId",
                        column: x => x.InPlansBooksId,
                        principalTable: "TeamBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamBookTranslationTeam_TranslationTeam_InPlansTeamsId",
                        column: x => x.InPlansTeamsId,
                        principalTable: "TranslationTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamBookTranslationTeam1",
                columns: table => new
                {
                    CanceledBooksId = table.Column<int>(type: "int", nullable: false),
                    CanceledTeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamBookTranslationTeam1", x => new { x.CanceledBooksId, x.CanceledTeamsId });
                    table.ForeignKey(
                        name: "FK_TeamBookTranslationTeam1_TeamBooks_CanceledBooksId",
                        column: x => x.CanceledBooksId,
                        principalTable: "TeamBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamBookTranslationTeam1_TranslationTeam_CanceledTeamsId",
                        column: x => x.CanceledTeamsId,
                        principalTable: "TranslationTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamBookTranslationTeam2",
                columns: table => new
                {
                    InProcessBooksId = table.Column<int>(type: "int", nullable: false),
                    InProcessTeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamBookTranslationTeam2", x => new { x.InProcessBooksId, x.InProcessTeamsId });
                    table.ForeignKey(
                        name: "FK_TeamBookTranslationTeam2_TeamBooks_InProcessBooksId",
                        column: x => x.InProcessBooksId,
                        principalTable: "TeamBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamBookTranslationTeam2_TranslationTeam_InProcessTeamsId",
                        column: x => x.InProcessTeamsId,
                        principalTable: "TranslationTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslationTeamMemberRoleTranslatedTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueEntityId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationTeamMemberRoleTranslatedTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationTeamMemberRoleTranslatedTexts_TranslationTeamMemberRoles_ValueEntityId",
                        column: x => x.ValueEntityId,
                        principalTable: "TranslationTeamMemberRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslationTeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranslationTeamId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationTeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationTeamMembers_TranslationTeamMemberRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TranslationTeamMemberRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslationTeamMembers_TranslationTeam_TranslationTeamId",
                        column: x => x.TranslationTeamId,
                        principalTable: "TranslationTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookCount",
                table: "BookAuthors",
                column: "BookCount",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_TeamBookTranslationTeam_InPlansTeamsId",
                table: "TeamBookTranslationTeam",
                column: "InPlansTeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamBookTranslationTeam1_CanceledTeamsId",
                table: "TeamBookTranslationTeam1",
                column: "CanceledTeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamBookTranslationTeam2_InProcessTeamsId",
                table: "TeamBookTranslationTeam2",
                column: "InProcessTeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationTeamMemberRoleTranslatedTexts_ValueEntityId",
                table: "TranslationTeamMemberRoleTranslatedTexts",
                column: "ValueEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationTeamMembers_RoleId",
                table: "TranslationTeamMembers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationTeamMembers_TranslationTeamId",
                table: "TranslationTeamMembers",
                column: "TranslationTeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "TeamBookTranslationTeam");

            migrationBuilder.DropTable(
                name: "TeamBookTranslationTeam1");

            migrationBuilder.DropTable(
                name: "TeamBookTranslationTeam2");

            migrationBuilder.DropTable(
                name: "TranslationTeamMemberRoleTranslatedTexts");

            migrationBuilder.DropTable(
                name: "TranslationTeamMembers");

            migrationBuilder.DropTable(
                name: "TeamBooks");

            migrationBuilder.DropTable(
                name: "TranslationTeamMemberRoles");

            migrationBuilder.DropTable(
                name: "TranslationTeam");
        }
    }
}
