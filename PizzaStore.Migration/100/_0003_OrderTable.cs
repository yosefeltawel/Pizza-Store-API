using FluentMigrator;

namespace PizzaStore.Migration._100;

[Migration(3)]
public class _0003_OrderTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.Order)
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Note").AsString().Nullable();
    }
}