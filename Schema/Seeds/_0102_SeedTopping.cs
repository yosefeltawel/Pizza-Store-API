using FluentMigrator;

namespace Schema
{
    [Migration(102)]
    public class _0102_SeedTopping : AutoReversingMigration
    {
        public override void Up()
        {
            Insert.IntoTable("Topping")
                .Row(new
                {
                    Name = "Cheddar", Price = 15
                })
                .Row(new
                {
                    Name = "Pepperoni", Price = 15
                })
                .Row(new
                {
                    Name = "Sausage", Price = 15
                })
                .Row(new
                {
                    Name = "Ranch Sauce", Price = 15
                });
        }
    }
}