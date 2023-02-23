using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAtPropertytoContactmodelandsampledata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "0b57deac-0d84-49bf-a0ba-a28138fade8d" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "30ed3c05-7777-45a1-b940-5f99e20030a7", "0b57deac-0d84-49bf-a0ba-a28138fade8d" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "be9b6864-5ad9-412b-8ba5-2fb9fd79e522", "0b57deac-0d84-49bf-a0ba-a28138fade8d" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7", "0b57deac-0d84-49bf-a0ba-a28138fade8d" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "269cf1a3-b20e-405d-863b-f8a427615294" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "269cf1a3-b20e-405d-863b-f8a427615294", "269cf1a3-b20e-405d-863b-f8a427615294" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "be9b6864-5ad9-412b-8ba5-2fb9fd79e522", "269cf1a3-b20e-405d-863b-f8a427615294" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "ea664eff-c559-4f93-a794-ae26e5824ed3", "269cf1a3-b20e-405d-863b-f8a427615294" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "30ed3c05-7777-45a1-b940-5f99e20030a7", "30ed3c05-7777-45a1-b940-5f99e20030a7" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75", "30ed3c05-7777-45a1-b940-5f99e20030a7" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "30ed3c05-7777-45a1-b940-5f99e20030a7" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "be9b6864-5ad9-412b-8ba5-2fb9fd79e522", "30ed3c05-7777-45a1-b940-5f99e20030a7" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "be9b6864-5ad9-412b-8ba5-2fb9fd79e522", "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "da8dfa3d-24a7-4198-b28a-36a716616107", "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "ea664eff-c559-4f93-a794-ae26e5824ed3", "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7", "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "269cf1a3-b20e-405d-863b-f8a427615294", "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75", "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "ea664eff-c559-4f93-a794-ae26e5824ed3", "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "da8dfa3d-24a7-4198-b28a-36a716616107", "be9b6864-5ad9-412b-8ba5-2fb9fd79e522" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "ea664eff-c559-4f93-a794-ae26e5824ed3", "be9b6864-5ad9-412b-8ba5-2fb9fd79e522" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7", "be9b6864-5ad9-412b-8ba5-2fb9fd79e522" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "269cf1a3-b20e-405d-863b-f8a427615294", "da8dfa3d-24a7-4198-b28a-36a716616107" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75", "da8dfa3d-24a7-4198-b28a-36a716616107" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "da8dfa3d-24a7-4198-b28a-36a716616107" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "30ed3c05-7777-45a1-b940-5f99e20030a7", "ea664eff-c559-4f93-a794-ae26e5824ed3" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "da8dfa3d-24a7-4198-b28a-36a716616107", "ea664eff-c559-4f93-a794-ae26e5824ed3" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "ea664eff-c559-4f93-a794-ae26e5824ed3", "ea664eff-c559-4f93-a794-ae26e5824ed3" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7", "ea664eff-c559-4f93-a794-ae26e5824ed3" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "30ed3c05-7777-45a1-b940-5f99e20030a7", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 1, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 23, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 0, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 1, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 1, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 1, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 1, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 1, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 1, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 1, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 1, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 1, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 1, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 1, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 1, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 2, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 2, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 2, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 2, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 2, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 2, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 2, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 2, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 2, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 2, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 2, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 2, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 3, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 3, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 3, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 3, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 3, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 3, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 3, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 3, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 3, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 3, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 3, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 3, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 4, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 4, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 4, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 4, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 4, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 4, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 4, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 4, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 4, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 4, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 4, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 4, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 5, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 5, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 5, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 5, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 5, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 5, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 5, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 5, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 5, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 5, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 5, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 5, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 6, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 6, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 6, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 6, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 6, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 6, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 6, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 6, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 6, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 6, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 6, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 6, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 7, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 7, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 7, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 7, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 7, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 7, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 7, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 7, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 7, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 7, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 7, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 7, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 8, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 8, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 8, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 8, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 8, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 8, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 8, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 8, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 8, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 8, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 8, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 8, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 9, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 9, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 9, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 9, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 9, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 9, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 9, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 9, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 9, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 9, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 9, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 9, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 10, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 10, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 10, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 10, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 10, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 10, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 10, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 10, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 10, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 10, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 10, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 10, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 11, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 11, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 11, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 11, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 11, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 11, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 11, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 11, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 11, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 11, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 11, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 11, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 12, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 12, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 12, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 12, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 12, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 12, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 12, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 12, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 12, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 12, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 12, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 12, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 13, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 13, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 13, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 13, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 13, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 13, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 13, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 13, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 13, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 13, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 13, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 13, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 14, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 14, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 14, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 14, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 14, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 14, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 14, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 14, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2022, 2, 22, 14, 40, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Contacts");

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 22, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 22, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 22, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 22, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 22, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 22, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 22, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 22, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 22, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 22, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 22, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 23, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 23, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 23, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 23, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 23, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 23, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 23, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 23, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 23, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 23, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 23, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 21, 23, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 0, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 0, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 0, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 0, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 0, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 0, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 0, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 0, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 0, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 0, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 0, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 1, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 1, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 1, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 1, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 1, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 1, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 1, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 1, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 1, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 1, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 1, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 1, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 2, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 2, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 2, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 2, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 2, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 2, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 2, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 2, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 2, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 2, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 2, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 2, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 3, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 3, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 3, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 3, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 3, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 3, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 3, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 3, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 3, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 3, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 3, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 3, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 4, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 4, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 4, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 4, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 4, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 4, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 4, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 4, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 4, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 4, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 4, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 4, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 5, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 5, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 5, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 5, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 5, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 5, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 5, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 5, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 5, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 5, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 5, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 5, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 6, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 6, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 6, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 6, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 6, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 6, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 6, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 6, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 6, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 6, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 6, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 6, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 7, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 7, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 7, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 7, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 7, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 7, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 7, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 7, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 7, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 7, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 7, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 7, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 8, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 8, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 8, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 8, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 8, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 8, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 8, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 8, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 8, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 8, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 8, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 8, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 9, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 9, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 9, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 9, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 9, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 9, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 9, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 9, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 9, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 9, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 9, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 9, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 10, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 10, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 10, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 10, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 10, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 10, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 10, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 10, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 10, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 10, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 10, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 10, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 11, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 11, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 11, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 11, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 11, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 11, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 11, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 11, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 11, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 11, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 11, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 11, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 12, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 12, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 12, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 12, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 12, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 12, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 12, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 12, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 12, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 12, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 12, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 12, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 13, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 13, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 13, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 13, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 13, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 13, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 13, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 13, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 13, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 13, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 13, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 13, 55, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 14, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 14, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 14, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 14, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 14, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 14, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 14, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 14, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "GroupMessages",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 22, 14, 40, 0, 0, DateTimeKind.Utc));
        }
    }
}
