namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeModelAgain : DbMigration
    {

        public override void Up()
        {
            AddColumn("dbo.Movies", "NewRelease", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NewRelease");
        }
    }
}
