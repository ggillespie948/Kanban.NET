namespace IssueTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProjectModels", "ApplicationUser_Id");
            AddForeignKey("dbo.ProjectModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ProjectModels", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.ProjectModels", "ApplicationUser_Id");
        }
    }
}
