using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogsNTags.Database.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Body", "CreatedAt", "Description", "Slug", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend nec justo ut sagittis. Curabitur vestibulum lorem vel est suscipit varius ac sed tellus. Maecenas efficitur nibh a velit sollicitudin ornare. Proin ac dui imperdiet, tincidunt turpis in, finibus ligula. Donec sed massa quis magna imperdiet cursus vitae quis justo", new DateTime(2021, 4, 28, 15, 34, 30, 508, DateTimeKind.Local).AddTicks(4341), "Short description about upcoming changes", "upcoming-changes-in-angularjs", "Upcoming changes in AngularJS", new DateTime(2021, 4, 28, 15, 34, 30, 508, DateTimeKind.Local).AddTicks(4427) },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend nec justo ut sagittis. Curabitur vestibulum lorem vel est suscipit varius ac sed tellus. Maecenas efficitur nibh a velit sollicitudin ornare. Proin ac dui imperdiet, tincidunt turpis in, finibus ligula. Donec sed massa quis magna imperdiet cursus vitae quis justo", new DateTime(2021, 4, 28, 15, 34, 30, 508, DateTimeKind.Local).AddTicks(4446), "Some description", "testing-your-accented-characters-test-or", "țestíng your accëntëd čharacters teśt, or | .-> []", new DateTime(2021, 4, 28, 15, 34, 30, 508, DateTimeKind.Local).AddTicks(4451) },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eleifend nec justo ut sagittis. Curabitur vestibulum lorem vel est suscipit varius ac sed tellus. Maecenas efficitur nibh a velit sollicitudin ornare. Proin ac dui imperdiet, tincidunt turpis in, finibus ligula. Donec sed massa quis magna imperdiet cursus vitae quis justo", new DateTime(2021, 4, 28, 15, 34, 30, 508, DateTimeKind.Local).AddTicks(4458), "Genning the migs", "adding-migrations-to-net-core-31-using-ef", "Adding migrations to .NET core 3.1 using EF", new DateTime(2021, 4, 28, 15, 34, 30, 508, DateTimeKind.Local).AddTicks(4462) }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 28, 15, 34, 30, 496, DateTimeKind.Local).AddTicks(1666), "ios", new DateTime(2021, 4, 28, 15, 34, 30, 504, DateTimeKind.Local).AddTicks(8308) },
                    { 2, new DateTime(2021, 4, 28, 15, 34, 30, 504, DateTimeKind.Local).AddTicks(9652), "android", new DateTime(2021, 4, 28, 15, 34, 30, 504, DateTimeKind.Local).AddTicks(9680) },
                    { 3, new DateTime(2021, 4, 28, 15, 34, 30, 504, DateTimeKind.Local).AddTicks(9687), "AngularJS", new DateTime(2021, 4, 28, 15, 34, 30, 504, DateTimeKind.Local).AddTicks(9694) },
                    { 4, new DateTime(2021, 4, 28, 15, 34, 30, 504, DateTimeKind.Local).AddTicks(9702), "EntityFramework", new DateTime(2021, 4, 28, 15, 34, 30, 504, DateTimeKind.Local).AddTicks(9707) },
                    { 5, new DateTime(2021, 4, 28, 15, 34, 30, 504, DateTimeKind.Local).AddTicks(9715), "dotnet", new DateTime(2021, 4, 28, 15, 34, 30, 504, DateTimeKind.Local).AddTicks(9720) }
                });

            migrationBuilder.InsertData(
                table: "BlogsTags",
                columns: new[] { "Id", "BlogId", "TagId" },
                values: new object[] { 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "BlogsTags",
                columns: new[] { "Id", "BlogId", "TagId" },
                values: new object[] { 2, 3, 4 });

            migrationBuilder.InsertData(
                table: "BlogsTags",
                columns: new[] { "Id", "BlogId", "TagId" },
                values: new object[] { 3, 3, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogsTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogsTags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogsTags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
