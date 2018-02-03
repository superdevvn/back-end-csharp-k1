namespace SampleAPI.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.USers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.USers");
        }
    }
}
