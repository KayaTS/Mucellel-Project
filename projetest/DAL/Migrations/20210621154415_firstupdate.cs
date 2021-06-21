using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class firstupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ContentsPlaces",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    Title = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentsPlaces", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurName = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    Mail = table.Column<string>(type: "varchar(60)", nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", nullable: true),
                    Password = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    RoleNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MediaPicture",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    Title = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    Owner = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    Description = table.Column<string>(type: "Varchar(400)", maxLength: 400, nullable: true),
                    View = table.Column<int>(type: "int", nullable: false),
                    Like = table.Column<int>(type: "int", nullable: false),
                    ImageData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    contentID = table.Column<int>(type: "int", nullable: false),
                    ContentsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaPicture", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MediaPicture_ContentsPlaces_ContentsID",
                        column: x => x.ContentsID,
                        principalTable: "ContentsPlaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlacesPictures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contentsPlacesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlacesPictures_ContentsPlaces_contentsPlacesID",
                        column: x => x.contentsPlacesID,
                        principalTable: "ContentsPlaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentsComments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    Title = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "Varchar(400)", maxLength: 400, nullable: true),
                    Like = table.Column<int>(type: "int", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: true),
                    pictureID = table.Column<int>(type: "int", nullable: true),
                    ContentsPlacesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentsComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContentsComments_ContentsPlaces_ContentsPlacesID",
                        column: x => x.ContentsPlacesID,
                        principalTable: "ContentsPlaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentsComments_MediaPicture_pictureID",
                        column: x => x.pictureID,
                        principalTable: "MediaPicture",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentsComments_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageComments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    Title = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "Varchar(400)", maxLength: 400, nullable: true),
                    Like = table.Column<int>(type: "int", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: true),
                    pictureID = table.Column<int>(type: "int", nullable: true),
                    ContentsPlacesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageComments_ContentsPlaces_ContentsPlacesID",
                        column: x => x.ContentsPlacesID,
                        principalTable: "ContentsPlaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageComments_MediaPicture_pictureID",
                        column: x => x.pictureID,
                        principalTable: "MediaPicture",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageComments_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentsComments_ContentsPlacesID",
                table: "ContentsComments",
                column: "ContentsPlacesID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentsComments_MemberID",
                table: "ContentsComments",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentsComments_pictureID",
                table: "ContentsComments",
                column: "pictureID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageComments_ContentsPlacesID",
                table: "ImageComments",
                column: "ContentsPlacesID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageComments_MemberID",
                table: "ImageComments",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageComments_pictureID",
                table: "ImageComments",
                column: "pictureID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPicture_ContentsID",
                table: "MediaPicture",
                column: "ContentsID");

            migrationBuilder.CreateIndex(
                name: "IX_PlacesPictures_contentsPlacesID",
                table: "PlacesPictures",
                column: "contentsPlacesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "ContentsComments");

            migrationBuilder.DropTable(
                name: "ImageComments");

            migrationBuilder.DropTable(
                name: "PlacesPictures");

            migrationBuilder.DropTable(
                name: "MediaPicture");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "ContentsPlaces");
        }
    }
}
