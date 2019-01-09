namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {

        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        AccountType = c.String(),
                        Credit = c.Double(nullable: false),
                        CanRent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Genre = c.String(),
                        Price = c.Double(nullable: false),
                        ReleaseYear = c.Int(nullable: false),
                        AvailableForRent = c.Boolean(nullable: false),
                        NewRelease = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        RentalId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        RentDate = c.String(),
                        ReturnDate = c.String(),
                        Cost = c.Double(nullable: false),
                        Returned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RentalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rentals");
            DropTable("dbo.Movies");
            DropTable("dbo.Customers");
        }
    }
}
