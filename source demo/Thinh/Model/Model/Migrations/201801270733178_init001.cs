namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 15),
                        description = c.String(maxLength: 30),
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        CreateBy = c.Guid(),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Firstname = c.String(maxLength: 50),
                        Lastname = c.String(maxLength: 50),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreateBy)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.CreateBy)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(maxLength: 15),
                        Name = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.Manufacters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(maxLength: 15),
                        Name = c.String(maxLength: 15),
                        Description = c.String(maxLength: 50),
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
                "dbo.Orderlines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        ProductId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        ManufacterId = c.Guid(),
                        Code = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .ForeignKey("dbo.Manufacters", t => t.ManufacterId)
                .ForeignKey("dbo.Users", t => t.UpdatedBy)
                .Index(t => t.CategoryId, unique: true, name: "IX_Code")
                .Index(t => t.ManufacterId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orderlines", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "UpdatedBy", "dbo.Users");
            DropForeignKey("dbo.Products", "ManufacterId", "dbo.Manufacters");
            DropForeignKey("dbo.Products", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Manufacters", "UpdatedBy", "dbo.Users");
            DropForeignKey("dbo.Manufacters", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Categories", "UpdatedBy", "dbo.Users");
            DropForeignKey("dbo.Categories", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "CreateBy", "dbo.Users");
            DropIndex("dbo.Products", new[] { "UpdatedBy" });
            DropIndex("dbo.Products", new[] { "CreatedBy" });
            DropIndex("dbo.Products", new[] { "ManufacterId" });
            DropIndex("dbo.Products", "IX_Code");
            DropIndex("dbo.Orderlines", new[] { "ProductId" });
            DropIndex("dbo.Manufacters", new[] { "UpdatedBy" });
            DropIndex("dbo.Manufacters", new[] { "CreatedBy" });
            DropIndex("dbo.Manufacters", new[] { "Code" });
            DropIndex("dbo.Roles", new[] { "Code" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Users", new[] { "CreateBy" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Categories", new[] { "UpdatedBy" });
            DropIndex("dbo.Categories", new[] { "CreatedBy" });
            DropTable("dbo.Products");
            DropTable("dbo.Orderlines");
            DropTable("dbo.Manufacters");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
        }
    }
}
