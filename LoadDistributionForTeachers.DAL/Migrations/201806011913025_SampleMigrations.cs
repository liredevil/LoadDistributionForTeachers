namespace LoadDistributionForTeachers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicDegrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Patronymic = c.String(nullable: false),
                        AcademicDegreeId = c.Int(nullable: false),
                        AcademicTitleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicDegrees", t => t.AcademicDegreeId, cascadeDelete: true)
                .ForeignKey("dbo.AcademicTitles", t => t.AcademicTitleId, cascadeDelete: true)
                .Index(t => t.AcademicDegreeId)
                .Index(t => t.AcademicTitleId);
            
            CreateTable(
                "dbo.AcademicTitles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoadFlows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ContentOfThePlanId = c.Int(nullable: false),
                        LectureFlowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContentOfThePlans", t => t.ContentOfThePlanId, cascadeDelete: true)
                .ForeignKey("dbo.LectureFlows", t => t.LectureFlowId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ContentOfThePlanId)
                .Index(t => t.LectureFlowId);
            
            CreateTable(
                "dbo.ContentOfThePlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfHoursOfLectures = c.Int(nullable: false),
                        NumberOfHoursOfPractice = c.Int(nullable: false),
                        SemesterNumber = c.Int(nullable: false),
                        Reporting = c.String(nullable: false),
                        AcademicPlanId = c.Int(nullable: false),
                        DisciplineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicPlans", t => t.AcademicPlanId, cascadeDelete: true)
                .ForeignKey("dbo.Disciplines", t => t.DisciplineId, cascadeDelete: true)
                .Index(t => t.AcademicPlanId)
                .Index(t => t.DisciplineId);
            
            CreateTable(
                "dbo.AcademicPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupCode = c.Int(nullable: false),
                        NameOfSpecialty = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoadSubgroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ContentOfThePlanId = c.Int(nullable: false),
                        SubgroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContentOfThePlans", t => t.ContentOfThePlanId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Subgroups", t => t.SubgroupId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ContentOfThePlanId)
                .Index(t => t.SubgroupId);
            
            CreateTable(
                "dbo.Subgroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfStudents = c.Int(nullable: false),
                        GroupNumber = c.Int(nullable: false),
                        LectureFlowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LectureFlows", t => t.LectureFlowId, cascadeDelete: true)
                .Index(t => t.LectureFlowId);
            
            CreateTable(
                "dbo.LectureFlows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ClientProfiles", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LoadFlows", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.LoadSubgroups", "SubgroupId", "dbo.Subgroups");
            DropForeignKey("dbo.Subgroups", "LectureFlowId", "dbo.LectureFlows");
            DropForeignKey("dbo.LoadFlows", "LectureFlowId", "dbo.LectureFlows");
            DropForeignKey("dbo.LoadSubgroups", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.LoadSubgroups", "ContentOfThePlanId", "dbo.ContentOfThePlans");
            DropForeignKey("dbo.LoadFlows", "ContentOfThePlanId", "dbo.ContentOfThePlans");
            DropForeignKey("dbo.ContentOfThePlans", "DisciplineId", "dbo.Disciplines");
            DropForeignKey("dbo.ContentOfThePlans", "AcademicPlanId", "dbo.AcademicPlans");
            DropForeignKey("dbo.Employees", "AcademicTitleId", "dbo.AcademicTitles");
            DropForeignKey("dbo.Employees", "AcademicDegreeId", "dbo.AcademicDegrees");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ClientProfiles", new[] { "Id" });
            DropIndex("dbo.Subgroups", new[] { "LectureFlowId" });
            DropIndex("dbo.LoadSubgroups", new[] { "SubgroupId" });
            DropIndex("dbo.LoadSubgroups", new[] { "ContentOfThePlanId" });
            DropIndex("dbo.LoadSubgroups", new[] { "EmployeeId" });
            DropIndex("dbo.ContentOfThePlans", new[] { "DisciplineId" });
            DropIndex("dbo.ContentOfThePlans", new[] { "AcademicPlanId" });
            DropIndex("dbo.LoadFlows", new[] { "LectureFlowId" });
            DropIndex("dbo.LoadFlows", new[] { "ContentOfThePlanId" });
            DropIndex("dbo.LoadFlows", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "AcademicTitleId" });
            DropIndex("dbo.Employees", new[] { "AcademicDegreeId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ClientProfiles");
            DropTable("dbo.LectureFlows");
            DropTable("dbo.Subgroups");
            DropTable("dbo.LoadSubgroups");
            DropTable("dbo.Disciplines");
            DropTable("dbo.AcademicPlans");
            DropTable("dbo.ContentOfThePlans");
            DropTable("dbo.LoadFlows");
            DropTable("dbo.AcademicTitles");
            DropTable("dbo.Employees");
            DropTable("dbo.AcademicDegrees");
        }
    }
}
