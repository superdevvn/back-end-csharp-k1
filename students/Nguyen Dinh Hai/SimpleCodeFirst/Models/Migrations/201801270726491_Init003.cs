namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init003 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 1000),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .ForeignKey("dbo.Users", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(maxLength: 15),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .ForeignKey("dbo.Users", t => t.UpdatedBy)
                .Index(t => t.Code, unique: true)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        ManufacturerId = c.Guid(),
                        Code = c.String(maxLength: 15),
                        Name = c.String(maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 1000),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId)
                .ForeignKey("dbo.Users", t => t.UpdatedBy)
                .Index(t => t.CategoryId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.Code, unique: true)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
            
            CreateIndex("dbo.Roles", "Code", unique: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UpdatedBy", "dbo.Users");
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Products", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Manufacturers", "UpdatedBy", "dbo.Users");
            DropForeignKey("dbo.Manufacturers", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Categories", "UpdatedBy", "dbo.Users");
            DropForeignKey("dbo.Categories", "CreatedBy", "dbo.Users");
            DropIndex("dbo.Products", new[] { "UpdatedBy" });
            DropIndex("dbo.Products", new[] { "CreatedBy" });
            DropIndex("dbo.Products", new[] { "Code" });
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Manufacturers", new[] { "UpdatedBy" });
            DropIndex("dbo.Manufacturers", new[] { "CreatedBy" });
            DropIndex("dbo.Manufacturers", new[] { "Code" });
            DropIndex("dbo.Roles", new[] { "Code" });
            DropIndex("dbo.Categories", new[] { "UpdatedBy" });
            DropIndex("dbo.Categories", new[] { "CreatedBy" });
            DropTable("dbo.Products");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Categories");
        }
    }
}
