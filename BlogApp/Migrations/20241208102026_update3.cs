using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogApp.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DownloadFiles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DownloadFiles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DownloadFiles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Specialty",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ScientificFacts",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Specialty",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ScientificFacts",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CreatedAt", "Description", "FilePath", "PublicationDate", "Title", "UserId" },
                values: new object[] { 3, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "<p>The Model-View-Controller (MVC) pattern is a design pattern that separates an application into three main components...</p>", "/images/articles/mvc.jpg", new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exploring the MVC Pattern", null });

            migrationBuilder.InsertData(
                table: "DownloadFiles",
                columns: new[] { "Id", "CreatedAt", "FilePath", "FileType", "Name", "UploadDate" },
                values: new object[,]
                {
                    { 3, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/files/Algorithms.zip", "zip", "Algorithms.zip", new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "/files/RandomNotes.docx", "docx", "RandomNotes.docx", new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "/files/SampleFile.docx", "docx", "SampleFile.docx", new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedAt", "Credits", "Hours", "MaterialsLink", "Name" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 45, "/materials/physics.pdf", "Physics" },
                    { 3, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 50, "/materials/chemistry.pdf", "Chemistry" }
                });
        }
    }
}
