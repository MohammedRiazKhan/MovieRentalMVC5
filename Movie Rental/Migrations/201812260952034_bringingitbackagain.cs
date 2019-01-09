namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bringingitbackagain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "DateRented", c => c.String());
            AlterColumn("dbo.Rentals", "DateReturned", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            AlterColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false));
        }
    }
}
