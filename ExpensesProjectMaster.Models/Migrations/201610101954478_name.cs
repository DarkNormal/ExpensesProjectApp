namespace ExpensesProjectMaster.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.String(maxLength: 50));
        }
    }
}
