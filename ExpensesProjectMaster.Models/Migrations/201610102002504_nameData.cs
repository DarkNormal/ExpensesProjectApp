namespace ExpensesProjectMaster.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
        }
    }
}
