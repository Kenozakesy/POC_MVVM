using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Dal.Repository.Interfaces;

namespace TreeViewExample.Dal.Repository.BusinessGlueCode
{
    public class SubrouteBusiness
    {
        ISubrouteRepository _Repository;

        public SubrouteBusiness(ISubrouteRepository repository)
        {
            _Repository = repository;
        }

        public bool DatabaseDelete(object obj)
        {
            return _Repository.DatabaseDelete(obj);
        }

        public bool DatabaseInsert(object obj)
        {
            return _Repository.DatabaseInsert(obj);
        }

        public bool DatabaseUpdate(object obj)
        {
            return _Repository.DatabaseDelete(obj);
        }

    }
}
