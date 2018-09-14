using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.Business.Models.DiagramModels.Parameters;
using TreeViewExample.Business.Singletons;
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


        public ObservableCollection<ParameterDefinition> GetAddAbleStandardParameters(Bin bin)
        {
            List<string> paramDefNames = _Repository.GetAllParameterDefinitionNames();
            List<ParameterDefinition> paramDef = ListGodClass.Instance.ParameterDefinitionList.Where(x => paramDefNames.Any(y => y == x.paf_ParNm)).ToList();

            List<ParameterDefinition> addAbleParametersList = paramDef.Where(x => !bin.bip_BinPars.Any(y => y.ParameterDefinition == x)).ToList();

            ObservableCollection<ParameterDefinition> addAbleParameters = new ObservableCollection<ParameterDefinition>(addAbleParametersList);

            return addAbleParameters;
        }

        #endregion
    }
}
