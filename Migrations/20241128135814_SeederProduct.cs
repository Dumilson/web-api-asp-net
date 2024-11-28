using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManager.Migrations
{
    /// <inheritdoc />
    public partial class SeederProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { Guid.NewGuid(), "Sumol", 500.00 },
                    { Guid.NewGuid(), "Orion", 350.00}
                }
        );
    }

    /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
              migrationBuilder.DeleteData(
                  table: "Products",
                  keyColumn: "Name",
                  keyValues: new []
                  {
                      "Sumol" ,
                      "Orion"
              
                  });
        }
    }
}
