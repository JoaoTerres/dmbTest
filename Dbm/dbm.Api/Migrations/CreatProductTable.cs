using FluentMigrator;

namespace dbm.Api.Migrations;

[Migration(20241112)]
public class CreatProductTable : Migration
{
    public override void Up()
    {
        Create.Table("Products")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("Description").AsString().Nullable()
            .WithColumn("Price").AsDecimal().NotNullable()
            .WithColumn("_ts_Create").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

        Insert.IntoTable("Products").Row(new
        {
            Name = "Produto 1",
            Description = "Descrição do Produto 1",
            Price = 10.99m,
            _ts_Create = SystemMethods.CurrentDateTime
        });

        Insert.IntoTable("Products").Row(new
        {
            Name = "Produto 2",
            Description = "Descrição do Produto 2",
            Price = 20.99m,
            _ts_Create = SystemMethods.CurrentDateTime
        });
    }

    public override void Down()
    {
        Delete.Table("Products");
    }
}
