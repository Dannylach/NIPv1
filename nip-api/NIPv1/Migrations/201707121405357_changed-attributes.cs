namespace NIPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedattributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyEntities", "Name", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyEntities", "Name", c => c.String(maxLength: 50));
        }
    }
}
