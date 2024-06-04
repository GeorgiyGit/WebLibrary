using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Categories.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addbuilders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TagTypes",
                columns: new[] { "Id", "IsCancelable", "IsCompraced" },
                values: new object[,]
                {
                    { "BookType", true, true },
                    { "LanguageTag", true, true },
                    { "Tag", true, false }
                });

            migrationBuilder.InsertData(
                table: "TagTypeTranslatedTexts",
                columns: new[] { "Id", "LanguageCode", "Value", "ValueEntityId" },
                values: new object[,]
                {
                    { 1, "en-US", "Languages", "LanguageTag" },
                    { 2, "sk-SK", "Jazyky", "LanguageTag" },
                    { 3, "en-US", "Tag", "Tag" },
                    { 4, "sk-SK", "Štítok", "Tag" },
                    { 5, "en-US", "Type", "BookType" },
                    { 6, "sk-SK", "Typ", "BookType" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "DataCreationTime", "DataLastDeleteTime", "DataLastEditTime", "IsDeleted", "IsEdited", "TypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 4, 16, 4, 57, 564, DateTimeKind.Utc).AddTicks(3474), null, null, false, false, "LanguageTag" },
                    { 2, new DateTime(2024, 6, 4, 16, 4, 57, 564, DateTimeKind.Utc).AddTicks(3479), null, null, false, false, "LanguageTag" }
                });

            migrationBuilder.InsertData(
                table: "TagTranslatedTexts",
                columns: new[] { "Id", "LanguageCode", "Value", "ValueEntityId" },
                values: new object[,]
                {
                    { 1, "en-US", "English", 1 },
                    { 2, "sk-SK", "Angličtina", 1 },
                    { 3, "en-US", "Slovak", 2 },
                    { 4, "sk-SK", "Slovenčina", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TagTranslatedTexts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TagTranslatedTexts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TagTranslatedTexts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TagTranslatedTexts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TagTypeTranslatedTexts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TagTypeTranslatedTexts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TagTypeTranslatedTexts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TagTypeTranslatedTexts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TagTypeTranslatedTexts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TagTypeTranslatedTexts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TagTypes",
                keyColumn: "Id",
                keyValue: "BookType");

            migrationBuilder.DeleteData(
                table: "TagTypes",
                keyColumn: "Id",
                keyValue: "Tag");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TagTypes",
                keyColumn: "Id",
                keyValue: "LanguageTag");
        }
    }
}
