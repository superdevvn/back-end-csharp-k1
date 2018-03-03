namespace SuperDev.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentLocation",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DepartmentId, t.LocationId })
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .Index(t => t.DepartmentId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50),
                        Name = c.String(),
                        SSN = c.String(),
                        AssDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.Dependent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Name = c.String(),
                        Sex = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Relationship = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        SupervisorId = c.Int(),
                        Username = c.String(),
                        Password = c.String(),
                        Code = c.String(maxLength: 50),
                        Name = c.String(),
                        Address = c.String(),
                        Salary = c.Double(nullable: false),
                        Sex = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        StartedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Employee", t => t.SupervisorId)
                .Index(t => t.DepartmentId)
                .Index(t => t.SupervisorId)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        Code = c.String(maxLength: 50),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .Index(t => t.LocationId)
                .Index(t => t.DepartmentId)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.WorkOn",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Hours = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.ProjectId })
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOn", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.WorkOn", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Project", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Project", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Dependent", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "SupervisorId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.DepartmentLocation", "LocationId", "dbo.Location");
            DropForeignKey("dbo.DepartmentLocation", "DepartmentId", "dbo.Department");
            DropIndex("dbo.WorkOn", new[] { "ProjectId" });
            DropIndex("dbo.WorkOn", new[] { "EmployeeId" });
            DropIndex("dbo.Project", new[] { "Code" });
            DropIndex("dbo.Project", new[] { "DepartmentId" });
            DropIndex("dbo.Project", new[] { "LocationId" });
            DropIndex("dbo.Employee", new[] { "Code" });
            DropIndex("dbo.Employee", new[] { "SupervisorId" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Dependent", new[] { "EmployeeId" });
            DropIndex("dbo.Location", new[] { "Code" });
            DropIndex("dbo.Department", new[] { "Code" });
            DropIndex("dbo.DepartmentLocation", new[] { "LocationId" });
            DropIndex("dbo.DepartmentLocation", new[] { "DepartmentId" });
            DropTable("dbo.WorkOn");
            DropTable("dbo.Project");
            DropTable("dbo.Employee");
            DropTable("dbo.Dependent");
            DropTable("dbo.Location");
            DropTable("dbo.Department");
            DropTable("dbo.DepartmentLocation");
        }
    }
}
