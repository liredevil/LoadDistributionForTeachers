namespace LoadDistributionForTeachers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subgroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfStudents = c.Int(nullable: false),
                        GroupNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.AcademicDegrees", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AcademicDegrees", "Title", c => c.String());
            DropTable("dbo.Subgroups");
        }
    }
}
