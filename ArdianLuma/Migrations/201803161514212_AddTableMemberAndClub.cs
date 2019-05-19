namespace luma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableMemberAndClub : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Club",
                c => new
                    {
                        ClubId = c.Int(nullable: false, identity: true),
                        ClubName = c.String(nullable: false, maxLength: 255),
                        Location = c.String(maxLength: 255),
                        Motto = c.String(maxLength: 255),
                        EstablishedDate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClubId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(maxLength: 255),
                        DateOfBirth = c.DateTime(nullable: false),
                        Height = c.Int(),
                        Weight = c.Int(),
                        Email = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Member");
            DropTable("dbo.Club");
        }
    }
}
