namespace ExpensesProjectMaster.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creditcard : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Expenses", "FromDate");
            DropColumn("dbo.Expenses", "ToDate");
            RenameColumn(table: "dbo.Expenses", name: "FromDate1", newName: "FromDate");
            RenameColumn(table: "dbo.Expenses", name: "ToDate1", newName: "ToDate");
            DropColumn("dbo.Expenses", "ProjectID");
            DropColumn("dbo.Expenses", "EstimatedAmount");
            DropColumn("dbo.Expenses", "FromCity");
            DropColumn("dbo.Expenses", "ToCity");
            DropColumn("dbo.Expenses", "ReturnFlight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "ReturnFlight", c => c.Boolean());
            AddColumn("dbo.Expenses", "ToCity", c => c.String(maxLength: 50));
            AddColumn("dbo.Expenses", "FromCity", c => c.String(maxLength: 50));
            AddColumn("dbo.Expenses", "EstimatedAmount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Expenses", "ProjectID", c => c.Int());
            RenameColumn(table: "dbo.Expenses", name: "ToDate", newName: "ToDate1");
            RenameColumn(table: "dbo.Expenses", name: "FromDate", newName: "FromDate1");
            AddColumn("dbo.Expenses", "ToDate", c => c.DateTime());
            AddColumn("dbo.Expenses", "FromDate", c => c.DateTime());
        }
    }
}
