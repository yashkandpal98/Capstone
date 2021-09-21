namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToManager : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Managers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Managers", "Name");
        }
    }
}
