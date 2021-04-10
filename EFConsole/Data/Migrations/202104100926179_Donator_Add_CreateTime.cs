namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Donator_Add_CreateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donators", "CreateTime", c => c.DateTime(nullable: false, defaultValueSql: "GetDate()"));
        }

        public override void Down()
        {
            DropColumn("dbo.Donators", "CreateTime");
        }
    }
}
