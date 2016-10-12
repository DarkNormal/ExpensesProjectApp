namespace ExpensesProjectMaster.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pendingExpense : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expenses", "Comment", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expenses", "Comment", c => c.String(maxLength: 200));
        }
    }
}
