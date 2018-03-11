namespace SamplePaging.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Demo", "RoleId", c => c.Int());
            CreateIndex("dbo.Demo", "RoleId");
            AddForeignKey("dbo.Demo", "RoleId", "dbo.Role", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Demo", "RoleId", "dbo.Role");
            DropIndex("dbo.Demo", new[] { "RoleId" });
            DropColumn("dbo.Demo", "RoleId");
            DropTable("dbo.Role");
        }
    }
}
