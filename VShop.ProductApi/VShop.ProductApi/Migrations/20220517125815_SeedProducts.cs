using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId) " +
                "Values('Product 1', 7.55, 'Description 1', 10, 'caderno1.jpg', 1)");
            
            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId) " +
                "Values('Product 2', 10.89, 'Description 2', 20, 'lapis1.jpg', 2)");
            
            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId) " +
                "Values('Product 3', 25.75, 'Description 3', 30, 'clips1.jpg', 1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Products");
        }
    }
}
