namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Donator_Name_Add_Index : DbMigration
    {
        public override void Up()
        {
            CreateIndex(
          "Donators",
          new[] { "Name" },
          name: "Index_Donator_Name"
          );
        }

        public override void Down()
        {
            DropIndex("Donators", "Index_Donator_Name");
        }
    }
}
