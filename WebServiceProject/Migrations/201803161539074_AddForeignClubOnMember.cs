namespace ClubCompetition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignClubOnMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "ClubId", c => c.Int(nullable: false));
            CreateIndex("dbo.Member", "ClubId");
            AddForeignKey("dbo.Member", "ClubId", "dbo.Club", "ClubId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Member", "ClubId", "dbo.Club");
            DropIndex("dbo.Member", new[] { "ClubId" });
            DropColumn("dbo.Member", "ClubId");
        }
    }
}
