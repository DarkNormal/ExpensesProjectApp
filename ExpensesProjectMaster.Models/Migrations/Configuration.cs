namespace ExpensesProjectMaster.Models.Migrations
{
    using Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            new List<V1Entity>
            {
                new V1Entity { V1EntityID=1, V1EntityName="Version 1 Software UK Ltd", Country=Country.UK },
                new V1Entity { V1EntityID=2, V1EntityName="Version 1 Ltd", Country=Country.Ireland },
                new V1Entity { V1EntityID=3, V1EntityName="Version 1 Solutions Ltd", Country=Country.Ireland },
                new V1Entity { V1EntityID=4, V1EntityName="Version 1 Software", Country=Country.Ireland }
            }.ForEach(i => context.V1Entity.AddOrUpdate(i));
            new List<Customer>
            {
                new Customer { Id=1, Name="DS Smith UK IT", V1EntityId=1 },
                new Customer { Id=2, Name="DS Smith Recycling Group", V1EntityId=1},
                new Customer { Id=3, Name="Wood Mackenzie", V1EntityId=2 },
                new Customer { Id=4, Name="DS Smith Paper Group", V1EntityId=1},
                new Customer { Id=5, Name="Saica Pack UK Ltd", V1EntityId=1},
                new Customer { Id=6, Name="DS Smith Corporate", V1EntityId=1},
                new Customer { Id=7, Name="Lloyds Banking Group", V1EntityId=2},
                new Customer { Id=8, Name="Wood Group PSN Limited", V1EntityId=2},
                new Customer { Id=9, Name="Heriot Watt University", V1EntityId=2},
                new Customer { Id=10, Name="Yodel Delivery Network Limited", V1EntityId=2},
                new Customer { Id=11, Name="TAQA Bratani Limited", V1EntityId=2},
                new Customer { Id=12, Name="Eir", V1EntityId=4},
                new Customer { Id=13, Name="Solas (FAS)", V1EntityId=4},
                new Customer { Id=14, Name="University College Dublin", V1EntityId=4},
                new Customer { Id=15, Name="VHI", V1EntityId=4},
            }.ForEach(i => context.Customer.AddOrUpdate(i));
            new List<Team> {
                new Team { TeamID=1,TeamName="MSP Kings Hill", Country=Country.UK, Practice=Practice.MSP },
                new Team { TeamID=2,TeamName="MSP KH Recycling", Country=Country.UK, Practice=Practice.MSP },
                new Team { TeamID=3,TeamName="BP Service Operations", Country=Country.UK, Practice=Practice.BAS },
                new Team { TeamID=4,TeamName="MSP KH Paper", Country=Country.UK, Practice=Practice.MSP },
                new Team { TeamID=5,TeamName="MSP KH Packaging", Country=Country.UK, Practice=Practice.MSP },
                new Team { TeamID=6,TeamName="MSP KH iConnect", Country=Country.UK, Practice=Practice.MSP },
                new Team { TeamID=7,TeamName="SAM & Licence Management", Country=Country.UK, Practice=Practice.Legal },
                new Team { TeamID=8,TeamName="Business Application Solutions", Country=Country.UK, Practice=Practice.BAS },
                new Team { TeamID=9,TeamName="BAS UK", Country=Country.UK, Practice=Practice.BAS },
                new Team { TeamID=10,TeamName="ERP Projects", Country=Country.UK, Practice=Practice.ERP },
                new Team { TeamID=11,TeamName="ERP Managed Service", Country=Country.UK, Practice=Practice.ERP },
                new Team { TeamID=12,TeamName="LM Projects", Country=Country.UK, Practice=Practice.BAS },
                new Team { TeamID=13,TeamName="LM Managed Services", Country=Country.Ireland, Practice=Practice.BAS },
                new Team { TeamID=14,TeamName="MSP Database 1", Country=Country.UK, Practice=Practice.MSP },
                new Team { TeamID=15,TeamName="MSP Database 2", Country=Country.UK, Practice=Practice.MSP },
                new Team { TeamID=16,TeamName="MSP Infrastructure Services", Country=Country.Ireland, Practice=Practice.MSP },
                new Team { TeamID=17,TeamName="MSP .Net Services 1", Country=Country.Ireland, Practice=Practice.MSP },
                new Team { TeamID=18,TeamName="MSP Network & Systems", Country=Country.Ireland, Practice=Practice.MSP },
                new Team { TeamID=19,TeamName="BAS FS Other", Country=Country.Ireland, Practice=Practice.BAS },
            }.ForEach(i => context.Teams.AddOrUpdate(i));
            new List<Project>
            {
                new Project { ProjectID=5574, Name="DS Smith Hyperion Support", CustomerId=1, TeamID=1 },
                new Project { ProjectID=761216, Name="DS Smith Enwis - UK DB Support", CustomerId=2, TeamID=2 },
                new Project { ProjectID=761192, Name="Wood Mackenzie ULA Service", CustomerId=3, TeamID=3},
                new Project { ProjectID=5309, Name="DS Smith Supply Chain Data Warehouse", CustomerId=4, TeamID=4},
                new Project { ProjectID=10009, Name="SAICA UK: CBS", CustomerId=5, TeamID=5},
                new Project { ProjectID=121399, Name="DS Smith iConnect", CustomerId=6, TeamID=6},
                new Project { ProjectID=760886, Name="Wood Mackenzie Oracle Diagnosis Project", CustomerId=3, TeamID=7},
                new Project { ProjectID=5826, Name="Lloyds SQL 2005 Currency Fixed Price Modelling", CustomerId=7, TeamID=8},
                new Project { ProjectID=2014120501, Name="Wood Group XML Support", CustomerId=8, TeamID=9},
                new Project { ProjectID=5605, Name="HWU - Malaysia Tax Configuration", CustomerId=9, TeamID=11},
                new Project { ProjectID=29761354, Name="Wood Group Discoverer Reports Review", CustomerId=8, TeamID=10},
                new Project { ProjectID=29761353, Name="YDN ULA Service", CustomerId=10, TeamID=12},
                new Project { ProjectID=760856, Name="YDN Scripts Support & Maintenance", CustomerId=10, TeamID=13},
                new Project { ProjectID=5798, Name="TAQA Oracle DBA Support", CustomerId=11, TeamID=14},
                new Project { ProjectID=2014120101, Name="Wood Group DBA Support", CustomerId=8, TeamID=15},
                new Project { ProjectID=29761442, Name="ICT Services (Musgraves)", CustomerId=12, TeamID=16},
                new Project { ProjectID=761638, Name="Solas SSIS Support", CustomerId=13, TeamID=17},
                new Project { ProjectID=761878, Name="SofGen (Eir)", CustomerId=12, TeamID=18},
                new Project { ProjectID=5808, Name="VHI SharePoint O365 PoC", CustomerId=14, TeamID=19},
            }.ForEach(i => context.Projects.AddOrUpdate(i));

            //context.Roles.AddOrUpdate(new IdentityRole { Name = "Finance" });
            //context.Roles.AddOrUpdate(new IdentityRole { Name = "Receptionist" });
            //context.Roles.AddOrUpdate(new IdentityRole { Name = "PortfolioDirector" });
            //context.Roles.AddOrUpdate(new IdentityRole { Name = "Employee" });
            context.SaveChanges();
        }
    }
}
