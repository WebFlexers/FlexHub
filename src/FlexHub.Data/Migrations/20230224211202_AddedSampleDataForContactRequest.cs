using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlexHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSampleDataForContactRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContactRequests",
                columns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                values: new object[,]
                {
                    { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "0b57deac-0d84-49bf-a0ba-a28138fade8d" },
                    { "da8dfa3d-24a7-4198-b28a-36a716616107", "0b57deac-0d84-49bf-a0ba-a28138fade8d" },
                    { "ea664eff-c559-4f93-a794-ae26e5824ed3", "0b57deac-0d84-49bf-a0ba-a28138fade8d" },
                    { "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75", "30ed3c05-7777-45a1-b940-5f99e20030a7" },
                    { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "30ed3c05-7777-45a1-b940-5f99e20030a7" },
                    { "ea664eff-c559-4f93-a794-ae26e5824ed3", "30ed3c05-7777-45a1-b940-5f99e20030a7" },
                    { "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7", "30ed3c05-7777-45a1-b940-5f99e20030a7" },
                    { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75" },
                    { "ea664eff-c559-4f93-a794-ae26e5824ed3", "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75" },
                    { "30ed3c05-7777-45a1-b940-5f99e20030a7", "ea664eff-c559-4f93-a794-ae26e5824ed3" },
                    { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "ea664eff-c559-4f93-a794-ae26e5824ed3" },
                    { "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75", "ea664eff-c559-4f93-a794-ae26e5824ed3" },
                    { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "ea664eff-c559-4f93-a794-ae26e5824ed3" },
                    { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" },
                    { "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" }
                });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "0b57deac-0d84-49bf-a0ba-a28138fade8d" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "30ed3c05-7777-45a1-b940-5f99e20030a7", "0b57deac-0d84-49bf-a0ba-a28138fade8d" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "be9b6864-5ad9-412b-8ba5-2fb9fd79e522", "0b57deac-0d84-49bf-a0ba-a28138fade8d" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7", "0b57deac-0d84-49bf-a0ba-a28138fade8d" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 25, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "269cf1a3-b20e-405d-863b-f8a427615294" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "269cf1a3-b20e-405d-863b-f8a427615294", "269cf1a3-b20e-405d-863b-f8a427615294" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "be9b6864-5ad9-412b-8ba5-2fb9fd79e522", "269cf1a3-b20e-405d-863b-f8a427615294" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "ea664eff-c559-4f93-a794-ae26e5824ed3", "269cf1a3-b20e-405d-863b-f8a427615294" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 40, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "30ed3c05-7777-45a1-b940-5f99e20030a7", "30ed3c05-7777-45a1-b940-5f99e20030a7" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "30ed3c05-7777-45a1-b940-5f99e20030a7" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "be9b6864-5ad9-412b-8ba5-2fb9fd79e522", "30ed3c05-7777-45a1-b940-5f99e20030a7" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 5, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "be9b6864-5ad9-412b-8ba5-2fb9fd79e522", "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "da8dfa3d-24a7-4198-b28a-36a716616107", "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 35, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "ea664eff-c559-4f93-a794-ae26e5824ed3", "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7", "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 15, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "269cf1a3-b20e-405d-863b-f8a427615294", "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75", "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "ea664eff-c559-4f93-a794-ae26e5824ed3", "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 20, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "da8dfa3d-24a7-4198-b28a-36a716616107", "be9b6864-5ad9-412b-8ba5-2fb9fd79e522" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "ea664eff-c559-4f93-a794-ae26e5824ed3", "be9b6864-5ad9-412b-8ba5-2fb9fd79e522" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7", "be9b6864-5ad9-412b-8ba5-2fb9fd79e522" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 45, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "269cf1a3-b20e-405d-863b-f8a427615294", "da8dfa3d-24a7-4198-b28a-36a716616107" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75", "da8dfa3d-24a7-4198-b28a-36a716616107" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "da8dfa3d-24a7-4198-b28a-36a716616107" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 30, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "30ed3c05-7777-45a1-b940-5f99e20030a7", "ea664eff-c559-4f93-a794-ae26e5824ed3" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "da8dfa3d-24a7-4198-b28a-36a716616107", "ea664eff-c559-4f93-a794-ae26e5824ed3" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "ea664eff-c559-4f93-a794-ae26e5824ed3", "ea664eff-c559-4f93-a794-ae26e5824ed3" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7", "ea664eff-c559-4f93-a794-ae26e5824ed3" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 10, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "30ed3c05-7777-45a1-b940-5f99e20030a7", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 50, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumns: new[] { "ContactObjectId", "UserObjectId" },
                keyValues: new object[] { "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" },
                column: "CreatedAt",
                value: new DateTime(2022, 2, 21, 22, 50, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "0b57deac-0d84-49bf-a0ba-a28138fade8d" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "da8dfa3d-24a7-4198-b28a-36a716616107", "0b57deac-0d84-49bf-a0ba-a28138fade8d" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "ea664eff-c559-4f93-a794-ae26e5824ed3", "0b57deac-0d84-49bf-a0ba-a28138fade8d" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75", "30ed3c05-7777-45a1-b940-5f99e20030a7" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "30ed3c05-7777-45a1-b940-5f99e20030a7" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "ea664eff-c559-4f93-a794-ae26e5824ed3", "30ed3c05-7777-45a1-b940-5f99e20030a7" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7", "30ed3c05-7777-45a1-b940-5f99e20030a7" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "ea664eff-c559-4f93-a794-ae26e5824ed3", "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "30ed3c05-7777-45a1-b940-5f99e20030a7", "ea664eff-c559-4f93-a794-ae26e5824ed3" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "ea664eff-c559-4f93-a794-ae26e5824ed3" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75", "ea664eff-c559-4f93-a794-ae26e5824ed3" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "ea664eff-c559-4f93-a794-ae26e5824ed3" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" });

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
        }
    }
}
