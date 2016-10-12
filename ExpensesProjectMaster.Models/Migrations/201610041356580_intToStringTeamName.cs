namespace ExpensesProjectMaster.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intToStringTeamName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teams", "TeamName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teams", "TeamName", c => c.Int(nullable: false));
        }
    }
}
