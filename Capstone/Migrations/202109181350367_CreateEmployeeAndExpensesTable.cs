namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmployeeAndExpensesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsManager = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ExpenseType = c.String(),
                        ExpenseAmount = c.Int(nullable: false),
                        DateIncurred = c.DateTime(),
                        DateSubmitted = c.DateTime(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ExpenseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Expenses");
            DropTable("dbo.Employees");
        }
    }
}
