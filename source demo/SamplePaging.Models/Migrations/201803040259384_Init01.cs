namespace SamplePaging.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Demo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Salary = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Demo");
        }
    }
}
