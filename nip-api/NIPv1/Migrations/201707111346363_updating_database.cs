namespace NIPv1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updating_database : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Data", newName: "CompanyEntities");
            RenameTable(name: "dbo.Statistics", newName: "LogEntities");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.LogEntities", newName: "Statistics");
            RenameTable(name: "dbo.CompanyEntities", newName: "Data");
        }
    }
}
