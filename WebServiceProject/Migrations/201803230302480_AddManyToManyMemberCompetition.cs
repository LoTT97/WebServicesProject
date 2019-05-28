namespace ClubCompetition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyToManyMemberCompetition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberCompetition",
                c => new
                    {
                        MemberId = c.Int(nullable: false),
                        CompetitionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MemberId, t.CompetitionId })
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Competition", t => t.CompetitionId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.CompetitionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberCompetition", "CompetitionId", "dbo.Competition");
            DropForeignKey("dbo.MemberCompetition", "MemberId", "dbo.Member");
            DropIndex("dbo.MemberCompetition", new[] { "CompetitionId" });
            DropIndex("dbo.MemberCompetition", new[] { "MemberId" });
            DropTable("dbo.MemberCompetition");
        }
    }
}
