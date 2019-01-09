namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "AccountType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "AccountType", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
