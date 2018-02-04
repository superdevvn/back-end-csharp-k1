namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleId = c.Guid(),
                        CreatedBy = c.Guid(nullable: false),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.CreatedBy)
                .Index(t => t.Username, unique: true, name: "Ix_Username");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "CreatedBy", "dbo.Users");
            DropIndex("dbo.Users", "Ix_Username");
            DropIndex("dbo.Users", new[] { "CreatedBy" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
