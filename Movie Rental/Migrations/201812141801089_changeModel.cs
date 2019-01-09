namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeModel : DbMigration
    {

        public override void Up()
        {
            DropColumn("dbo.Movies", "NewRelease");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "NewRelease", c => c.Boolean(nullable: false));
        }
    }
}
