namespace LoadDistributionForTeachers.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoadSubgroups", "TypeOfEmployee_Id", "dbo.TypeOfEmployees");
            DropIndex("dbo.LoadSubgroups", new[] { "TypeOfEmployee_Id" });
            DropColumn("dbo.LoadSubgroups", "TypeOfEmployee_Id");
            DropTable("dbo.TypeOfEmployees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TypeOfEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.LoadSubgroups", "TypeOfEmployee_Id", c => c.Int());
            CreateIndex("dbo.LoadSubgroups", "TypeOfEmployee_Id");
            AddForeignKey("dbo.LoadSubgroups", "TypeOfEmployee_Id", "dbo.TypeOfEmployees", "Id");
        }
    }
}
