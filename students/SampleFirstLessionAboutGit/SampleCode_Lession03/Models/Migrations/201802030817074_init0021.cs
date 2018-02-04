namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init0021 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "CreatedBy", "dbo.Users");
            DropIndex("dbo.Users", new[] { "CreatedBy" });
            RenameColumn(table: "dbo.Users", name: "RoleId", newName: "Role_Id");
            RenameIndex(table: "dbo.Users", name: "IX_RoleId", newName: "IX_Role_Id");
            DropColumn("dbo.Users", "CreatedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CreatedBy", c => c.Guid(nullable: false));
            RenameIndex(table: "dbo.Users", name: "IX_Role_Id", newName: "IX_RoleId");
            RenameColumn(table: "dbo.Users", name: "Role_Id", newName: "RoleId");
            CreateIndex("dbo.Users", "CreatedBy");
            AddForeignKey("dbo.Users", "CreatedBy", "dbo.Users", "Id");
        }
    }
}
