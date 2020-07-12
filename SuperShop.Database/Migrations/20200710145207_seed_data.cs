using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperShop.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Customers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Designation", "Email", "Image", "Name", "Password", "isDelete" },
                values: new object[] { 1, 2, "Software Engineer", "imran_bof@live.com", null, "Imran Khan", "12345", false });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Designation", "Email", "Image", "Name", "Password", "isDelete" },
                values: new object[] { 2, 2, "Software Engineer", "sabit@mail.com", null, "Sabit Khan", "12345", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Customers");
        }
    }
}
