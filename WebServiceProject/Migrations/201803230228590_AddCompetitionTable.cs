namespace ClubCompetition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompetitionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Competition",
                c => new
                    {
                        CompetitionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Location = c.String(maxLength: 255),
                        StartDate = c.String(nullable: false),
                        EndDate = c.String(nullable: false),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.CompetitionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Competition");
        }
    }
}
