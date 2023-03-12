using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlexHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddContactRequestSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContactRequests",
                columns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                values: new object[,]
                {
                    { "269cf1a3-b20e-405d-863b-f8a427615294", "0073bcdb-3aa2-47ee-a224-abf589b53db0" },
                    { "be9b6864-5ad9-412b-8ba5-2fb9fd79e522", "0073bcdb-3aa2-47ee-a224-abf589b53db0" },
                    { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "0b57deac-0d84-49bf-a0ba-a28138fade8d" },
                    { "b233ac29-adce-43d6-8ba1-c4862e9cf87a", "0b57deac-0d84-49bf-a0ba-a28138fade8d" },
                    { "0073bcdb-3aa2-47ee-a224-abf589b53db0", "269cf1a3-b20e-405d-863b-f8a427615294" },
                    { "88906cdb-ff0d-4031-9276-aaab0f9b5d8c", "269cf1a3-b20e-405d-863b-f8a427615294" },
                    { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "88906cdb-ff0d-4031-9276-aaab0f9b5d8c" },
                    { "da8dfa3d-24a7-4198-b28a-36a716616107", "88906cdb-ff0d-4031-9276-aaab0f9b5d8c" },
                    { "88906cdb-ff0d-4031-9276-aaab0f9b5d8c", "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a" },
                    { "b233ac29-adce-43d6-8ba1-c4862e9cf87a", "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a" },
                    { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5" },
                    { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5" },
                    { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "b233ac29-adce-43d6-8ba1-c4862e9cf87a" },
                    { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "b233ac29-adce-43d6-8ba1-c4862e9cf87a" },
                    { "0073bcdb-3aa2-47ee-a224-abf589b53db0", "be9b6864-5ad9-412b-8ba5-2fb9fd79e522" },
                    { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "be9b6864-5ad9-412b-8ba5-2fb9fd79e522" },
                    { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "da8dfa3d-24a7-4198-b28a-36a716616107" },
                    { "88906cdb-ff0d-4031-9276-aaab0f9b5d8c", "da8dfa3d-24a7-4198-b28a-36a716616107" },
                    { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" },
                    { "da8dfa3d-24a7-4198-b28a-36a716616107", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "269cf1a3-b20e-405d-863b-f8a427615294", "0073bcdb-3aa2-47ee-a224-abf589b53db0" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "be9b6864-5ad9-412b-8ba5-2fb9fd79e522", "0073bcdb-3aa2-47ee-a224-abf589b53db0" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "0b57deac-0d84-49bf-a0ba-a28138fade8d" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "b233ac29-adce-43d6-8ba1-c4862e9cf87a", "0b57deac-0d84-49bf-a0ba-a28138fade8d" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "0073bcdb-3aa2-47ee-a224-abf589b53db0", "269cf1a3-b20e-405d-863b-f8a427615294" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "88906cdb-ff0d-4031-9276-aaab0f9b5d8c", "269cf1a3-b20e-405d-863b-f8a427615294" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "88906cdb-ff0d-4031-9276-aaab0f9b5d8c" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "da8dfa3d-24a7-4198-b28a-36a716616107", "88906cdb-ff0d-4031-9276-aaab0f9b5d8c" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "88906cdb-ff0d-4031-9276-aaab0f9b5d8c", "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "b233ac29-adce-43d6-8ba1-c4862e9cf87a", "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "b233ac29-adce-43d6-8ba1-c4862e9cf87a" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "b233ac29-adce-43d6-8ba1-c4862e9cf87a" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "0073bcdb-3aa2-47ee-a224-abf589b53db0", "be9b6864-5ad9-412b-8ba5-2fb9fd79e522" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5", "be9b6864-5ad9-412b-8ba5-2fb9fd79e522" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "0b57deac-0d84-49bf-a0ba-a28138fade8d", "da8dfa3d-24a7-4198-b28a-36a716616107" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "88906cdb-ff0d-4031-9276-aaab0f9b5d8c", "da8dfa3d-24a7-4198-b28a-36a716616107" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" });

            migrationBuilder.DeleteData(
                table: "ContactRequests",
                keyColumns: new[] { "ReceiverUserObjectId", "SenderUserObjectId" },
                keyValues: new object[] { "da8dfa3d-24a7-4198-b28a-36a716616107", "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7" });
        }
    }
}
