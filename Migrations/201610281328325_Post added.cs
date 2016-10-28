namespace ChatterBugs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Postadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followers", "FollowedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followers", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.Followers", new[] { "FollowedBy_Id" });
            DropIndex("dbo.Followers", new[] { "User_Id" });
            DropIndex("dbo.Followers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Followers", new[] { "ApplicationUser_Id1" });
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        PostMessage = c.String(maxLength: 150),
                        CreatedDate = c.String(),
                    })
                .PrimaryKey(t => t.PostID);
            
            CreateTable(
                "dbo.ApplicationUser_Follow",
                c => new
                    {
                        ApplicationUserID = c.String(nullable: false, maxLength: 128),
                        FollowerID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUserID, t.FollowerID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerID)
                .Index(t => t.ApplicationUserID)
                .Index(t => t.FollowerID);
            
            AddColumn("dbo.AspNetUsers", "UserPost_PostID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "UserPost_PostID");
            AddForeignKey("dbo.AspNetUsers", "UserPost_PostID", "dbo.Posts", "PostID");
            DropTable("dbo.Followers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        FollowerID = c.Int(nullable: false),
                        FollowerType = c.Int(nullable: false),
                        FollowedBy_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.AspNetUsers", "UserPost_PostID", "dbo.Posts");
            DropForeignKey("dbo.ApplicationUser_Follow", "FollowerID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUser_Follow", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUser_Follow", new[] { "FollowerID" });
            DropIndex("dbo.ApplicationUser_Follow", new[] { "ApplicationUserID" });
            DropIndex("dbo.AspNetUsers", new[] { "UserPost_PostID" });
            DropColumn("dbo.AspNetUsers", "UserPost_PostID");
            DropTable("dbo.ApplicationUser_Follow");
            DropTable("dbo.Posts");
            CreateIndex("dbo.Followers", "ApplicationUser_Id1");
            CreateIndex("dbo.Followers", "ApplicationUser_Id");
            CreateIndex("dbo.Followers", "User_Id");
            CreateIndex("dbo.Followers", "FollowedBy_Id");
            AddForeignKey("dbo.Followers", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Followers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Followers", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Followers", "FollowedBy_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
