namespace ORMData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_ForeignKey_OrderStatus : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.OrderStatus", "InventoryId");
            AddForeignKey("dbo.OrderStatus", "InventoryId", "dbo.Inventories", "InventoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderStatus", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.OrderStatus", new[] { "InventoryId" });
        }
    }
}
