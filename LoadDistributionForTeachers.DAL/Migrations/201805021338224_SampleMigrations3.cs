namespace LoadDistributionForTeachers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations3 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentOfThePlans", "DisciplineId", "dbo.Disciplines");
            DropForeignKey("dbo.ContentOfThePlans", "AcademicPlanId", "dbo.AcademicPlans");
            DropIndex("dbo.ContentOfThePlans", new[] { "DisciplineId" });
            DropIndex("dbo.ContentOfThePlans", new[] { "AcademicPlanId" });
            DropTable("dbo.ContentOfThePlans");
        }
    }
}
