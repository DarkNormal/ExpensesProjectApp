namespace ExpensesProjectMaster.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        IsReceptionist = c.Boolean(nullable: false),
                        TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Teams", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseID = c.Int(nullable: false, identity: true),
                        ActualAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Rechargeable = c.Boolean(nullable: false),
                        Comment = c.String(maxLength: 200),
                        ApprovalStatus = c.String(maxLength: 20),
                        EmployeeID = c.Int(nullable: false),
                        ProjectNo = c.Int(nullable: false),
                        CreditCardRequestID = c.Int(),
                        ProjectID = c.Int(),
                        EstimatedAmount = c.Decimal(precision: 18, scale: 2),
                        FromCity = c.String(maxLength: 50),
                        ToCity = c.String(maxLength: 50),
                        FromDate = c.DateTime(),
                        ToDate = c.DateTime(),
                        ReturnFlight = c.Boolean(),
                        DateOfExpense = c.DateTime(),
                        FromLocation = c.String(maxLength: 50),
                        ToLocation = c.String(maxLength: 50),
                        Country = c.Int(),
                        Distance = c.Decimal(precision: 18, scale: 2),
                        Rate = c.Decimal(precision: 18, scale: 2),
                        FromDate1 = c.DateTime(),
                        ToDate1 = c.DateTime(),
                        Location = c.String(maxLength: 50),
                        Rate1 = c.Decimal(precision: 18, scale: 2),
                        ImageUrl = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ExpenseID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectNo, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.ProjectNo);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        CustomerId = c.Int(nullable: false),
                        TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamID, cascadeDelete: false)
                .Index(t => t.CustomerId)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        V1EntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.V1Entity", t => t.V1EntityId, cascadeDelete: true)
                .Index(t => t.V1EntityId);
            
            CreateTable(
                "dbo.V1Entity",
                c => new
                    {
                        V1EntityID = c.Int(nullable: false, identity: true),
                        V1EntityName = c.String(),
                        Country = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.V1EntityID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.Int(nullable: false),
                        Practice = c.Int(nullable: false),
                        Country = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProjectEmployees",
                c => new
                    {
                        Project_ProjectID = c.Int(nullable: false),
                        Employee_EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ProjectID, t.Employee_EmployeeID })
                .ForeignKey("dbo.Projects", t => t.Project_ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID, cascadeDelete: true)
                .Index(t => t.Project_ProjectID)
                .Index(t => t.Employee_EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Employees", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.Expenses", "ProjectNo", "dbo.Projects");
            DropForeignKey("dbo.Projects", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.ProjectEmployees", "Employee_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.ProjectEmployees", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "V1EntityId", "dbo.V1Entity");
            DropForeignKey("dbo.Expenses", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.ProjectEmployees", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.ProjectEmployees", new[] { "Project_ProjectID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Customers", new[] { "V1EntityId" });
            DropIndex("dbo.Projects", new[] { "TeamID" });
            DropIndex("dbo.Projects", new[] { "CustomerId" });
            DropIndex("dbo.Expenses", new[] { "ProjectNo" });
            DropIndex("dbo.Expenses", new[] { "EmployeeID" });
            DropIndex("dbo.Employees", new[] { "TeamID" });
            DropTable("dbo.ProjectEmployees");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Teams");
            DropTable("dbo.V1Entity");
            DropTable("dbo.Customers");
            DropTable("dbo.Projects");
            DropTable("dbo.Expenses");
            DropTable("dbo.Employees");
        }
    }
}
