namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnot : DbMigration
    {

        public override void Up()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Genre", c => c.String());
            AlterColumn("dbo.Movies", "Description", c => c.String());
            AlterColumn("dbo.Movies", "Title", c => c.String());
        }
    }
}
