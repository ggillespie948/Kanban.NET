namespace IssueTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "ProjectModels_Id", "dbo.ProjectModels");
            DropIndex("dbo.ProjectModels", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "ProjectModels_Id" });
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAccountProjectModels",
                c => new
                    {
                        UserAccount_Id = c.Int(nullable: false),
                        ProjectModels_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserAccount_Id, t.ProjectModels_Id })
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProjectModels", t => t.ProjectModels_Id, cascadeDelete: true)
                .Index(t => t.UserAccount_Id)
                .Index(t => t.ProjectModels_Id);
            
            AddColumn("dbo.ProjectTasks", "UserAccount_Id", c => c.Int());
            AddColumn("dbo.ProjectTasks", "ProjectModels_Id", c => c.Int());
            CreateIndex("dbo.ProjectTasks", "UserAccount_Id");
            CreateIndex("dbo.ProjectTasks", "ProjectModels_Id");
            AddForeignKey("dbo.ProjectTasks", "UserAccount_Id", "dbo.UserAccounts", "Id");
            AddForeignKey("dbo.ProjectTasks", "ProjectModels_Id", "dbo.ProjectModels", "Id");
            DropColumn("dbo.ProjectModels", "ApplicationUser_Id");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "ProjectModels_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ProjectModels_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.ProjectModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.ProjectTasks", "ProjectModels_Id", "dbo.ProjectModels");
            DropForeignKey("dbo.ProjectTasks", "UserAccount_Id", "dbo.UserAccounts");
            DropForeignKey("dbo.UserAccountProjectModels", "ProjectModels_Id", "dbo.ProjectModels");
            DropForeignKey("dbo.UserAccountProjectModels", "UserAccount_Id", "dbo.UserAccounts");
            DropIndex("dbo.UserAccountProjectModels", new[] { "ProjectModels_Id" });
            DropIndex("dbo.UserAccountProjectModels", new[] { "UserAccount_Id" });
            DropIndex("dbo.ProjectTasks", new[] { "ProjectModels_Id" });
            DropIndex("dbo.ProjectTasks", new[] { "UserAccount_Id" });
            DropColumn("dbo.ProjectTasks", "ProjectModels_Id");
            DropColumn("dbo.ProjectTasks", "UserAccount_Id");
            DropTable("dbo.UserAccountProjectModels");
            DropTable("dbo.UserAccounts");
            CreateIndex("dbo.AspNetUsers", "ProjectModels_Id");
            CreateIndex("dbo.ProjectModels", "ApplicationUser_Id");
            AddForeignKey("dbo.AspNetUsers", "ProjectModels_Id", "dbo.ProjectModels", "Id");
            AddForeignKey("dbo.ProjectModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
