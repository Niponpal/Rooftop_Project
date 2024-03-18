using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Top_Rooftop_project.Migrations
{
    /// <inheritdoc />
    public partial class createFarmers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Farmer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SquarFeet = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Image3 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    GoogleMap = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SomeDetails = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    MoreDetails = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Price = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(156)", maxLength: 156, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(156)", maxLength: 156, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(156)", maxLength: 156, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsPaymentConfirm = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Cartitems = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    OrderTime = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Farmer");

            migrationBuilder.DropTable(
                name: "HouseOwners");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
