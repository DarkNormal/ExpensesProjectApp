namespace ExpensesProjectMaster.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expenses", "Comment", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expenses", "Comment", c => c.String(nullable: false, maxLength: 1000));
        }
    }
}
