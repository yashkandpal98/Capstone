namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManagerToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        EmployeeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ManagerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Managers");
        }
    }
}
