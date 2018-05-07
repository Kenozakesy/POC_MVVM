using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Dal.DatabaseConnection;

namespace TreeViewExample.Dal.EntityFramework
{
    public class UniContext : DbContext
    {
        public UniContext() : base(nameOrConnectionString: DatabaseConnectionClass.GetConnectionString())
        {

        }

        public DbSet<ParameterDefinition> ParameterDefinitions { get; set; }



    }
}
