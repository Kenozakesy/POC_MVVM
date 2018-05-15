﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Statics;
using TreeViewExample.Dal.Repository.Interfaces;

namespace TreeViewExample.Dal.Repository.BusinessGlueCode
{
    public class RouteBusiness
    {
        IRouteRepository _Repository;

        public RouteBusiness(IRouteRepository repository)
        {
            _Repository = repository;
        }

        #region Methods

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
            return _Repository.DatabaseUpdate(obj);
        }

        #endregion
    }
}
