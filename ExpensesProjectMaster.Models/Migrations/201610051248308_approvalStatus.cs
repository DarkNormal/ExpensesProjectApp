namespace ExpensesProjectMaster.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class approvalStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expenses", "ApprovalStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expenses", "ApprovalStatus", c => c.String(maxLength: 20));
        }
    }
}
