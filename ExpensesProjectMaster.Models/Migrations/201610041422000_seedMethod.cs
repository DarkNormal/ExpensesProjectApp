namespace ExpensesProjectMaster.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedMethod : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectEmployees", newName: "EmployeeProjects");
            DropPrimaryKey("dbo.EmployeeProjects");
            AddPrimaryKey("dbo.EmployeeProjects", new[] { "Employee_EmployeeID", "Project_ProjectID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.EmployeeProjects");
            AddPrimaryKey("dbo.EmployeeProjects", new[] { "Project_ProjectID", "Employee_EmployeeID" });
            RenameTable(name: "dbo.EmployeeProjects", newName: "ProjectEmployees");
        }
    }
}
