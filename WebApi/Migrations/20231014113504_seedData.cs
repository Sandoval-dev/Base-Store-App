using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[] { 1, 75m, "Bursa'dan Anılar" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[] { 2, 750m, "Para Nasıl Kazanılır?" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[] { 3, 142m, "Oyun Oynamayı Öğren" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
