namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManagerToDbAndRemoveColsFromEmployee : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "IsManager");
            DropColumn("dbo.Employees", "ManagerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ManagerId", c => c.Byte(nullable: false));
            AddColumn("dbo.Employees", "IsManager", c => c.Boolean(nullable: false));
        }
    }
}
