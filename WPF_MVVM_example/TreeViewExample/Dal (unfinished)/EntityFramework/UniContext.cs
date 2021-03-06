﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DatabaseModels;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Dal.DatabaseConnection;

namespace TreeViewExample.Dal.EntityFramework
{
    public class UniContext : DbContext
    {
        public UniContext() : base(nameOrConnectionString: "Server=172.21.5.120;Initial Catalog=STG-KWAR_TestDatabase_PROMASST_MES_V7.4.0;Persist Security Info=True; User = sa; password=k00lZ@@D")
        {
            //STG_KWAR_PROMASST_MES_V7.3.0
            //PROMASST_MES_V7.4.0

            this.Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.Log = s => { };
        }

        #region DBsets

        public IDbSet<ParameterDefinition> ParameterDefinitions { get; set; }
        public IDbSet<pca_ProcCellPars> ProcescellParameters { get; set; }
        public IDbSet<rop_RoutePars> RouteParameters { get; set; }
        public IDbSet<bip_BinPars> BinParameters { get; set; }



        public IDbSet<tpm_TableParMaps> tpm_TableParMaps { get; set; }
        public IDbSet<pat_ParTables> pat_ParTables { get; set; }
        public IDbSet<pac_ParDefsProcCellTypes> pac_ParDefsProcCellTypes { get; set; }
        public IDbSet<pct_ProcCellTypes> pct_ProcCellTypes { get; set; }



        public IDbSet<ProcessCel> ProcesCells { get; set; }
        public IDbSet<Route> Routes { get; set; }
        public IDbSet<SubRoute> SubRoutes { get; set; }
        public IDbSet<Bin> Bins { get; set; }
        public IDbSet<bis_BinStocks> BinStock { get; set; }
        public IDbSet<pru_Procedures> Procedures { get; set; }
        public IDbSet<oar_OARcps> OARrecipes { get; set; }
        public IDbSet<sri_SubRoutesInRoutes> SubRoutesInRoutes { get; set; }
        public IDbSet<bir_BinsInSubRoutes> BinsInSubroutes { get; set; }


        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProcessCel>()
                 .HasMany(e => e.opc_OAProcCellDefs)
                 .WithRequired(e => e.prc_ProcCells)
                 .HasForeignKey(e => e.opc_ProcCellId)
                 .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<pru_Procedures>()
                .HasMany(e => e.oar_OARcps)
                .WithRequired(e => e.pru_Procedures)
                .HasForeignKey(e => e.oar_ProcedureId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pru_Procedures>()
                .HasMany(e => e.rot_Routes)
                .WithOptional(e => e.pru_Procedures)
                .HasForeignKey(e => e.ProcedureId);


            modelBuilder.Entity<pca_ProcCellPars>()
                   .HasRequired(e => e.ParameterDefinition)
                   .WithMany(e => e.ProcesCellParametersList)
                   .HasForeignKey(e => e.pca_ParNm)
                   .WillCascadeOnDelete(false);

            modelBuilder.Entity<rop_RoutePars>()
                .HasRequired(e => e.ParameterDefinition)
                .WithMany(e => e.RouteParametersList)
                .HasForeignKey(e => e.rop_ParNm)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<bip_BinPars>()
                .HasRequired(e => e.ParameterDefinition)
                .WithMany(e => e.BinParametersList)
                .HasForeignKey(e => e.bip_ParNm)
                .WillCascadeOnDelete(false);

        }



    }
}
