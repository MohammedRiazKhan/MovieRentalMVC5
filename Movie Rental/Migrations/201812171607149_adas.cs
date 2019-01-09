namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adas : DbMigration
    {

        public override void Up()
        {
            AddColumn("dbo.Rentals", "Customer_CustomerId", c => c.Int());
            AddColumn("dbo.Rentals", "Movie_MovieId", c => c.Int());
            CreateIndex("dbo.Rentals", "Customer_CustomerId");
            CreateIndex("dbo.Rentals", "Movie_MovieId");
            AddForeignKey("dbo.Rentals", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.Rentals", "Movie_MovieId", "dbo.Movies", "MovieId");
            DropColumn("dbo.Rentals", "CustomerId");
            DropColumn("dbo.Rentals", "MovieId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "MovieId", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rentals", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movie_MovieId" });
            DropIndex("dbo.Rentals", new[] { "Customer_CustomerId" });
            DropColumn("dbo.Rentals", "Movie_MovieId");
            DropColumn("dbo.Rentals", "Customer_CustomerId");
        }
    }
}
