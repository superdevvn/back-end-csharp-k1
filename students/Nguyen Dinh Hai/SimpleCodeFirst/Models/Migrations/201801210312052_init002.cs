namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init002 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "Username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Username" });
        }
    }
}
