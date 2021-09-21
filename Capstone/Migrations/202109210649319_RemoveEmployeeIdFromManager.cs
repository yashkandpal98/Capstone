namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEmployeeIdFromManager : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Managers", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Managers", "EmployeeId", c => c.Byte(nullable: false));
        }
    }
}
