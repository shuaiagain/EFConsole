namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Donator_Add_CreateTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DonateDate = c.DateTime(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donators", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Donators", new[] { "ProvinceId" });
            DropTable("dbo.Provinces");
            DropTable("dbo.Donators");
        }
    }
}
