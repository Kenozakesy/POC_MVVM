using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DatabaseModels;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Dal.DatabaseConnection;

namespace TreeViewExample.Dal.EntityFramework
{
    public class UniContext : DbContext
    {
        public UniContext() : base(nameOrConnectionString: DatabaseConnectionClass.GetConnectionString())
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        #region DBsets

        public DbSet<ParameterDefinition> ParameterDefinitions { get; set; }

        public DbSet<ProcessCel> ProcesCells { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<SubRoute> SubRoutes { get; set; }




        #region DatabaseSetsOnly

        public DbSet<SubRoutesInRoutes> SubRoutesInRoutes { get; set; }

        #endregion

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ProcessCel>()
            //            .HasMany(r => r.RouteList)
            //            .WithRequired(p => p.ProcesCell);

            //modelBuilder.Entity<ProcessCel>()
            //            .HasMany(r => r.SubrouteList)
            //            .WithRequired(p => p.ProcessCel);


        }



    }
}
