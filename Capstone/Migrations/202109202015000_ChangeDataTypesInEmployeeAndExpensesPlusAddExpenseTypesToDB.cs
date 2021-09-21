namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataTypesInEmployeeAndExpenses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Password", c => c.String());
            CreateIndex("dbo.Expenses", "ExpenseTypeId");
            CreateIndex("dbo.Expenses", "StatusId");
            AddForeignKey("dbo.Expenses", "ExpenseTypeId", "dbo.ExpenseTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Expenses", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            DropColumn("dbo.Employees", "PasswordId");
            DropColumn("dbo.Employees", "Password_PassWord");
            DropColumn("dbo.Expenses", "ExpenseType_Type");
            DropColumn("dbo.Expenses", "Status_StatusType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "Status_StatusType", c => c.String());
            AddColumn("dbo.Expenses", "ExpenseType_Type", c => c.String());
            AddColumn("dbo.Employees", "Password_PassWord", c => c.String());
            AddColumn("dbo.Employees", "PasswordId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Expenses", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Expenses", "ExpenseTypeId", "dbo.ExpenseTypes");
            DropIndex("dbo.Expenses", new[] { "StatusId" });
            DropIndex("dbo.Expenses", new[] { "ExpenseTypeId" });
            DropColumn("dbo.Employees", "Password");
        }
    }
}
