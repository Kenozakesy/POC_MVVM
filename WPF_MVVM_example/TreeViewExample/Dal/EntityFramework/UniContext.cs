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
            //Configuration.AutoDetectChangesEnabled = true;
            //Configuration.ProxyCreationEnabled = true;
            //this.Configuration.LazyLoadingEnabled = false;
        }

        #region DBsets

        public DbSet<ParameterDefinition> ParameterDefinitions { get; set; }

        public DbSet<ProcessCel> ProcesCells { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<SubRoute> SubRoutes { get; set; }




        #region DatabaseSetsOnly

        public DbSet<sri_SubRoutesInRoutes> SubRoutesInRoutes { get; set; }

        #endregion

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Route>()
            //    .HasMany(e => e.RouteParameterList)
            //    .WithRequired(e => e.Route)
            //    .HasForeignKey(e => new { e.Route, e.rop_RouteId })
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.SubrouteInRouteList)
                .WithRequired(e => e.rot_Routes)
                .HasForeignKey(e => new { e.sri_ProcCellId, e.sri_RouteId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubRoute>()
                 .HasMany(e => e.sri_SubRoutesInRoutes)
                 .WithRequired(e => e.sur_SubRoutes)
                 .HasForeignKey(e => new { e.sri_ProcCellId, e.sri_SubRouteId })
                 .WillCascadeOnDelete(false);

        }



    }
}
