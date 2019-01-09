namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModelsasadas : DbMigration
    {

        public override void Up()
        {
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
