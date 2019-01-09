namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migss : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Description", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
