namespace NIPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleted_attributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyEntities", "Krs", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyEntities", "Krs", c => c.String(maxLength: 10));
        }
    }
}
