namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovies : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Movies values ('Batman', 'Movie about a man with anger issues', 'Sperhero', 15, 2001, 'true', 'false')");

        }
        

        public override void Down()
        {
        }
    }
}
