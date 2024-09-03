using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NplayBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSongAndChords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chroma = table.Column<int>(type: "int", nullable: false),
                    Scale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BPM = table.Column<int>(type: "int", nullable: true),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Recognitions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpotifyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SimpleChords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Intro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Verse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerseEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreChorus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chorus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChorusEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bridge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    SongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimpleChords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimpleChords_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SimpleChords_SongId",
                table: "SimpleChords",
                column: "SongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimpleChords");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
