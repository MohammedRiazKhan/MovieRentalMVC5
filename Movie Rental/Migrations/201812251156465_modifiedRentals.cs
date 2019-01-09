namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedRentals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            AddColumn("dbo.Rentals", "Customer_CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "Movie_MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "Customer_CustomerId");
            CreateIndex("dbo.Rentals", "Movie_MovieId");
            AddForeignKey("dbo.Rentals", "Customer_CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Movie_MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
            DropColumn("dbo.Rentals", "CustomerId");
            DropColumn("dbo.Rentals", "MovieId");
            DropColumn("dbo.Rentals", "RentDate");
            DropColumn("dbo.Rentals", "ReturnDate");
            DropColumn("dbo.Rentals", "Cost");
            DropColumn("dbo.Rentals", "Returned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "Returned", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rentals", "Cost", c => c.Double(nullable: false));
            AddColumn("dbo.Rentals", "ReturnDate", c => c.String());
            AddColumn("dbo.Rentals", "RentDate", c => c.String());
            AddColumn("dbo.Rentals", "MovieId", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rentals", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movie_MovieId" });
            DropIndex("dbo.Rentals", new[] { "Customer_CustomerId" });
            DropColumn("dbo.Rentals", "Movie_MovieId");
            DropColumn("dbo.Rentals", "Customer_CustomerId");
            DropColumn("dbo.Rentals", "DateReturned");
            DropColumn("dbo.Rentals", "DateRented");
        }
    }
}
