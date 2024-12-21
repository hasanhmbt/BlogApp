using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations.AppIdentityDb
{
    /// <inheritdoc />
    public partial class update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7cfd5e6c-f6e6-4b62-ad4b-77f4ed0b8af9", "17d6a04c-3394-42cc-a579-339ab3e35174" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cfd5e6c-f6e6-4b62-ad4b-77f4ed0b8af9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17d6a04c-3394-42cc-a579-339ab3e35174");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "81fb533b-0d9e-43a6-956f-4a136d134d46", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "726f43d3-a17e-4708-94e8-aed2324a41d6", 0, "7fcbfd61-2d15-406c-9e1a-d81b4aa23df8", "qafarov.electronics@gmail.com", true, false, null, "QAFAROV.ELECTRONICS@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAENl225IJfRxCX5WAivn1Vvy8sShpvJUUBe1zpQsUNWjQBGoN/HK5OnbBevKRU3NIKQ==", null, false, "ad613d31-8cd0-41e0-8ca9-7ddc4e67afba", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "81fb533b-0d9e-43a6-956f-4a136d134d46", "726f43d3-a17e-4708-94e8-aed2324a41d6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "81fb533b-0d9e-43a6-956f-4a136d134d46", "726f43d3-a17e-4708-94e8-aed2324a41d6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81fb533b-0d9e-43a6-956f-4a136d134d46");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "726f43d3-a17e-4708-94e8-aed2324a41d6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cfd5e6c-f6e6-4b62-ad4b-77f4ed0b8af9", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "17d6a04c-3394-42cc-a579-339ab3e35174", 0, "f14e8c92-d777-4dc9-a232-e80c8fb56e2d", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAENHkNvoBkQxgNhsV5SO0BtLUjT78I48Mp4KNKlMzb2xw50YMR3qSPZI9ZyXQfIOIdQ==", null, false, "6d09027b-6de5-4d52-80b1-9d7699bdb94f", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7cfd5e6c-f6e6-4b62-ad4b-77f4ed0b8af9", "17d6a04c-3394-42cc-a579-339ab3e35174" });
        }
    }
}
