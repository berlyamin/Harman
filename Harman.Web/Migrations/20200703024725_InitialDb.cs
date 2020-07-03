using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Harman.Web.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Customerid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(maxLength: 50, nullable: false),
                    Customerlastname = table.Column<string>(maxLength: 50, nullable: false),
                    Customeridentification = table.Column<string>(maxLength: 15, nullable: false),
                    CustomerPhone = table.Column<string>(maxLength: 15, nullable: false),
                    CustomerCellPhone = table.Column<string>(maxLength: 15, nullable: false),
                    CustomerEmail = table.Column<string>(nullable: false),
                    CustomerAddress = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Customerid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
