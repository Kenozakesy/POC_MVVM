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
        public DbSet<Bin> Bins { get; set; }
        public DbSet<bis_BinStocks> BinStock { get; set; }




        #region DatabaseSetsOnly

        public DbSet<sri_SubRoutesInRoutes> SubRoutesInRoutes { get; set; }

        #endregion

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.SubrouteInRouteList)
                .WithRequired(e => e.rot_Routes)
                .HasForeignKey(e => new { e.sri_ProcCellId, e.sri_RouteId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.rop_RoutePars)
                .WithRequired(e => e.rot_Routes)
                .HasForeignKey(e => new { e.rop_ProcCellId, e.rop_RouteId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubRoute>()
                 .HasMany(e => e.sri_SubRoutesInRoutes)
                 .WithRequired(e => e.sur_SubRoutes)
                 .HasForeignKey(e => new { e.sri_ProcCellId, e.sri_SubRouteId })
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubRoute>()
                .HasMany(e => e.bir_BinsInSubRoutes)
                .WithRequired(e => e.sur_SubRoutes)
                .HasForeignKey(e => new { e.bir_ProcCellId, e.bir_SubRouteId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubRoute>()
                .HasMany(e => e.uis_UnitsInSubRoutes)
                .WithRequired(e => e.sur_SubRoutes)
                .HasForeignKey(e => new { e.uis_ProcCellId, e.uis_SubRouteId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.uis_UnitsInSubRoutes)
                .WithRequired(e => e.Unit)
                .HasForeignKey(e => e.uis_OAUnitId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bin>()
                  .HasMany(e => e.bir_BinsInSubRoutes)
                  .WithRequired(e => e.bin_Bins)
                  .HasForeignKey(e => e.bir_BinId)
                  .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bin>()
                   .HasOptional(e => e.bis_BinStocks)
                   .WithRequired(e => e.bin_Bins);

            modelBuilder.Entity<Bin>()
                .HasMany(e => e.bip_BinPars)
                .WithRequired(e => e.bin_Bins)
                .HasForeignKey(e => e.bip_BinId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bin>()
               .HasMany(e => e.bib_BinBatches)
               .WithRequired(e => e.bin_Bins)
               .HasForeignKey(e => e.bib_BinId)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bin>()
                .HasMany(e => e.tbb_TempBinBatches)
                .WithRequired(e => e.bin_Bins)
                .HasForeignKey(e => e.tbb_BinId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bin>()
                .HasMany(e => e.pri_PropIns)
                .WithRequired(e => e.bin_Bins)
                .HasForeignKey(e => e.pri_BinId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProcessCel>()
                .HasMany(e => e.pca_ProcCellPars)
                .WithRequired(e => e.prc_ProcCells)
                .HasForeignKey(e => e.pca_ProcCellId)
                .WillCascadeOnDelete(false);





        }



    }
}
