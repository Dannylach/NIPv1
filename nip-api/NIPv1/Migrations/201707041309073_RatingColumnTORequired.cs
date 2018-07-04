namespace NIPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingColumnToRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Data", "Rating", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Data", "Rating", c => c.String());
        }
    }
}
