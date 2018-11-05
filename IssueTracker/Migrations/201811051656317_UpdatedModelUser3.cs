namespace IssueTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModelUser3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccounts", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.UserAccounts", "LastName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAccounts", "LastName");
            DropColumn("dbo.UserAccounts", "FirstName");
        }
    }
}
