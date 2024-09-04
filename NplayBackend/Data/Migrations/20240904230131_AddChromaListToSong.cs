using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NplayBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddChromaListToSong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChromaArray",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("591aead4-1d88-4366-bfac-5f67f3fc1695"),
                column: "ChromaArray",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("747a77ac-4a1a-4a96-957b-6c37136b3fb2"),
                column: "ChromaArray",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("7c5ecbd8-5a76-4eb5-984c-a3bc90be5244"),
                column: "ChromaArray",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("93c46f97-0fd3-4d58-9875-72417acf0924"),
                column: "ChromaArray",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("b63b2c08-f150-4bb8-a702-7805194e64eb"),
                column: "ChromaArray",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("ce6e5559-4d14-442c-8490-c3e415d5420a"),
                column: "ChromaArray",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("f4b3b3b4-1d88-4366-bfac-5f67f3fc1695"),
                column: "ChromaArray",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("fedd2b44-d9ea-47e4-817c-cd924aacf935"),
                column: "ChromaArray",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChromaArray",
                table: "Songs");
        }
    }
}
