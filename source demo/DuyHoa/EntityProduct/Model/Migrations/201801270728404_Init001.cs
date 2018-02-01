namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryName = c.String(),
                        CategoryDes = c.String(),
                        CreateBy = c.Guid(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.Guid(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreateBy)
                .ForeignKey("dbo.Users", t => t.UpdateBy)
                .Index(t => t.CreateBy)
                .Index(t => t.UpdateBy);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreateBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreateBy)
                .Index(t => t.CreateBy);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreateBy = c.Guid(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.Guid(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreateBy)
                .ForeignKey("dbo.Users", t => t.UpdateBy)
                .Index(t => t.CreateBy)
                .Index(t => t.UpdateBy);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateBy = c.Guid(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.Guid(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreateBy)
                .ForeignKey("dbo.Users", t => t.UpdateBy)
                .Index(t => t.CreateBy)
                .Index(t => t.UpdateBy);
            
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreateBy = c.Guid(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.Guid(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreateBy)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UpdateBy)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId)
                .Index(t => t.CreateBy)
                .Index(t => t.UpdateBy);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateBy = c.Guid(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.Guid(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreateBy)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Users", t => t.UpdateBy)
                .Index(t => t.CustomerId)
                .Index(t => t.CreateBy)
                .Index(t => t.UpdateBy);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        ManufacturerId = c.Guid(),
                        Code = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CreateBy = c.Guid(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.Guid(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreateBy)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId)
                .ForeignKey("dbo.Users", t => t.UpdateBy)
                .Index(t => t.CategoryId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.CreateBy)
                .Index(t => t.UpdateBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLines", "UpdateBy", "dbo.Users");
            DropForeignKey("dbo.OrderLines", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "UpdateBy", "dbo.Users");
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Products", "CreateBy", "dbo.Users");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderLines", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UpdateBy", "dbo.Users");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CreateBy", "dbo.Users");
            DropForeignKey("dbo.OrderLines", "CreateBy", "dbo.Users");
            DropForeignKey("dbo.Manufacturers", "UpdateBy", "dbo.Users");
            DropForeignKey("dbo.Manufacturers", "CreateBy", "dbo.Users");
            DropForeignKey("dbo.Customers", "UpdateBy", "dbo.Users");
            DropForeignKey("dbo.Customers", "CreateBy", "dbo.Users");
            DropForeignKey("dbo.Categories", "UpdateBy", "dbo.Users");
            DropForeignKey("dbo.Categories", "CreateBy", "dbo.Users");
            DropForeignKey("dbo.Users", "CreateBy", "dbo.Users");
            DropIndex("dbo.Products", new[] { "UpdateBy" });
            DropIndex("dbo.Products", new[] { "CreateBy" });
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Orders", new[] { "UpdateBy" });
            DropIndex("dbo.Orders", new[] { "CreateBy" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderLines", new[] { "UpdateBy" });
            DropIndex("dbo.OrderLines", new[] { "CreateBy" });
            DropIndex("dbo.OrderLines", new[] { "ProductId" });
            DropIndex("dbo.OrderLines", new[] { "OrderId" });
            DropIndex("dbo.Manufacturers", new[] { "UpdateBy" });
            DropIndex("dbo.Manufacturers", new[] { "CreateBy" });
            DropIndex("dbo.Customers", new[] { "UpdateBy" });
            DropIndex("dbo.Customers", new[] { "CreateBy" });
            DropIndex("dbo.Users", new[] { "CreateBy" });
            DropIndex("dbo.Categories", new[] { "UpdateBy" });
            DropIndex("dbo.Categories", new[] { "CreateBy" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderLines");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Customers");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
        }
    }
}
