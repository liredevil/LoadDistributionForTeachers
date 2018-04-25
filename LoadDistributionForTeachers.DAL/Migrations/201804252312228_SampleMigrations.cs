namespace LoadDistributionForTeachers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupCode = c.Int(nullable: false),
                        NameOfSpecialty = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AcademicPlans");
        }
    }
}
