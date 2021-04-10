namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Donator_Remove_CreateTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Donators", "CreateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Donators", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}
