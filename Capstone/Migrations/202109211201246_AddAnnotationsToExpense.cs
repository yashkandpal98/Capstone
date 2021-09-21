namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationsToExpense : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expenses", "DateIncurred", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Expenses", "DateSubmitted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expenses", "DateSubmitted", c => c.DateTime());
            AlterColumn("dbo.Expenses", "DateIncurred", c => c.DateTime());
        }
    }
}
