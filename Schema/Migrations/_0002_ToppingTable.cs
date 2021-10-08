using FluentMigrator;

namespace Schema
{
    [Migration(2)]
    public class _0002_ToppingTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Topping")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity().Indexed()
                .WithColumn("Name").AsString(20).NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable();
        }
    }
}