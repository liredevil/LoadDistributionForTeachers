namespace LoadDistributionForTeachers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subgroups", "GroupNumber2", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subgroups", "GroupNumber2");
        }
    }
}
