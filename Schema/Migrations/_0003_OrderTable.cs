using System;
using FluentMigrator;
using FluentMigrator.Postgres;
using FluentMigrator.SqlServer;

namespace Schema
{
    [Migration(3)]
    public class _0003_OrderTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Order")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().Indexed().NotNullable()
                .WithColumn("Note").AsString().Nullable();
        }
        
    }
}