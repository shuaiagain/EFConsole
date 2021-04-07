namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Donator_Add_CreateTime1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Provinces", "CreateTime", c => c.DateTime(nullable: false, defaultValueSql: "GetDate()"));
        }

        public override void Down()
        {
            DropColumn("dbo.Provinces", "CreateTime");
        }
    }
}
