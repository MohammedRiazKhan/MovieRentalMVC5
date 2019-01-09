namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSQLServerModel : DbMigration
    {

        public override void Up()
        {

            Sql("INSERT INTO Customers values('Riaz', 'Khan', '123', 'c', 123, 1)");

        }
        
        public override void Down()
        {
            

        }
    }
}
