using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NplayBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Approved", "Artist", "BPM", "Chroma", "Difficulty", "Recognitions", "Scale", "SpotifyCode", "Title", "YoutubeCode" },
                values: new object[,]
                {
                    { new Guid("591aead4-1d88-4366-bfac-5f67f3fc1695"), true, "Ed Sheeran", null, 2, 1, null, "D", "spotify:track:6PCUP3dWmTjcTtXY02oFdT", "Castle on the Hill", "K0ibBPhiaG0" },
                    { new Guid("747a77ac-4a1a-4a96-957b-6c37136b3fb2"), true, "Ed Sheeran", null, 1, 2, null, "D", "spotify:track:34gCuhDGsG4bRPIf9bb02f", "Thinking Out Loud", "34gCuhDGsG4bRPIf9bb02f" },
                    { new Guid("7c5ecbd8-5a76-4eb5-984c-a3bc90be5244"), true, "Ed Sheeran", null, 2, 1, null, "E", "spotify:track:7qiZfU4dY1lWllzX7mPBI3", "Shape of You", null },
                    { new Guid("93c46f97-0fd3-4d58-9875-72417acf0924"), true, "Ed Sheeran", null, 8, 1, null, "G#", "spotify:track:0tgVpDi06FyKpA1z0VMD4v", "Perfect", "2Vv-BfVoq4g" },
                    { new Guid("b63b2c08-f150-4bb8-a702-7805194e64eb"), true, "Ed Sheeran", null, 0, 1, null, "C", "spotify:track:4btFHqumCO31GksfuBLLv3", "Overpass Graffiti", "k6ZoE4RrcDs" },
                    { new Guid("ce6e5559-4d14-442c-8490-c3e415d5420a"), true, "Ed Sheeran", null, 2, 1, null, "F", "spotify:track:1HNkqx9Ahdgi1Ixy2xkKkL", "Photograph", null },
                    { new Guid("f4b3b3b4-1d88-4366-bfac-5f67f3fc1695"), true, "Ed Sheeran", null, 2, 0, null, "D", "spotify:track:50nfwKoDiSYg8zOCREWAm5", "Shivers", "Il0S8BoucSA" },
                    { new Guid("fedd2b44-d9ea-47e4-817c-cd924aacf935"), true, "Ed Sheeran & Justin Bieber", null, 2, 0, null, "F#", "spotify:track:3HVWdVOQ0ZA45FuZGSfvns", "I don't care", "y83x7MgzWOA" }
                });

            migrationBuilder.InsertData(
                table: "SimpleChords",
                columns: new[] { "Id", "Approved", "Bridge", "Chorus", "ChorusEnd", "Intro", "Outro", "PreChorus", "SongId", "Verse", "VerseEnd" },
                values: new object[,]
                {
                    { new Guid("23a5d7e5-9c9d-4f3c-84b2-4f2e10a2e03a"), true, "[\"9\\u002Bm\",\"5\\u002B\",\"0\\u002B\",\"7\\u002B\"]", "[\"0\\u002B\",\"5\\u002B\",\"9\\u002Bm\",\"7\\u002B\"]", null, null, null, "[\"5\\u002B\",\"7\\u002B\",\"0\\u002B\",\"5\\u002B\",\"7\\u002B\",\"0\\u002B\",\"5\\u002B\",\"7\\u002B\"]", new Guid("591aead4-1d88-4366-bfac-5f67f3fc1695"), "[\"0\\u002B\",\"5\\u002B\",\"9\\u002Bm\",\"7\\u002B\"]", null },
                    { new Guid("3a69d00e-91f4-4a91-9298-6e5786a1f5e3"), true, null, "[\"0\\u002B\",\"9\\u002Bm\",\"5\\u002B\",\"7\\u002B\"]", null, null, null, null, new Guid("fedd2b44-d9ea-47e4-817c-cd924aacf935"), "[\"0\\u002B\",\"9\\u002Bm\",\"5\\u002B\",\"7\\u002B\"]", null },
                    { new Guid("95f6d2f4-9eb2-4e17-a5ea-d65c7ed1b6b2"), true, null, "[\"0\\u002B\",\"7\\u002B\",\"2\\u002Bm\",\"5\\u002B\"]", "[\"7\\u002B\"]", null, null, "[\"7\\u002B\",\"5\\u002B\",\"7\\u002B\",\"5\\u002B\",\"7\\u002B\"]", new Guid("b63b2c08-f150-4bb8-a702-7805194e64eb"), "[\"9\\u002Bm\",\"7\\u002B\",\"5\\u002B\"]", null },
                    { new Guid("a1f5c3d1-8b2a-4e2a-a7c8-83716c1d8cb8"), true, null, "[\"9\\u002Bm\",\"5\\u002B\",\"0\\u002B\",\"7\\u002B\"]", null, null, null, null, new Guid("f4b3b3b4-1d88-4366-bfac-5f67f3fc1695"), "[\"9\\u002Bm\",\"5\\u002B\",\"0\\u002B\",\"7\\u002B\"]", null },
                    { new Guid("d9e73f0a-89ba-4b8b-9d2c-3e537d2d7ea5"), true, null, "[\"0\\u002B\",\"9\\u002Bm7\",\"5\\u002B\",\"7\\u002B\"]", "[\"9\\u002Bm\",\"7\\u002B\",\"5\\u002B\",\"0\\u002B\",\"5\\u002B\",\"7\\u002B\",\"0\\u002B\"]", null, null, "[\"2\\u002Bm\",\"7\\u002B\",\"0\\u002B\",\"2\\u002Bm\",\"7\\u002B\",\"2\\u002Bm\",\"7\\u002B\",\"9\\u002Bm\",\"2\\u002Bm\",\"7\\u002B\"]", new Guid("747a77ac-4a1a-4a96-957b-6c37136b3fb2"), "[\"0\\u002B\",\"9\\u002Bm7\",\"5\\u002B\",\"7\\u002B\"]", null },
                    { new Guid("e9c2c7ab-3e93-4fb3-b0a7-36bfb6e70df1"), true, null, "[\"9\\u002Bm\",\"5\\u002B\",\"0\\u002B\",\"7\\u002B\"]", null, null, null, null, new Guid("93c46f97-0fd3-4d58-9875-72417acf0924"), "[\"0\\u002B\",\"9\\u002Bm\",\"5\\u002B\",\"7\\u002B\"]", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("23a5d7e5-9c9d-4f3c-84b2-4f2e10a2e03a"));

            migrationBuilder.DeleteData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("3a69d00e-91f4-4a91-9298-6e5786a1f5e3"));

            migrationBuilder.DeleteData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("95f6d2f4-9eb2-4e17-a5ea-d65c7ed1b6b2"));

            migrationBuilder.DeleteData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("a1f5c3d1-8b2a-4e2a-a7c8-83716c1d8cb8"));

            migrationBuilder.DeleteData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("d9e73f0a-89ba-4b8b-9d2c-3e537d2d7ea5"));

            migrationBuilder.DeleteData(
                table: "SimpleChords",
                keyColumn: "Id",
                keyValue: new Guid("e9c2c7ab-3e93-4fb3-b0a7-36bfb6e70df1"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("7c5ecbd8-5a76-4eb5-984c-a3bc90be5244"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("ce6e5559-4d14-442c-8490-c3e415d5420a"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("591aead4-1d88-4366-bfac-5f67f3fc1695"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("747a77ac-4a1a-4a96-957b-6c37136b3fb2"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("93c46f97-0fd3-4d58-9875-72417acf0924"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("b63b2c08-f150-4bb8-a702-7805194e64eb"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("f4b3b3b4-1d88-4366-bfac-5f67f3fc1695"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("fedd2b44-d9ea-47e4-817c-cd924aacf935"));
        }
    }
}
