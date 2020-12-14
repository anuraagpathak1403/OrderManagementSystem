namespace ORMData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OMS_Models_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 200),
                        LastName = c.String(maxLength: 200),
                        EmailAddress = c.String(maxLength: 200),
                        MobileNumber = c.Long(nullable: false),
                        Address = c.String(nullable: false, maxLength: 500),
                        Password = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Long(nullable: false, identity: true),
                        InventoryName = c.String(nullable: false, maxLength: 300),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageInventoryId = c.Long(nullable: false),
                        Stock_Keeping_Unit = c.String(maxLength: 50),
                        Barcode = c.String(maxLength: 15),
                        AvailableQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedBy = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId);
            
            CreateTable(
                "dbo.InventoryAttachements",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FileName = c.String(maxLength: 100),
                        AttachmentPath = c.String(maxLength: 600),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Long(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        OrderId = c.Long(nullable: false, identity: true),
                        InventoryId = c.Long(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOrder = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Long(nullable: false),
                        SalesManLoginDomain = c.Long(nullable: false),
                        Status = c.Long(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedBy = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.SalesManInfoes", t => t.SalesManLoginDomain, cascadeDelete: true)
                .ForeignKey("dbo.StatusMasters", t => t.Status, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.SalesManLoginDomain)
                .Index(t => t.Status);
            
            CreateTable(
                "dbo.SalesManInfoes",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        LoginDomain = c.String(nullable: false, maxLength: 200),
                        FirstName = c.String(nullable: false, maxLength: 200),
                        LastName = c.String(maxLength: 200),
                        MobileNumber = c.Long(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedBy = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.StatusMasters",
                c => new
                    {
                        StatusId = c.Long(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderStatus", "Status", "dbo.StatusMasters");
            DropForeignKey("dbo.OrderStatus", "SalesManLoginDomain", "dbo.SalesManInfoes");
            DropForeignKey("dbo.OrderStatus", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderStatus", new[] { "Status" });
            DropIndex("dbo.OrderStatus", new[] { "SalesManLoginDomain" });
            DropIndex("dbo.OrderStatus", new[] { "CustomerId" });
            DropTable("dbo.StatusMasters");
            DropTable("dbo.SalesManInfoes");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.InventoryAttachements");
            DropTable("dbo.Inventories");
            DropTable("dbo.Customers");
        }
    }
}
