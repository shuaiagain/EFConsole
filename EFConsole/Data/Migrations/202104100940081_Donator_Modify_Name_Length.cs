namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Donator_Modify_Name_Length : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donators", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donators", "Name", c => c.String());
        }
    }
}
