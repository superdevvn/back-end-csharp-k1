namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init001 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "Code", c => c.String(maxLength: 10));
            AlterColumn("dbo.Roles", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String());
            AlterColumn("dbo.Roles", "Code", c => c.String());
        }
    }
}
