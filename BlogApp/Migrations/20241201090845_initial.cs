using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogApp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DownloadFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    MaterialsLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScientificFacts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CreatedAt", "Description", "FilePath", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "<p>ASP.NET Core is a cross-platform, high-performance framework for building modern web applications...</p>", "/images/articles/aspnetcore.jpg", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Getting Started with ASP.NET Core" },
                    { 2, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "<p>Entity Framework Core (EF Core) is a modern object-database mapper for .NET...</p>", "/images/articles/efcore.jpg", new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Understanding Entity Framework Core" },
                    { 3, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "<p>The Model-View-Controller (MVC) pattern is a design pattern that separates an application into three main components...</p>", "/images/articles/mvc.jpg", new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exploring the MVC Pattern" }
                });

            migrationBuilder.InsertData(
                table: "DownloadFiles",
                columns: new[] { "Id", "CreatedAt", "FilePath", "FileType", "Name", "UploadDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "/files/IntroProgramming.pdf", "pdf", "Introduction to Programming.pdf", new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "/files/DataStructures.docx", "docx", "DataStructures.docx", new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/files/Algorithms.zip", "zip", "Algorithms.zip", new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/files/RandomNotes.docx", "docx", "RandomNotes.docx", new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "/files/SampleFile.docx", "docx", "SampleFile.docx", new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedAt", "Credits", "Hours", "MaterialsLink", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 60, "/materials/mathematics.pdf", "Mathematics" },
                    { 2, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 45, "/materials/physics.pdf", "Physics" },
                    { 3, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 50, "/materials/chemistry.pdf", "Chemistry" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "JobTitle", "LastName", "ProfileImageUrl", "ScientificFacts", "Specialty" },
                values: new object[] { 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.johnson@example.com", "Alice", "Senior Developer", "Johnson", "/images/users/alice.jpg", "Published 5 papers on cloud computing.", "Full Stack Development" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "DownloadFiles");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
