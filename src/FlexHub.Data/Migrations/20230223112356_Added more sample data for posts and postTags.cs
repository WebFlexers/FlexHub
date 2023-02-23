using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlexHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedmoresampledataforpostsandpostTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "Title", "UpdatedAt", "UserObjectId" },
                values: new object[,]
                {
                    { 350, "Lorem ipsum dolor sit amet", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post 350", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "30ed3c05-7777-45a1-b940-5f99e20030a7" },
                    { 876, "Lorem ipsum dolor sit amet", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post 876", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" },
                    { 956, "Lorem ipsum dolor sit amet", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post 956", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "30ed3c05-7777-45a1-b940-5f99e20030a7" }
                });

            migrationBuilder.InsertData(
                table: "PostsTags",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 350, 4 },
                    { 350, 10 },
                    { 876, 3 },
                    { 876, 4 },
                    { 876, 10 },
                    { 956, 4 },
                    { 956, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostsTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 350, 4 });

            migrationBuilder.DeleteData(
                table: "PostsTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 350, 10 });

            migrationBuilder.DeleteData(
                table: "PostsTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 876, 3 });

            migrationBuilder.DeleteData(
                table: "PostsTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 876, 4 });

            migrationBuilder.DeleteData(
                table: "PostsTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 876, 10 });

            migrationBuilder.DeleteData(
                table: "PostsTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 956, 4 });

            migrationBuilder.DeleteData(
                table: "PostsTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { 956, 10 });

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 876);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 956);
        }
    }
}
