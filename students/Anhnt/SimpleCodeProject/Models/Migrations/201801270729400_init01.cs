namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdateBy = c.Guid(),
                        CreatedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .ForeignKey("dbo.Users", t => t.UpdateBy)
                .Index(t => t.UpdateBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Description = c.String(),
                        CreatedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdateBy = c.Guid(),
                        CreatedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .ForeignKey("dbo.Users", t => t.UpdateBy)
                .Index(t => t.UpdateBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdateBy = c.Guid(),
                        CreatedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .ForeignKey("dbo.Users", t => t.UpdateBy)
                .Index(t => t.UpdateBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CategoryId = c.Guid(),
                        ManufacturerId = c.Guid(),
                        Code = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdateBy = c.Guid(),
                        CreatedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId)
                .ForeignKey("dbo.Users", t => t.UpdateBy)
                .Index(t => t.CategoryId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.UpdateBy)
                .Index(t => t.CreatedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UpdateBy", "dbo.Users");
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Products", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "UpdateBy", "dbo.Users");
            DropForeignKey("dbo.Customers", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Manufacturers", "UpdateBy", "dbo.Users");
            DropForeignKey("dbo.Manufacturers", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Categories", "UpdateBy", "dbo.Users");
            DropForeignKey("dbo.Categories", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Users", "CreatedBy", "dbo.Users");
            DropIndex("dbo.Products", new[] { "CreatedBy" });
            DropIndex("dbo.Products", new[] { "UpdateBy" });
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Customers", new[] { "CreatedBy" });
            DropIndex("dbo.Customers", new[] { "UpdateBy" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Manufacturers", new[] { "CreatedBy" });
            DropIndex("dbo.Manufacturers", new[] { "UpdateBy" });
            DropIndex("dbo.Users", new[] { "CreatedBy" });
            DropIndex("dbo.Categories", new[] { "CreatedBy" });
            DropIndex("dbo.Categories", new[] { "UpdateBy" });
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
        }
    }
}
