namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManagerIdToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ManagerId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ManagerId");
        }
    }
}
