using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Dal.DatabaseConnection;

namespace TreeViewExample.Dal.EntityFramework
{
    public class UniContext : DbContext
    {
        public UniContext() : base(nameOrConnectionString: DatabaseConnectionClass.GetConnectionString())
        {

        }

        #region DBsets

        public DbSet<ParameterDefinition> ParameterDefinitions { get; set; }
        public DbSet<ProcessCel> ProcesCells { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
