using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NplayBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimarySimpleChordsIdToSong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PrimarySimpleChordsId",
                table: "Songs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "SimpleChords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("23a5d7e5-9c9d-4f3c-84b2-4f2e10a2e03a"),
                columns: new[] { "Approved", "Version" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("3a69d00e-91f4-4a91-9298-6e5786a1f5e3"),
                columns: new[] { "Approved", "Version" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("95f6d2f4-9eb2-4e17-a5ea-d65c7ed1b6b2"),
                columns: new[] { "Approved", "Version" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("a1f5c3d1-8b2a-4e2a-a7c8-83716c1d8cb8"),
                columns: new[] { "Approved", "Version" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("d9e73f0a-89ba-4b8b-9d2c-3e537d2d7ea5"),
                columns: new[] { "Approved", "Version" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("e9c2c7ab-3e93-4fb3-b0a7-36bfb6e70df1"),
                columns: new[] { "Approved", "Version" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("591aead4-1d88-4366-bfac-5f67f3fc1695"),
                column: "PrimarySimpleChordsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("747a77ac-4a1a-4a96-957b-6c37136b3fb2"),
                column: "PrimarySimpleChordsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("7c5ecbd8-5a76-4eb5-984c-a3bc90be5244"),
                column: "PrimarySimpleChordsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("93c46f97-0fd3-4d58-9875-72417acf0924"),
                column: "PrimarySimpleChordsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("b63b2c08-f150-4bb8-a702-7805194e64eb"),
                columns: new[] { "Approved", "PrimarySimpleChordsId" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("ce6e5559-4d14-442c-8490-c3e415d5420a"),
                column: "PrimarySimpleChordsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("f4b3b3b4-1d88-4366-bfac-5f67f3fc1695"),
                column: "PrimarySimpleChordsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("fedd2b44-d9ea-47e4-817c-cd924aacf935"),
                column: "PrimarySimpleChordsId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimarySimpleChordsId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "SimpleChords");

            migrationBuilder.UpdateData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("23a5d7e5-9c9d-4f3c-84b2-4f2e10a2e03a"),
                column: "Approved",
                value: true);

            migrationBuilder.UpdateData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("3a69d00e-91f4-4a91-9298-6e5786a1f5e3"),
                column: "Approved",
                value: true);

            migrationBuilder.UpdateData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("95f6d2f4-9eb2-4e17-a5ea-d65c7ed1b6b2"),
                column: "Approved",
                value: true);

            migrationBuilder.UpdateData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("a1f5c3d1-8b2a-4e2a-a7c8-83716c1d8cb8"),
                column: "Approved",
                value: true);

            migrationBuilder.UpdateData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("d9e73f0a-89ba-4b8b-9d2c-3e537d2d7ea5"),
                column: "Approved",
                value: true);

            migrationBuilder.UpdateData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("e9c2c7ab-3e93-4fb3-b0a7-36bfb6e70df1"),
                column: "Approved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("b63b2c08-f150-4bb8-a702-7805194e64eb"),
                column: "Approved",
                value: true);
        }
    }
}
