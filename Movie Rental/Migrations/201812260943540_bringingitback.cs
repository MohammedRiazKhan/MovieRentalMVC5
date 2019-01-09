namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bringingitback : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Movie_MovieId", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Rentals", new[] { "Movie_MovieId" });
            AddColumn("dbo.Rentals", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "MovieId", c => c.Int(nullable: false));
            DropColumn("dbo.Rentals", "Customer_CustomerId");
            DropColumn("dbo.Rentals", "Movie_MovieId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "Movie_MovieId", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "Customer_CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.Rentals", "MovieId");
            DropColumn("dbo.Rentals", "CustomerId");
            CreateIndex("dbo.Rentals", "Movie_MovieId");
            CreateIndex("dbo.Rentals", "Customer_CustomerId");
            AddForeignKey("dbo.Rentals", "Movie_MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Customer_CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
