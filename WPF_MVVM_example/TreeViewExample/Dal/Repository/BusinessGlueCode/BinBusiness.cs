using System;
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
    public class BinBusiness
    {
        IBinRepository _Repository;

        public BinBusiness(IBinRepository repository)
        {
            _Repository = repository;
        }

        #region Methods

        public List<Bin> GetAllBins()
        {
            List<Bin> bins = _Repository.GetAllBins();

            var selected = from p in bins
                           select p;

            return selected.ToList();
        }

        public bool DatabaseDelete(object obj)
        {
            return _Repository.DatabaseDelete(obj);
        }

        public bool DatabaseInsert(object obj)
        {
           return _Repository.DatabaseUpdate(obj);
        }

        public bool DatabaseUpdate(object obj)
        {
            return _Repository.DatabaseUpdate(obj);
        }

        #endregion
    }
}
