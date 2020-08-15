using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingApp.Data.Migrations
{
    public partial class MSG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: false),
                    ValidBooking = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomServices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    BedCount = table.Column<int>(nullable: false),
                    PersonCount = table.Column<int>(nullable: false),
                    Surface = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    RoomTypeId = table.Column<long>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomServiceTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    RoomServiceId = table.Column<long>(nullable: false),
                    RoomTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomServiceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomServiceTypes_RoomServices_RoomServiceId",
                        column: x => x.RoomServiceId,
                        principalTable: "RoomServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomServiceTypes_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Sex = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    State = table.Column<string>(maxLength: 100, nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    GuestId = table.Column<long>(nullable: false),
                    BookingStatusId = table.Column<long>(nullable: false),
                    RoomId = table.Column<long>(nullable: false),
                    BeginningDate = table.Column<DateTime>(nullable: false),
                    EndingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_BookingStatuses_BookingStatusId",
                        column: x => x.BookingStatusId,
                        principalTable: "BookingStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    BookingId = table.Column<long>(nullable: false),
                    PaymentId = table.Column<long>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    InvoiceDueDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    InvoiceNum = table.Column<string>(maxLength: 10, nullable: false),
                    SalePoint = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookingStatuses",
                columns: new[] { "Id", "CreatedAt", "Description", "Status", "ValidBooking" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 8, 15, 12, 59, 56, 769, DateTimeKind.Local).AddTicks(4593), "Booking nikada nije modificiran", "ALL OK BOSS", true },
                    { 2L, new DateTime(2020, 8, 15, 12, 59, 56, 769, DateTimeKind.Local).AddTicks(5079), "Bookinga nema, server je u vatri", "FATAL BOOKINNG ERROR", true },
                    { 3L, new DateTime(2020, 8, 15, 12, 59, 56, 769, DateTimeKind.Local).AddTicks(5133), "blank description", "ALL OK BOSS 2", true }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedAt", "Description", "Status", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 8, 15, 12, 59, 56, 769, DateTimeKind.Local).AddTicks(9976), "opis placanja visom", true, "Visa" },
                    { 2L, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(430), "placanje nije proslo itd itd", false, "Mastercard" },
                    { 3L, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(454), "opis placanja visom br 3", true, "Visa" }
                });

            migrationBuilder.InsertData(
                table: "RoomServices",
                columns: new[] { "Id", "CreatedAt", "Name", "Price" },
                values: new object[,]
                {
                    { 6L, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(5074), "ekstra rucnici", 67.230000000000004 },
                    { 5L, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(5071), "Dorucak", 59.229999999999997 },
                    { 4L, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(5068), "Sat TV", 0.23000000000000001 },
                    { 2L, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(5047), "Topla voda", 84.230000000000004 },
                    { 1L, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(4703), "WIFI", 25.399999999999999 },
                    { 3L, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(5065), "Parking", 569.23000000000002 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "BedCount", "CreatedAt", "Description", "PersonCount", "Surface", "Type" },
                values: new object[,]
                {
                    { 1L, 3, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(7179), "dugacak opis sobe", 6, 58, "Deluxe spavaca sobe 1" },
                    { 2L, 1, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(7884), "dugacak opis sobe 2", 2, 30, "Basic spavaca sobe 2" },
                    { 3L, 15, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(7919), "dugacak opis sobe 3", 30, 90, "Deluxe spavaca soba 3" },
                    { 4L, 3, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(7923), "dugacak opis sobe 4", 9, 170, "Deluxe spavaca soba 4" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { 2L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(75), "biggie@smalls.com", "%EEASTZFGOJOBVTZE%$#&/=(", "Biggie" },
                    { 1L, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(9541), "admin@admin.com", "$%&/(=PŠČŽĐ?)(=?)=(T%RWSR", "Admin" },
                    { 3L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(98), "brk@os.com", "E$%#&/%&)=OHFD%/ER()/())PN", "BrankoKos" }
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Address", "City", "CreatedAt", "FirstName", "LastName", "MobileNumber", "Sex", "State", "UserId" },
                values: new object[,]
                {
                    { 3L, "BTMW 23", "Los Angeles", new DateTime(2020, 8, 15, 12, 59, 56, 769, DateTimeKind.Local).AddTicks(8369), "Chris", "Brown", "+12361234", "Ž", "USA", 3L },
                    { 1L, "Adresa 123", "Zagreb", new DateTime(2020, 8, 15, 12, 59, 56, 769, DateTimeKind.Local).AddTicks(7270), "Pero", "Perić", "+123456789", "M", "Hrvatska", 1L },
                    { 2L, "Adresa 987", "Imotski", new DateTime(2020, 8, 15, 12, 59, 56, 769, DateTimeKind.Local).AddTicks(8321), "Ante", "Antić", "+987654321", "M", "Hrvatska", 2L }
                });

            migrationBuilder.InsertData(
                table: "RoomServiceTypes",
                columns: new[] { "Id", "CreatedAt", "RoomServiceId", "RoomTypeId" },
                values: new object[,]
                {
                    { 17L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4105), 3L, 4L },
                    { 15L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4102), 3L, 4L },
                    { 10L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4089), 2L, 4L },
                    { 6L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4077), 1L, 4L },
                    { 5L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4073), 1L, 4L },
                    { 4L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4070), 1L, 4L },
                    { 16L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4114), 4L, 3L },
                    { 14L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4099), 3L, 3L },
                    { 9L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4086), 2L, 3L },
                    { 3L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4067), 1L, 3L },
                    { 11L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4111), 4L, 2L },
                    { 13L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4095), 3L, 2L },
                    { 8L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4083), 2L, 2L },
                    { 2L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4048), 1L, 2L },
                    { 18L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4108), 4L, 1L },
                    { 12L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4092), 3L, 1L },
                    { 7L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(4080), 2L, 1L },
                    { 1L, new DateTime(2020, 8, 15, 12, 59, 56, 771, DateTimeKind.Local).AddTicks(3699), 1L, 1L }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CreatedAt", "Price", "RoomTypeId" },
                values: new object[,]
                {
                    { 2L, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(2483), 134.69999999999999, 2L },
                    { 3L, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(2533), 23.800000000000001, 3L },
                    { 1L, new DateTime(2020, 8, 15, 12, 59, 56, 770, DateTimeKind.Local).AddTicks(2143), 123.40000000000001, 1L }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BeginningDate", "BookingStatusId", "CreatedAt", "EndingDate", "GuestId", "RoomId" },
                values: new object[] { 1L, new DateTime(2005, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2020, 8, 15, 12, 59, 56, 769, DateTimeKind.Local).AddTicks(1627), new DateTime(2005, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BeginningDate", "BookingStatusId", "CreatedAt", "EndingDate", "GuestId", "RoomId" },
                values: new object[] { 3L, new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2020, 8, 15, 12, 59, 56, 769, DateTimeKind.Local).AddTicks(2695), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BeginningDate", "BookingStatusId", "CreatedAt", "EndingDate", "GuestId", "RoomId" },
                values: new object[] { 2L, new DateTime(2005, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2020, 8, 15, 12, 59, 56, 769, DateTimeKind.Local).AddTicks(2653), new DateTime(2005, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 2L });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "Amount", "BookingId", "CreatedAt", "InvoiceDate", "InvoiceDueDate", "InvoiceNum", "PaymentId", "SalePoint", "Status" },
                values: new object[] { 1L, 234.0, 1L, new DateTime(2020, 8, 15, 12, 59, 56, 766, DateTimeKind.Local).AddTicks(6916), new DateTime(2005, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2005, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "1/27/123", 1L, 12L, true });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "Amount", "BookingId", "CreatedAt", "InvoiceDate", "InvoiceDueDate", "InvoiceNum", "PaymentId", "SalePoint", "Status" },
                values: new object[] { 3L, 19834.0, 1L, new DateTime(2020, 8, 15, 12, 59, 56, 768, DateTimeKind.Local).AddTicks(2531), new DateTime(2005, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2005, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "2/5/987", 2L, 5L, true });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "Amount", "BookingId", "CreatedAt", "InvoiceDate", "InvoiceDueDate", "InvoiceNum", "PaymentId", "SalePoint", "Status" },
                values: new object[] { 2L, 987.0, 2L, new DateTime(2020, 8, 15, 12, 59, 56, 768, DateTimeKind.Local).AddTicks(2461), new DateTime(2005, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2005, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "1/27/987", 2L, 1L, false });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BookingId",
                table: "Bills",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PaymentId",
                table: "Bills",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingStatusId",
                table: "Bookings",
                column: "BookingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestId",
                table: "Bookings",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_UserId",
                table: "Guests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceTypes_RoomServiceId",
                table: "RoomServiceTypes",
                column: "RoomServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceTypes_RoomTypeId",
                table: "RoomServiceTypes",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "RoomServiceTypes");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RoomServices");

            migrationBuilder.DropTable(
                name: "BookingStatuses");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
