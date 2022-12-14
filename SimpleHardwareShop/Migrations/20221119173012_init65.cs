using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleHardwareShop.Migrations
{
    /// <inheritdoc />
    public partial class init65 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    SecondLastName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    DefaultBankCardId = table.Column<int>(type: "INTEGER", nullable: true),
                    DefaultDeliveryAdressId = table.Column<int>(type: "INTEGER", nullable: true),
                    DefaultFiscalAdressId = table.Column<int>(type: "INTEGER", nullable: true),
                    RetailShop = table.Column<int>(type: "INTEGER", nullable: true),
                    EmployeeType = table.Column<int>(type: "INTEGER", nullable: true),
                    EmployeeAdressId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Stock = table.Column<double>(type: "REAL", nullable: false),
                    DefaultStock = table.Column<double>(type: "REAL", nullable: false),
                    Serie = table.Column<string>(type: "TEXT", nullable: false),
                    Inventory = table.Column<string>(type: "TEXT", nullable: false),
                    RetailShop = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    EmployeeUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    StreetAdress = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<int>(type: "INTEGER", nullable: false),
                    RFC = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_ApplicationUsers_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Adresses_ApplicationUsers_EmployeeUserId",
                        column: x => x.EmployeeUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BankCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Account = table.Column<string>(type: "TEXT", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SecurityCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankCards_ApplicationUsers_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    YaSeEnvioAlCliente = table.Column<bool>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CotizacionDetails_ApplicationUsers_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CotizacionDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_ApplicationUsers_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderTotal = table.Column<double>(type: "REAL", nullable: false),
                    DeliveryAdressId = table.Column<int>(type: "INTEGER", nullable: false),
                    FiscalAdressId = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_Adresses_DeliveryAdressId",
                        column: x => x.DeliveryAdressId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_Adresses_FiscalAdressId",
                        column: x => x.FiscalAdressId,
                        principalTable: "Adresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderHeaders_ApplicationUsers_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderHeaderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_CustomerUserId",
                table: "Adresses",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_EmployeeUserId",
                table: "Adresses",
                column: "EmployeeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_UserName",
                table: "ApplicationUsers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_CustomerUserId",
                table: "BankCards",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionDetails_CustomerUserId",
                table: "CotizacionDetails",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionDetails_ProductId",
                table: "CotizacionDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_CustomerUserId",
                table: "OrderHeaders",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_DeliveryAdressId",
                table: "OrderHeaders",
                column: "DeliveryAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_FiscalAdressId",
                table: "OrderHeaders",
                column: "FiscalAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CustomerUserId",
                table: "ShoppingCarts",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankCards");

            migrationBuilder.DropTable(
                name: "CotizacionDetails");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");
        }
    }
}
