using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupChats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ObjectId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    GivenName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ObjectId);
                });

            migrationBuilder.CreateTable(
                name: "ContactRequests",
                columns: table => new
                {
                    SenderUserObjectId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    ReceiverUserObjectId = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactRequests", x => new { x.SenderUserObjectId, x.ReceiverUserObjectId });
                    table.ForeignKey(
                        name: "FK_ContactRequests_Users_ReceiverUserObjectId",
                        column: x => x.ReceiverUserObjectId,
                        principalTable: "Users",
                        principalColumn: "ObjectId");
                    table.ForeignKey(
                        name: "FK_ContactRequests_Users_SenderUserObjectId",
                        column: x => x.SenderUserObjectId,
                        principalTable: "Users",
                        principalColumn: "ObjectId");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    UserObjectId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    ContactObjectId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => new { x.UserObjectId, x.ContactObjectId });
                    table.ForeignKey(
                        name: "FK_Contacts_Users_ContactObjectId",
                        column: x => x.ContactObjectId,
                        principalTable: "Users",
                        principalColumn: "ObjectId");
                    table.ForeignKey(
                        name: "FK_Contacts_Users_UserObjectId",
                        column: x => x.UserObjectId,
                        principalTable: "Users",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderUserObjectId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    ReceiverUserObjectId = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectMessages_Users_ReceiverUserObjectId",
                        column: x => x.ReceiverUserObjectId,
                        principalTable: "Users",
                        principalColumn: "ObjectId");
                    table.ForeignKey(
                        name: "FK_DirectMessages_Users_SenderUserObjectId",
                        column: x => x.SenderUserObjectId,
                        principalTable: "Users",
                        principalColumn: "ObjectId");
                });

            migrationBuilder.CreateTable(
                name: "GroupMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderUserObjectId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    GroupChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMessages_GroupChats_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "GroupChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMessages_Users_SenderUserObjectId",
                        column: x => x.SenderUserObjectId,
                        principalTable: "Users",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserObjectId = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserObjectId",
                        column: x => x.UserObjectId,
                        principalTable: "Users",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersGroupChats",
                columns: table => new
                {
                    UserObjectId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    GroupChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGroupChats", x => new { x.UserObjectId, x.GroupChatId });
                    table.ForeignKey(
                        name: "FK_UsersGroupChats_GroupChats_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "GroupChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersGroupChats_Users_UserObjectId",
                        column: x => x.UserObjectId,
                        principalTable: "Users",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersTags",
                columns: table => new
                {
                    UserObjectId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTags", x => new { x.UserObjectId, x.TagId });
                    table.ForeignKey(
                        name: "FK_UsersTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersTags_Users_UserObjectId",
                        column: x => x.UserObjectId,
                        principalTable: "Users",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostsTags",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsTags", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostsTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactRequests_ReceiverUserObjectId",
                table: "ContactRequests",
                column: "ReceiverUserObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactObjectId",
                table: "Contacts",
                column: "ContactObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectMessages_ReceiverUserObjectId",
                table: "DirectMessages",
                column: "ReceiverUserObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectMessages_SenderUserObjectId_ReceiverUserObjectId_CreatedAt",
                table: "DirectMessages",
                columns: new[] { "SenderUserObjectId", "ReceiverUserObjectId", "CreatedAt" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessages_GroupChatId_CreatedAt",
                table: "GroupMessages",
                columns: new[] { "GroupChatId", "CreatedAt" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessages_SenderUserObjectId",
                table: "GroupMessages",
                column: "SenderUserObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserObjectId",
                table: "Posts",
                column: "UserObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsTags_TagId",
                table: "PostsTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroupChats_GroupChatId",
                table: "UsersGroupChats",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersTags_TagId",
                table: "UsersTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactRequests");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "DirectMessages");

            migrationBuilder.DropTable(
                name: "GroupMessages");

            migrationBuilder.DropTable(
                name: "PostsTags");

            migrationBuilder.DropTable(
                name: "UsersGroupChats");

            migrationBuilder.DropTable(
                name: "UsersTags");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "GroupChats");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
