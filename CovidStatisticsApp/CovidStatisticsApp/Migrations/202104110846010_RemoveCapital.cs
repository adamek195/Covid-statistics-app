namespace CovidStatisticsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCapital : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Countries", "Capital");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Countries", "Capital", c => c.String(nullable: false, maxLength: 64));
        }
    }
}
