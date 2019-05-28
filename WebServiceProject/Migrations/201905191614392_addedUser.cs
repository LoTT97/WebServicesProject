namespace ClubCompetition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "userPassword", c => c.String());
            DropColumn("dbo.Users", "userPasswoord");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "userPasswoord", c => c.String());
            DropColumn("dbo.Users", "userPassword");
        }
    }
}
