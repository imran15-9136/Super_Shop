using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperShop.Migrations
{
    public partial class Seed_data_customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    INSERT INTO Customers (Name,Phone,Email,Address,isDelete)
                                    Values('Md. Imran Hossain','01773893339','imran_bof@live.com','58/9, Free School Street',0);
                               ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    DELETE FROM Customers Where Name='Md. Imran Hossain';
                               ");
        }
    }
}
