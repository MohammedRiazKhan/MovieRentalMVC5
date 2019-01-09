namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnno : DbMigration
    {

        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "AccountType", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "AccountType", c => c.String());
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
        }
    }
}
